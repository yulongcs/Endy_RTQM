/* 来料不合格报告表 */

create table [dbo].[lg_DisqualificationReports]
(
	[Id] uniqueidentifier not null,             -- 报告标识
	[CreateDate] datetime not null,             -- 报告创建日期
    [OrderId] uniqueidentifier not null,        -- 报告的采购订单标识
    [OrderLineId] uniqueidentifier not null,    -- 报告的采购订单行标识
    [OrderDate] datetime not null,              -- 报告的采购订单日期
    [OrderNo] nvarchar(50) not null,            -- 报告的采购订单编号
    [MaterialNo] nvarchar(50) not null,         -- 报告的采购订单行物料编号
    [SupplierName] nvarchar(50) not null,       -- 报告的采购订单行供应商名称
    [Total] int not null,                       -- 采购订单行物料总数
    [DefectCount] int not null,                 -- 采购订单行缺陷总数
    [QtyCount] int not null,                    -- 采购订单行入库总数
    [DefectFindIn] nvarchar(500) not null,      -- 不合格发现在
    [DefectDescription] nvarchar(500) not null,  -- 不合格描述
    [DisposalOption] int not null,              -- 处置方式
    [DisposalView] nvarchar(500) not null,      -- 处置意见
    [DisposalAdvanceOption] int not null,       -- 后置处理方式
    [UseDepartmentView] nvarchar(500) not null, -- 使用部门意见
    [Decision] nvarchar(500) not null,          -- 决定
)
