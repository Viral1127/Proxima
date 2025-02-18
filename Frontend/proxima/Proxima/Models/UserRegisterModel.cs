using System.ComponentModel.DataAnnotations;

namespace Proxima.Models
{
    public class UserRegisterModel
    {
        public int? UserID { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

    }
}
