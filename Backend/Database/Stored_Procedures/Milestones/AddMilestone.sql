ALTER PROCEDURE [dbo].[PR_Milestone_AddMilestone]
    @ProjectID INT,
    @Title NVARCHAR(255),
    @DueDate DATE
AS
BEGIN
    INSERT INTO Milestones (ProjectID, Title,DueDate)
    VALUES (@ProjectID, @Title, @DueDate);

    PRINT 'Milestone added successfully.';
END;

EXEC [PR_Milestone_AddMilestone] 
    @ProjectID = 1, 
    @Title = 'Requirement Analysis',
    @DueDate = '2025-01-10'

	select * from Milestones
	select * from Projects
