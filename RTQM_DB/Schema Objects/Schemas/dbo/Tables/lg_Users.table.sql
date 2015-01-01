create table [dbo].[lg_Users]
(
	[Id] uniqueidentifier not null,             -- 用户标识
	[UserName] nvarchar(20) not null,           -- 用户名
    [Password] varchar(50) not null,            -- 用户密码
    [RelationADAccount] nvarchar(50) not null,  -- 关联的 AD 账号
    [RealName] nvarchar(20) not null,           -- 真实名称
    [Department] nvarchar(20) not null,         -- 所属部门
    [Email] varchar(50) not null,               -- 电子邮箱
    [CreateDate] datetime not null,             -- 创建日期
)
