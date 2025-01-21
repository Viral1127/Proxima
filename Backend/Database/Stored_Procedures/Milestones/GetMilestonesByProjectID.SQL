CREATE PROCEDURE [dbo].[PR_Milestones_GetMilestonesByProjectID]
    @ProjectID INT
AS
BEGIN
    SELECT 
        [MilestoneID], 
        [Title], 
        [Description], 
        [DueDate], 
        [Status]
    FROM [dbo].[Milestones]
    WHERE [ProjectID] = @ProjectID;

    PRINT 'Milestones retrieved successfully.';
END;


[PR_Milestones_GetMilestonesByProjectID] 1