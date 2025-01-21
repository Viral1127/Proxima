CREATE PROCEDURE [dbo].[PR_Teams_DeleteTeam]
    @TeamID INT
AS
BEGIN
    DELETE FROM Teams
    WHERE TeamID = @TeamID;

    PRINT 'Team deleted successfully.';
END;

[PR_Teams_DeleteTeam] 2

select * from Teams