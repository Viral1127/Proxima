using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proxima.Models;

namespace Proxima.Data
{
    public class ProjectRepository
    {
        private readonly string _connectionString;
        private readonly ApplicationDbContext _context;

        public ProjectRepository(IConfiguration configuration,ApplicationDbContext context)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
            _context = context;
        }

        #region GetAllProjects

        public List<ProjectModel> GetProjects() { 
            var projects = new List<ProjectModel>();
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Projects_GetAllProjects", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projects.Add(new ProjectModel
                    {
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                        ClientID = reader["ClientID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ClientID"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        Status = reader["Status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    });
                }
                return projects;
            }
        }

        #endregion

        #region GetProjectByUserID
        public List<ProjectModel> GetProjectByUserID(int? UserID)
        {
            var projects = new List<ProjectModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Projects_GetProjectsByUserID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(new ProjectModel
                            {
                                ProjectID = reader["ProjectID"] != DBNull.Value ? Convert.ToInt32(reader["ProjectID"]) : 0,
                                Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                                ClientID = reader["ClientID"] != DBNull.Value ? Convert.ToInt32(reader["ClientID"]) : 0,
                                StartDate = (DateTime)(reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : (DateTime?)null),
                                EndDate = (DateTime)(reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : (DateTime?)null),
                                Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Unknown",
                                CreatedAt = reader["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedAt"]) : DateTime.MinValue,
                                UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedAt"]) : (DateTime?)null
                            });
                        }
                    }
                }
            }

            return projects;
        }

        #endregion

        #region GetProjectByID
        public ProjectModel GetProjectByID(int ProjectID)
        {
            ProjectModel projects = null;
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Projects_SelectByPK", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProjectID",ProjectID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    projects = new ProjectModel
                    {
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                        ClientID = reader["ClientID"] != DBNull.Value ? Convert.ToInt32(reader["ClientID"]) : 0,
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        Status = reader["Status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    };
                }

            }
            return projects;
        }
        #endregion

        #region GetProjectByClientID
        public List<ProjectModel> GetProjectByClientID(int ClientID)
        {
            var projects = new List<ProjectModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_Projects_GetProjectsByClientID";
                cmd.Parameters.AddWithValue("@ClientID", ClientID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projects.Add(new ProjectModel
                    {
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        ClientID = Convert.ToInt32(reader["ClientID"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        Status = reader["Status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    });
                }
            }

            return projects;
        }
        #endregion

        #region CreateProject
        public bool CreateProject(ProjectSave project)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Projects_AddProject", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Title", project.Title);
                cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                cmd.Parameters.AddWithValue("@EndDate",project.EndDate); 
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region UpdateProject
        public bool UpdateProject(ProjectUpdate project)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Projects_UpdateProject", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProjectID", project.ProjectID);
                cmd.Parameters.AddWithValue("@Title", project.Title);
                cmd.Parameters.AddWithValue("@Description", project.Description);
                cmd.Parameters.AddWithValue("@Status", project.Status);
                cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", project.EndDate);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;    
            }
        }
        #endregion

        #region ArchiveProject

        public bool ArchiveProject(int ProjectID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Projects_ArchiveProject", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        #endregion

        public async Task<TaskCountsDto> GetTaskCountsAsync(int projectId)
        {

            var taskCounts = await _context.Tasks
                .Where(t => t.ProjectID == projectId)
                .GroupBy(t => t.ProjectID)
                .Select(g => new TaskCountsDto
                {
                    CompletedTasks = g.Count(t => t.Status == "Completed"),
                    IncompleteTasks = g.Count(t => t.Status != "Completed"),
                    OverdueTasks = g.Count(t => t.DueDate < DateTime.Now && t.Status != "Completed")
                })
                .FirstOrDefaultAsync();

            return taskCounts ?? new TaskCountsDto();
        }

    }
}
