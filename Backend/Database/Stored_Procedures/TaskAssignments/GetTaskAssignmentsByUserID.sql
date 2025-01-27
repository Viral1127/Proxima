CREATE PROCEDURE [dbo].[PR_TaskAssignments_GetTaskAssignmentsByUserID]
    @UserID INT
AS
BEGIN
    SELECT 
        ta.AssignmentID,
        ta.TaskID,
        t.Title AS TaskTitle,
        ta.UserID,
        u.Name AS UserName,
        ta.RoleID,
        r.RoleName AS RoleName,
        ta.AssignedAt
    FROM TaskAssignments ta
    INNER JOIN Tasks t ON ta.TaskID = t.TaskID
    INNER JOIN Users u ON ta.UserID = u.UserID
    INNER JOIN UserRoles r ON ta.RoleID = r.RoleID
    WHERE ta.UserID = @UserID;
END;

[PR_TaskAssignments_GetTaskAssignmentsByUserID] 1
select * from TaskAssignments
