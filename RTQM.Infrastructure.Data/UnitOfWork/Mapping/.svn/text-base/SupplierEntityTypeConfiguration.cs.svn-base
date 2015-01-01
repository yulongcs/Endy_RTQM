using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class SupplierEntityTypeConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierEntityTypeConfiguration()
        {
            HasKey(s => s.Id);
            Property(s => s.SupplierName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            Property(s => s.IsDelete)
                .IsRequired();

            ToTable("lg_SupplierInfos");
        }
    }
}
