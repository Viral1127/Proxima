CREATE PROCEDURE [dbo].[PR_TaskTypes_UpdateTaskType]
    @TaskTypeID INT,
    @TypeName VARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[TaskTypes]
    SET [TypeName] = @TypeName
    WHERE [TaskTypeID] = @TaskTypeID;

    IF @@ROWCOUNT > 0
        PRINT 'Task type updated successfully.'
    ELSE
        PRINT 'No task type found with the given ID.';
END;

[PR_TaskTypes_UpdateTaskType] 1 ,'designn'

select * from TaskTypes