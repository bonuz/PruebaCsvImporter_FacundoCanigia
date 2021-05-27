using CsvImporter.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace CsvImporter
{
    public class Program
    {

        private readonly IImporter _importer;
        private readonly IStockConfig _config;
        private readonly ILogger<Program> _logger;

        public Program(IImporter importer, IStockConfig config, ILogger<Program> logger)
        {
            this._importer = importer;
            this._config = config;
            this._logger = logger;
        }

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public void Run()
        {
            _logger.LogInformation("Start");
            //string connString = _config.ConnectionString;
            //string destinationFolder = _config.DestinationFolder;
            //string fileUrl = _config.FileUrl;
            _importer.ImportFile();
            _logger.LogInformation("End");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IDownloader, Downloader>();
                    services.AddTransient<IImporter, CsvImporter>();
                    services.AddSingleton<IStockConfig, StockConfig>();
                    services.AddLogging();
                });
        }
    }
}
