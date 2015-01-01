using System;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;

namespace Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg
{
    public static class DisqualificationReportFactory
    {
        public static DisqualificationReport CreateReport(OrderLine orderLine, string defectFindIn,
                                                          string defectDescription, int disposalOption,
                                                          string disposalView, int disposalAdvanceOption,
                                                          string useDepartmentView, string decision)
        {
            if (orderLine == null || orderLine.Order == null || orderLine.Material == null || orderLine.Supplier == null)
                throw new ArgumentException("为不合格报告指定的数据不正确。");

            if (defectFindIn == null)
                defectFindIn = string.Empty;
            if (defectDescription == null)
                defectDescription = string.Empty;
            if (disposalView == null)
                disposalView = string.Empty;
            if (useDepartmentView == null)
                useDepartmentView = string.Empty;
            if (decision == null)
                decision = string.Empty;

            var report = new DisqualificationReport
                             {
                                 CreateDate = DateTime.Now,
                                 OrderId = orderLine.OrderId,
                                 OrderLineId = orderLine.Id,
                                 OrderDate = orderLine.Order.OrderDate,
                                 OrderNo = orderLine.Order.OrderNo,
                                 MaterialNo = orderLine.Material.MaterialNo,
                                 SupplierName = orderLine.Supplier.SupplierName,
                                 Total = orderLine.InspectResult.Total,
                                 DefectCount = orderLine.InspectResult.Total - orderLine.InspectResult.QtyTotal,
                                 QtyCount = orderLine.InspectResult.QtyTotal,
                                 DefectFindIn = defectFindIn,
                                 DefectDescription = defectDescription,
                                 DisposalOption = disposalOption,
                                 DisposalView = disposalView,
                                 DisposalAdvanceOption = disposalAdvanceOption,
                                 UseDepartmentView = useDepartmentView,
                                 Decision = decision,
                             };

            return report;
        }
    }
}
