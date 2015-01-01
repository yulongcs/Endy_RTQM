using System;
using System.Collections.Generic;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;

namespace Lgsoft.RTQM.Application.SecurityModule.Services
{
    /// <summary>
    /// 用户应用服务。
    /// </summary>
    public interface IUserAppService
    {
        /// <summary>
        /// 创建用户。
        /// </summary>
        /// <param name="userDTO">用户信息。</param>
        /// <returns>返回新创建的用户信息。</returns>
        UserDTO CreateNewUser(UserDTO userDTO);

        /// <summary>
        /// 修改用户。
        /// </summary>
        /// <param name="userDTO">用户信息。</param>
        /// <returns>返回修改后的用户信息。</returns>
        /// <remarks>用户名、用户密码及创建日期不能通过该方法修改。</remarks>
        UserDTO UpdateUser(UserDTO userDTO);

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="userId">用户标识。</param>
        void RemoveUser(Guid userId);

        /// <summary>
        /// 设置用户的角色。
        /// </summary>
        /// <param name="userId">用户标识。</param>
        /// <param name="roleIds">角色标识列表。</param>
        void SetUserRoles(Guid userId, Guid[] roleIds);

        /// <summary>
        /// 设置用户密码。
        /// </summary>
        /// <param name="userId">用户标识。</param>
        /// <param name="password">用户密码。</param>
        void SetUserPassword(Guid userId, string password);

        /// <summary>
        /// 检查用户名和密码。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="password">用户密码。</param>
        /// <returns>用户名与密码匹配返回 true，否则返回 false。</returns>
        bool CheckUserPassword(string userName, string password);

        /// <summary>
        /// 获取指定用户的所有角色。
        /// </summary>
        /// <param name="userId">用户标识。</param>
        /// <returns>返回角色的集合。</returns>
        List<RoleDTO> GetUserRoles(Guid userId);
        
        /// <summary>
        /// 根据用户标识获取用户信息。
        /// </summary>
        /// <param name="userId">用户标识。</param>
        /// <returns>返回用户信息。</returns>
        UserDTO GetUser(Guid userId);

        /// <summary>
        /// 根据用户名获取用户信息。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>返回用户信息。</returns>
        UserDTO GetUser(string userName);

        /// <summary>
        /// 获取所有用户。
        /// </summary>
        /// <returns>返回所有用户的集合。</returns>
        List<UserDTO> GetAllUsers();
    }
}
