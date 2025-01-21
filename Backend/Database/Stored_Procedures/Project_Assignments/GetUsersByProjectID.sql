CREATE PROCEDURE [dbo].[PR_ProjectAssignments_GetUsersByProjectID]
    @ProjectID INT
AS
BEGIN
    SELECT 
        PA.AssignmentID,
        U.UserID,
        U.Name,
        R.RoleName,
        PA.AssignedAt
    FROM 
        ProjectAssignments PA
    INNER JOIN Users U ON PA.UserID = U.UserID
    INNER JOIN UserRoles R ON PA.RoleID = R.RoleID
    WHERE 
        PA.ProjectID = @ProjectID;
END;

EXEC [PR_ProjectAssignments_GetUsersByProjectID] @ProjectID = 2;
