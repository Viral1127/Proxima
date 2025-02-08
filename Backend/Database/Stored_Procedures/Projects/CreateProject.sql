ALTER PROCEDURE [dbo].[PR_Projects_AddProject]
    @Title NVARCHAR(100),
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN

	INSERT INTO Projects (Title, StartDate, EndDate, CreatedAt)
    VALUES (@Title,@StartDate, @EndDate, GETDATE());
	PRINT 'Project added successfully.';
END;

EXEC PR_Projects_AddProject
    @Title = 'New vc',
    @StartDate = '2025-01-10',
    @EndDate = '2025-02-15';

	select * from Projects

	select * from Clients