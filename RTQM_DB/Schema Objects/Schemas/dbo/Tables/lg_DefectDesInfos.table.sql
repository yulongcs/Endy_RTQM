/* 缺陷描述信息表 */

create table [dbo].[lg_DefectDesInfos]
(
    [Id] int identity not null,             /* 缺陷描述标识 */
    [DefectDes] nvarchar(50) not null,      /* 缺陷描述内容 */
)
