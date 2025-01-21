CREATE PROCEDURE [dbo].[PR_UserRoles_AddRole]
    @RoleName NVARCHAR(50),
    @Description NVARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM UserRoles WHERE [RoleName] = @RoleName)
    BEGIN
        PRINT 'Role already exists. Cannot add duplicate roles.';
        RETURN;
    END

    INSERT INTO UserRoles(RoleName, Description)
    VALUES (@RoleName, @Description);

    PRINT 'Role added successfully.';
END;

EXEC [PR_UserRoles_AddRole] 
    @RoleName = 'HR', 
    @Description = 'Manages project deliverables and milestones.';



