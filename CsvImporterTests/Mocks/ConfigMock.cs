using CsvImporter;

namespace CsvImporterTests.Mocks
{
    public class ConfigMock : CsvImporter.Contracts.IStockConfig
    {
        public string ConnectionString
        {
            get { 
            return "";
            }
        }

        public string DestinationFolder
        {
            get {
                return "";
            }
        }

        public string FileUrl
        {
            get {
                return "";
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
}
