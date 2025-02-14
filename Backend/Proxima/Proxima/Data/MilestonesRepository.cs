using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class MilestonesRepository
    {
        private readonly string _connectionString;

        public MilestonesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetMilestones
        public List<MilestonesModel> GetMilestones()
        {
            var milestones = new List<MilestonesModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("PR_Milestones_GetAllMileStones", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    milestones.Add(new MilestonesModel
                    {
                        MilestoneID = Convert.ToInt32(reader["MilestoneID"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        Title = reader["Title"].ToString(),
                        DueDate = Convert.ToDateTime(reader["DueDate"]),
                        Status = reader["Status"].ToString(),
                        Description = reader["Description"].ToString(),

                    });
                }
            }
            return milestones;
        }
        #endregion

        #region GetMilestoneByID
        public MilestonesModel GetMilestoneByID(int MilestoneID)
        {
            MilestonesModel milestones = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Milestones_SelectMilestoneByPK", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MilestoneID", MilestoneID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    milestones = new MilestonesModel
                    {
                        MilestoneID = Convert.ToInt32(reader["MilestoneID"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"]),
                        Title = reader["Title"].ToString(),
                        DueDate = Convert.ToDateTime(reader["DueDate"]),
                        Status = reader["Status"].ToString(),
                        Description = reader["Description"].ToString(),
                    };
                }
            }
            return milestones;
        }
        #endregion

        #region GetMilestonesByProjectID
        public List<MilestonesModel> GetMilestonesByProjectID(int ProjectID)
        {
            var milestones = new List<MilestonesModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_Milestones_GetMilestonesByProjectID";
                cmd.Parameters.AddWithValue("@ProjectID", ProjectID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    milestones.Add(new MilestonesModel
                    {
                        MilestoneID = Convert.ToInt32(reader["MilestoneID"]),   
                        Title = reader["Title"].ToString(),
                        DueDate = Convert.ToDateTime(reader["DueDate"]),
                        Status = reader["Status"].ToString(),
                        Description = reader["Description"].ToString(),
                    });
                }
            }

            return milestones;
        }
        #endregion

        #region CreateMilestones
        public bool CreateMilestones(MilestoneSaveModel milestones)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Milestone_AddMilestone", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProjectID", milestones.ProjectID);
                cmd.Parameters.AddWithValue("@Title", milestones.Title);
                cmd.Parameters.AddWithValue("@DueDate", milestones.DueDate);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region UpdateMilestone
        public bool UpdateMilestones(MilestonesModel milestones)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Milestones_UpdateMilestone", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MilestoneID", milestones.MilestoneID);
                cmd.Parameters.AddWithValue("@Title", milestones.Title);
                cmd.Parameters.AddWithValue("@Description", milestones.Description);
                cmd.Parameters.AddWithValue("@DueDate", milestones.DueDate);
                cmd.Parameters.AddWithValue("@Status", milestones.Status);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region UpdateMilestone Status
        public bool UpdateMilestoneStatus(MilestonesStatusModel milestoneStatus)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Milestones_UpdateMilestoneStatus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MilestoneID", milestoneStatus.MilestoneID);
                cmd.Parameters.AddWithValue("@Status", milestoneStatus.Status);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region DeleteMilestone
        public bool DeleteMilestone(int MilestoneID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Milestones_DeleteMilestone", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MilestoneID", MilestoneID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

    }
}
