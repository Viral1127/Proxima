using Proxima.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proxima.Data
{
    public class AdminDashboardRepository
    {
        private readonly string _connectionString;

        public AdminDashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public AdminDashboardData GetDashboardData()
        {
            AdminDashboardData dashboardData = new AdminDashboardData
            {
                Counts = new List<DashboardCount>(),
                RecentProjects = new List<RecentProject>(),
                RecentTasks = new List<RecentTask>(),
                UpcomingMilestones = new List<UpcomingMilestone>(),
                RecentUsers = new List<RecentUser>(),
                ProjectsPerMonth = new List<ProjectPerMonth>(),
                ProjectStatusCounts = new List<ProjectStatusCount>()
            };

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_GetAdminDashboardData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Step 1: Read Counts
                        while (reader.Read())
                        {
                            dashboardData.Counts.Add(new DashboardCount
                            {
                                Metric = reader["Metric"].ToString(),
                                Value = Convert.ToInt32(reader["Value"])
                            });
                        }
                        reader.NextResult();

                        // Step 2: Read Recent Projects
                        while (reader.Read())
                        {
                            dashboardData.RecentProjects.Add(new RecentProject
                            {
                                ProjectID = Convert.ToInt32(reader["ProjectID"]),
                                Title = reader["Title"].ToString(),
                                ClientName = reader["ClientName"].ToString(),
                                StartDate = Convert.ToDateTime(reader["DueDate"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                        reader.NextResult();

                        // Step 3: Read Recent Tasks
                        while (reader.Read())
                        {
                            dashboardData.RecentTasks.Add(new RecentTask
                            {
                                TaskID = Convert.ToInt32(reader["TaskID"]),
                                Title = reader["Title"].ToString(),
                                AssignedTo = reader["AssignedTo"].ToString(),
                                ProjectName = reader["ProjectName"].ToString(),
                                DueDate = Convert.ToDateTime(reader["DueDate"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                        reader.NextResult();

                        // Step 4: Read Upcoming Milestones
                        while (reader.Read())
                        {
                            dashboardData.UpcomingMilestones.Add(new UpcomingMilestone
                            {
                                MilestoneID = Convert.ToInt32(reader["MilestoneID"]),
                                ProjectName = reader["ProjectName"].ToString(),
                                Title = reader["Title"].ToString(),
                                DueDate = Convert.ToDateTime(reader["DueDate"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                        reader.NextResult();

                        // Step 5: Read Recent Users
                        while (reader.Read())
                        {
                            dashboardData.RecentUsers.Add(new RecentUser
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Role = reader["Role"].ToString(),
                                Status = reader["Status"].ToString()
                            });
                        }
                        reader.NextResult();

                        // Step 6: Read Project Count Per Month
                        while (reader.Read())
                        {
                            dashboardData.ProjectsPerMonth.Add(new ProjectPerMonth
                            {
                                MonthName = reader["MonthName"].ToString(),
                                Year = Convert.ToInt32(reader["Year"]),
                                TotalProjects = Convert.ToInt32(reader["TotalProjects"])
                            });
                        }
                        reader.NextResult();

                        // Step 7: Read Project Status Count
                        while (reader.Read())
                        {
                            dashboardData.ProjectStatusCounts.Add(new ProjectStatusCount
                            {
                                Status = reader["Status"].ToString(),
                                TotalProjects = Convert.ToInt32(reader["TotalProjects"])
                            });
                        }
                    }
                }
            }

            return dashboardData;
        }
    }
}
