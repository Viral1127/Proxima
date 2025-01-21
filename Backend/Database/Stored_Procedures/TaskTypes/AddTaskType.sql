CREATE PROCEDURE [dbo].[PR_TaskTypes_AddTaskType]
    @TypeName VARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[TaskTypes] ([TypeName])
    VALUES (@TypeName);

    PRINT 'Task type added successfully.';
END;

[PR_TaskTypes_AddTaskType] 'Logical'

select * from TaskTypes