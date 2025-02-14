namespace Proxima.Models
{
    public class MilestonesModel
    {
        public int MilestoneID { get; set; }
        public int ProjectID { get; set; }
        public string Title{ get; set; }
        public DateTime DueDate{ get; set; }
        public string Status { get; set; }
        public string Description{ get; set; }
    }

    public class MilestonesStatusModel
    {
        public int MilestoneID { get; set; }
        public string Status { get; set; }
    }

    public class MilestoneSaveModel
    {
        public int MilestoneID { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }
}
