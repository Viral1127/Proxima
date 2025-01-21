CREATE PROCEDURE [dbo].[PR_Teams_GetAllTeams]
AS
BEGIN
    SELECT 
        [TeamID],
        [TeamName],
        [Description],
        [CreatedAt],
        [UpdatedAt]
    FROM [dbo].[Teams]
    WHERE [Description] != 'Archived';
END;


[PR_Teams_GetAllTeams]