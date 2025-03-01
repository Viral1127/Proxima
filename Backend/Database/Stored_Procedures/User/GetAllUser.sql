ALTER PROCEDURE [dbo].[PR_Users_GetAllUsers]
AS
BEGIN
    SELECT 
        U.[UserID],
        U.[Name],
        U.[Email],
        U.[Password],
        UR.[RoleID],
        UR.[RoleName],
        U.[Status],
        U.[CreatedAt],
        U.[UpdatedAt],
        (SELECT COUNT(*) FROM ProjectAssignments PA WHERE PA.UserID = U.UserID) AS ProjectCount,
        (SELECT COUNT(*) FROM TaskAssignments TA WHERE TA.UserID = U.UserID) AS TaskCount
    FROM Users U
    JOIN UserRoles UR ON UR.RoleID = U.RoleID;
END;


[PR_Users_GetAllUsers]