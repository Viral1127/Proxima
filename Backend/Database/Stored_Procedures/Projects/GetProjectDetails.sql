CREATE PROCEDURE [dbo].[PR_Projects.SelectByPK]
    @ProjectID INT
AS
BEGIN
    SELECT * FROM [dbo].[Projects]
    WHERE [ProjectID] = @ProjectID;
END;

exec [PR_Projects.SelectByPK] 1