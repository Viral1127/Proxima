ALTER PROCEDURE [dbo].[PR_Taks_GetAllTasks]
AS
BEGIN
	SELECT
		TaskID,
		Tasks.Title,
		Tasks.[Description],
		T.TaskTypeID,
		T.TypeName,
		DueDate,
		Tasks.[Status],
		AssignedTo,u.[Name],
		p.ProjectID,
		p.Title as ProjectName,
		Tasks.CreatedAt,
		Tasks.UpdatedAt
		FROM Tasks
	Inner join TaskTypes t
	ON Tasks.TaskTypeID = t.TaskTypeID
	Inner join Users u
	ON Tasks.AssignedTo = u.UserID
	Inner join Projects p
	ON Tasks.ProjectID = p.ProjectID
END
select * from Tasks

[PR_Taks_GetAllTasks]

select * from Users