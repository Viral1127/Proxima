ALTER PROCEDURE [dbo].[PR_Tasks_DeleteTask]
    @TaskID INT
AS
BEGIN
    -- Remove all task assignments related to this TaskID
    DELETE FROM [dbo].[TaskAssignments] WHERE TaskID = @TaskID;

    -- Now delete the task
    DELETE FROM [dbo].[Tasks] WHERE TaskID = @TaskID;

    PRINT 'Task and all its assignments deleted successfully.';
END;


[PR_Tasks_DeleteTask] 17

select * from Tasks
select * from TaskAssignments
select * from TaskComments
select * from TaskAttachments
select * from SprintTasks
delete from TaskAttachments