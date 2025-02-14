using System.ComponentModel.DataAnnotations;

namespace Proxima.Models
{
    public class ProjectModel
    {
        [Key]
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? ClientID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class TaskCountsDto
    {
        public int CompletedTasks { get; set; }
        public int IncompleteTasks { get; set; }
        public int OverdueTasks { get; set; }
    }

    public class ProjectUpdate
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
