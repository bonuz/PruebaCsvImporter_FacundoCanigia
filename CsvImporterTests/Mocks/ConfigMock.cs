using CsvImporter;

namespace CsvImporterTests.Mocks
{
    public class ConfigMock : CsvImporter.Contracts.IStockConfig
    {
        public string ConnectionString
        {
            get { 
            return "Data Source=BONUZKTOP\\FNCSQL;Initial Catalog=Importer;Integrated Security=True;";
            }
        }

        public string DestinationFolder
        {
            get {
                return "C:\\DEV\\CSharp\\CsvImporter\\Files\\";
            }
        }

        public string FileUrl
        {
            get {
                return "https://csvimporteraa.blob.core.windows.net/csvfiles/OriginalStock_1000Rows.CSV";
            }
        }

        public string Title
        {
            get {
                return "PointOfSale;Product;Date;Stock";
            }
            
        }

        public int BatchSize
        {
            get {
                return 1000;
            }
        }
    }

    public class ConfigMock1000RowsFile : CsvImporter.Contracts.IStockConfig
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=BONUZKTOP\\FNCSQL;Initial Catalog=Importer;Integrated Security=True;";
            }
        }

        public string DestinationFolder
        {
            get
            {
                return "C:\\DEV\\CSharp\\CsvImporter\\Files\\";
            }
        }

        public string FileUrl
        {
            get
            {
                return "https://csvimporteraa.blob.core.windows.net/csvfiles/OriginalStock_1000Rows.CSV";
            }
        }

        public string Title
        {
            get
            {
                return "PointOfSale;Product;Date;Stock";
            }

        }

        public int BatchSize
        {
            get
            {
                return 1000;
            }
        }
    }


    public class ConfigMock30RowsFile : CsvImporter.Contracts.IStockConfig
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=BONUZKTOP\\FNCSQL;Initial Catalog=Importer;Integrated Security=True;";
            }
        }

        public string DestinationFolder
        {
            get
            {
                return "C:\\DEV\\CSharp\\CsvImporter\\Files\\";
            }
        }

        public string FileUrl
        {
            get
            {
                return "https://csvimporteraa.blob.core.windows.net/csvfiles/OriginalStock_30Rows.CSV";
            }
        }

        public string Title
        {
            get
            {
                return "PointOfSale;Product;Date;Stock";
            }

        }

        public int BatchSize
        {
            get
            {
                return 1000;
            }
        }
    }

}
