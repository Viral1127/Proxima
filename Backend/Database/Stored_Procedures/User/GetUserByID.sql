CREATE PROCEDURE [dbo].[PR_User_GetUserByID]
    @UserID INT
AS
BEGIN
    SELECT [UserID], [Name], [Email], [RoleID], [Status], [CreatedAt], [UpdatedAt]
    FROM [dbo].[Users]
    WHERE [UserID] = @UserID;
END;

[PR_User_GetUserByID] 2