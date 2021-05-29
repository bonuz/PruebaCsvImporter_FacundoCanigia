using CsvImporter.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;

namespace CsvImporter
{
    public class Downloader : IDownloader
    {
        private readonly IStockConfig _config;
        private readonly ILogger<Program> _logger;
        private readonly IStopWatch _stopwatch;

        public Downloader(IStockConfig config, ILogger<Program> logger, IStopWatch stopWatch)
        {
            _config = config;
            _logger = logger;
            _stopwatch = stopWatch;
        }

        public string DownloadCSV(string fileUrl)
        {
            return "";
            string timeStamp = GetTimestamp(DateTime.Now);
            string fileName = timeStamp + "_stock.CSV";

            // read destination from config file
            //string csvDestination = "C:\\DEV\\CSharp\\CsvImporter\\CsvImporter\\DownloadedFiles\\" + fileName;
            string csvDestination = _config.DestinationFolder + fileName;
            WebClient myWebClient = new WebClient();

            try
            {
                _logger.LogInformation("Downloading File", fileUrl);
                _stopwatch.Start();

                // write statistics down: size, number of rows
                // try to add a download %
                myWebClient.DownloadFile(fileUrl, csvDestination);

                _stopwatch.Stop();

                _logger.LogInformation("Successfully Downloaded File \"{0}\" in {1}\n", fileUrl, _stopwatch.GetElapsedTime());
                _logger.LogInformation("Downloaded file saved in: " + csvDestination);

                return fileName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }
    }
}
