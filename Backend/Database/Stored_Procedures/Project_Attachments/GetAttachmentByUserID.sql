CREATE PROCEDURE [dbo].[PR_ProjectAttachments_GetAttachmentsByUser]
    @UserID INT
AS
BEGIN
    SELECT 
        pa.AttachmentID,
        pa.FileName,
        pa.FilePath,
        pa.FileType,
        pa.UploadedAt,
        p.Title
    FROM ProjectAttachments pa
    JOIN Projects p ON pa.ProjectID = p.ProjectID
    WHERE pa.UploadedBy = @UserID;
END;

[PR_ProjectAttachments_GetAttachmentsByUser] 2
