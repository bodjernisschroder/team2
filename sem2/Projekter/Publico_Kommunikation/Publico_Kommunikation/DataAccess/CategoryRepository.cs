using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.DataAccess
{
    /// <summary>
    /// A repository class for managing <see cref="Category"/> entities.
    /// Implements the <see cref="ISimpleKeyRepository{T}"/> interface.
    /// </summary>
    public class CategoryRepository : ISimpleKeyRepository<Category>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        /// <summary>
        /// Initializes a new instance of <see cref="CategoryRepository"/> with the specified <paramref name="connectionString"/>.
        /// </summary>
        /// <param name="connectionString">The connection string used to establish a connection to the database.</param>
        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves all <see cref="Category"/> entities from the database by executing the
        /// stored procedure <c>uspGetAllCategory</c>.
        /// </summary>
        /// <returns>A collection of <see cref="Category"/>entities.</returns>
        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();
            {
                using (var sqlCon = new SqlConnection(_connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("uspGetAllCategory", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate the object from the SQL data
                            categories.Add(new Category
                            {
                                CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("CategoryId")),

                                // Directly cast "Description" to string, no need for DBNull check if it's guaranteed to be non-null
                                CategoryName = reader.IsDBNull(reader.GetOrdinal("CategoryName")) ? string.Empty : reader.GetString(reader.GetOrdinal("CategoryName")),

                            });
                        }
                    }
                }
            }
            return categories;
        }


        /// <summary>
        /// Retrieves a specific entity of <see cref="Category"/> by its <see cref="Category.CategoryId"/>
        /// by executing the stored procedure <c>uspGetByKeyCategory</c>.
        /// </summary>
        /// <param name="key">The <see cref="Category.CategoryId"/> of <see cref="Category"/> to retrieve.</param>
        /// <returns>The <see cref="Category"/> entity that matches the specified <paramref name="key"/>.</returns>
        public Category GetByKey(int key)
        {
            Category? category = null;
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetByKeyCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = key;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        category = new Category
                        {
                            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt32(reader.GetOrdinal("CategoryId")),
                            CategoryName = reader.IsDBNull(reader.GetOrdinal("CategoryName")) ? string.Empty : reader.GetString(reader.GetOrdinal("CategoryName")),
                        };
                    }
                }
            }
            return category;
        }

        /// <summary>
        /// Adds a new <see cref="Category"/> entity to the database by executing
        /// the stored procedure <c>uspCreateCategory</c>.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to add.</param>
        public void Add(Category category)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates an existing <see cref="Category"/> entity in the database by executing
        /// the stored procedure <c>uspUpdateCategory</c>.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to update.</param>
        public void Update(Category category)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspUpdateCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = category.CategoryId;
                sql_cmnd.Parameters.AddWithValue("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deletes a <see cref="Category"/> entity from the database by executing
        /// the stored procedure <c>uspDeleteCategory</c>.
        /// </summary>
        /// <param name="key">The <see cref="Category.CategoryId"/> of <see cref="Category"/> to delete.</param>
        public void Delete(int key)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspDeleteCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = key;
                sql_cmnd.ExecuteNonQuery();
            }
        }
    }
}