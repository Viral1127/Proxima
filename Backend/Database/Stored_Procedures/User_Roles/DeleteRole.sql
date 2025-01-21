CREATE PROCEDURE [dbo].[PR_UserRoles_DeleteRole]
    @RoleID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [dbo].[UserRoles] WHERE [RoleID] = @RoleID)
    BEGIN
        DELETE FROM [dbo].[UserRoles]
        WHERE [RoleID] = @RoleID;

        PRINT 'Role deleted successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Role does not exist.';
    END
END;
select * from UserRoles
[PR_UserRoles_DeleteRole] 5
