using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Contracts
{
    public interface IStockConfig
    {
        string ConnectionString { get; }
        string DestinationFolder { get; }
        string FileUrl { get;  }

    }
}
