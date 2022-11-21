CREATE PROCEDURE [dbo].[sp_DeleteUser]
	 @Id int
	 
AS
begin
	delete from  dbo.[User]
	where Id = @Id;
end;
