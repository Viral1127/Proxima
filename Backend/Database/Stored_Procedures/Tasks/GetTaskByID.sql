CREATE PROCEDURE [dbo].[PR_Tasks_GetTaskByID]
    @TaskID INT
AS
BEGIN
    SELECT *
    FROM [dbo].[Tasks]
    WHERE [TaskID] = @TaskID;
END;

[PR_Tasks_GetTaskByID] 2
