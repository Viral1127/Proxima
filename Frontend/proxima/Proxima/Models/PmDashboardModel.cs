namespace Proxima.Models
{
    public class PmDashboardModel
    {
        public class PmDashboardCount
        {
            public string Metric { get; set; }
            public int Value { get; set; }
        }

        public class AssignedProjects
        {
            public int ProjectID { get; set; }
            public string Title { get; set; }
            public string ClientName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Status { get; set; }
            public DateTime AssignedAt { get; set; }
        }

        public class AssignedTasks
        {
            public int TaskID { get; set; }
            public string Title { get; set; }
            public string ProjectName { get; set; }
            public DateTime DueDate { get; set; }
            public string Status { get; set; }
            public DateTime AssignedAt { get; set; }
        }

        public class PmDashboardData
        {
            public List<PmDashboardCount> Counts { get; set; }
            public List<AssignedProjects> RecentProjects { get; set; }
            public List<AssignedTasks> RecentTasks { get; set; }
        }
    }
}
