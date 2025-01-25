ALTER PROCEDURE RegisterUser
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100),
    @RoleName NVARCHAR(50),
    @Status BIT = 1
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @RoleID INT;
        SELECT @RoleID = RoleID FROM UserRoles WHERE RoleName = @RoleName;

        IF @RoleID IS NULL
        BEGIN
            THROW 50000, 'Invalid role specified.', 1;
        END


        IF EXISTS (SELECT Email FROM Users WHERE Email = @Email)
        BEGIN
            THROW 50001, 'Email already registered.', 1;
        END

        INSERT INTO Users (Name, Email, Password, RoleID, Status)
        VALUES (@Name, @Email, @Password, @RoleID, @Status);

        COMMIT TRANSACTION;
        PRINT 'User registered successfully.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END CATCH
END;


EXEC RegisterUser 
    @Name = 'Vivek Bhoraniya', 
    @Email = 'bhoran@example.com', 
    @Password = '1234', 
    @RoleName = 'Project Manager', 
    @Status = 1;

		SELECT * FROM Users

