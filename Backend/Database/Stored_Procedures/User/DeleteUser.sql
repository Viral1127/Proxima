ALTER PROCEDURE [dbo].[PR_Users_DeleteUser]
@UserID int
AS
BEGIN
	Delete from Users
	where @UserID = UserID
	PRINT ('User Deleted Successfully')
END

[PR_Users_DeleteUser] 5

select * from Users