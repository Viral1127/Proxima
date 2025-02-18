ALTER PROCEDURE [dbo].[PR_Tasks_AddTask]
    @Title VARCHAR(100),
    @Description VARCHAR(100),
    @TaskTypeID INT,
    @DueDate DATETIME,
    @AssignedTo INT,
    @ProjectID INT
AS
BEGIN
    DECLARE @TaskID INT;
    DECLARE @RoleID INT;

    -- Fetch RoleID for the Assigned User
    SELECT @RoleID = RoleID FROM Users WHERE UserID = @AssignedTo;

    -- Ensure RoleID is found before proceeding
    IF @RoleID IS NULL
    BEGIN
        PRINT 'User does not have an assigned role.';
        RETURN;
    END

    -- Insert task into Tasks table
    INSERT INTO [dbo].[Tasks] ([Title], [Description], [TaskTypeID], [DueDate], [AssignedTo], [ProjectID])
    VALUES (@Title, @Description, @TaskTypeID, @DueDate, @AssignedTo, @ProjectID);

    -- Retrieve the newly generated TaskID
    SET @TaskID = SCOPE_IDENTITY();

    -- Insert into TaskAssignments table with RoleID
    INSERT INTO [dbo].[TaskAssignments] (TaskID, UserID, RoleID)
    VALUES (@TaskID, @AssignedTo, @RoleID);

    PRINT 'Task added and user assigned successfully.';
END;






select * from Tasks

EXEC [PR_Tasks_AddTask] 
    @Title = 'Develop API',
    @Description = 'Create the backend API for the application.',
    @TaskTypeID = 1, -- E.g., Bug, Feature
    @DueDate = '2025-02-15',
    @AssignedTo = 1, -- User ID of the assignee
    @ProjectID = 1; -- Project ID

select * from TaskAssignments
