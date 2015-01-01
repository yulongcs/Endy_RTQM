using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class PurchaseOrderEntityTypeConfiguration : EntityTypeConfiguration<PurchaseOrder>
    {
        public PurchaseOrderEntityTypeConfiguration()
        {
            HasKey(po => po.Id);
            Property(po => po.OrderNo)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50)
                .HasColumnName("PONo");
            Property(po => po.OrderDate)
                .IsRequired()
                .HasColumnName("PODate");
            Property(po => po.ItemCount)
                .IsRequired();

            ToTable("lg_PurchaseOrders");
        }
    }
}
