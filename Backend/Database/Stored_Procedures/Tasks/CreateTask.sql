CREATE PROCEDURE [dbo].[PR_Tasks_AddTask]
	@Title VARCHAR(100),
    @Description VARCHAR(100),
    @TaskTypeID INT,
    @DueDate DATETIME,
    @AssignedTo INT,
    @ProjectID INT
AS
BEGIN
    INSERT INTO [dbo].[Tasks] ([Title], [Description], [TaskTypeID], [DueDate], [AssignedTo],[ProjectID])
    VALUES (@Title, @Description, @TaskTypeID, @DueDate, @AssignedTo, @ProjectID);

    PRINT 'Task added successfully.';
END;

select * from Tasks

EXEC [PR_Tasks_AddTask] 
    @Title = 'Develop API',
    @Description = 'Create the backend API for the application.',
    @TaskTypeID = 1, -- E.g., Bug, Feature
    @DueDate = '2025-02-15',
    @AssignedTo = 4, -- User ID of the assignee
    @ProjectID = 1; -- Project ID

