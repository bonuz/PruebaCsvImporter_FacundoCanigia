using CsvImporter.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;

namespace CsvImporter
{
    public class Downloader : IDownloader
    {
        //public async Task DownloadCSV(string remoteUri, string fileName)
        private readonly IStockConfig _config;
        private readonly ILogger<Program> _logger;

        public Downloader(IStockConfig config, ILogger<Program> logger)
        {
            _config = config;
            _logger = logger;
        }

        public string DownloadCSV(string fileUrl)
        {
            string timeStamp = GetTimestamp(DateTime.Now);
            string fileName = timeStamp + "_stock.CSV";

            // read destination from config file
            //string csvDestination = "C:\\DEV\\CSharp\\CsvImporter\\CsvImporter\\DownloadedFiles\\" + fileName;
            string csvDestination = _config.DestinationFolder + fileName;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts; string elapsedTime;
            WebClient myWebClient = new WebClient();

            try
            {
                _logger.LogInformation("Downloading File \"{0}\"", fileUrl);
                stopWatch.Start();

                // write statistics down: size, number of rows
                // try to add a download %
                myWebClient.DownloadFile(fileUrl, csvDestination);

                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                //Console.WriteLine("Successfully Downloaded File \"{0}\" in {1}", fileUrl, elapsedTime);
                //Console.WriteLine("Downloaded file saved in: " + csvDestination);
                _logger.LogInformation("Successfully Downloaded File \"{0}\" in {1}", fileUrl, elapsedTime);
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
