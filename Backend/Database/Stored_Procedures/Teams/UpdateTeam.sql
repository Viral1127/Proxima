CREATE PROCEDURE [dbo].[PR_Teams_UpdateTeam]
    @TeamID INT,
    @TeamName VARCHAR(100),
    @Description VARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[Teams]
    SET 
        [TeamName] = @TeamName,
        [Description] = @Description,
        [UpdatedAt] = GETDATE()
    WHERE [TeamID] = @TeamID;

    PRINT 'Team updated successfully.';
END;

EXEC [PR_Teams_UpdateTeam]
    @TeamID = 1, 
    @TeamName = 'QA Team', 
    @Description = 'Handles quality assurance tasks';

	select * from Teams
