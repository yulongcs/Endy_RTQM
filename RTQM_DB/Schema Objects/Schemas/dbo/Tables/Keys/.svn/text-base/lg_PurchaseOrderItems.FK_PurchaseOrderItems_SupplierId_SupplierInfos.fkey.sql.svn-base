/* 设置物料检验数据表 SupplierId 外键 */

alter table [dbo].[lg_PurchaseOrderItems]
    add constraint [FK_PurchaseOrderItems_SupplierId_SupplierInfos]
    foreign key ([SupplierId])
    references [dbo].[lg_SupplierInfos] ([Id])	
