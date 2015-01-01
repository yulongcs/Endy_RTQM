using System.Data.Entity;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.SF.Infrastructure.Data;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork
{
    public interface IRTQMUnitOfWork : IQueryableUnitOfWork
    {
        IDbSet<Material> Materials { get; }

        IDbSet<Supplier> Suppliers { get; }

        IDbSet<PurchaseOrder> PurchaseOrders { get; }

        IDbSet<OrderLine> OrderLines { get; }
    }
}
