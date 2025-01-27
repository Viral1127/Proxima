ALTER PROCEDURE [dbo].[PR_Users_GetAllUsers]
AS
BEGIN
	SELECT	[UserID],
			[Name],
			[Email],
			[Password],
			UserRoles.RoleID,
			[UserRoles].RoleName,
			[Status],
			CreatedAt,
			UpdatedAt

	FROM Users
	join UserRoles
	on UserRoles.RoleID = Users.RoleID
END

[PR_Users_GetAllUsers]