using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class ProjectAssignmentsRepository
    {
        private readonly string _connectionString;

        public ProjectAssignmentsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region AssignUserToProject
        public bool AssignUserToProject(ProjectAssignmentsModel projectAssignments)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ProjectAssignments_AssignUserToProject", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProjectID", projectAssignments.ProjectID);
                cmd.Parameters.AddWithValue("@UserID", projectAssignments.UserID);
                cmd.Parameters.AddWithValue("@RoleID", projectAssignments.RoleID);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion
        #region GetUserByProjectID
        public List<ProjectAssignmentsModel> GetUserByProjectID(int ProjectID)
        {
            var users = new List<ProjectAssignmentsModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_ProjectAssignments_GetUsersByProjectID";
                cmd.Parameters.AddWithValue("@ProjectID", ProjectID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new ProjectAssignmentsModel
                    {
                        AssignmentID = reader.GetInt32(reader.GetOrdinal("AssignmentID")),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Name = reader["Name"].ToString(),
                        RoleName = reader["RoleName"].ToString(),
                        AssignedAt = Convert.ToDateTime(reader["AssignedAt"])
                    });
                }
            }

            return users;
        }
        #endregion
        #region RemoveUserFromProject

        #endregion
    }
}
