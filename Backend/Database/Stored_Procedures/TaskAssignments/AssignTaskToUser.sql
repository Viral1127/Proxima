CREATE PROCEDURE [dbo].[PR_TaskAssignments_AddTaskAssignments]	
    @TaskID INT,
    @UserID INT,
    @RoleID INT
AS
BEGIN
    INSERT INTO [dbo].[TaskAssignments] ([TaskID] ,[UserID], [RoleID])
    VALUES (@TaskID, @UserID, @RoleID);

    PRINT 'Task assigned successfully.';
END;

EXEC [PR_TaskAssignments_AddTaskAssignments] @TaskID = 2, @UserID = 3, @RoleID = 2;

select * from TaskAssignments