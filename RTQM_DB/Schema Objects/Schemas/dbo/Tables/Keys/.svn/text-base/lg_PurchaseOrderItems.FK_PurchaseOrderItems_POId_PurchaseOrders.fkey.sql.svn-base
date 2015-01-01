/* 设置物料检验数据表 POId 外键 */

alter table [dbo].[lg_PurchaseOrderItems]
    add constraint [FK_PurchaseOrderItems_POId_PurchaseOrders]
    foreign key ([POId])
    references [dbo].[lg_PurchaseOrders] ([Id])
    on delete cascade
