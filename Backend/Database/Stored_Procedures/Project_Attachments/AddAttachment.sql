CREATE PROCEDURE [dbo].[PR_ProjectAttachments_InsertProjectAttachment]
    @FileName NVARCHAR(255),
    @FilePath NVARCHAR(500),
    @FileType NVARCHAR(100),
    @ProjectID INT,
    @UploadedBy INT
AS
BEGIN
    INSERT INTO [dbo].[ProjectAttachments]([FileName], FilePath, FileType, ProjectID, UploadedBy)
    VALUES (@FileName, @FilePath, @FileType, @ProjectID, @UploadedBy);
END;

EXEC [PR_ProjectAttachments_InsertProjectAttachment] 'logo.png', '/uploads/logo.png', 'image/png', 1, 2;
select * from ProjectAttachments