ALTER PROCEDURE [dbo].[PR_User_GetUserByID]
    @UserID INT
AS
BEGIN
    SELECT [UserID], [Name], [Email], UserRoles.[RoleID],UserRoles.RoleName, [Status], [CreatedAt], [UpdatedAt]
    FROM [dbo].[Users]
	join UserRoles
	on UserRoles.RoleID = Users.RoleID
    WHERE [UserID] = @UserID;
END;

[PR_User_GetUserByID] 2