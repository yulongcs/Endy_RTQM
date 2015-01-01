using System;
using System.Collections.Generic;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<Role> GetUserRoles(Guid userId);

        User GetUserWithRoles(Guid userId);
    }
}
