namespace Proxima.Models
{
    public class ProjectAttachmentModel
    {
        public int AttachmentID { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public int UploadedBy { get; set; }
        public string UploadedByUser { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
