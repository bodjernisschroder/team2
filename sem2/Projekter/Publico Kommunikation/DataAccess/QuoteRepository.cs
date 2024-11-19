using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.DataAccess
{
    // Repository class implementing the IRepository interface
    public class QuoteRepository : IRepository<Quote>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        // Constructor to initialize the repository with a connection string
        public QuoteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Stored procedure
        SqlConnection sqlCon = null;

        String SqlconString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Method to retrieve all records from the database
        public IEnumerable<Quote> GetAll()
        {
            var quote = new List<Quote>();
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetAllQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        quote.Add(new Quote
                        {
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("QuoteId")),
                            HourlyRate = reader.IsDBNull(reader.GetOrdinal("HourlyRate")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("HourlyRate")),
                            DiscountPercentage = reader.IsDBNull(reader.GetOrdinal("DiscountPercentage")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("DiscountPercentage")),
                            Sum = reader.IsDBNull(reader.GetOrdinal("Sum")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Sum"))
                        });
                    }
                }
            }
            return quote;
        }

        // Method to retrieve a specific record by its Id
        public Quote GetById(int id)
        {
            Quote quote = null;
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        quote = new Quote
                        {
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("QuoteId")),
                            HourlyRate = reader.IsDBNull(reader.GetOrdinal("HourlyRate")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("HourlyRate")),
                            DiscountPercentage = reader.IsDBNull(reader.GetOrdinal("DiscountPercentage")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("DiscountPercentage")),
                            Sum = reader.IsDBNull(reader.GetOrdinal("Sum")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Sum"))
                        };
                    }
                }
            }
            return quote;
        }

        // Method to add a new record to the database
        public void Add(Quote quote)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@HourlyRate", SqlDbType.Int).Value = quote.HourlyRate;
                sql_cmnd.Parameters.AddWithValue("@DiscountPercentage", SqlDbType.Float).Value = quote.DiscountPercentage;
                sql_cmnd.Parameters.AddWithValue("@Sum", SqlDbType.Float).Value = quote.Sum;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to update an existing record in the database
        public void Update(Quote quote)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspUpdateQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = quote.QuoteId;
                sql_cmnd.Parameters.AddWithValue("@HourlyRate", SqlDbType.Int).Value = quote.HourlyRate;
                sql_cmnd.Parameters.AddWithValue("@DiscountPercentage", SqlDbType.Float).Value = quote.DiscountPercentage;
                sql_cmnd.Parameters.AddWithValue("@Sum", SqlDbType.Float).Value = quote.Sum;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to delete a record from the database by its Id
        public void Delete(int id)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspDeleteQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = id;
                sql_cmnd.ExecuteNonQuery();
            }
        }
    }
}
