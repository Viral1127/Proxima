alter PROCEDURE [dbo].[PR_ProjectAttachments_RemoveAttachmentsByProject]
    @ProjectID INT
AS
BEGIN
    DELETE FROM ProjectAttachments WHERE ProjectID = @ProjectID;
END;

[PR_ProjectAttachments_RemoveAttachmentsByProject] 1
