namespace Proxima.Models
{
    public class ProjectDetailsViewModel
    {
        public ProjectModel Project { get; set; }
        public List<TaskModel> Tasks { get; set; }

        public List<MilestoneModel> Milestones { get; set; }
    }
}
