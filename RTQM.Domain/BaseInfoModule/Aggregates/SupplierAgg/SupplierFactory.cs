using System;

namespace Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg
{
    public static class SupplierFactory
    {
        public static Supplier CreateSupplier(string supplierName)
        {
            if (string.IsNullOrWhiteSpace(supplierName))
                throw new ArgumentNullException("supplierName", "供应商名称不能为空。");

            var supplier = new Supplier
                               {
                                   SupplierName = supplierName,
                               };
            supplier.Enable();

            return supplier;
        }
    }
}
