using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        
        #region GetTasks
        public List<TaskModel> GetTasks()
        {
            var tasks = new List<TaskModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("PR_Taks_GetAllTasks", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(new TaskModel
                    {
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        TaskTypeID = Convert.ToInt32(reader["TaskTypeID"]),
                        TypeName = reader["TypeName"].ToString(),
                        DueDate = Convert.ToDateTime(reader["DueDate"]),
                        Status = reader["Status"].ToString(),
                        AssignedTo = Convert.ToInt32(reader["AssignedTo"]),
                        Name = reader["Name"].ToString(),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        ProjectName = reader["ProjectName"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])

                    });
                }
                return tasks;
            }
            
        }
        #endregion

        #region GetTaskByID
        public TaskModel GetTaskByID(int TaskID)
        {
            TaskModel tasks = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_GetTaskByID", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", TaskID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tasks = new TaskModel
                    {
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        TaskTypeID = Convert.ToInt32(reader["TaskTypeID"]),
                        DueDate = Convert.ToDateTime(reader["DueDate"]),
                        Status = reader["Status"].ToString(),
                        AssignedTo = Convert.ToInt32(reader["AssignedTo"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    };
                }
            }
            return tasks;
        }
        #endregion

        #region GettasksByProjectID
        public List<TaskModel> GetTasksByProjectID(int ProjectID)
        {
            var tasks = new List<TaskModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_Tasks_GetTasksByProjectID";
                cmd.Parameters.AddWithValue("@ProjectID", ProjectID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tasks.Add(new TaskModel
                    {
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        TaskTypeID = Convert.ToInt32(reader["TaskTypeID"]),
                        DueDate = Convert.ToDateTime(reader["DueDate"]),
                        Status = reader["Status"].ToString(),
                        AssignedTo = Convert.ToInt32(reader["AssignedTo"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    });
                }
            }

            return tasks;
        }
        #endregion

        #region CreateTasks
        public bool CreateTasks(TaskSaveModel tasks)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_AddTask", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Title", tasks.Title);
                cmd.Parameters.AddWithValue("@Description", tasks.Description);
                cmd.Parameters.AddWithValue("@TaskTypeID",tasks.TaskTypeID);
                cmd.Parameters.AddWithValue("@DueDate", tasks.DueDate);
                cmd.Parameters.AddWithValue("@AssignedTo", tasks.AssignedTo);
                cmd.Parameters.AddWithValue("@ProjectID", tasks.ProjectID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region UpdateTasks
        public bool UpdateTasks(TaskModel tasks)
        {   
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_UpdateTask", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", tasks.TaskID);
                cmd.Parameters.AddWithValue("@Title", tasks.Title);
                cmd.Parameters.AddWithValue("@Description", tasks.Description);
                cmd.Parameters.AddWithValue("@TaskTypeID", tasks.TaskTypeID);
                cmd.Parameters.AddWithValue("@DueDate", tasks.DueDate);
                cmd.Parameters.AddWithValue("@Status", tasks.Status);
                cmd.Parameters.AddWithValue("@AssignedTo", tasks.AssignedTo);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion
        #region UpdateTasks
        public bool UpdateTaskStatus(TaskStatusModel taskStatus)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_UpdateTaskStatus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", taskStatus.TaskID);
                cmd.Parameters.AddWithValue("@Status", taskStatus.Status);
                
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region DeleteMilestone
        public bool DeleteTasks(int TaskID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_DeleteTask", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", TaskID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion
    }
}
