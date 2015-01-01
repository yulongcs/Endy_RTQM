using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class RoleEntityTypeConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityTypeConfiguration()
        {
            HasKey(r => r.Id);
            Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(20);
            Property(r => r.Description)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);
            HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .Map(m =>
                         {
                             m.MapLeftKey("RoleId");
                             m.MapRightKey("UserId");
                             m.ToTable("lg_UserRoles");
                         });

            ToTable("lg_Roles");
        }
    }
}
