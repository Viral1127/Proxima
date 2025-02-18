ALTER PROCEDURE RegisterUser
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100),
    @RoleID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF @RoleID IS NULL
        BEGIN
            THROW 50000, 'Invalid role specified.', 1;
        END


        IF EXISTS (SELECT Email FROM Users WHERE Email = @Email)
        BEGIN
            THROW 50001, 'Email already registered.', 1;
        END

        INSERT INTO Users (Name, Email, Password, RoleID)
        VALUES (@Name, @Email, @Password, @RoleID);

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
    @Email = 'bhora@example.com', 
    @Password = '1234', 
    @RoleID = 1

		SELECT * FROM Users

