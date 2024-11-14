using Publico_Kommunikation_Project.Models;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Publico_Kommunikation_Project.DataAccess
{
    // Repository class implementing the IRepository interface
    public class CategoryRepository : IRepository<Category>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        // Constructor to initialize the repository with a connection string
        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Stored procedure
        SqlConnection sqlCon = null;

        String SqlconString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Method to retrieve all records from the database
        public IEnumerable<Category> GetAll()
        {
            var category = new List<Category>();
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetAllCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        category.Add(new Category
                        {
                            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("CategoryId")),

                            // Directly cast "Description" to string, no need for DBNull check if it's guaranteed to be non-null
                            CategoryName = reader.IsDBNull(reader.GetOrdinal("CategoryName")) ? string.Empty : reader.GetString(reader.GetOrdinal("CategoryName")),

                        });
                    }
                }
            }
            return category;
        }

        // Method to retrieve a specific record by its Id
        public Category GetById(int id) 
        {
            Category category = null;
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        category = new Category
                        {
                            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("CategoryId")),
                            CategoryName = reader.IsDBNull(reader.GetOrdinal("CategoryName")) ? string.Empty : reader.GetString(reader.GetOrdinal("CategoryName")),
                        };
                    }
                }
            }
            return category;
        }

        // Method to add a new record to the database
        public void Add(Category category)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to update an existing record in the database
        public void Update(Category category)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspUpdateCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = category.CategoryId;
                sql_cmnd.Parameters.AddWithValue("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to delete a record from the database by its Id
        public void Delete(int id)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspDeleteCategory", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = id;
                sql_cmnd.ExecuteNonQuery();
            }
        }
    }
}
