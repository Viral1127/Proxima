CREATE PROCEDURE [dbo].[PR_Milestones_SelectMilestoneByPK]
    @MilestoneID INT
AS
BEGIN
    SELECT 
        [MilestoneID], 
        [ProjectID],
        [Title], 
        [Description], 
        [DueDate], 
        [Status]
    FROM [dbo].[Milestones]
    WHERE [MilestoneID] = @MilestoneID;

    PRINT 'Milestone details retrieved successfully.';
END;

[PR_Milestones_SelectMilestoneByPK] 4
