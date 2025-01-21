CREATE PROCEDURE [dbo].[PR_Milestones_UpdateMilestone]
    @MilestoneID INT,
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @DueDate DATE,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Milestones]
    SET 
        [Title] = @Title,
        [Description] = @Description,
        [DueDate] = @DueDate,
        [Status] = @Status
    WHERE [MilestoneID] = @MilestoneID;

    PRINT 'Milestone updated successfully.';
END;

EXEC [PR_Milestones_UpdateMilestone] 
    @MilestoneID = 4, 
    @Title = 'Revised Requirement Analysis', 
    @Description = 'Update analysis after client feedback.', 
    @DueDate = '2025-01-15', 
    @Status = 'Achieved';

	select * from Milestones
