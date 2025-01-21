CREATE PROCEDURE [dbo].[PR_TeamMembers_GetTeamMembersByTeamID]
    @TeamID INT
AS
BEGIN
    SELECT tm.TeamID, tm.UserID, u.Name AS UserName, u.Email
    FROM TeamMembers tm
    INNER JOIN Users u ON tm.UserID = u.UserID
    WHERE tm.TeamID = @TeamID;
END;

[PR_TeamMembers_GetTeamMembersByTeamID] 1
