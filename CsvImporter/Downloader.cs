using CsvImporter.Contracts;
using Microsoft.Extensions.Logging;
using System;
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

        public string DownloadCSV()
        {
            string timeStamp = GetTimestamp(DateTime.Now);
            string fileName = timeStamp + "_stock.CSV";
            string fileUrl = _config.FileUrl;
            string csvDestination = _config.DestinationFolder + fileName;

            WebClient webClient = new WebClient();

            try
            {
                _logger.LogInformation("Downloading File", fileUrl);
                _stopwatch.Start();

                webClient.DownloadFile(fileUrl, csvDestination);

                _stopwatch.Stop();

                _logger.LogInformation("Successfully Downloaded File \"{0}\" in {1}\n", fileUrl, _stopwatch.GetElapsedTime());
                _logger.LogInformation("Downloaded file saved in: " + csvDestination);

                return fileName;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                webClient.Dispose();
            }
        }

        private static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }
    }
}
