using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg
{
    public static class UserSpecifications
    {
        public static Specification<User> UserNameExactMatching(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                return new DirectSpecification<User>(u => u.UserName.ToLower() == userName.ToLower());
            }
            return new NotSpecification<User>(new TrueSpecification<User>());
        }
    }
}
