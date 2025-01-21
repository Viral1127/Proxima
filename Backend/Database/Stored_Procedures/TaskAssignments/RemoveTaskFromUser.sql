CREATE PROCEDURE [dbo].[PR_TaskAssignments_DeleteTaskAssignment]
    @AssignmentID INT
AS
BEGIN
    DELETE FROM TaskAssignments
    WHERE AssignmentID = @AssignmentID;

    PRINT 'Task assignment deleted successfully.';
END;

[PR_TaskAssignments_DeleteTaskAssignment] 3