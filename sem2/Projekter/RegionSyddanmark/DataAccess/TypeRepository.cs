using Microsoft.Data.SqlClient;

namespace RegionSyd.DataAccess
{
    public class TypeRepository : IRepository<Model.Type>
    {
        private readonly string _connectionString;

        public TypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Model.Type> GetAll()
        {
            var types = new List<Model.Type>();
            string query = "SELECT * FROM TYPE";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        types.Add(new Model.Type
                        {
                            TypeId = reader.IsDBNull(reader.GetOrdinal("TypeId")) ? 0 : (int)reader["TypeId"],
                            TypeName = (string)reader["TypeName"],
                            ServiceGoal = (string)reader["ServiceGoal"],
                        });
                    }
                }
            }
            return types;
        }

        public Model.Type GetById(int id)
        {
            Model.Type type = null;
            string query = "SELECT * FROM TYPE WHERE TypeId = @TypeId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeId", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = new Model.Type
                        {
                            TypeId = reader.IsDBNull(reader.GetOrdinal("TypeId")) ? 0 : (int)reader["TypeId"],
                            TypeName = (string)reader["TypeName"],
                            ServiceGoal = (string)reader["ServiceGoal"]
                        };
                    }
                }
            }
            return type;
        }

        public void Add(Model.Type type)
        {
            string query = "INSERT INTO TYPE (TypeId, TypeName, ServiceGoal) VALUES (@TypeId, @TypeName, @ServiceGoal)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeId", type.TypeId);
                command.Parameters.AddWithValue("@TypeName", type.TypeName);
                command.Parameters.AddWithValue("@ServiceGoal", type.ServiceGoal);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Model.Type type)
        {
            string query = "UPDATE TYPE SET TypeName = @TypeName, ServiceGoal = @ServiceGoal WHERE TypeId = @TypeId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeId", type.TypeId);
                command.Parameters.AddWithValue("@TypeName", type.TypeName);
                command.Parameters.AddWithValue("@ServiceGoal", type.ServiceGoal);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM TYPE WHERE TypeId = @TypeId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
