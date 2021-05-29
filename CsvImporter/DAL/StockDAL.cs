using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CsvImporter.Contracts;
using CsvImporter.Models;

namespace CsvImporter.DAL
{
    public class StockDAL: IStockDAL
    {
        private readonly IStockConfig _config;
        

        public StockDAL(IStockConfig config)
        {
            _config = config;
        }

        private SqlDataReader ExecuteReader(string Query)
        {
            string connString = _config.ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DownloadedFiles", con)
                {
                    CommandType = CommandType.Text
                };
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                return rdr;
            }
        }

        private void ExecuteCommand(string Query)
        {
            string connString = _config.ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(Query, con)
                {
                    CommandType = CommandType.Text
                };
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void CleanStockTable()
        {
            this.ExecuteCommand("truncate table dbo.Stock");
        }

        public void UpdateDownloadedFileInformation(DownloadedFile file)
        {

            string query = "Insert into dbo.DownloadedFiles values(@date, @fileName, @inserted)";

            string connString = _config.ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@date", file.DownloadDate);
                cmd.Parameters.AddWithValue("@fileName", file.FileName );
                cmd.Parameters.AddWithValue("@inserted", file.InsertedRows);

                con.Open();

                cmd.ExecuteNonQuery();
            }

        }
    }


}
