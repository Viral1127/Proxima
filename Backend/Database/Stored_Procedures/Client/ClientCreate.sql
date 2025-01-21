CREATE PROCEDURE [dbo].[PR_Client_AddClient]
@Name nvarchar(100),
@Email nvarchar(100),
@Phone nvarchar(20),
@Address nvarchar(100),
@Status bit
as
begin
INSERT INTO [dbo].[Clients]
( 
	[Name],Email,Phone,[Address],[Status]
)
Values(@Name,@Email,@Phone,@Address,@Status)
end

exec [PR_Client_AddClient] 'Viral' ,'vc@gmail.com','989899','asdf',1
