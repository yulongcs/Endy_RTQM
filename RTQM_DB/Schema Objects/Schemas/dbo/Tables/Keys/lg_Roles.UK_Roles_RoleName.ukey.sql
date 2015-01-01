alter table [dbo].[lg_Roles]
    add constraint [UK_Roles_RoleName]
    unique ([RoleName])