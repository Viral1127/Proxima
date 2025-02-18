Alter PROCEDURE [dbo].[PR_ProjectAttachments_EditProjectAttachment]
    @AttachmentID INT,
    @FileName NVARCHAR(255),
    @FileType NVARCHAR(100),
	@FilePath NVARCHAR(500)
AS
BEGIN
    UPDATE [dbo].[ProjectAttachments]
    SET 
        [FileName] = @FileName,
        FileType = @FileType,
		FilePath = @FilePath,
        UploadedAt = GETDATE()
    WHERE AttachmentID = @AttachmentID;
END
select * from ProjectAttachments
EXEC [PR_ProjectAttachments_EditProjectAttachment] @AttachmentID = 3, @FileName = 'new_logo.png', @FileType = 'image/png',@FilePath='/uploads/img.png';

