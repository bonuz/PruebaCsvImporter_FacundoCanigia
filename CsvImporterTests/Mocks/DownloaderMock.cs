using CsvImporter;
using CsvImporter.Contracts;

namespace CsvImporterTests.Mocks
{
    public class DownloaderMock1000Rows : CsvImporter.Contracts.IDownloader
    {
        string IDownloader.DownloadCSV()
        {
            return "OriginalStock_1000Rows.CSV";
        }
    }

    public class DownloaderMock1000RowsWOTitle : CsvImporter.Contracts.IDownloader
    {
        string IDownloader.DownloadCSV()
        {
            return "OriginalStock_1000RowsWOTitle.CSV";
        }
    }

    public class DownloaderMock30Rows : CsvImporter.Contracts.IDownloader
    {
        string IDownloader.DownloadCSV()
        {
            return "OriginalStock_30Rows.CSV";
        }
    }

    public class DownloaderMockOriginalFile : CsvImporter.Contracts.IDownloader
    {
        string IDownloader.DownloadCSV()
        {
            return "OriginalStock.CSV";
        }
    }

}
