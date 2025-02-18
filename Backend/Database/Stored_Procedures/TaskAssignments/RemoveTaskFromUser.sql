Alter PROCEDURE [dbo].[PR_TaskAssignments_DeleteTaskAssignment]
    @TaskID INT,
    @UserID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM [dbo].TaskAssignments
        WHERE TaskID = @TaskID AND [UserID] = @UserID
    )
    BEGIN
        DELETE FROM TaskAssignments
        WHERE TaskID = @TaskID AND [UserID] = @UserID;

        PRINT 'User successfully removed from the task.';
    END
    ELSE
    BEGIN
        PRINT 'User is not assigned to this task.';
    END
END;
select * from TaskAssignments
[PR_TaskAssignments_DeleteTaskAssignment] 32 , 1