CREATE PROCEDURE [dbo].[PR_Teams_CreateTeam]
    @TeamName VARCHAR(100),
    @Description VARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[Teams] ([TeamName] ,[Description],[CreatedAt])
    VALUES (@TeamName, @Description, GETDATE());

    PRINT 'Team created successfully.';
END;

EXEC [PR_Teams_CreateTeam] 
    @TeamName = 'Development Team', 
    @Description = 'Handles all development tasks';

