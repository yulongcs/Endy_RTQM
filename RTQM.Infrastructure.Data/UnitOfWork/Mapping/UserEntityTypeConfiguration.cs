using System.Data.Entity.ModelConfiguration;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping
{
    class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityTypeConfiguration()
        {
            HasKey(u => u.Id);
            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(20);
            Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);
            Property(u => u.RelationADAccount)
                .IsRequired()
                .HasMaxLength(50);
            Property(u => u.RealName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);
            Property(u => u.Department)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);
            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);
            Property(u => u.CreateDate)
                .IsRequired();
            HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("lg_UserRoles");
                });

            ToTable("lg_Users");
        }
    }
}
