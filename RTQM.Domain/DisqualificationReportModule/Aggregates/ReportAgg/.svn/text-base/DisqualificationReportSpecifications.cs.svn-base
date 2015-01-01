using System;
using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg
{
    public static class DisqualificationReportSpecifications
    {
        public static Specification<DisqualificationReport> CreateDate(DateTime? startDate, DateTime? endDate)
        {
            Specification<DisqualificationReport> specification = new TrueSpecification<DisqualificationReport>();

            if (startDate.HasValue)
            {
                specification &=
                    new DirectSpecification<DisqualificationReport>(dr => dr.CreateDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                specification &=
                    new DirectSpecification<DisqualificationReport>(dr => dr.CreateDate <= endDate.Value);
            }

            return specification;
        }

        public static Specification<DisqualificationReport> OrderDate(DateTime? startDate, DateTime? endDate)
        {
            Specification<DisqualificationReport> specification = new TrueSpecification<DisqualificationReport>();

            if (startDate.HasValue)
            {
                specification &=
                    new DirectSpecification<DisqualificationReport>(dr => dr.OrderDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                specification &=
                    new DirectSpecification<DisqualificationReport>(dr => dr.OrderDate <= endDate.Value);
            }

            return specification;
        }

        public static Specification<DisqualificationReport> OrderNo(string orderNo)
        {
            Specification<DisqualificationReport> specification = new TrueSpecification<DisqualificationReport>();

            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                specification &=
                    new DirectSpecification<DisqualificationReport>(
                        dr => dr.OrderNo.ToLower().Contains(orderNo.ToLower()));
            }

            return specification;
        }

        public static Specification<DisqualificationReport> MaterialNo(string materialNo)
        {
            Specification<DisqualificationReport> specification = new TrueSpecification<DisqualificationReport>();

            if (!string.IsNullOrWhiteSpace(materialNo))
            {
                specification &=
                    new DirectSpecification<DisqualificationReport>(
                        dr => dr.MaterialNo.ToLower().Contains(materialNo.ToLower()));
            }

            return specification;
        }
        
        public static Specification<DisqualificationReport> SupplierName(string supplierName)
        {
            Specification<DisqualificationReport> specification = new TrueSpecification<DisqualificationReport>();

            if (!string.IsNullOrWhiteSpace(supplierName))
            {
                specification &=
                    new DirectSpecification<DisqualificationReport>(
                        dr => dr.SupplierName.ToLower().Contains(supplierName.ToLower()));
            }

            return specification;
        }
    }
}
