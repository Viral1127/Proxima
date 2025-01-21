CREATE PROCEDURE [dbo].[PR_Client_DeleteClient]
@ClientID int
AS
BEGIN
	UPDATE Clients
    SET Status = 0 -- Mark as Inactive
    WHERE ClientID = @ClientID;
    
    PRINT 'Client deactivated successfully.';
END

[PR_Client_DeleteClient] 2

SELECT * FROM Clients