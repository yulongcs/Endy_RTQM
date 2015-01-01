using System;
using System.Collections.Generic;
using System.Linq;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Services;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.SecurityModule.Services
{
    public class RoleAppService : IRoleAppService
    {
        private readonly ITypeAdapter _typeAdapter;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleService _userRoleService;

        public RoleAppService(ITypeAdapter typeAdapter, IRoleRepository roleRepository, IUserRoleService userRoleService)
        {
            _typeAdapter = typeAdapter;
            _roleRepository = roleRepository;
            _userRoleService = userRoleService;
        }

        #region Implementation of IRoleAppService

        public void SetRoleUsers(Guid roleId, Guid[] userIds)
        {
            _userRoleService.SetRoleUsers(roleId, userIds);
        }

        public bool IsUserInRole(Guid roleId, Guid userId)
        {
            var role = _roleRepository.GetRoleWithUsers(roleId);

            return role != null && role.Users.Select(u => u.Id).Contains(userId);
        }

        public List<UserDTO> GetRoleUsers(Guid roleId)
        {
            return _typeAdapter.Adapt<IEnumerable<User>, List<UserDTO>>(_roleRepository.GetRoleUsers(roleId));
        }

        public RoleDTO GetRole(string roleName)
        {
            var role = _roleRepository.AllMatching(RoleSpecifications.RoleNameExactMatching(roleName)).SingleOrDefault();

            if (role != null)
                _typeAdapter.Adapt<Role, RoleDTO>(role);
            return null;
        }

        public List<RoleDTO> GetAllRoles()
        {
            return _typeAdapter.Adapt<IEnumerable<Role>, List<RoleDTO>>(_roleRepository.GetAll());
        }

        #endregion
    }
}
