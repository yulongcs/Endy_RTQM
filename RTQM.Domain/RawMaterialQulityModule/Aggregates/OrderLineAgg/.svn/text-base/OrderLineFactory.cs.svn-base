using System;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg
{
    public static class OrderLineFactory
    {
        public static OrderLine CreateOrderLine(Guid orderId, Guid materialId, Guid supplierId, string batchNo, int materialType,
                                         string defectDes, int total, int concessionCount, int reworkCount,
                                         int rejectionCount, int scrapCount)
        {
            if (orderId == Guid.Empty || materialId == Guid.Empty || supplierId == Guid.Empty || string.IsNullOrWhiteSpace(batchNo))
                throw new ArgumentException("为采购订单行指定的数据不正确。");

            if (defectDes == null)
                defectDes = string.Empty;
            if (total < 0)
                total = 0;
            if (concessionCount < 0)
                concessionCount = 0;
            if (reworkCount < 0)
                rejectionCount = 0;
            if (rejectionCount < 0)
                rejectionCount = 0;
            if (scrapCount < 0)
                scrapCount = 0;

            var line = new OrderLine
                           {
                               Id = IdentityGenerator.NewSequentialGuid(),
                               BatchNo = batchNo,
                               MaterialType = materialType,
                               OrderId = orderId,
                               MaterialId = materialId,
                               SupplierId = supplierId,
                           };
            var inspectResult = new InspectResult
                                    {
                                        DefectDescrption = defectDes,
                                        Total = total,
                                        ConcessionCount = concessionCount,
                                        ReworkCount = reworkCount,
                                        RejectionCount = rejectionCount,
                                        ScrapCount = scrapCount,
                                        QtyTotal = total - concessionCount - reworkCount - rejectionCount - scrapCount,
                                    };
            if (inspectResult.QtyTotal < 0)
                throw new ArgumentException("为采购订单行指定的数据不正确。");
            inspectResult.Conformance = (float)inspectResult.QtyTotal / inspectResult.Total;
            line.InspectResult = inspectResult;

            return line;
        }

        public static OrderLine CreateOrderLine(PurchaseOrder order, Material material, Supplier supplier, string batchNo, int materialType,
                                         string defectDes, int total, int concessionCount, int reworkCount,
                                         int rejectionCount, int scrapCount)
        {
            if (order == null || order.IsTransient() || material == null || material.IsTransient() || supplier == null || supplier.IsTransient() || string.IsNullOrWhiteSpace(batchNo))
                throw new ArgumentException("为采购订单行指定的数据不正确。");

            if (defectDes == null)
                defectDes = string.Empty;
            if (total < 0)
                total = 0;
            if (concessionCount < 0)
                concessionCount = 0;
            if (reworkCount < 0)
                rejectionCount = 0;
            if (rejectionCount < 0)
                rejectionCount = 0;
            if (scrapCount < 0)
                scrapCount = 0;

            var line = new OrderLine
                           {
                               Id = IdentityGenerator.NewSequentialGuid(),
                               BatchNo = batchNo,
                               MaterialType = materialType,
                           };
            line.SetOrder(order);
            line.SetMaterial(material);
            line.SetSupplier(supplier);
            var inspectResult = new InspectResult
                                    {
                                        DefectDescrption = defectDes,
                                        Total = total,
                                        ConcessionCount = concessionCount,
                                        ReworkCount = reworkCount,
                                        RejectionCount = rejectionCount,
                                        ScrapCount = scrapCount,
                                        QtyTotal = total - concessionCount - reworkCount - rejectionCount - scrapCount,
                                    };
            if (inspectResult.QtyTotal < 0)
                throw new ArgumentException("为采购订单行指定的数据不正确。");
            inspectResult.Conformance = (float)inspectResult.QtyTotal / inspectResult.Total;
            line.InspectResult = inspectResult;

            return line;
        }
    }
}
