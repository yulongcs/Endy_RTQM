using System;
using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg
{
    public static class OrderLineSpecifications
    {
        public static Specification<OrderLine> OrderId(Guid? orderId)
        {
            Specification<OrderLine> specification = new TrueSpecification<OrderLine>();

            if (orderId.HasValue)
            {
                specification &=
                    new DirectSpecification<OrderLine>(ol => ol.OrderId == orderId.Value);
            }

            return specification;
        }

        public static Specification<OrderLine> OrderNo(string orderNo)
        {
            Specification<OrderLine> specification = new TrueSpecification<OrderLine>();

            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                specification &=
                    new DirectSpecification<OrderLine>(ol => ol.Order.OrderNo.ToLower().Contains(orderNo.ToLower()));
            }

            return specification;
        }

        public static Specification<OrderLine> OrderDate(DateTime? startDate, DateTime? endDate)
        {
            Specification<OrderLine> specification = new TrueSpecification<OrderLine>();

            if (startDate.HasValue)
            {
                specification &=
                    new DirectSpecification<OrderLine>(ol => ol.Order.OrderDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                specification &=
                    new DirectSpecification<OrderLine>(ol => ol.Order.OrderDate <= endDate.Value);
            }

            return specification;
        }

        public static Specification<OrderLine> BatchNo(string batchNo)
        {
            Specification<OrderLine> specification = new TrueSpecification<OrderLine>();

            if (!string.IsNullOrWhiteSpace(batchNo))
            {
                specification &=
                    new DirectSpecification<OrderLine>(ol => ol.BatchNo.ToLower().Contains(batchNo.ToLower()));
            }

            return specification;
        }

        public static Specification<OrderLine> MaterialNo(string materialNo)
        {
            Specification<OrderLine> specification = new TrueSpecification<OrderLine>();

            if (!string.IsNullOrWhiteSpace(materialNo))
            {
                specification &=
                    new DirectSpecification<OrderLine>(
                        ol => ol.Material.MaterialNo.ToLower().Contains(materialNo.ToLower()));
            }

            return specification;
        }

        public static Specification<OrderLine> SupplierName(string supplierName)
        {
            Specification<OrderLine> specification = new TrueSpecification<OrderLine>();

            if (!string.IsNullOrWhiteSpace(supplierName))
            {
                specification &=
                    new DirectSpecification<OrderLine>(
                        ol => ol.Supplier.SupplierName.ToLower().Contains(supplierName.ToLower()));
            }

            return specification;
        }

        public static Specification<OrderLine> Conformance(float? lowConformance, float? highConformance)
        {
            Specification<OrderLine> specification = new TrueSpecification<OrderLine>();

            if (lowConformance.HasValue)
            {
                specification &=
                    new DirectSpecification<OrderLine>(ol => ol.InspectResult.Conformance >= lowConformance.Value);
            }

            if (highConformance.HasValue)
            {
                specification &=
                    new DirectSpecification<OrderLine>(ol => ol.InspectResult.Conformance <= highConformance.Value);
            }

            return specification;
        }

        public static Specification<OrderLine> BatchNoExactMatching(string batchNo)
        {
            if (!string.IsNullOrWhiteSpace(batchNo))
            {
                return new DirectSpecification<OrderLine>(ol => ol.BatchNo.ToLower() == batchNo.ToLower());
            }
            else
            {
                return new NotSpecification<OrderLine>(new TrueSpecification<OrderLine>());
            }
        }
    }
}
