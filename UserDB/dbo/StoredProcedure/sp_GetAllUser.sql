CREATE PROCEDURE [dbo].[sp_GetAllUser]
	 
	 
AS
begin
	SELECT FirstName,LastName from dbo.[User];
 



END
