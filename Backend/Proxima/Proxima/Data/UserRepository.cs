using System.Data;
using System.Reflection.Metadata;
using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetUsers
        public List<UserModel> GetUsers()
        {
            var users = new List<UserModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_Users_GetAllUsers";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserModel
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Status = Convert.ToBoolean(reader["Status"]),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    });
                }
                return users;

            }
        }
        #endregion

        #region GetUserByID
        public UserModel GetUserByID(int UserID)
        {
            UserModel user = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_User_GetUserByID";
                cmd.Parameters.AddWithValue("@UserID", UserID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new UserModel
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Status = Convert.ToBoolean(reader["Status"]),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedAt"])
                    };
                }
            }

            return user;
        }
        #endregion

        #region GetUserByRole

        public List<UserModel> GetUserByRole(int RoleID)
        {
            var users = new List<UserModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_UserRoles_GetUsersByRole";
                cmd.Parameters.AddWithValue("@RoleID", RoleID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserModel
                    {
                        UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                    });
                }
            }

            return users;
        }
        #endregion

        #region UpdateUser

        public bool UpdateUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_User_UpdateUser";

                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@RoleID", user.RoleID);
                cmd.Parameters.AddWithValue("@Status", user.Status);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        #endregion

        #region DeactivateUser

        public bool DeactivateUser(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_User_DeleteUser";

                cmd.Parameters.AddWithValue("@UserID", UserID);
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;


            }
        }
        #endregion

        #region DeleteUser

        public bool DeleteUser(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_Users_DeleteUser";
                cmd.Parameters.AddWithValue("@UserID", UserID);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

    }
}
