using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class RolesRepository
    {
        private readonly string _connectionString;

        public RolesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetRoles
        public List<RolesModel> GetRoles()
        {
            var roles = new List<RolesModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("PR_UserRoles_GetAll", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add(new RolesModel
                    {
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }
            return roles;
        }
        #endregion

        #region GetRoleByID
        public RolesModel GetRoleByID(int RoleID)
        {
            RolesModel roles = null;

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_UserRoles_GetByID", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    roles = new RolesModel
                    {
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }
            }
            return roles;
        }
        #endregion

        #region CreateRole
        public bool CreateRole(RolesModel roles)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_UserRoles_AddRole", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@RoleName", roles.RoleName);
                cmd.Parameters.AddWithValue("Description", roles.Description);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region DeleteRole

        public bool DeleteRole(int RoleID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_UserRoles_DeleteRole", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion
    }
}
