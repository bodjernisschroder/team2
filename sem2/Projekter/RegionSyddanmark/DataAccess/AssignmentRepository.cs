using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd.Model;
using Microsoft.Data.SqlClient;

namespace RegionSyd.DataAccess
{
    public class AssignmentRepository : IRepository<Assignment>
    {
        private readonly string _connectionString;

        public AssignmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Assignment> GetAll()
        {
            var assignments = new List<Assignment>();
            string query = "SELECT * FROM ASSIGNMENT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        assignments.Add(new Assignment
                        {
                            RegionEnum = (RegionEnum)(int)reader["RegionId"],
                            RegionalId = (int)reader["RegionalAssignmentId"],
                            Type = (Model.Type)reader["TypeId"],
                            Description = (string)reader["Description"],
                            ScheduledDateTime = (DateTime)reader["ScheduledDateTime"],
                            FromAddress = (string)reader["FromAddress"],
                            ToAddress = (string)reader["ToAddress"],
                            ComboId = (int)reader["ComboId"]
                        });
                    }
                }
            }
            return assignments;
        }

        public Assignment GetById(int id)
        {
            Assignment assignment = null;
            string query = "SELECT * FROM ASSIGNMENT WHERE RegionalAssignmentId = @RegionalAssignmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegionalAssignmentID", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        assignment = new Assignment
                        {
                            RegionEnum = (RegionEnum)(int)reader["RegionId"],
                            RegionalId = (int)reader["RegionalAssignmentId"],
                            Type = (Model.Type)reader["TypeId"],
                            Description = (string)reader["Description"],
                            ScheduledDateTime = (DateTime)reader["ScheduledDateTime"],
                            FromAddress = (string)reader["FromAddress"],
                            ToAddress = (string)reader["ToAddress"],
                            ComboId = (int)reader["ComboId"]
                        };
                    }
                }
            }
            return assignment;
        }

        public void Add(Assignment assignment)
        {
            string query = "INSERT INTO ASSIGNMENT (RegionId, RegionalAssignmentId, TypeId, Description, ScheduledDateTime, FromAddress, ToAddress, ComboId) VALUES (@Region, @RegionalId, @Type, @Description, @ScheduledDateTime, @FromAddress, @ToAddress, @ComboId)";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Region", (int)assignment.RegionEnum);
                command.Parameters.AddWithValue("@RegionalId", assignment.RegionalId);
                command.Parameters.AddWithValue("@Type", assignment.Type.TypeId);
                command.Parameters.AddWithValue("@Description", assignment.Description);
                command.Parameters.AddWithValue("@ScheduledDateTime", assignment.ScheduledDateTime);
                command.Parameters.AddWithValue("@FromAddress", assignment.FromAddress);
                command.Parameters.AddWithValue("@ToAddress", assignment.ToAddress);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Assignment assignment)
        {
            string query = "UPDATE ASSIGNMENT SET RegionId = @Region, TypeId = @Type, Description = @Description, ScheduledDateTime = @ScheduledDateTime, FromAddress = @FromAddress, ToAddress = @ToAddress, ComboId = @ComboId WHERE RegionalAssignmentId = @RegionalId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@Region", (int)assignment.RegionEnum);
                command.Parameters.AddWithValue("@Type", assignment.Type.TypeId);
                command.Parameters.AddWithValue("@Description", assignment.Description);
                command.Parameters.AddWithValue("@ScheduledDateTime", assignment.ScheduledDateTime);
                command.Parameters.AddWithValue("@FromAddress", assignment.FromAddress);
                command.Parameters.AddWithValue("@ToAddress", assignment.ToAddress);
                command.Parameters.AddWithValue("@ComboId", assignment.ComboId);
                command.Parameters.AddWithValue("@RegionalId", assignment.RegionalId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM ASSIGNMENT WHERE RegionalAssignmentId = @RegionalId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@RegionalId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
