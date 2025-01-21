CREATE PROCEDURE [dbo].[PR_TeamMembers_AddTeamMember]
    @TeamID INT,
    @UserID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [dbo].[TeamMembers] WHERE [TeamID] = @TeamID AND [UserID] = @UserID)
    BEGIN
        PRINT 'User is already part of the team.';
        RETURN;
    END

    INSERT INTO [dbo].[TeamMembers] ([TeamID], [UserID])
    VALUES (@TeamID, @UserID);

    PRINT 'Team member added successfully.';
END;

EXEC [PR_TeamMembers_AddTeamMember] @TeamID = 1, @UserID = 3;

select * from TeamMembers