using Microsoft.Data.SqlClient;
using RegionSyd.Model;

namespace RegionSyd.DataAccess
{
    public class RegionRepository : IRepository<Region>
        {
            private readonly string _connectionString;

            public RegionRepository(string connectionString)
            {
                _connectionString = connectionString;
            }

            public IEnumerable<Region> GetAll()
            {
                var regions = new List<Region>();
                string query = "SELECT * FROM REGION";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            regions.Add(new Region
                            {
                                RegionId = reader.IsDBNull(reader.GetOrdinal("RegionId")) ? 0 : (int)reader["RegionId"]

                            });
                        }
                    }
                }
                return regions;
            }

            public Region GetById(int id)
            {
                Region region = null;
                string query = "SELECT * FROM REGION WHERE RegionId = @RegionId";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RegionId", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            region = new Region
                            {
                                RegionId = reader.IsDBNull(reader.GetOrdinal("RegionId")) ? 0 : (int)reader["RegionId"]
                            };
                        }
                    }
                }
                return region;
            }

            public void Add()
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                string query = "DELETE FROM REGION WHERE RegionId = @RegionId";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query);
                    command.Parameters.AddWithValue("@RegionId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
}