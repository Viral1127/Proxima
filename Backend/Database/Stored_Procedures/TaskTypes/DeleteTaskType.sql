CREATE PROCEDURE [dbo].[PR_TaskTypes_DeleteTaskType]
    @TaskTypeID INT
AS
BEGIN
    DELETE FROM [dbo].[TaskTypes]
    WHERE [TaskTypeID] = @TaskTypeID;

    IF @@ROWCOUNT > 0
        PRINT 'Task type deleted successfully.'
    ELSE
        PRINT 'No task type found with the given ID.';
END;

[PR_TaskTypes_DeleteTaskType] 5