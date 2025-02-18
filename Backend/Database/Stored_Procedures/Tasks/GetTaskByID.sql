Alter PROCEDURE [dbo].[PR_Tasks_GetTaskByID]
    @TaskID INT
AS
BEGIN
    SELECT
	Tasks.TaskID,
	Tasks.[Title],
	Tasks.[Description],
	TaskTypes.TaskTypeID,
	TaskTypes.TypeName,
	Tasks.[Status],
	Tasks.AssignedTo,
	Projects.ProjectID,
	Projects.Title as ProjectTitle,
	Tasks.CreatedAt,
	Tasks.UpdatedAt,
	Tasks.DueDate
    FROM [dbo].[Tasks]
	inner join TaskTypes
	on Tasks.TaskTypeID = TaskTypes.TaskTypeID
	inner join Projects
	on Tasks.ProjectID = Projects.ProjectID
	
    WHERE [TaskID] = @TaskID;
END;

[PR_Tasks_GetTaskByID] 19
