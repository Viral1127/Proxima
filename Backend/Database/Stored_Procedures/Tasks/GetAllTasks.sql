ALTER PROCEDURE [dbo].[PR_Taks_GetAllTasks]
AS
BEGIN
	SELECT 
        T.TaskID,
        T.Title,
        T.[Description],
        TT.TaskTypeID,
        TT.TypeName,
        T.DueDate,
        T.[Status],
        TA.UserID AS AssignedTo,  -- Fetching Assigned User from TaskAssignments
        U.[Name] AS AssignedUser,
        P.ProjectID,
        P.Title AS ProjectName,
        T.CreatedAt,
        T.UpdatedAt
    FROM Tasks T
    INNER JOIN TaskTypes TT ON T.TaskTypeID = TT.TaskTypeID
    INNER JOIN Projects P ON T.ProjectID = P.ProjectID
    INNER JOIN TaskAssignments TA ON T.TaskID = TA.TaskID  -- Get assigned user from TaskAssignments
    INNER JOIN Users U ON TA.UserID = U.UserID; -- Fetch user details
END
select * from Tasks

[PR_Taks_GetAllTasks]

select * from Users