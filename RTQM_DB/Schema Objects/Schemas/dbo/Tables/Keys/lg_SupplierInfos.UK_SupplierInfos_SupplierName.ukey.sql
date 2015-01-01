alter table [dbo].[lg_SupplierInfos]
    add constraint [UK_SupplierInfos_SupplierName]
    unique nonclustered ([SupplierName])