using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg
{
    public static class SupplierSpecifications
    {
        public static Specification<Supplier> EnabledSupplier()
        {
            return new DirectSpecification<Supplier>(s => s.IsDelete == false);
        }

        public static Specification<Supplier> SupplierName(string supplierName)
        {
            var specification = EnabledSupplier();

            if (!string.IsNullOrWhiteSpace(supplierName))
            {
                specification &=
                    new DirectSpecification<Supplier>(s => s.SupplierName.ToLower().Contains(supplierName.ToLower()));
            }

            return specification;
        }

        public static Specification<Supplier> SupplierNameExactMatching(string supplierName)
        {
            if (!string.IsNullOrWhiteSpace(supplierName))
            {
                return new DirectSpecification<Supplier>(s => s.SupplierName.ToLower() == supplierName.ToLower());
            }
            else
            {
                return new NotSpecification<Supplier>(new TrueSpecification<Supplier>());
            }
        }
    }
}
