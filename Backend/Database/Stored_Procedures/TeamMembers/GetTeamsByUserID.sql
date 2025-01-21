CREATE PROCEDURE [dbo].[PR_TeamMembers_GetTeamsByUserID]
    @UserID INT
AS
BEGIN
    SELECT tm.TeamID, t.TeamName
    FROM [dbo].[TeamMembers] tm
    INNER JOIN [dbo].[Teams] t ON tm.TeamID = t.TeamID
    WHERE tm.UserID = @UserID;
END;

[PR_TeamMembers_GetTeamsByUserID] 1