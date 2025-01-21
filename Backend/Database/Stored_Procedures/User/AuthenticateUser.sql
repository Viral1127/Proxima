ALTER PROCEDURE AuthenticateUser
    @Email NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        IF NOT EXISTS (SELECT Email FROM Users WHERE Email = @Email)
        BEGIN
            THROW 50000, 'Invalid email or password.', 1;
        END

        DECLARE @UserID INT, @Name NVARCHAR(100), @RoleName NVARCHAR(50), @Status BIT;
        SELECT 
            @UserID = UserID,
            @Name = Name,
            @RoleName = UR.RoleName,
            @Status = Status
        FROM Users U
        JOIN UserRoles UR ON U.RoleID = UR.RoleID
        WHERE U.Email = @Email AND U.Password = @Password;

        IF @UserID IS NULL
        BEGIN
            THROW 50001, 'Invalid email or password.', 1;
        END

        IF @Status = 0
        BEGIN
            THROW 50002, 'Your account is inactive. Please contact admin.', 1;
        END

        SELECT 
            @UserID AS UserID,
            @Name AS Name,
            @Email AS Email,
            @RoleName AS Role,
            @Status AS Status;

        PRINT 'Login successful.';
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END;

EXEC AuthenticateUser 'bhoran@example.com' ,'12'

SELECT * FROM Users




