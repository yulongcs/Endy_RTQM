/* 设置物料检验数据表 MaterialId 外键 */

alter table [dbo].[lg_PurchaseOrderItems]
    add constraint [FK_PurchaseOrderItems_MaterialId_MaterialInfos]
    foreign key ([MaterialId])
    references [dbo].[lg_MaterialInfos] ([Id])
