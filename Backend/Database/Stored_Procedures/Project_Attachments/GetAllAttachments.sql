ALTER PROCEDURE [dbo].[PR_ProjectAttachments_GetAllAttachments]
AS
BEGIN
    SELECT 
        PA.AttachmentID,
		P.ProjectID,
        P.Title,
        PA.FileName,
        PA.FileType,
        PA.FilePath,
		U.UserID,
        U.Name AS UploadedByUser,
        PA.UploadedAt
    FROM ProjectAttachments PA
    INNER JOIN Projects P ON PA.ProjectID = P.ProjectID
    INNER JOIN Users U ON PA.UploadedBy = U.UserID
    ORDER BY PA.UploadedAt DESC;
END;

[PR_ProjectAttachments_GetAllAttachments]
