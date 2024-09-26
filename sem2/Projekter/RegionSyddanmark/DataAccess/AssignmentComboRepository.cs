using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                            ComboId = (int)reader["ComboId"],
                            
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
                            ComboId = (int)reader["ComboId"]
                        };
                    }
                }
            }
            return assignmentcombo;
        }

        public void Add(AssignmentCombo assignmentcombo)
        {
            string query = "INSERT INTO ASSIGNMENTCOMBO (ComboId) DEFAULT VALUES";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
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
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@ComboId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
