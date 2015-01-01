/* 设置采购订单信息表 PONo 唯一键 */

alter table [dbo].[lg_PurchaseOrders]
    add constraint [UK_PurchaseOrders_PONo]
    unique clustered ([PONo])
