using CsvImporter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Contracts
{
    public interface IStockDAL
    {
        public void CleanStockTable();
        public void UpdateDownloadedFileInformation(DownloadedFile file);
        public int ReadNumberOfRowsInStock();

    }
}
