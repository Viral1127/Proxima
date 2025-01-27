using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class ProjectRepository
    {
        private readonly string _connectionString;

        public ProjectRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
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
                        Description = reader["Description"].ToString(),
                        ClientID = Convert.ToInt32(reader["ClientID"]),
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
                        Description = reader["Description"].ToString(),
                        ClientID = Convert.ToInt32(reader["ClientID"]),
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
        public bool CreateProject(ProjectModel project)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Projects_AddProject", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ClientID", project.ClientID);
                cmd.Parameters.AddWithValue("@Title", project.Title);
                cmd.Parameters.AddWithValue("@Description", project.Description);
                cmd.Parameters.AddWithValue("@Status", project.Status);
                cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                cmd.Parameters.AddWithValue("@EndDate",project.EndDate); 
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region UpdateProject
        public bool UpdateProject(ProjectModel project)
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
    }
}
