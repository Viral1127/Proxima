ALTER PROCEDURE [dbo].[PR_GetAdminDashboardData]
AS
BEGIN
    -- Enable NOCOUNT for better performance
    SET NOCOUNT ON;

    -- Temporary tables for organized data fetching
    CREATE TABLE #Counts (
        Metric NVARCHAR(255),
        Value INT
    );

    CREATE TABLE #RecentProjects (
        ProjectID INT,
        Title NVARCHAR(100),
        ClientName NVARCHAR(100),
        DueDate DATETIME,
        Status NVARCHAR(50)
    );

    CREATE TABLE #RecentTasks (
        TaskID INT,
        Title NVARCHAR(100),
        AssignedTo NVARCHAR(100),
        ProjectName NVARCHAR(100),
        DueDate DATETIME,
        Status NVARCHAR(50)
    );

    CREATE TABLE #UpcomingMilestones (
        MilestoneID INT,
        ProjectName NVARCHAR(100),
        Title NVARCHAR(100),
        DueDate DATETIME,
        Status NVARCHAR(50)
    );

    CREATE TABLE #RecentUsers (
        UserID INT,
        Name NVARCHAR(100),
        Email NVARCHAR(100),
        Role NVARCHAR(50),
        Status NVARCHAR(50)
    );

    CREATE TABLE #ProjectsPerMonth (
        MonthName NVARCHAR(50),
        Year INT,
        TotalProjects INT
    );
	CREATE TABLE #ProjectStatusCount (
        Status NVARCHAR(50),
        TotalProjects INT
    );

    ---- Step 1: Get Counts ----
    INSERT INTO #Counts
        SELECT 'TotalUsers', COUNT(*) FROM Users;
    INSERT INTO #Counts
        SELECT 'TotalActiveUsers', COUNT(*) FROM Users WHERE Status = 1;
    INSERT INTO #Counts
        SELECT 'TotalProjects', COUNT(*) FROM Projects;
    INSERT INTO #Counts
        SELECT 'OngoingProjects', COUNT(*) FROM Projects WHERE Status = 'Ongoing';
    INSERT INTO #Counts
        SELECT 'CompletedProjects', COUNT(*) FROM Projects WHERE Status = 'Completed';
    INSERT INTO #Counts
        SELECT 'TotalTasks', COUNT(*) FROM Tasks;
    INSERT INTO #Counts
        SELECT 'PendingMilestones', COUNT(*) FROM Milestones WHERE Status = 'Pending';
    INSERT INTO #Counts
        SELECT 'TotalClients', COUNT(*) FROM Clients;

    ---- Step 2: Get Recent Projects ----
    INSERT INTO #RecentProjects
    SELECT TOP 10
        P.ProjectID,
        P.Title,
        C.Name AS ClientName,
        P.EndDate,
        P.Status
    FROM Projects P
    LEFT JOIN Clients C ON P.ClientID = C.ClientID
    ORDER BY P.CreatedAt DESC;

    ---- Step 3: Get Recent Tasks ----
    INSERT INTO #RecentTasks
    SELECT TOP 5
        T.TaskID,
        T.Title,
        U.Name AS AssignedTo,
        P.Title AS ProjectName,
        T.DueDate,
        T.Status
    FROM Tasks T
    LEFT JOIN Users U ON T.AssignedTo = U.UserID
    LEFT JOIN Projects P ON T.ProjectID = P.ProjectID
    ORDER BY T.CreatedAt DESC;

    ---- Step 4: Get Upcoming Milestones ----
    INSERT INTO #UpcomingMilestones
    SELECT TOP 10
        M.MilestoneID,
        P.Title AS ProjectName,
        M.Title,
        M.DueDate,
        M.Status
    FROM Milestones M
    LEFT JOIN Projects P ON M.ProjectID = P.ProjectID
    WHERE M.Status = 'Pending'
    ORDER BY M.DueDate ASC;

    ---- Step 5: Get Recent Users ----
    INSERT INTO #RecentUsers
    SELECT TOP 10
        U.UserID,
        U.Name,
        U.Email,
        R.RoleName,
        CASE WHEN U.Status = 1 THEN 'Active' ELSE 'Blocked' END AS Status
    FROM Users U
    INNER JOIN UserRoles R ON U.RoleID = R.RoleID
    ORDER BY U.CreatedAt DESC;

    ---- Step 6: Get Project Count Per Month ----
    INSERT INTO #ProjectsPerMonth
    SELECT 
        DATENAME(MONTH, CreatedAt) AS MonthName,
        YEAR(CreatedAt) AS Year,
        COUNT(*) AS TotalProjects
    FROM Projects
    GROUP BY DATENAME(MONTH, CreatedAt), YEAR(CreatedAt),DATEPART(MONTH, CreatedAt) 
    ORDER BY Year DESC, DATEPART(MONTH, CreatedAt) ASC;

	INSERT INTO #ProjectStatusCount
    SELECT 
        Status, 
        COUNT(*) AS TotalProjects
    FROM Projects
    GROUP BY Status;

    ---- Output Results ----
    SELECT * FROM #Counts;
    SELECT * FROM #RecentProjects;
    SELECT * FROM #RecentTasks;
    SELECT * FROM #UpcomingMilestones;
    SELECT * FROM #RecentUsers;
    SELECT * FROM #ProjectsPerMonth;
	SELECT * FROM #ProjectStatusCount;

    ---- Cleanup Temporary Tables ----
    DROP TABLE #Counts;
    DROP TABLE #RecentProjects;
    DROP TABLE #RecentTasks;
    DROP TABLE #UpcomingMilestones;
    DROP TABLE #RecentUsers;
    DROP TABLE #ProjectsPerMonth;
	DROP TABLE #ProjectStatusCount;
END;
select * from Projects
[PR_GetAdminDashboardData]