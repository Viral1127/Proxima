using System.Data;
using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class TeamsRepository
    {
        private readonly string _connectionString;

        public TeamsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetTeams
        public List<TeamsModel> GetTeams()
        {
            var teams = new List<TeamsModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("PR_Teams_GetAllTeams", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    teams.Add(new TeamsModel
                    {
                        TeamID = Convert.ToInt32(reader["TeamID"]),
                        TeamName = reader["TeamName"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    });
                }
            }
            return teams;
        }
        #endregion

        #region GetTeamByID
        public TeamsModel GetTeamByID(int TeamID)
        {
            TeamsModel teams = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Teams_GetTeamByID", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TeamID", TeamID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    teams = new TeamsModel
                    {
                        TeamID = Convert.ToInt32(reader["TeamID"]),
                        TeamName = reader["TeamName"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    };
                }
            }
            return teams;
        }
        #endregion

        #region GetTeamByUserID
        public TeamsModel GetTeamByUserID(int UserID)
        {
            TeamsModel teams = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_TeamMembers_GetTeamsByUserID", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    teams = new TeamsModel
                    {
                        TeamID = Convert.ToInt32(reader["TeamID"]),
                        TeamName = reader["TeamName"].ToString(),
                    };
                }
            }
            return teams;
        }
        #endregion

        #region Create Team
        public bool CreateTeam(TeamsModel teams)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Teams_CreateTeam", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TeamName", teams.TeamName);
                cmd.Parameters.AddWithValue("Description", teams.Description);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region Update Team
        public bool UpdateTeam(TeamsModel teams)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Teams_UpdateTeam", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TeamID", teams.TeamID);
                cmd.Parameters.AddWithValue("@TeamName", teams.TeamName);
                cmd.Parameters.AddWithValue("Description", teams.Description);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region Delete Team
        public bool DeleteTeam(int TeamID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Teams_DeleteTeam", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TeamID", TeamID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region Add Team Member
        public bool AddTeamMember(TeamMemberModel teamMember)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_TeamMembers_AddTeamMember", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TeamID", teamMember.TeamID);
                cmd.Parameters.AddWithValue("@UserID", teamMember.UserID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region GetTeamMember By TeamID
        public List<TeamMemberModel> GetTeamMembersByTeamID(int TeamID)
        {
            var teamMembers = new List<TeamMemberModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_TeamMembers_GetTeamMembersByTeamID";
                cmd.Parameters.AddWithValue("@TeamID", TeamID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teamMembers.Add(new TeamMemberModel
                    {
                        UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                        UserName = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString(),
                    });
                }
            }

            return teamMembers;
        }
        #endregion

        #region Remove TeamMember
        public bool RemoveTeamMember(int TeamMemberID)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_TeamMembers_RemoveTeamMember", connection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TeamMemberID",TeamMemberID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
                
            }
        }
        #endregion
    }
}
