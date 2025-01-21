ALTER PROCEDURE GetAllPermissions
AS
BEGIN
        SELECT 
            PermissionID,
            PermissionName
        FROM 
            Permissions
END;

GetAllPermissions