using System.ComponentModel.DataAnnotations;

namespace Proxima.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskTypeID { get; set; }
        public string TypeName { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int AssignedTo { get; set; }
        public string Name { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public class TaskSaveModel
    {
        [Key]
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskTypeID { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedTo { get; set; }
        public int ProjectID { get; set; }
    }
    public class TaskStatusModel
    {
        [Key]
        public int TaskID { get; set; }
        public string Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
