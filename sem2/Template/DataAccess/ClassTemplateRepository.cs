using Template.Models;
using Microsoft.Data.SqlClient;

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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open(); // Open the SQL connection

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the object from the SQL data
                        template.Add(new ClassTemplate
                        {
                            ClassTemplateId = reader.IsDBNull(reader.GetOrdinal("ClassTemplateId")) ? 0 : (int)reader["ClassTemplateId"],
                            Description = (string)reader["Description"],
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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClassTemplateId", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the object from the SQL data
                        template = new ClassTemplate
                        {
                            ClassTemplateId = reader.IsDBNull(reader.GetOrdinal("TemplateId")) ? 0 : (int)reader["TemplateId"],
                            Description = (string)reader["Description"],
                        };
                    }
                }
            }
            return template; // Return the object, or null if not found
        }

        // Method to add a new record to the database
        public void Add(ClassTemplate classTemplate)
        {

            string query = "INSERT INTO CLASSTEMPLATE (ClassTemplateId, Description) " +
                           "VALUES (@ClassTemplateId, @Description);" +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClassTemplateId", (int)classTemplate.ClassTemplateId);
                command.Parameters.AddWithValue("@Description", classTemplate.Description);

                connection.Open();
            }
        }

        // Method to update an existing record in the database
        public void Update(ClassTemplate classTemplate)
        {
            string query = "UPDATE CLASSTEMPLATE SET RelatedId = @RelatedId WHERE ClassTemplateId = @ClassTemplateId";

            using (SqlConnection connection = new SqlConnection(_connectionString))  
            {
                SqlCommand command = new SqlCommand(query, connection);  

                command.Parameters.AddWithValue("@RelatedId", classTemplate.RelatedId);
                command.Parameters.AddWithValue("@ClassTemplateId", classTemplate.ClassTemplateId);

                connection.Open();  
                command.ExecuteNonQuery(); // Execute the update query
            }
        }

        // Method to delete a record from the database by its Id
        public void Delete(int id)
        {
            string query = "DELETE FROM CLASSTEMPLATE WHERE ClassTemplateId = @ClassTemplateId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClassTemplateId", id);
                connection.Open();
                command.ExecuteNonQuery(); // Execute the delete query
            }
        }
    }
}
