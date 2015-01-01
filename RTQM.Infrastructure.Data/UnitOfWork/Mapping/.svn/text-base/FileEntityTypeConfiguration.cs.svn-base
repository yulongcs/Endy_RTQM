using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class FileEntityTypeConfiguration : EntityTypeConfiguration<File>
    {
        public FileEntityTypeConfiguration()
        {
            HasKey(f => f.Id);
            Property(f => f.FileName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            Property(f => f.FileExtName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(10);
            Property(f => f.FileSize)
                .IsRequired();
            Property(f => f.StorageFileName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(30);
            Property(f => f.IsTempFile)
                .IsRequired();
            Property(f => f.CreateDate)
                .IsRequired();

            ToTable("lg_Files");
        }
    }
}
