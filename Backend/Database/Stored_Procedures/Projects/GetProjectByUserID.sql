CREATE PROCEDURE [dbo].[PR_Projects_GetProjectsByUserID]
    @UserID INT
AS
BEGIN
    SELECT * FROM [dbo].[Projects]
	join ProjectAssignments
	on ProjectAssignments.ProjectID = Projects.ProjectID
	where ProjectAssignments.UserID = @UserID
END;

[PR_Projects_GetProjectsByUserID] 17
select * from Projects
select * from ProjectAssignments
select * from Users