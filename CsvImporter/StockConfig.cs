using Microsoft.Extensions.Configuration;
using CsvImporter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace CsvImporter
{
    class StockConfig : IStockConfig
    {
        private readonly IConfiguration _configuration;

        public StockConfig(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string ConnectionString
        {
            get {
                return this._configuration["ConnectionStrings:Default"];
            }
        }

        public string DestinationFolder {
            get
            {
                return this._configuration["CSVImporter:DestinationFolder"];
            }
        }

        public string FileUrl {
            get
            {
                return this._configuration["CSVImporter:FileUrl"];
            }
        }
    }
}
