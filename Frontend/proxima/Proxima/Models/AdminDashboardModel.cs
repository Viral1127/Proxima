namespace Proxima.Models
{
    public class DashboardCount
    {
        public string Metric { get; set; }
        public int Value { get; set; }
    }

    public class RecentProject
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
    }

    public class RecentTask
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string AssignedTo { get; set; }
        public string ProjectName { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }

    public class UpcomingMilestone
    {
        public int MilestoneID { get; set; }
        public string ProjectName { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }

    public class RecentUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }

    public class ProjectPerMonth
    {
        public string MonthName { get; set; }
        public int Year { get; set; }
        public int TotalProjects { get; set; }
    }

    public class ProjectStatusCount
    {
        public string Status { get; set; }
        public int TotalProjects { get; set; }
    }

    public class AdminDashboardData
    {
        public List<DashboardCount> Counts { get; set; }
        public List<RecentProject> RecentProjects { get; set; }
        public List<RecentTask> RecentTasks { get; set; }
        public List<UpcomingMilestone> UpcomingMilestones { get; set; }
        public List<RecentUser> RecentUsers { get; set; }
        public List<ProjectPerMonth> ProjectsPerMonth { get; set; }
        public List<ProjectStatusCount> ProjectStatusCounts { get; set; }
    }

}
