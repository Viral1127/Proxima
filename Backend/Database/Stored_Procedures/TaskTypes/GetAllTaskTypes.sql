CREATE PROCEDURE [dbo].[PR_TaskTypes_GetAllTaskTypes]
AS
BEGIN
	SELECT * FROM [dbo].[TaskTypes]
	PRINT 'Task types retrieved successfully.';
END

[PR_TaskTypes_GetAllTaskTypes]