CREATE PROCEDURE [dbo].[PR_Projects_GetProjectsByClientID]
    @ClientID INT
AS
BEGIN
    SELECT * FROM [dbo].[Projects]
    WHERE ClientID = @ClientID;
END;

[PR_Projects_GetProjectsByClientID] 1