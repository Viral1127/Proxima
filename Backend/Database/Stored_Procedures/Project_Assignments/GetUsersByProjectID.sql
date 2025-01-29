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


Alter PROCEDURE [dbo].[PR_ProjectAssignments_GetProjectsByUserID]
    @UserID INT
AS
BEGIN
    SELECT
		U.Name,
        P.ProjectID,
        P.Title,
        PA.AssignmentID,
        R.RoleName,
        PA.AssignedAt
    FROM 
        ProjectAssignments PA
    INNER JOIN Projects P ON PA.ProjectID = P.ProjectID
    INNER JOIN UserRoles R ON PA.RoleID = R.RoleID
	Inner Join Users U ON PA.UserID = U.UserID
    WHERE 
        PA.UserID = @UserID;
END;

[PR_ProjectAssignments_GetProjectsByUserID] 1


