CREATE PROCEDURE [dbo].[sp_InsertUser]
	 @FirstName nvarchar(50),
	 @LastName nvarchar(50)
	 
AS
begin
	INSERt into dbo.[user] ( FirstName,LastName ) values (@FirstName, @LastName)
	 

end;
