alter table [dbo].[lg_Users]
    add constraint [UK_Users_UserName]
    unique ([UserName])