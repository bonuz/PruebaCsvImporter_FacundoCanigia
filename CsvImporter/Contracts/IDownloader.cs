using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Contracts
{
    public interface IDownloader
    {
        string DownloadCSV();
    }
}
