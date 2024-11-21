using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.DataAccess
{
    // Repository class implementing the IRepository interface
    public class QuoteProductRepository : ICompositeKeyRepository<QuoteProduct>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        // Constructor to initialize the repository with a connection string
        public QuoteProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Stored procedure
        //SqlConnection sqlCon = null;

        //String SqlconString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Method to retrieve all records from the database
        public IEnumerable<QuoteProduct> GetAll()
        {
            var quoteProduct = new List<QuoteProduct>();
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetAllQuoteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        quoteProduct.Add(new QuoteProduct
                        {
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("QuoteId")),
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("ProductId")),
                            QuoteProductTimeEstimate = reader.IsDBNull(reader.GetOrdinal("QuoteProductTimeEstimate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductTimeEstimate")),
                            QuoteProductPrice = reader.IsDBNull(reader.GetOrdinal("QuoteProductPrice")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductPrice"))
                        });
                    }
                }
            }
            return quoteProduct;
        }

        // Method to retrieve a specific record by its Id
        public QuoteProduct GetByKey(int key1, int key2)
        {
            QuoteProduct quoteProduct = null;
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateQuoteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = key1;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = key2;
                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        quoteProduct = new QuoteProduct
                        {
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("QuoteId")),
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("ProductId")),
                            QuoteProductTimeEstimate = reader.IsDBNull(reader.GetOrdinal("QuoteProductTimeEstimate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductTimeEstimate")),
                            QuoteProductPrice = reader.IsDBNull(reader.GetOrdinal("QuoteProductPrice")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductPrice"))
                        };
                    }
                }
            }
            return quoteProduct;
        }

        // Method to add a new record to the database
        public void Add(QuoteProduct quoteProduct)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateQuoteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = quoteProduct.QuoteId;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = quoteProduct.ProductId;
                sql_cmnd.Parameters.AddWithValue("@QuoteProductTimeEstimate", SqlDbType.Float).Value = quoteProduct.QuoteProductTimeEstimate;
                sql_cmnd.Parameters.AddWithValue("@QuoteProductPrice", SqlDbType.Float).Value = quoteProduct.QuoteProductPrice;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to update an existing record in the database
        public void Update(QuoteProduct quoteProduct)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspUpdateQuoteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = quoteProduct.QuoteId;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = quoteProduct.ProductId;
                sql_cmnd.Parameters.AddWithValue("@QuoteProductTimeEstimate", SqlDbType.Float).Value = quoteProduct.QuoteProductTimeEstimate;
                sql_cmnd.Parameters.AddWithValue("@QuoteProductPrice", SqlDbType.Float).Value = quoteProduct.QuoteProductPrice;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to delete a record from the database by its Id
        public void Delete(int key1, int key2)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspDeleteQuoteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = key1;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = key2;
                sql_cmnd.ExecuteNonQuery();
            }
        }
    }
}
