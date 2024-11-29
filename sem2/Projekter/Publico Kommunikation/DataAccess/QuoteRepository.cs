using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.DataAccess
{
    // Repository class implementing the IRepository interface
    public class QuoteRepository : ISimpleKeyRepository<Quote>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        // Constructor to initialize the repository with a connection string
        public QuoteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Stored procedure
        // SqlConnection sqlCon = null;

        // String SqlconString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Method to retrieve all records from the database
        public IEnumerable<Quote> GetAll()
        {
            var quote = new List<Quote>();
            using (var sqlCon = new SqlConnection(_connectionString))
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
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("QuoteId")),
                            HourlyRate = reader.IsDBNull(reader.GetOrdinal("HourlyRate")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("HourlyRate")),
                            DiscountPercentage = reader.IsDBNull(reader.GetOrdinal("DiscountPercentage")) ? 0.0m : reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
                            Sum = reader.IsDBNull(reader.GetOrdinal("Sum")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Sum"))
                        });
                    }
                }
            }
            return quote;
        }

        // Method to retrieve a specific record by its Id
        public Quote GetByKey(int key)
        {
            Quote quote = null;
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetByKeyQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = key;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        quote = new Quote
                        {
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("QuoteId")),
                            HourlyRate = reader.IsDBNull(reader.GetOrdinal("HourlyRate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("HourlyRate")),
                            DiscountPercentage = reader.IsDBNull(reader.GetOrdinal("DiscountPercentage")) ? 0.0m : reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
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
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@HourlyRate", SqlDbType.Int).Value = quote.HourlyRate;
                sql_cmnd.Parameters.AddWithValue("@DiscountPercentage", SqlDbType.Float).Value = quote.DiscountPercentage;
                sql_cmnd.Parameters.AddWithValue("@Sum", SqlDbType.Float).Value = quote.Sum;
                var quoteId = new SqlParameter { ParameterName = "@QuoteId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                sql_cmnd.Parameters.Add(quoteId);
                // sql_cmnd.Parameters.AddWithValue("@quoteId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output).Value = quote.QuoteId;
                sql_cmnd.ExecuteNonQuery();
                quote.QuoteId = Convert.ToInt32(quoteId.Value);
            }
        }

        // public void Add(Quote quote)
        // {
        //     using (var sqlCon = new SqlConnection(_connectionString))
        //     {
        //         sqlCon.Open();
        //         using (var sql_cmnd = new SqlCommand("uspCreateQuote", sqlCon))
        //         {
        //             sql_cmnd.CommandType = CommandType.StoredProcedure;

        //             sql_cmnd.Parameters.AddWithValue("@HourlyRate", quote.HourlyRate);
        //             sql_cmnd.Parameters.AddWithValue("@DiscountPercentage", quote.DiscountPercentage);
        //             sql_cmnd.Parameters.AddWithValue("@Sum", quote.Sum);

        //             // Capture the returned ID
        //             var newIdParam = new SqlParameter
        //             {
        //                 ParameterName = "@NewID",
        //                 SqlDbType = SqlDbType.Int,
        //                 Direction = ParameterDirection.Output
        //             };
        //             sql_cmnd.Parameters.Add(newIdParam);

        //             sql_cmnd.ExecuteNonQuery();

        //             // Set the ID in the Quote object
        //             quote.ID = Convert.ToInt32(newIdParam.Value);
        //         }
        //     }
        // }

        

        // Method to update an existing record in the database
        public void Update(Quote quote)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
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
        public void Delete(int key)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspDeleteQuote", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = key;
                sql_cmnd.ExecuteNonQuery();
            }
        }
    }
}
