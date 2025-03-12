using Proxima.Controllers;
using Proxima.Models;
using System.Data;
using System.Data.SqlClient;
using static Proxima.Models.PmDashboardModel;

namespace Proxima.Data
{
    public class PmDashboardRepository
    {
        private readonly string _connectionString;

        public PmDashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public PmDashboardData GetDashboardData(int UserID)
        {
            PmDashboardData dashboardData = new PmDashboardData
            {
                Counts = new List<PmDashboardCount>(),
                RecentProjects = new List<AssignedProjects>(),
                RecentTasks = new List<AssignedTasks>(),
            };

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_Get_PM_DashboardData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Step 1: Read Counts
                        while (reader.Read())
                        {
                            dashboardData.Counts.Add(new PmDashboardCount
                            {
                                Metric = reader["Metric"].ToString(),
                                Value = Convert.ToInt32(reader["Value"])
                            });
                        }
                        reader.NextResult();

                        // Step 2: Read Recent Projects
                        while (reader.Read())
                        {
                            dashboardData.RecentProjects.Add(new AssignedProjects
                            {
                                ProjectID = Convert.ToInt32(reader["ProjectID"]),
                                Title = reader["Title"].ToString(),
                                ClientName = reader["ClientName"].ToString(),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = Convert.ToDateTime(reader["EndDate"]),
                                Status = reader["Status"].ToString(),
                                AssignedAt = Convert.ToDateTime(reader["AssignedAt"])
                            });
                        }
                        reader.NextResult();

                        // Step 3: Read Recent Tasks
                        while (reader.Read())
                        {
                            dashboardData.RecentTasks.Add(new AssignedTasks
                            {
                                TaskID = Convert.ToInt32(reader["TaskID"]),
                                Title = reader["Title"].ToString(),
                                ProjectName = reader["ProjectName"].ToString(),
                                DueDate = Convert.ToDateTime(reader["DueDate"]),
                                Status = reader["Status"].ToString(),
                                AssignedAt = Convert.ToDateTime(reader["AssignedAt"])
                            });
                        }
                        reader.NextResult();
                    }
                }
            }

            return dashboardData;
        }
    }
}
