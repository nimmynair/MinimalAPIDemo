CREATE PROCEDURE [dbo].[sp_GetUser]
	 @Id int
	 
AS
begin
	SELECT FirstName,LastName from dbo.[User]
	where Id = @Id;
end;
