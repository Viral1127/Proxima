CREATE PROCEDURE [dbo].[PR_Milestone_AddMilestone]
    @ProjectID INT,
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @DueDate DATE,
    @Status NVARCHAR(50)
AS
BEGIN
    INSERT INTO Milestones (ProjectID, Title, Description, DueDate, Status)
    VALUES (@ProjectID, @Title, @Description, @DueDate, @Status);

    PRINT 'Milestone added successfully.';
END;

EXEC [PR_Milestone_AddMilestone] 
    @ProjectID = 1, 
    @Title = 'Requirement Analysis', 
    @Description = 'Analyze client requirements.', 
    @DueDate = '2025-01-10', 
    @Status = 'Pending';

	select * from Milestones
	select * from Projects

