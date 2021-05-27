using CsvImporter.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsvImporter
{
    public class CsvImporter : IImporter
    {
        private IDownloader _downloader;
        private IStockConfig _config;
        private readonly ILogger<Program> _logger;

        public CsvImporter(IDownloader downloader, IStockConfig config, ILogger<Program> logger)
        {
            _downloader = downloader;
            _config = config;
            _logger = logger;
        }

        public void ImportFile()
        {
            //var fileName = _downloader.DownloadCSV("https://storage10082020.blob.core.windows.net/y9ne9ilzmfld/Stock.CSV");
            var fileName = _downloader.DownloadCSV(_config.FileUrl);
            _logger.LogInformation(fileName);

        }
    }
}
