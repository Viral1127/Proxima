using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class TaskTypeRepository
    {
        private readonly string _connectionString;

        public TaskTypeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetTaskTypes
        public List<TaskTypeModel> GetTaskTypes()
        {
            var taskTypes = new List<TaskTypeModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("PR_TaskTypes_GetAllTaskTypes", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    taskTypes.Add(new TaskTypeModel
                    {
                        TaskTypeID = Convert.ToInt32(reader["TaskTypeID"]),
                        TypeName = reader["TypeName"].ToString()
                    });
                }
            }
            return taskTypes;
        }
        #endregion

        #region AddTaskType
        public bool AddTaskType(TaskTypeModel taskType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_TaskTypes_AddTaskType", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                
                cmd.Parameters.AddWithValue("@TypeName", taskType.TypeName);
                
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region UpdateTaskType
        public bool UpdateTaskType(TaskTypeModel taskType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_TaskTypes_UpdateTaskType", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskTypeID", taskType.TaskTypeID);
                cmd.Parameters.AddWithValue("@TypeName", taskType.TypeName);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region DeleteTaskType
        public bool DeleteTaskType(int TaskTypeID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_TaskTypes_DeleteTaskType", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskTypeID", TaskTypeID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion
    }
}
