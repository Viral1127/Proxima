using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class TaskAssignmentRepository
    {
        private readonly string _connectionString;

        public TaskAssignmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region AssignTaskToUser
        public bool AssignTaskToUser(TaskAssignmentSave taskAssignment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_TaskAssignments_AddTaskAssignments", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", taskAssignment.TaskID);
                cmd.Parameters.AddWithValue("@UserID", taskAssignment.UserID);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region GetTaskAssignmentsByTaskID
        public List<TaskAssignmentModel> GetTaskAssignmentsByTaskID(int TaskID)
        {
            var assignments  = new List<TaskAssignmentModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_TaskAssignments_GetTaskAssignmentsByTaskID";
                cmd.Parameters.AddWithValue("@TaskID", TaskID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    assignments.Add(new TaskAssignmentModel
                    {
                        AssignmentID = reader.GetInt32(reader.GetOrdinal("AssignmentID")),
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        TaskTitle = reader["TaskTitle"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = reader["UserName"].ToString(),
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        AssignedAt = Convert.ToDateTime(reader["AssignedAt"])
                    });
                }
                return assignments;
            }   
        }
        #endregion

        #region GetTaskAssignmentsByUserID
        public List<TaskAssignmentModel> GetTaskAssignmentsByUserID(int UserID)
        {
            var assignments = new List<TaskAssignmentModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_TaskAssignments_GetTaskAssignmentsByUserID";
                cmd.Parameters.AddWithValue("@UserID", UserID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    assignments.Add(new TaskAssignmentModel
                    {
                        AssignmentID = reader.GetInt32(reader.GetOrdinal("AssignmentID")),
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        TaskTitle = reader["TaskTitle"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = reader["UserName"].ToString(),
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        AssignedAt = Convert.ToDateTime(reader["AssignedAt"])
                    });
                }
                return assignments;
            }
        }
        #endregion

        #region RemoveTaskFromUser
        public bool DeleteTaskAssignments(int TaskID, int UserID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("PR_TaskAssignments_DeleteTaskAssignment", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@TaskID", TaskID));
                    command.Parameters.Add(new SqlParameter("@UserID", UserID));

                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }
        #endregion  
    }
}
