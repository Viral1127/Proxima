CREATE PROCEDURE [dbo].[PR_ProjectAssignments_RemoveUserFromProject]
    @ProjectID INT,
    @UserID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM [dbo].[ProjectAssignments]
        WHERE [ProjectID] = @ProjectID AND [UserID] = @UserID
    )
    BEGIN
        DELETE FROM ProjectAssignments
        WHERE [ProjectID] = @ProjectID AND [UserID] = @UserID;

        PRINT 'User successfully removed from the project.';
    END
    ELSE
    BEGIN
        PRINT 'User is not assigned to this project.';
    END
END;

EXEC [PR_ProjectAssignments_RemoveUserFromProject] @ProjectID = 1, @UserID = 2;
