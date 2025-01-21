CREATE PROCEDURE GetAllPermissionWithRoleName
AS
BEGIN
        SELECT 
            P.PermissionID,
            P.PermissionName,
            R.RoleName
        FROM 
            Permissions P
        LEFT JOIN 
            RolePermissions RP ON P.PermissionID = RP.PermissionID
        LEFT JOIN 
            UserRoles R ON RP.RoleID = R.RoleID
        ORDER BY 
            P.PermissionName, R.RoleName;
END;

GetAllPermissionWithRoleName