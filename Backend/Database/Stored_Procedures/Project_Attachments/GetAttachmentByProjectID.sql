Alter PROCEDURE [dbo].[PR_ProjectAttachments_GetAttachmentsByProject]
    @ProjectID INT
AS
BEGIN
    SELECT 
        pa.AttachmentID,
		pa.ProjectID,
		p.Title,
        pa.FileName,
        pa.FilePath,
        pa.FileType,
        pa.UploadedAt,
		u.UserID,
		 u.[Name] AS UploadedBy
    FROM ProjectAttachments pa
    JOIN Users u ON pa.UploadedBy = u.UserID
	join Projects p ON p.ProjectID = pa.ProjectID
    WHERE pa.ProjectID = @ProjectID;
END;

[PR_ProjectAttachments_GetAttachmentsByProject] 17