using Template.Models;
using Microsoft.Data.Sqlite;

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

        // Method to retrieve all records from the database
        public IEnumerable<ClassTemplate> GetAll()
        {
            var template = new List<ClassTemplate>();
            string query = "SELECT * FROM CLASSTEMPLATE";

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open(); // Open the SQL connection

                using (SqliteDataReader reader = command.ExecuteReader())
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
            return template; // Return the list of objects gathered from the database
        }

        // Method to retrieve a specific record by its Id
        public ClassTemplate GetById(int id)
        {
            ClassTemplate template = null;
            string query = "SELECT * FROM CLASSTEMPLATE WHERE ClassTemplateId = @ClassTemplateId"; 

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ClassTemplateId", id);
                connection.Open();

                using (SqliteDataReader reader = command.ExecuteReader())
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
            return template; // Return the object, or null if not found
        }

        // Method to add a new record to the database
        public void Add(ClassTemplate classTemplate)
        {
            string query = "INSERT INTO CLASSTEMPLATE (Description, RelatedId) " +
                           "VALUES (@Description, @RelatedId);" +
                           "SELECT SCOPE_IDENTITY();";

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Description", classTemplate.Description);
                command.Parameters.AddWithValue("@RelatedId", (int)classTemplate.RelatedId);
                connection.Open();
                int classTemplateId = Convert.ToInt32(command.ExecuteScalar());
                classTemplate.ClassTemplateId = classTemplateId;
            }
        }

        // Method to update an existing record in the database
        public void Update(ClassTemplate classTemplate)
        {
            string query = "UPDATE CLASSTEMPLATE SET Description = @Description, RelatedId = @RelatedId WHERE ClassTemplateId = @ClassTemplateId";

            using (SqliteConnection connection = new SqliteConnection(_connectionString))  
            {
                SqliteCommand command = new SqliteCommand(query, connection);  
                command.Parameters.AddWithValue("@ClassTemplateId", classTemplate.ClassTemplateId);
                command.Parameters.AddWithValue("@Description", classTemplate.Description);
                command.Parameters.AddWithValue("@RelatedId", classTemplate.RelatedId);
                connection.Open();
                command.ExecuteNonQuery(); // Execute the update query
            }
        }

        // Method to delete a record from the database by its Id
        public void Delete(int id)
        {
            string query = "DELETE FROM CLASSTEMPLATE WHERE ClassTemplateId = @ClassTemplateId";

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ClassTemplateId", id);
                connection.Open();
                command.ExecuteNonQuery(); // Execute the delete query
            }
        }
    }
}
