using System;
using System.Collections.Generic;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<User> GetRoleUsers(Guid roleId);

        Role GetRoleWithUsers(Guid roleId);
    }
}
