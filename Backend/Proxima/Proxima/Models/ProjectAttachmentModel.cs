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
    public class ProjectAttachmentSave
    {
        public int ProjectID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public int UploadedBy { get; set; }
    }
    public class UpdateAttachmentModel
    {
        public int AttachmentID { get; set; }  // Unique ID of the attachment
        public string FileName { get; set; }   // Updated file name
        public string FileType { get; set; }   // Updated file type (.jpg, .pdf, etc.)
        public string FilePath { get; set; }   // Updated file storage path
    }

}
