CREATE PROCEDURE [dbo].[PR_UserRoles_GetUsersByRole]
    @RoleID INT
AS
BEGIN
    SELECT U.UserID, U.[Name], U.Email
    FROM [dbo].[Users] U
    WHERE U.RoleID = @RoleID;
END;

[PR_UserRoles_GetUsersByRole] 3
