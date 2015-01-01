using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg
{
    public static class RoleSpecifications
    {
        public static Specification<Role> RoleNameExactMatching(string roleName)
        {
            if (!string.IsNullOrWhiteSpace(roleName))
            {
                return new DirectSpecification<Role>(r => r.RoleName.ToLower() == roleName.ToLower());
            }
            return new NotSpecification<Role>(new TrueSpecification<Role>());
        }
    }
}
