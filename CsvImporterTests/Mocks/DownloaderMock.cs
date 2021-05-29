using CsvImporter;
using CsvImporter.Contracts;

namespace CsvImporterTests.Mocks
{
    public class DownloaderMock : CsvImporter.Contracts.IDownloader
    {
        string IDownloader.DownloadCSV(string fileUrl)
        {
            return "C:\\DEV\\CSharp\\CsvImporter\\Files\\OriginalStock.CSV";
        }
    }
}
