using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.DataAccess
{
    /// <summary>
    /// A repository class for managing <see cref="QuoteProduct"/> entities.
    /// Implements the <see cref="ICompositeKeyRepository{T}"/> interface.
    /// </summary>
    public class QuoteProductRepository : ICompositeKeyRepository<QuoteProduct>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        /// <summary>
        /// Initializes a new instance of <see cref="QuoteProductRepository"/> with the specified <paramref name="connectionString"/>.
        /// </summary>
        /// <param name="connectionString">The connection string used to establish a connection to the database.</param>
        public QuoteProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves all <see cref="QuoteProduct"/> entities from the database by executing the
        /// stored procedure <c>uspGetAllQuoteProduct</c>.
        /// </summary>
        /// <returns>A collection of <see cref="QuoteProduct"/>entities.</returns>
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
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("QuoteId")),
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("ProductId")),
                            QuoteProductTimeEstimate = reader.IsDBNull(reader.GetOrdinal("QuoteProductTimeEstimate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductTimeEstimate")),
                            QuoteProductPrice = reader.IsDBNull(reader.GetOrdinal("QuoteProductPrice")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductPrice"))
                        });
                    }
                }
            }
            return quoteProduct;
        }

        /// <summary>
        /// Retrieves a specific entity of <see cref="QuoteProduct"/> by its composite key
        /// by executing the stored procedure <c>uspGetByKeyQuoteProduct</c>.
        /// </summary>
        /// <param name="key1">The <see cref="Quote.QuoteId"/> of <see cref="QuoteProduct"/> to retrieve.</param>
        /// <param name="key2">The <see cref="Product.ProductId"/> of <see cref="QuoteProduct"/> to retrieve.</param>
        /// <returns>The <see cref="QuoteProduct"/> entity that matches the specified composite key.</returns>
        public QuoteProduct GetByCompositeKey(int key1, int key2)
        {
            QuoteProduct quoteProduct = null;
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetByKeyQuoteProduct", sqlCon);
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
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("QuoteId")),
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("ProductId")),
                            QuoteProductTimeEstimate = reader.IsDBNull(reader.GetOrdinal("QuoteProductTimeEstimate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductTimeEstimate")),
                            QuoteProductPrice = reader.IsDBNull(reader.GetOrdinal("QuoteProductPrice")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductPrice"))
                        };
                    }
                }
            }
            return quoteProduct;
        }

        /// <summary>
        /// Retrieves all <see cref="QuoteProduct"/> entities from the database that are associated with
        /// the specified <see cref="Quote.QuoteId"/> by executing the stored procedure <c>uspGetByKeyOneQuoteProduct</c>.
        /// </summary>
        /// <param name="key1">The <see cref="Quote.QuoteId"/> of <see cref="QuoteProduct"/> entities to retrieve.</param>
        /// <returns>A collection of <see cref="QuoteProduct"/>entities.</returns>
        public IEnumerable<QuoteProduct> GetByKeyOne(int key1)
        {
            var quoteProduct = new List<QuoteProduct>();
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetByKeyOneQuoteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@QuoteId", SqlDbType.Int).Value = key1;
                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        quoteProduct.Add(new QuoteProduct
                        {
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("QuoteId")),
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("ProductId")),
                            QuoteProductTimeEstimate = reader.IsDBNull(reader.GetOrdinal("QuoteProductTimeEstimate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductTimeEstimate")),
                            QuoteProductPrice = reader.IsDBNull(reader.GetOrdinal("QuoteProductPrice")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductPrice"))
                        });
                    }
                }
            }
            return quoteProduct;
        }

        /// <summary>
        /// Retrieves all <see cref="QuoteProduct"/> entities from the database that are associated with
        /// the specified <see cref="Product.ProductId"/> by executing the stored procedure <c>uspGetByKeyTwoQuoteProduct</c>.
        /// </summary>
        /// <param name="key2">The <see cref="Product.ProductId"/> of <see cref="QuoteProduct"/> entities to retrieve.</param>
        /// <returns>A collection of <see cref="QuoteProduct"/>entities.</returns>
        public IEnumerable<QuoteProduct> GetByKeyTwo(int key2)
        {
            var quoteProduct = new List<QuoteProduct>();
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetByKeyTwoQuoteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = key2;
                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        quoteProduct.Add(new QuoteProduct
                        {
                            QuoteId = reader.IsDBNull(reader.GetOrdinal("QuoteId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("QuoteId")),
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("ProductId")),
                            QuoteProductTimeEstimate = reader.IsDBNull(reader.GetOrdinal("QuoteProductTimeEstimate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductTimeEstimate")),
                            QuoteProductPrice = reader.IsDBNull(reader.GetOrdinal("QuoteProductPrice")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("QuoteProductPrice"))
                        });
                    }
                }
            }
            return quoteProduct;
        }

        /// <summary>
        /// Adds a new <see cref="QuoteProduct"/> entity to the database by executing
        /// the stored procedure <c>uspCreateQuoteProduct</c>.
        /// </summary>
        /// <param name="quoteProduct">The <see cref="QuoteProduct"/> to add.</param>
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

        /// <summary>
        /// Updates an existing <see cref="QuoteProduct"/> entity in the database by executing
        /// the stored procedure <c>uspUpdateQuoteProduct</c>.
        /// </summary>
        /// <param name="quoteProduct">The <see cref="QuoteProduct"/> to update.</param>
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

        /// <summary>
        /// Deletes a <see cref="QuoteProduct"/> entity from the database by executing
        /// the stored procedure <c>uspDeleteQuoteProduct</c>.
        /// </summary>
        /// <param name="key1">The <see cref="Quote.QuoteId"/> of <see cref="QuoteProduct"/> to delete.</param>
        /// <param name="key2">The <see cref="Product.ProductId"/> of <see cref="QuoteProduct"/> to delete.</param>
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
