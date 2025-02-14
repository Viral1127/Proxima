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

CREATE PROCEDURE [dbo].[PR_Tasks_UpdateTaskStatus]
    @TaskID INT,
    @Status VARCHAR(50) -- Must be 'In Progress', 'Under Review', 'Completed'
AS
BEGIN
    UPDATE [dbo].[Tasks]
    SET 
        [Status] = @Status,
        [UpdatedAt] = GETDATE()
    WHERE [TaskID] = @TaskID;

    PRINT 'Task status updated successfully.';
END;

[PR_Tasks_UpdateTaskStatus] 12,'Under Review'

EXEC [PR_Tasks_UpdateTask]
    @TaskID = 3,
    @Title = 'API Integration',
    @Description = 'Integrate APIs into the app.',
    @TaskTypeID = 2, -- Updated TaskTypeID
    @DueDate = '2025-02-20',
    @Status = 'Under Review', -- Updated status
    @AssignedTo = 3; -- Updated AssignedTo

	select * from Tasks
