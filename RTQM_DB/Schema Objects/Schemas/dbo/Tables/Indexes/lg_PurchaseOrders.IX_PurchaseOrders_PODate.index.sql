/* 设置采购订单信息表 PODate 索引 */

create index [IX_PurchaseOrders_PODate]
    on [dbo].[lg_PurchaseOrders]
    ([PODate], [PONo])
