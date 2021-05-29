using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Models
{
    public class Stock
    {
        public string PointOfSale { get; set; }
        public string Product { get; set; }
        public string Date { get; set; }
        public int NumberOfItems { get; set; }
        public int StockId { get; set; }
    }
}
