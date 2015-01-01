/* 设置物料信息表 Id 主键 */

alter table [dbo].[lg_MaterialInfos]
    add constraint [PK_MaterialInfos]
    primary key clustered ([Id])
