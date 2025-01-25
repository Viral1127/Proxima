CREATE PROCEDURE [dbo].[PR_ProjectAssignments_AssignUserToProject]
    @ProjectID INT,
    @UserID INT,
    @RoleID INT -- (Project Manager, Team Member)
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM ProjectAssignments
        WHERE ProjectID = @ProjectID AND UserID = @UserID
    )
    BEGIN
        PRINT 'User is already assigned to this project.';
    END
    ELSE
    BEGIN
        INSERT INTO ProjectAssignments (ProjectID, UserID, RoleID)
        VALUES (@ProjectID, @UserID, @RoleID);

        PRINT 'User successfully assigned to the project.';
    END
END;

EXEC [PR_ProjectAssignments_AssignUserToProject] @ProjectID = 1, @UserID = 2, @RoleID = 3;

select * from ProjectAssignments

