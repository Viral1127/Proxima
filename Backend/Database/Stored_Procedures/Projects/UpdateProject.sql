ALTER PROCEDURE [PR_Projects_UpdateProject]
    @ProjectID INT,
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @StartDate DATE,
    @EndDate DATE,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Projects]
    SET 
        [Title] = @Title,
        [Description] = @Description,
        [StartDate] = @StartDate,
        [EndDate] = @EndDate,
        [Status] = @Status,
		[UpdatedAt] = GETDATE()
    WHERE [ProjectID] = @ProjectID;

    PRINT 'Project updated successfully.';
END;

select * from Projects

EXEC [PR_Projects_UpdateProject] 
    @ProjectID = 1, 
    @Title = 'Updated Website Redesign', 
    @Description = 'Update description.',
    @StartDate = '2024-01-15', 
    @EndDate = '2024-06-01', 
    @Status = 'Ongoing';
