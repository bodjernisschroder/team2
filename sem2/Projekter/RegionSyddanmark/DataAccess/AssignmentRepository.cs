﻿using RegionSyd.Model;
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
                            RegionId = reader.IsDBNull(reader.GetOrdinal("RegionId")) ? 0 : (int)reader["RegionId"],
                            RegionalId = reader.IsDBNull(reader.GetOrdinal("RegionalAssignmentId")) ? 0 : (int)reader["RegionalAssignmentId"],
                            TypeId = reader.IsDBNull(reader.GetOrdinal("TypeId")) ? 0 : (int)reader["TypeId"],
                            Description = (string)reader["Description"],
                            ScheduledDateTime = (DateTime)reader["ScheduledDateTime"],
                            FromAddress = (string)reader["FromAddress"],
                            ToAddress = (string)reader["ToAddress"],
                            ComboId = reader.IsDBNull(reader.GetOrdinal("ComboId")) ? 0 : (int)reader["ComboId"]
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
                            RegionId = reader.IsDBNull(reader.GetOrdinal("RegionId")) ? 0 : (int)reader["RegionId"],
                            RegionalId = reader.IsDBNull(reader.GetOrdinal("RegionalAssignmentId")) ? 0 : (int)reader["RegionalAssignmentId"],
                            TypeId = reader.IsDBNull(reader.GetOrdinal("TypeId")) ? 0 : (int)reader["TypeId"],
                            Description = (string)reader["Description"],
                            ScheduledDateTime = (DateTime)reader["ScheduledDateTime"],
                            FromAddress = (string)reader["FromAddress"],
                            ToAddress = (string)reader["ToAddress"],
                            ComboId = reader.IsDBNull(reader.GetOrdinal("ComboId")) ? 0 : (int)reader["ComboId"]
                        };
                    }
                }
            }
            return assignment;
        }

        public void Add(Assignment assignment)
        {

            string query = "INSERT INTO ASSIGNMENT (RegionId, RegionalAssignmentId, TypeId, Description, ScheduledDateTime, FromAddress, ToAddress, ComboId) " +
                           "VALUES (@RegionId, @RegionalAssignmentId, @TypeId, @Description, @ScheduledDateTime, @FromAddress, @ToAddress, @ComboId);" +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegionId", (int)assignment.RegionId);
                command.Parameters.AddWithValue("@RegionalAssignmentId", assignment.RegionalId);
                command.Parameters.AddWithValue("@TypeId", assignment.TypeId);
                command.Parameters.AddWithValue("@Description", assignment.Description);
                command.Parameters.AddWithValue("@ScheduledDateTime", assignment.ScheduledDateTime);
                command.Parameters.AddWithValue("@FromAddress", assignment.FromAddress);
                command.Parameters.AddWithValue("@ToAddress", assignment.ToAddress);
                connection.Open();
            }
        }

        public void Update(Assignment assignment)
        {
            string query = "UPDATE Assignment SET ComboId = @ComboId WHERE RegionaAssignmentlId = @RegionalAssignmentId";

            using (SqlConnection connection = new SqlConnection(_connectionString))  
            {
                SqlCommand command = new SqlCommand(query, connection);  

                command.Parameters.AddWithValue("@ComboId", assignment.ComboId);
                command.Parameters.AddWithValue("@RegionalAssignmentId", assignment.RegionalId);

                connection.Open();  
                command.ExecuteNonQuery();
            }
        }
       
        public void Delete(int id)
        {
            string query = "DELETE FROM ASSIGNMENT WHERE RegionalAssignmentId = @RegionalAssignmentId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegionalAssignmentId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
