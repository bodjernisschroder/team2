using Template.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Template.DataAccess
{
    // Repository class implementing the IRepository interface
    public class ClassTemplateRepository : IRepository<ClassTemplate>
    {
        private readonly string _connectionString; // Connection string for the SQL database

        // Constructor to initialize the repository with a connection string
        public ClassTemplateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Stored procedure
        SqlConnection sqlCon = null;

        String SqlconString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Method to retrieve all records from the database
        public IEnumerable<ClassTemplate> GetAll()
        {
            var template = new List<ClassTemplate>();
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspGetAllClassTemplate", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        template.Add(new ClassTemplate
                        {
                            ClassTemplateId = reader.IsDBNull(reader.GetOrdinal("ClassTemplateId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("ClassTemplateId")),

                            // Directly cast "Description" to string, no need for DBNull check if it's guaranteed to be non-null
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),

                            // Check if "RelatedId" is DBNull, if not cast it from Int64 to Int32
                            RelatedId = reader.IsDBNull(reader.GetOrdinal("RelatedId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("RelatedId"))
                        });
                    }
                }
            }
            return template;
        }

        // Method to retrieve a specific record by its Id
        public ClassTemplate GetById(int id) 
        {
            ClassTemplate template = null;
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateClassTemplate", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ClassTemplateId", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        template = new ClassTemplate
                        {
                            ClassTemplateId = reader.IsDBNull(reader.GetOrdinal("ClassTemplateId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("ClassTemplateId")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
                            RelatedId = reader.IsDBNull(reader.GetOrdinal("RelatedId")) ? 0 : (int)reader.GetInt64(reader.GetOrdinal("RelatedId"))
                        };
                    }
                }
            }
            return template;
        }

        // Method to add a new record to the database
        public void Add(ClassTemplate classTemplate)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspCreateClassTemplate", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = classTemplate.Description;
                sql_cmnd.Parameters.AddWithValue("@RelatedId", SqlDbType.Int).Value = classTemplate.RelatedId;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to update an existing record in the database
        public void Update(ClassTemplate classTemplate)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspUpdateClassTemplate", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ClassTemplateId", SqlDbType.Int).Value = classTemplate.ClassTemplateId;
                sql_cmnd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = classTemplate.Description;
                sql_cmnd.Parameters.AddWithValue("@RelatedId", SqlDbType.Int).Value = classTemplate.RelatedId;
                sql_cmnd.ExecuteNonQuery();
            }
        }

        // Method to delete a record from the database by its Id
        public void Delete(int id)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("uspDeleteClassTemplate", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ClassTemplateId", SqlDbType.Int).Value = id;
                sql_cmnd.ExecuteNonQuery();
            }
        }
    }
}
