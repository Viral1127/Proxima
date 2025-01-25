ALTER PROCEDURE [dbo].[PR_User_UpdateUser]
    @UserID INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(256) = NULL, -- Optional update
    @RoleID INT = NULL,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Users]
    SET [Name] = @Name,
        [Email] = @Email,
        [Password] = ISNULL(@Password, Password), -- Only update if provided
        [RoleID] = ISNULL(@RoleID,RoleID),
        [Status] = @Status,
        [UpdatedAt] = GETDATE()
    WHERE [UserID] = @UserID;

    PRINT 'User details updated successfully.';
END;

EXEC [PR_User_UpdateUser] 
    @UserID = 2,
    @Name = 'Viral chauhan',
    @Email = 'vc@example.com',
    @Status = 1;

select * from Users

