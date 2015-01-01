using System;
using System.Collections.Generic;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;

namespace Lgsoft.RTQM.Application.SecurityModule.Services
{
    /// <summary>
    /// 角色应用服务。
    /// </summary>
    public interface IRoleAppService
    {
        /// <summary>
        /// 设置角色的用户。
        /// </summary>
        /// <param name="roleId">角色标识。</param>
        /// <param name="userIds">用户标识列表。</param>
        void SetRoleUsers(Guid roleId, Guid[] userIds);

        /// <summary>
        /// 检查指定用户是否属于指定角色。
        /// </summary>
        /// <param name="roleId">角色标识。</param>
        /// <param name="userId">用户标识。</param>
        /// <returns>用户属于角色返回 true，否则返回 false。</returns>
        bool IsUserInRole(Guid roleId, Guid userId);

        /// <summary>
        /// 获取指定角色的所有用户。
        /// </summary>
        /// <param name="roleId">角色标识。</param>
        /// <returns>返回用户的集合。</returns>
        List<UserDTO> GetRoleUsers(Guid roleId);

        /// <summary>
        /// 根据角色名称获取角色信息。
        /// </summary>
        /// <param name="roleName">角色名称。</param>
        /// <returns>返回角色信息。</returns>
        RoleDTO GetRole(string roleName);

        /// <summary>
        /// 获取所有角色。
        /// </summary>
        /// <returns>返回所有角色的集合。</returns>
        List<RoleDTO> GetAllRoles();
    }
}
