using System;
using System.ComponentModel.DataAnnotations;

namespace Proxima.Models
{
    public class ProjectSave
    {
        [Key]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        [Compare(nameof(StartDate), ErrorMessage = "End Date must be after Start Date.")]
        public DateTime EndDate { get; set; }
    }
}
