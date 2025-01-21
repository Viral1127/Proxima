CREATE PROCEDURE [dbo].[PR_Client_GetClientByID]
    @ClientID INT
AS
BEGIN
    SELECT ClientID, Name, Address, Phone, Email, Status
    FROM Clients
    WHERE ClientID = @ClientID;
END;

EXEC [PR_Client_GetClientByID] 2
