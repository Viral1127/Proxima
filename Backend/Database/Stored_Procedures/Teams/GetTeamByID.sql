CREATE PROCEDURE [dbo].[PR_Teams_GetTeamByID]
    @TeamID INT
AS
BEGIN
    SELECT 
        [TeamID],
        [TeamName],
        [Description],
        [CreatedAt],
        [UpdatedAt]
    FROM [dbo].[Teams]
    WHERE [TeamID] = @TeamID;
END;

[PR_Teams_GetTeamByID] 1

