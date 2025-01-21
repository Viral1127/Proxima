CREATE PROCEDURE [dbo].[PR_Tasks_UpdateTask]
    @TaskID INT,
    @Title VARCHAR(100),
    @Description VARCHAR(100),
    @TaskTypeID INT,
    @DueDate DATETIME,
    @Status VARCHAR(50), -- Must be 'In Progress', 'Under Review', 'Completed'
    @AssignedTo INT
AS
BEGIN
    UPDATE [dbo].[Tasks]
    SET 
        [Title] = @Title,
        [Description] = @Description,
        [TaskTypeID] = @TaskTypeID,
        [DueDate] = @DueDate,
        [Status] = @Status,
        [AssignedTo] = @AssignedTo,
        [UpdatedAt] = GETDATE()
    WHERE [TaskID] = @TaskID;

    PRINT 'Task updated successfully.';
END;

EXEC [PR_Tasks_UpdateTask]
    @TaskID = 5,
    @Title = 'Update API Documentation',
    @Description = 'Revise and complete the API documentation.',
    @TaskTypeID = 2, -- Updated TaskTypeID
    @DueDate = '2025-02-20',
    @Status = 'Under Review', -- Updated status
    @AssignedTo = 3; -- Updated AssignedTo

	select * from Tasks
