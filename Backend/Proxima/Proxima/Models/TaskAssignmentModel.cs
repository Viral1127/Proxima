namespace Proxima.Models
{
    public class TaskAssignmentModel
    {
        public int AssignmentID { get; set; }
        public int TaskID { get; set; }
        public string TaskTitle { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public DateTime AssignedAt { get; set; }
    }
    public class TaskAssignmentSave
    {
        public int AssignmentID { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
    }
}
