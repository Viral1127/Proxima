
namespace Proxima.Models
{
    public class ProjectAssignmentsModel
    {
        public int AssignmentID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public DateTime AssignedAt { get; set; }

    }
    public class ProjectAssignmentSave
    {
        public int AssignmentID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
    }
}
