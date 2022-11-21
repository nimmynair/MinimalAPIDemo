if not exists (select 1 from dbo.[user])
BEGIN

insert into dbo.[user] (FirstName,LastName)
values ('Tim','Correy'),('NN', 'RR'), ('John','Smith');

END
