CREATE PROCEDURE [dbo].[PR_Tasks_GetTasksByProjectID]
    @ProjectID INT
AS
BEGIN
    SELECT *
    FROM [dbo].[Tasks]
    WHERE ProjectID = @ProjectID;
END;


[PR_Tasks_GetTasksByProjectID] 1