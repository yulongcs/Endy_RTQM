/* 设置物料检验数据表 BatchNo 唯一键 */

alter table [dbo].[lg_PurchaseOrderItems]
    add constraint [UK_PurchaseOrderItems_BatchNo]
    unique clustered ([BatchNo])
