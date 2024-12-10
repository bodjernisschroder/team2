using System.Data;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.DataAccess
{
    /// <summary>
    /// A repository class for managing <see cref="Product"/> entities.
    /// Implements the <see cref="ISimpleKeyRepository{T}"/> interface.
    /// </summary>
    public class ProductRepository : ISimpleKeyRepository<Product>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        /// <summary>
        /// Initializes a new instance of <see cref="ProductRepository"/> with the specified <paramref name="connectionString"/>.
        /// </summary>
        /// <param name="connectionString">The connection string used to establish a connection to the database.</param>
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves all <see cref="Product"/> entities from the database by executing the
        /// stored procedure <c>uspGetAllProduct</c>.
        /// </summary>
        /// <returns>A collection of <see cref="Product"/>entities.</returns>
        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetAllProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        products.Add(new Product
                        {
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("ProductId")),

                            // Directly cast to string, no need for DBNull check if it's guaranteed to be non-null
                            ProductName = reader.IsDBNull(reader.GetOrdinal("ProductName")) ? string.Empty : reader.GetString(reader.GetOrdinal("ProductName")),

                            // Check if DBNull, if not cast it from Int64 to Int32
                            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("CategoryId"))
                        });
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Retrieves a specific entity of <see cref="Product"/> by its <see cref="Product.ProductId"/>
        /// by executing the stored procedure <c>uspGetByKeyProduct</c>.
        /// </summary>
        /// <param name="key">The <see cref="Product.ProductId"/> of <see cref="Product"/> to retrieve.</param>
        /// <returns>The <see cref="Product"/> entity that matches the specified <paramref name="key"/>.</returns>
        public Product GetByKey(int key)
        {
            Product product = null;
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetByKeyProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = key;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        product = new Product
                        {
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("ProductId")),
                            ProductName = reader.IsDBNull(reader.GetOrdinal("ProductName")) ? string.Empty : reader.GetString(reader.GetOrdinal("ProductName")),
                            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("CategoryId"))
                        };
                    }
                }
            }
            return product;
        }

        /// <summary>
        /// Adds a new <see cref="Product"/> entity to the database by executing
        /// the stored procedure <c>uspCreateProduct</c>.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to add.</param>
        public void Add(Product product)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = product.ProductName;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = product.CategoryId;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates an existing <see cref="Product"/> entity in the database by executing
        /// the stored procedure <c>uspUpdateProduct</c>.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to update.</param>
        public void Update(Product product)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspUpdateProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = product.ProductId;
                sql_cmnd.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = product.ProductName;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = product.CategoryId;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deletes a <see cref="product"/> entity from the database by executing
        /// the stored procedure <c>uspDeleteProduct</c>.
        /// </summary>
        /// <param name="key">The <see cref="Product.ProductId"/> of <see cref="Product"/> to delete.</param>
        public void Delete(int key)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspDeleteProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = key;
                sql_cmnd.ExecuteNonQuery();
            }
        }
    }
}
