CREATE PROCEDURE [dbo].[sp_UpsertUser]
@Id int,
	 @FirstName nvarchar(50),
	 @LastName nvarchar(50)
	 
AS
begin
	UPDATE   dbo.[user]  set  FirstName = @FirstName,LastName =   @LastName;
	 

end;
