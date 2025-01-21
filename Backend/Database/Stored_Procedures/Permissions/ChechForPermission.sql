ALTER PROCEDURE HasPermission
    @UserID INT,
    @PermissionName NVARCHAR(100),
	@HasPermission BIT OUTPUT
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM Users U
        INNER JOIN RolePermissions RP ON U.RoleID = RP.RoleID
        INNER JOIN Permissions P ON RP.PermissionID = P.PermissionID
        WHERE U.UserID = @UserID AND P.PermissionName = @PermissionName
    )
    BEGIN
        SET @HasPermission = 1;
    END
    ELSE
    BEGIN
        SET @HasPermission = 0;
    END
END;

SELECT * FROM Users

-- Declare a variable to store the output
DECLARE @HasPermission BIT;

-- Execute the HasPermission procedure
EXEC HasPermission
    @UserID = 1,               -- Example UserID
    @PermissionName = 'AddProject', -- Example PermissionName
    @HasPermission = @HasPermission OUTPUT;

-- Check the result
SELECT @HasPermission AS PermissionStatus;

