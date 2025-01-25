namespace Proxima.Models
{
    public class TeamsModel
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int UserID { get; set; }
    }

    public class TeamMemberModel
    {
        public int TeamMemberID { get; set; }
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public int TeamID { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}