using System;

namespace Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg
{
    public static class PurchaseOrderFactory
    {
        public static PurchaseOrder CreatePurchaseOrder(string orderNo, DateTime orderDate)
        {
            if (string.IsNullOrWhiteSpace(orderNo))
                throw new ArgumentException("采购订单编号不能为空。", "orderNo");

            var order = new PurchaseOrder
                            {
                                OrderNo = orderNo,
                                OrderDate = orderDate,
                                ItemCount = 0,
                            };
            return order;
        }
    }
}
