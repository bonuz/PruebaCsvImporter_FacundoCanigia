using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System.IO;

namespace CsvImporterTests
{
    class CsvImporterTest
    {

        CsvImporter.Contracts.IStockConfig _mockConfig;
        CsvImporter.Contracts.IDownloader _mockDownloader;
        CsvImporter.Contracts.IStopWatch _stopWatch;
        CsvImporter.Contracts.IStockDAL _stockDAL;
        ILogger<CsvImporter.Program> _logger;

        [SetUp]
        public void Setup()
        {
            _mockConfig = new Mocks.ConfigMock();
            _stopWatch = new CsvImporter.StopWatch();
            _stockDAL = new CsvImporter.DAL.StockDAL(_mockConfig);
            _logger = new NullLogger<CsvImporter.Program>();
        }

        [Test]
        public void ImportOriginalFile()
        {
            _mockDownloader = new Mocks.DownloaderMockOriginalFile();
            CsvImporter.CsvImporter importer = new CsvImporter.CsvImporter(_mockDownloader, _mockConfig, _logger, _stopWatch, _stockDAL);

            importer.ImportFile();

            int insertedRows = _stockDAL.ReadNumberOfRowsInStock();

            Assert.AreEqual(17175295, insertedRows);
        }


        [Test]
        public void ImportTestFile1000Rows()
        {
            _mockDownloader = new Mocks.DownloaderMock1000Rows();
            CsvImporter.CsvImporter importer = new CsvImporter.CsvImporter(_mockDownloader, _mockConfig, _logger, _stopWatch, _stockDAL);

            importer.ImportFile();

            int insertedRows = _stockDAL.ReadNumberOfRowsInStock();

            Assert.AreEqual(1000, insertedRows);
        }

        [Test]
        public void ImportTestFile1000RowsWithoutTitleInFile()
        {
            _mockDownloader = new Mocks.DownloaderMock1000Rows();
            CsvImporter.CsvImporter importer = new CsvImporter.CsvImporter(_mockDownloader, _mockConfig, _logger, _stopWatch, _stockDAL);

            importer.ImportFile();

            int insertedRows = _stockDAL.ReadNumberOfRowsInStock();

            Assert.AreEqual(1000, insertedRows);
        }

        [Test]
        public void ImportTestFile30Rows()
        {
            _mockDownloader = new Mocks.DownloaderMock30Rows();
            CsvImporter.CsvImporter importer = new CsvImporter.CsvImporter(_mockDownloader, _mockConfig, _logger, _stopWatch, _stockDAL);

            importer.ImportFile();

            int insertedRows = _stockDAL.ReadNumberOfRowsInStock();

            Assert.AreEqual(30, insertedRows);
        }

        [Test]
        public void Download1000RowsFileAndCheckIfExists()
        {
            CsvImporter.Contracts.IStockConfig mockStockConfig = new Mocks.ConfigMock1000RowsFile();

            CsvImporter.Downloader downloader = new CsvImporter.Downloader(mockStockConfig, _logger, _stopWatch);

            string fileName = downloader.DownloadCSV();

            Assert.IsTrue(File.Exists(_mockConfig.DestinationFolder + fileName));
        }

        [Test]
        public void Download30RowsFileAndCheckIfExists()
        {
            CsvImporter.Contracts.IStockConfig mockStockConfig = new Mocks.ConfigMock30RowsFile();

            CsvImporter.Downloader downloader = new CsvImporter.Downloader(mockStockConfig, _logger, _stopWatch);

            string fileName = downloader.DownloadCSV();

            Assert.IsTrue(File.Exists(_mockConfig.DestinationFolder + fileName));
        }



    }
}

