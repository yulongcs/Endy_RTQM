/* 设置采购订单信息表 Id 主键 */

alter table [dbo].[lg_PurchaseOrders]
    add constraint [PK_PurchaseOrders]
    primary key nonclustered ([Id])
