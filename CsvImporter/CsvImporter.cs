using CsvImporter.Contracts;
using CsvImporter.Models;
using FastMember;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CsvImporter
{
    public class CsvImporter : IImporter
    {
        private readonly IDownloader _downloader;
        private readonly IStockConfig _config;
        private readonly ILogger<Program> _logger;
        private readonly IStopWatch _stopWatch;
        private readonly IStockDAL _stockDAL;
        private readonly string[] copyParameters = new string[]
            {
                nameof(Stock.StockId),
                nameof(Stock.PointOfSale),
                nameof(Stock.Product),
                nameof(Stock.Date),
                nameof(Stock.NumberOfItems)
            };

        public CsvImporter(IDownloader downloader, IStockConfig config, ILogger<Program> logger, IStopWatch stopWatch, IStockDAL stockDAL)
        {
            _downloader = downloader;
            _config = config;
            _logger = logger;
            _stopWatch = stopWatch;
            _stockDAL = stockDAL;
        }

        public void ImportFile()
        {
            //var fileName = _downloader.DownloadCSV("https://storage10082020.blob.core.windows.net/y9ne9ilzmfld/Stock.CSV");
            string fileName = _downloader.DownloadCSV(_config.FileUrl);
            string filePath = _config.DestinationFolder + fileName;

            filePath = "C:\\DEV\\CSharp\\CsvImporter\\Files\\OriginalStock.CSV";

            InsertStockValues(filePath);
        }

        public void InsertStockValues(string filePath)
        {
            _stockDAL.CleanStockTable();

            DownloadedFile downloadedFile;
            string connString = _config.ConnectionString;
            int batchSize = _config.BatchSize;

            _stopWatch.Start();

            List<Stock> stocks = GetStockList(filePath);

            // generating a datatable takes almost 2 minutes, double as making a list
            // GetStockToInsert(filePath);

            _stopWatch.Stop();
            _logger.LogInformation("Elapsed time to open file and transform to object list {0}", _stopWatch.GetElapsedTime());

            _stopWatch.Start();

            using (var sqlCopy = new SqlBulkCopy(connString))
            {
                sqlCopy.DestinationTableName = "[Stock]";
                sqlCopy.BatchSize = batchSize;
                using (var reader = ObjectReader.Create(stocks, copyParameters))
                {
                    sqlCopy.WriteToServer(reader);
                }
            }

            _stopWatch.Stop();
            _logger.LogInformation("Elapsed time to insert rows {0}", _stopWatch.GetElapsedTime());

            downloadedFile = new DownloadedFile
            {
                InsertedRows = stocks.Count,
                FileName = filePath,
                DownloadDate = DateTime.Now
            };

            _stockDAL.UpdateDownloadedFileInformation(downloadedFile);

            Console.ReadKey();
            // Cleanup
        }

        private List<Stock> GetStockList(string filePath)
        {
            List<Stock> stocks = new List<Stock>();

            foreach (String record in GetRecordsList(filePath))
            {
                //Console.WriteLine(record);
                if (record != "")
                {
                    Stock stock = new Stock();
                    string[] textpart = record.Split(';');
                    stock.PointOfSale = textpart[0];
                    stock.Product = textpart[1];
                    stock.Date = textpart[2];
                    stock.NumberOfItems = Convert.ToInt32(textpart[3].Replace("\r", ""));
                    stocks.Add(stock);
                }
            }

            return stocks;
        }

        private List<string> GetRecordsList(string filePath)
        {
            string fileTitle = _config.Title;

            /// Open file
            List<string> records;
            using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
            {
                string file = sr.ReadToEnd();
                records = new List<string>(file.Split('\n'));
            }

            // Remove title
            if (records[0].Contains(fileTitle)) records.RemoveAt(0);

            return records;
        }

        private DataTable GetStockToInsert(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PointOfSale", typeof(string)));
            dt.Columns.Add(new DataColumn("Product", typeof(string)));
            dt.Columns.Add(new DataColumn("Date", typeof(string)));
            dt.Columns.Add(new DataColumn("Stock", typeof(int)));
            dt.Columns.Add(new DataColumn("StockId", typeof(int)));

            foreach (String record in GetRecordsList(filePath))
            {
                if (record != "")
                {
                    string[] textpart = record.Split(';');
                    var row = dt.NewRow();
                    row["PointOfSale"] = textpart[0];
                    row["Product"] = textpart[1];
                    row["Date"] = textpart[2];
                    row["Stock"] = Convert.ToInt32(textpart[3].Replace("\r", ""));

                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

    }
}

