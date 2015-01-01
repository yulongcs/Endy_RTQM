/* 采购订单物料检验数据表 */

create table [dbo].[lg_PurchaseOrderItems]
(
    [Id] uniqueidentifier not null,     /* 物料检验数据标识 */
    [POId] uniqueidentifier not null,   /* 采购订单标识 */
    [BatchNo] nvarchar(50) not null,    /* 批号 */
    [MaterialId] uniqueidentifier not null,     /* 物料标识 */
    [SupplierId] uniqueidentifier not null,     /* 供应商标识 */
    [MaterialType] int not null,        /* 物料类型：1－EP；2－VI */
    [Total] int not null,               /* 物料总量 */
    [DefectDes] nvarchar(50) null,      /* 缺陷描述 */
    [ConcessionCount] int not null,     /* 让步数量 */
    [ReworkCount] int not null,         /* 返工数量 */
    [RejectionCount] int not null,      /* 退货数量 */
    [ScrapCount] int not null,          /* 报废数量 */
    [QtyTotal] int not null,            /* 入库总量 */
    [Conformance] float not null,       /* 合格率 */
)
