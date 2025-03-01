namespace Proxima.Models
{
    public class UserModel
    {
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleID { get; set; }
        public string RoleName { get; set; }
        public Boolean Status {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ProjectCount { get; set; }
        public int TaskCount { get; set; }

    }

    public class UserRoleCount
    {
        public string RoleName { get; set; }
        public int UserCount { get; set; }
    }


    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleID { get; set; }
    }
}
