using Microsoft.Data.SqlClient;
using RegionSyd.Model;

namespace RegionSyd.DataAccess
{
    public class AssignmentComboRepository : IRepository<AssignmentCombo>
    {
        private readonly string _connectionString;

        public AssignmentComboRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<AssignmentCombo> GetAll()
        {
            var assignmentcombos = new List<AssignmentCombo>();
            string query = "SELECT * FROM ASSIGNMENTCOMBO";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        assignmentcombos.Add(new AssignmentCombo
                        {
                            ComboId = reader.IsDBNull(reader.GetOrdinal("ComboId")) ? 0 : (int)reader["ComboId"],
                            RegionalId1 = reader.IsDBNull(reader.GetOrdinal("RegionalId1")) ? 0 : (int)reader["RegionalId1"],
                            RegionalId2 = reader.IsDBNull(reader.GetOrdinal("RegionalId2")) ? 0 : (int)reader["RegionalId2"],
                            RegionalId3 = reader.IsDBNull(reader.GetOrdinal("RegionalId3")) ? 0 : (int)reader["RegionalId3"],
                            RegionalId4 = reader.IsDBNull(reader.GetOrdinal("RegionalId4")) ? 0 : (int)reader["RegionalId4"],
                            RegionalId5 = reader.IsDBNull(reader.GetOrdinal("RegionalId5")) ? 0 : (int)reader["RegionalId5"]
                        });
                    }
                }
            }
            return assignmentcombos;
        }

        public AssignmentCombo GetById(int id)
        {
            AssignmentCombo assignmentcombo = null;
            string query = "SELECT * FROM ASSIGNMENTCOMBO WHERE ComboId = @ComboId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComboId", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        assignmentcombo = new AssignmentCombo
                        {
                            ComboId = reader.IsDBNull(reader.GetOrdinal("ComboId")) ? 0 : (int)reader["ComboId"],
                            RegionalId1 = reader.IsDBNull(reader.GetOrdinal("RegionalId1")) ? 0 : (int)reader["RegionalId1"],
                            RegionalId2 = reader.IsDBNull(reader.GetOrdinal("RegionalId2")) ? 0 : (int)reader["RegionalId2"],
                            RegionalId3 = reader.IsDBNull(reader.GetOrdinal("RegionalId3")) ? 0 : (int)reader["RegionalId3"],
                            RegionalId4 = reader.IsDBNull(reader.GetOrdinal("RegionalId4")) ? 0 : (int)reader["RegionalId4"],
                            RegionalId5 = reader.IsDBNull(reader.GetOrdinal("RegionalId5")) ? 0 : (int)reader["RegionalId5"]
                        };
                    }
                }
            }
            return assignmentcombo;
        }

        public void Add(AssignmentCombo assignmentcombo)
        {
            string query = "INSERT INTO ASSIGNMENTCOMBO " +
                "(RegionalId1, RegionalId2, RegionalId3, RegionalId4, RegionalId5) " +
                "VALUES (@RegionalId1, @RegionalId2, @RegionalId3, @RegionalId4, @RegionalId5)" + 
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RegionalId1", assignmentcombo.RegionalId1);
                command.Parameters.AddWithValue("@RegionalId2", assignmentcombo.RegionalId2);
                command.Parameters.AddWithValue("@RegionalId3", assignmentcombo.RegionalId3);
                command.Parameters.AddWithValue("@RegionalId4", assignmentcombo.RegionalId4);
                command.Parameters.AddWithValue("@RegionalId5", assignmentcombo.RegionalId5);
                connection.Open();
                int newComboId = Convert.ToInt32(command.ExecuteScalar());
                assignmentcombo.ComboId = newComboId;
            }
        }

        public void Update(AssignmentCombo assignmentcombo)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM ASSIGNMENTCOMBO WHERE ComboId = @ComboId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComboId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
