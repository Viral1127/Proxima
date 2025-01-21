ALTER PROCEDURE [dbo].[PR_Client_UpdateClient]
	@ClientID INT,
    @ClientName NVARCHAR(255),
    @Address NVARCHAR(500),
    @PhoneNumber NVARCHAR(15),
    @Email NVARCHAR(100),
    @Status BIT --
AS
BEGIN
	UPDATE Clients
	Set Name = @ClientName,
        Address = @Address,
        Phone = @PhoneNumber,
        Email = @Email,
        Status = @Status
    WHERE ClientID = @ClientID;

	PRINT 'Record Updated Successfully'
END

SELECT * FROM Clients

EXEC [PR_Client_UpdateClient] 
	@ClientID = 4,
	@ClientName = 'VC Technologies',
	@Address = '456 Oak St, City, Country',
	@PhoneNumber = '0987654321',
	@Email = 'info@xyzcorp.com',
	@Status = 1;
