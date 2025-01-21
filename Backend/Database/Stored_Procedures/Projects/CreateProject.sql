ALTER PROCEDURE [dbo].[PR_Projects_AddProject]
    @ClientID INT,
    @Title NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @Status VARCHAR(50),
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN

	INSERT INTO Projects (ClientID, Title, Description, Status, StartDate, EndDate, CreatedAt)
    VALUES (@ClientID, @Title, @Description, @Status, @StartDate, @EndDate, GETDATE());
	PRINT 'Project added successfully.';
END;

EXEC PR_Projects_AddProject
    @ClientID = 1,
    @Title = 'New Website',
    @Description = 'Build a new e-commerce website',
    @Status = 'Ongoing',
    @StartDate = '2025-01-10',
    @EndDate = '2025-02-15';

	select * from Projects

	select * from Clients