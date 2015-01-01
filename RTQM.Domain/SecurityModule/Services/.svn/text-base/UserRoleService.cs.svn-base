using System;
using System.Linq;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;

namespace Lgsoft.RTQM.Domain.SecurityModule.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserRoleService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        #region Implementation of IUserRoleService

        public void SetUserRoles(Guid userId, Guid[] roleIds)
        {
            var roles = roleIds.Select(roleId => _roleRepository.Get(roleId)).Where(role => role != null).ToList();
            var user = _userRepository.GetUserWithRoles(userId);

            user.Roles.Clear();

            foreach (var role in roles)
            {
                user.Roles.Add(role);
            }

            _userRepository.UnitOfWork.Commit();
        }

        public void SetRoleUsers(Guid roleId, Guid[] userIds)
        {
            var users = userIds.Select(userId => _userRepository.Get(userId)).Where(user => user != null).ToList();
            var role = _roleRepository.GetRoleWithUsers(roleId);

            role.Users.Clear();

            foreach (var user in users)
            {
                role.Users.Add(user);
            }

            _roleRepository.UnitOfWork.Commit();
        }

        #endregion
    }
}
