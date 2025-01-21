ALTER PROCEDURE [dbo].[PR_Milestones_DeleteMilestone]
    @MilestoneID INT
AS
BEGIN
    UPDATE [dbo].[Milestones]
    SET [Status] = 'Achieved'
    WHERE [MilestoneID] = @MilestoneID

    PRINT 'Milestone archived successfully.';
END;

EXEC [PR_Milestones_DeleteMilestone] @MilestoneID = 1;

select * from Milestones