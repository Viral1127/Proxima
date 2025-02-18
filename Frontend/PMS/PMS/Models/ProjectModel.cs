using System.ComponentModel.DataAnnotations;

namespace PMS.Models
{
    public class ProjectModel
    {
        [Key]
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; }
    }
}
