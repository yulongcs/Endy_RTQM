using System;

namespace Lgsoft.RTQM.Domain.SecurityModule.Services
{
    public interface IUserRoleService
    {
        void SetUserRoles(Guid userId, Guid[] roleIds);

        void SetRoleUsers(Guid roleId, Guid[] userIds);
    }
}
