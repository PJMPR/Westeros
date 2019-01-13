update dbo.RecipeDb set IsNew  = 1 where id >0
update dbo.MailServerDb set IsNew  = 1 where id >0
delete from dbo.MailServerDb where id >0
delete from dbo.LogDb where id >0
delete from dbo.MailDB where id >0