using System;
using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg
{
    public static class PurchaseOrderSpecifications
    {
        public static Specification<PurchaseOrder> OrderNo(string orderNo)
        {
            Specification<PurchaseOrder> spec = new TrueSpecification<PurchaseOrder>();

            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                spec &= new DirectSpecification<PurchaseOrder>(po => po.OrderNo.ToLower().Contains(orderNo.ToLower()));
            }
            return spec;
        }

        public static Specification<PurchaseOrder> OrderDate(DateTime startDate, DateTime endDate)
        {
            Specification<PurchaseOrder> spec = new TrueSpecification<PurchaseOrder>();

            if (startDate != DateTime.MinValue)
            {
                spec &= new DirectSpecification<PurchaseOrder>(po => po.OrderDate >= startDate);
            }
            if (endDate != DateTime.MaxValue)
            {
                spec &= new DirectSpecification<PurchaseOrder>(po => po.OrderDate <= endDate);
            }
            return spec;
        }

        public static Specification<PurchaseOrder> OrderNoExactMatching(string orderNo)
        {
            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                return new DirectSpecification<PurchaseOrder>(po => po.OrderNo.ToLower() == orderNo.ToLower());
            }
            return new NotSpecification<PurchaseOrder>(new TrueSpecification<PurchaseOrder>());
        }
    }
}
