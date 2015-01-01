using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class OrderLineEntityTypeConfiguration : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineEntityTypeConfiguration()
        {
            HasKey(ol => ol.Id);
            Property(ol => ol.BatchNo)
                .IsRequired()
                .HasMaxLength(50);
            Property(ol => ol.OrderId)
                .HasColumnName("POId");
            Property(ol => ol.MaterialType)
                .IsRequired();
            Property(ol => ol.InspectResult.DefectDescrption)
                .HasMaxLength(50)
                .HasColumnName("DefectDes");
            Property(ol => ol.InspectResult.Total)
                .IsRequired()
                .HasColumnName("Total");
            Property(ol => ol.InspectResult.ConcessionCount)
                .IsRequired()
                .HasColumnName("ConcessionCount");
            Property(ol => ol.InspectResult.ReworkCount)
                .IsRequired()
                .HasColumnName("ReworkCount");
            Property(ol => ol.InspectResult.RejectionCount)
                .IsRequired()
                .HasColumnName("RejectionCount");
            Property(ol => ol.InspectResult.ScrapCount)
                .IsRequired()
                .HasColumnName("ScrapCount");
            Property(ol => ol.InspectResult.QtyTotal)
                .IsRequired()
                .HasColumnName("QtyTotal");
            Property(ol => ol.InspectResult.Conformance)
                .IsRequired()
                .HasColumnType("float")
                .HasColumnName("Conformance");

            HasRequired(ol => ol.Order)
                .WithMany()
                .HasForeignKey(ol => ol.OrderId)
                .WillCascadeOnDelete(false);
            HasRequired(ol => ol.Material)
                .WithMany()
                .HasForeignKey(ol => ol.MaterialId)
                .WillCascadeOnDelete(false);
            HasRequired(ol => ol.Supplier)
                .WithMany()
                .HasForeignKey(ol => ol.SupplierId)
                .WillCascadeOnDelete(false);

            ToTable("lg_PurchaseOrderItems");
        }
    }
}
