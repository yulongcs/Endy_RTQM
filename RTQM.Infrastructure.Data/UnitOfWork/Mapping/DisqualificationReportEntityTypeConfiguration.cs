using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class DisqualificationReportEntityTypeConfiguration : EntityTypeConfiguration<DisqualificationReport>
    {
        public DisqualificationReportEntityTypeConfiguration()
        {
            HasKey(dr => dr.Id);
            Property(dr => dr.OrderId)
                .IsRequired();
            Property(dr => dr.OrderLineId)
                .IsRequired();
            Property(dr => dr.OrderNo)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            Property(dr => dr.OrderDate)
                .IsRequired();
            Property(dr => dr.CreateDate)
                .IsRequired();
            Property(dr => dr.MaterialNo)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            Property(dr => dr.SupplierName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            Property(dr => dr.Total)
                .IsRequired();
            Property(dr => dr.DefectCount)
                .IsRequired();
            Property(dr => dr.QtyCount)
                .IsRequired();
            Property(dr => dr.DefectFindIn)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(500);
            Property(dr => dr.DefectDescription)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(500);
            Property(dr => dr.DisposalOption)
                .IsRequired();
            Property(dr => dr.DisposalView)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(500);
            Property(dr => dr.DisposalAdvanceOption)
                .IsRequired();
            Property(dr => dr.UseDepartmentView)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(500);
            Property(dr => dr.Decision)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(500);

            ToTable("lg_DisqualificationReports");
        }
    }
}
