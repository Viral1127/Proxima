using System.Data;
using Microsoft.Data.SqlClient;
using Proxima.Models;

namespace Proxima.Data
{
    public class AuthRepository
    {
        private readonly string _connectionString;

        public AuthRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region Registration
        public bool Register(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RegisterUser";
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@RoleName", user.RoleName);
                cmd.Parameters.AddWithValue("@Status", user.Status);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        #endregion

        #region AuthenticateUser
        public UserModel AuthenticateUser(string Email, string Password)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AuthenticateUser";

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new UserModel
                        {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            RoleName = reader.GetString(reader.GetOrdinal("Role")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status"))
                        };
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 50000 || ex.Number == 50001 || ex.Number == 50002)
                    {
                        throw new Exception(ex.Message);
                    }
                    throw;
                }
            }
            return null;
        }
        #endregion

    }

}
