create table [dbo].[lg_Files]
(
	[Id] uniqueidentifier not null,             -- 文件标识
	[FileName] nvarchar(50) not null,           -- 文件名称
    [FileExtName] nvarchar(10) not null,        -- 文件扩展名
    [StorageFileName] nvarchar(30) not null,    -- 文件存储名称
    [FileSize] bigint not null,                 -- 文件大小
    [IsTempFile] bit not null,                  -- 是否临时文件
    [CreateDate] datetime not null,             -- 创建日期
)
