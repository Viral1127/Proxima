ALTER PROCEDURE [dbo].[PR_Get_PM_DashboardData]
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Temporary tables for structured data
    CREATE TABLE #Counts (
        Metric NVARCHAR(255),
        Value INT
    );

    CREATE TABLE #AssignedProjects (
        ProjectID INT,
        Title NVARCHAR(100),
        ClientName NVARCHAR(100),
        StartDate DATETIME,
        EndDate DATETIME,
        Status NVARCHAR(50),
        AssignedAt DATETIME
    );

    CREATE TABLE #AssignedTasks (
        TaskID INT,
        Title NVARCHAR(100),
        ProjectName NVARCHAR(100),
        DueDate DATETIME,
        Status NVARCHAR(50),
        AssignedAt DATETIME
    );

    ---- Step 1: Get Counts ----
    -- Count of assigned projects for the user (excluding archived)
    INSERT INTO #Counts
    SELECT 'AssignedProjects', COUNT(*)
    FROM ProjectAssignments PA
    INNER JOIN Projects P ON PA.ProjectID = P.ProjectID
    WHERE PA.UserID = @UserID AND P.Status <> 'Archived';

    -- Count of assigned tasks for the user
    INSERT INTO #Counts
    SELECT 'AssignedTasks', COUNT(*)
    FROM TaskAssignments TA
    WHERE TA.UserID = @UserID;

	Insert into #Counts
	select 'TeamMembers',Count(*)
	from Users
	where Users.RoleID = 3

    -- Count of completed tasks for the user
    INSERT INTO #Counts
    SELECT 'CompletedTasks', COUNT(*)
    FROM Tasks T
    INNER JOIN TaskAssignments TA ON T.TaskID = TA.TaskID
    WHERE TA.UserID = @UserID AND T.Status = 'Completed';

    -- Count of overdue tasks for the user
    INSERT INTO #Counts
    SELECT 'OverdueTasks', COUNT(*)
    FROM Tasks T
    INNER JOIN TaskAssignments TA ON T.TaskID = TA.TaskID
    WHERE TA.UserID = @UserID AND T.DueDate < GETDATE() AND T.Status <> 'Completed';

    ---- Step 2: Get Top 6 Recently Assigned Projects (Excluding Archived) ----
    INSERT INTO #AssignedProjects
    SELECT TOP 6
        P.ProjectID,
        P.Title,
        C.Name AS ClientName,
        P.StartDate,
        P.EndDate,
        P.Status,
        PA.AssignedAt
    FROM ProjectAssignments PA
    INNER JOIN Projects P ON PA.ProjectID = P.ProjectID
    LEFT JOIN Clients C ON P.ClientID = C.ClientID
    WHERE PA.UserID = @UserID AND P.Status <> 'Archived'
    ORDER BY PA.AssignedAt DESC;

    ---- Step 3: Get Top 6 Recently Assigned Tasks ----
    INSERT INTO #AssignedTasks
    SELECT TOP 6
        T.TaskID,
        T.Title,
        P.Title AS ProjectName,
        T.DueDate,
        T.Status,
        TA.AssignedAt
    FROM TaskAssignments TA
    INNER JOIN Tasks T ON TA.TaskID = T.TaskID
    LEFT JOIN Projects P ON T.ProjectID = P.ProjectID
    WHERE TA.UserID = @UserID
    ORDER BY TA.AssignedAt DESC;

    ---- Output Results ----
    SELECT * FROM #Counts;
    SELECT * FROM #AssignedProjects;
    SELECT * FROM #AssignedTasks;

    ---- Cleanup Temporary Tables ----
    DROP TABLE #Counts;
    DROP TABLE #AssignedProjects;
    DROP TABLE #AssignedTasks;
END;
[PR_Get_PM_DashboardData] 1