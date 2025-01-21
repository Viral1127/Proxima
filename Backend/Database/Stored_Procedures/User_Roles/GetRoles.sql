select * from UserRoles

-----------------------------Get All User Roles-----------------------

CREATE PROCEDURE [Dbo].[PR_UserRoles_GetAll]
AS
BEGIN
	SELECT * FROM [Dbo].[UserRoles]
END

exec [PR_UserRoles_GetAll]

------------------------------Get UserRole by ID-----------------------

CREATE PROCEDURE [Dbo].[PR_UserRoles_GetByID]
@roleID int
AS
BEGIN
	SELECT * FROM [dbo].[UserRoles]
	WHERE @roleID = RoleID
END

EXEC [PR_UserRoles_GetByID] 1