/* 物料信息表 */

create table [dbo].[lg_MaterialInfos]
(
    [Id] uniqueidentifier not null,         /* 物料信息标识 */
    [MaterialNo] nvarchar(50) not null,     /* 物料编号 */
    [MaterialDes] nvarchar(100) not null,   /* 物料描述 */
    [IsDeleted] bit not null,               /* 是否已经删除：0－未删除；1－已删除 */
)
