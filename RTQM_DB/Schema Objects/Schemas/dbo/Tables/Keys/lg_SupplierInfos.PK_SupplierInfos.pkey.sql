/* 设置供应商信息表 Id 主键 */

alter table [dbo].[lg_SupplierInfos]
    add constraint [PK_SupplierInfos]
    primary key clustered ([Id])
