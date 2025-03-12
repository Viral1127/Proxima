Alter PROCEDURE GetTaskCountByDate
    @FilterType VARCHAR(10),
    @ProjectID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartDate DATE;

    -- Determine the start date based on the filter type
    SET @StartDate = 
        CASE 
            WHEN @FilterType = '7' THEN DATEADD(DAY, -7, GETDATE())
            WHEN @FilterType = '30' THEN DATEADD(DAY, -30, GETDATE())
            WHEN @FilterType = 'month' THEN DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
        END;

    -- Fetch task counts for the specific project and date range
    SELECT 
        FORMAT(DueDate, 'dd MMM') AS TaskDate, 
        COUNT(*) AS TaskCount
    FROM Tasks
    WHERE 
        ProjectID = @ProjectID -- Filter by specific project
        AND DueDate >= @StartDate
    GROUP BY FORMAT(DueDate, 'dd MMM')
    ORDER BY MIN(DueDate);
END;


GetTaskCountByDate 7, 3
