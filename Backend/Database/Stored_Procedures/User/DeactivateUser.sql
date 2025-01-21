ALTER PROCEDURE [dbo].[PR_User_DeleteUser]
    @UserID INT
AS
BEGIN
    UPDATE [dbo].[Users]
    SET [Status] = 0,
        [UpdatedAt] = GETDATE()
    WHERE [UserID] = @UserID;

    PRINT 'User deactivated successfully.';
END;

[PR_User_DeleteUser] 1

select * from Users