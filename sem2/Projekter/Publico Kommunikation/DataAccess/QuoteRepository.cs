using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.DataAccess
{
    /// <summary>
    /// A repository class for managing <see cref="Quote"/> entities.
    /// Implements the <see cref="ISimpleKeyRepository{T}"/> interface.
    /// </summary>
    public class QuoteRepository : ISimpleKeyRepository<Quote>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        /// <summary>
        /// Initializes a new instance of <see cref="QuoteRepository"/> with the specified <paramref name="connectionString"/>.
        /// </summary>
        /// <param name="connectionString">The connection string used to establish a connection to the database.</param>
        public QuoteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves all <see cref="Quote"/> entities from the database by executing the
        /// stored procedure <c>uspGetAllQuote</c>.
        /// </summary>
        /// <returns>A collection of <see cref="Quote"/>entities.</returns>
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
                            HourlyRate = reader.IsDBNull(reader.GetOrdinal("HourlyRate")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("HourlyRate")),
                            DiscountPercentage = reader.IsDBNull(reader.GetOrdinal("DiscountPercentage")) ? 0.0m : reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
                            Sum = reader.IsDBNull(reader.GetOrdinal("Sum")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Sum"))
                        });
                    }
                }
            }
            return quote;
        }

        /// <summary>
        /// Retrieves a specific entity of <see cref="Quote"/> by its <see cref="Quote.QuoteId"/>
        /// by executing the stored procedure <c>uspGetByKeyQuote</c>.
        /// </summary>
        /// <param name="key">The <see cref="Quote.QuoteId"/> of <see cref="Quote"/> to retrieve.</param>
        /// <returns>The <see cref="Quote"/> entity that matches the specified <paramref name="key"/>.</returns>
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

        /// <summary>
        /// Adds a new <see cref="Quote"/> entity to the database by executing
        /// the stored procedure <c>uspCreateQuote</c>.
        /// </summary>
        /// <param name="quote">The <see cref="Quote"/> to add.</param>
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

        /// <summary>
        /// Updates an existing <see cref="Quote"/> entity in the database by executing
        /// the stored procedure <c>uspUpdateQuote</c>.
        /// </summary>
        /// <param name="quote">The <see cref="Quote"/> to update.</param>
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

        /// <summary>
        /// Deletes a <see cref="Quote"/> entity from the database by executing
        /// the stored procedure <c>uspDeleteQuote</c>.
        /// </summary>
        /// <param name="key">The <see cref="Quote.QuoteId"/> of <see cref="Quote"/> to delete.</param>
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
