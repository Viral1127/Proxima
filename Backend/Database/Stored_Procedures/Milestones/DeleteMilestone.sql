ALTER PROCEDURE [dbo].[PR_Milestones_DeleteMilestone]
    @MilestoneID INT
AS
BEGIN
    DELETE FROM Milestones
    WHERE [MilestoneID] = @MilestoneID

    PRINT 'Milestone deleted successfully.';
END;

EXEC [PR_Milestones_DeleteMilestone] @MilestoneID = 2;

select * from Milestones