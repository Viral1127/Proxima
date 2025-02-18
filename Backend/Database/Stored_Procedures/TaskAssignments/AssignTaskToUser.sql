Alter PROCEDURE [dbo].[PR_TaskAssignments_AddTaskAssignments]	
    @TaskID INT,
    @UserID INT
AS
BEGIN
    DECLARE @RoleID INT;

    -- Fetch the RoleID for the UserID
    SELECT @RoleID = RoleID FROM Users WHERE UserID = @UserID;

    -- Check if RoleID is found for the User
    IF @RoleID IS NULL
    BEGIN
        PRINT 'User does not have an assigned role.';
        RETURN;
    END

    -- Check if the user is already assigned to the task
    IF EXISTS (
        SELECT 1 FROM TaskAssignments
        WHERE TaskID = @TaskID AND UserID = @UserID
    )
    BEGIN
        PRINT 'User is already assigned to this task.';
    END
    ELSE
    BEGIN
        -- Insert the assignment if the user is not already assigned
        INSERT INTO TaskAssignments (TaskID, UserID, RoleID)
        VALUES (@TaskID, @UserID, @RoleID);

        PRINT 'User successfully assigned to the task.';
    END
END;

EXEC [PR_TaskAssignments_AddTaskAssignments] @TaskID = 2, @UserID = 6;
select * from Tasks
select * from TaskAssignments