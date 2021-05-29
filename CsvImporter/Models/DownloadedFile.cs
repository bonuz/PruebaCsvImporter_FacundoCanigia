using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Models
{
    public class DownloadedFile
    {
        public DateTime DownloadDate { get; set; }
        public string FileName { get; set; }
        public int InsertedRows { get; set; }
    }
}
