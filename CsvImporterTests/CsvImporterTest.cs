using NUnit.Framework;
using CsvImporter;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CsvImporterTests
{
    class CsvImporterTest
    {

        CsvImporter.Contracts.IStockConfig _mockConfig;
        CsvImporter.Contracts.IDownloader _mockDownloader;
        CsvImporter.Contracts.IStopWatch _stopWatch;
        ILogger<CsvImporter.Program> _logger;


        [SetUp]
        public void Setup()
        {
            _mockDownloader = new Mocks.DownloaderMock();
            _mockConfig = new Mocks.ConfigMock();
            _stopWatch = new CsvImporter.StopWatch();
            _logger = new NullLogger<CsvImporter.Program>();
        }

        [Test]
        public void ImportTestFile()
        {
            CsvImporter.CsvImporter importer = new CsvImporter.CsvImporter(_mockDownloader, _mockConfig, _logger, _stopWatch);

            importer.ImportFile();

            Assert.Pass();
        }

        [Test]
        public void Download30RowsFileAndCheckIfExists()
        {

        }

        [Test]
        public void Download1000RowsFileAndCheckIfExists()
        {

        }



    }
}

