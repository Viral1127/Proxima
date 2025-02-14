CREATE PROCEDURE [dbo].[PR_Projects_SelectByPK]
    @ProjectID INT
AS
BEGIN
    SELECT * FROM [dbo].[Projects]
    WHERE [ProjectID] = @ProjectID;
END;

exec [PR_Projects_SelectByPK] 1022

drop procedure [PR_Projects.SelectByPK]