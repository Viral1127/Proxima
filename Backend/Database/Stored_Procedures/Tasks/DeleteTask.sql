CREATE PROCEDURE [dbo].[PR_Tasks_DeleteTask]
    @TaskID INT
AS
BEGIN
    DELETE FROM [dbo].[Tasks]
    WHERE [TaskID] = @TaskID;

    PRINT 'Task deleted successfully.';
END;

[PR_Tasks_DeleteTask] 5

select * from Tasks