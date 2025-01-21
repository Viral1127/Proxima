ALTER PROCEDURE [dbo].[PR_TeamMembers_RemoveTeamMember]
    @TeamMemberID INT
AS
BEGIN
    -- Check if the TeamMemberID exists
    IF NOT EXISTS (SELECT 1 FROM TeamMembers WHERE TeamMemberID = @TeamMemberID)
    BEGIN
        PRINT 'Team member does not exist.';
        RETURN;
    END

    -- Delete the record by TeamMemberID
    DELETE FROM TeamMembers
    WHERE TeamMemberID = @TeamMemberID;

    PRINT 'Team member removed successfully.';
END;

EXEC [PR_TeamMembers_RemoveTeamMember] 4
select * from TeamMembers
