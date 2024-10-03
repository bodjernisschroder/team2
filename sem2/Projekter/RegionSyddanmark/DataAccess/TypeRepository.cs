using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using RegionSyd.Model;

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
                            Name = (string)reader["TypeName"],
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
                            Name = (string)reader["TypeName"],
                            ServiceGoal = (string)reader["ServiceGoal"]
                        };
                    }
                }
            }
            return type;
        }

        public void Add(Model.Type type)
        {
            string query = "INSERT INTO TYPE (TypeId, TypeName, ServiceGoal) VALUES (@TypeId, @Name, @Type, @ServiceGoal)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeId", type.TypeId);
                command.Parameters.AddWithValue("@Name", type.Name);
                command.Parameters.AddWithValue("@ServiceGoal", type.ServiceGoal);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Model.Type type)
        {
            string query = "UPDATE TYPE SET TypeName = @Name, ServiceGoal = @ServiceGoal WHERE TypeId = @TypeId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@TypeId", type.TypeId);
                command.Parameters.AddWithValue("@Name", type.Name);
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
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@TypeId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
