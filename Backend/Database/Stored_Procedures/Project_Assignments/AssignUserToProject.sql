Alter PROCEDURE [dbo].[PR_ProjectAssignments_AssignUserToProject]
    @ProjectID INT,
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

    -- Check if the user is already assigned to the project
    IF EXISTS (
        SELECT 1 FROM ProjectAssignments
        WHERE ProjectID = @ProjectID AND UserID = @UserID
    )
    BEGIN
        PRINT 'User is already assigned to this project.';
    END
    ELSE
    BEGIN
        -- Insert the assignment if the user is not already assigned
        INSERT INTO ProjectAssignments (ProjectID, UserID, RoleID)
        VALUES (@ProjectID, @UserID, @RoleID);

        PRINT 'User successfully assigned to the project.';
    END
END;


EXEC [PR_ProjectAssignments_AssignUserToProject] @ProjectID = 17, @UserID = 2;

select * from ProjectAssignments
select * from Projects
select * from Users

select * from Tasks