ALTER PROCEDURE [dbo].[PR_Projects_ArchiveProject]
	@ProjectID	INT
AS
BEGIN
	UPDATE [dbo].[Projects]
	SET [Status] = 'Archived'
	WHERE ProjectID = @ProjectID;

	PRINT 'Project archived successfully.';
END
SELECT * FROM Projects
EXEC [PR_Projects_ArchiveProject] @ProjectID = 1;
