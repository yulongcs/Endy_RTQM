alter table [dbo].[lg_DisqualificationReports]
	add constraint [FK_DisqualificationReports_OrderLineId] 
	foreign key ([OrderLineId])
	references [dbo].[lg_PurchaseOrderItems] ([Id])	
    on delete cascade
