Alter PROCEDURE [dbo].[PR_ProjectAttachments_RemoveProjectAttachment]
    @AttachmentID INT
AS
BEGIN
    DELETE FROM ProjectAttachments WHERE AttachmentID = @AttachmentID;
END;

[PR_ProjectAttachments_RemoveProjectAttachment] 1
select * from ProjectAttachments