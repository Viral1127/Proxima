CREATE PROCEDURE [dbo].[PR_Client_GetAllClients]
as
begin
	Select * from Clients
end

exec [PR_Client_GetAllClients]