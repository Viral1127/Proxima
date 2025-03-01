CREATE PROCEDURE [PR_Users_GetUserRoleCounts]
AS
BEGIN
    -- Count of Project Managers, Team Members, and Admins
    SELECT 
        UR.RoleName,
        COUNT(U.UserID) AS UserCount
    FROM Users U
    JOIN UserRoles UR ON U.RoleID = UR.RoleID
    WHERE UR.RoleName IN ('Project Manager', 'Team Member', 'Admin') -- Adjust role names if needed
    GROUP BY UR.RoleName;
    
    -- Count of Clients
    SELECT 
        'Clients' AS RoleName,
        COUNT(ClientID) AS UserCount
    FROM Clients;

    -- Count of Total Users (including all roles)
    SELECT 
        'Total Users' AS RoleName,
        COUNT(UserID) AS UserCount
    FROM Users;
END;

[PR_Users_GetUserRoleCounts]