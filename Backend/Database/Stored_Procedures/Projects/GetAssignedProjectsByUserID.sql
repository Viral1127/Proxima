CREATE PROCEDURE [dbo].[PR_Projects_GetAssignedProjectsByUserID]
    @UserID INT
AS
BEGIN
    SELECT p.*
    FROM [dbo].[Projects] p
    INNER JOIN [ProjectAssignments] pa ON p.ProjectID = pa.ProjectID
    WHERE pa.UserID = @UserID;
END;

[PR_Projects_GetAssignedProjectsByUserID] 3