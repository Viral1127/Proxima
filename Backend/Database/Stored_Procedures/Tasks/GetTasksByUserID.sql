ALTER PROCEDURE [dbo].[PR_Tasks_GetTasksByUserID]
   @UserID INT
AS
BEGIN

       SELECT 
        T.TaskID,
        T.Title,
        T.Description,
        TT.TaskTypeID,
        TT.TypeName,
        T.DueDate,
        T.Status,
        U.UserID AS AssignedTo,
        U.Name AS AssignedToUser,
        T.ProjectID,
        P.Title AS ProjectName,
        UR.RoleID,
        UR.RoleName,
        T.CreatedAt,
        T.UpdatedAt
    FROM Tasks T
    INNER JOIN TaskAssignments TA ON T.TaskID = TA.TaskID
    INNER JOIN Users U ON TA.UserID = U.UserID
    INNER JOIN Projects P ON T.ProjectID = P.ProjectID
    INNER JOIN UserRoles UR ON TA.RoleID = UR.RoleID
    LEFT JOIN TaskTypes TT ON T.TaskTypeID = TT.TaskTypeID
    WHERE TA.UserID = @UserID;
END;

[PR_Tasks_GetTasksByUserID] 6
select * from Tasks
select * from TaskAssignments