using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class MaterialEntityTypeConfiguration : EntityTypeConfiguration<Material>
    {
        public MaterialEntityTypeConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.MaterialNo)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            Property(m => m.MaterialDescrption)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100)
                .HasColumnName("MaterialDes");
            Property(m => m.IsDeleted)
                .IsRequired();

            ToTable("lg_MaterialInfos");
        }
    }
}
