using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.DataAccess
{
    // Repository class implementing the IRepository interface
    public class ProductRepository : ISimpleKeyRepository<Product>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        // Constructor to initialize the repository with a connection string
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Stored procedure
        // SqlConnection sqlCon = null;

        // String SqlconString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Method to retrieve all records from the database
        public IEnumerable<Product> GetAll()
        {
            var product = new List<Product>();
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
                        product.Add(new Product
                        {
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("ProductId")),

                            // Directly cast to string, no need for DBNull check if it's guaranteed to be non-null
                            ProductName = reader.IsDBNull(reader.GetOrdinal("ProductName")) ? string.Empty : reader.GetString(reader.GetOrdinal("ProductName")),

                            // Check if DBNull, if not cast it from Int64 to Int32
                            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("CategoryId"))
                        });
                    }
                }
            }
            return product;
        }

        // Method to retrieve a specific record by its Id
        public Product GetByKey(int key)
        {
            Product product = null;
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateProduct", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = key;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        product = new Product
                        {
                            ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("ProductId")),
                            ProductName = reader.IsDBNull(reader.GetOrdinal("ProductName")) ? string.Empty : reader.GetString(reader.GetOrdinal("ProductName")),
                            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("CategoryId"))
                        };
                    }
                }
            }
            return product;
        }

        // Method to add a new record to the database
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

        // Method to update an existing record in the database
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

        // Method to delete a record from the database by its Id
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

        // Tilføj metode om at hente View med en specifik CategoryId
    }
}
