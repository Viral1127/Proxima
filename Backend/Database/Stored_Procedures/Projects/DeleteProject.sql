CREATE PROCEDURE [dbo].[PR_Projects_DeleteProject]
	@ProjectID	INT
AS
BEGIN
	DELETE FROM Projects
	WHERE ProjectID = @ProjectID
	PRINT 'Project deleted successfully.';
END
select * from Projects
[PR_Projects_DeleteProject] 1021