using System;
using System.Linq;
using System.Web.Security;
using Lgsoft.RTQM.Application.SecurityModule.Services;
using Lgsoft.RTQM.Utility;

namespace Lgsoft.RTQM.Code
{
    public class RTQMRoleProvider : RoleProvider
    {
        #region Overrides of RoleProvider

        public override bool IsUserInRole(string username, string roleName)
        {
            var roleAppService = Container.Current.Resolve(typeof (IRoleAppService), null) as IRoleAppService;
            var userAppService = Container.Current.Resolve(typeof (IUserAppService), null) as IUserAppService;

            var role = roleAppService.GetRole(roleName);
            if (role == null)
                return false;

            var user = userAppService.GetUser(username);
            if (user == null)
                return false;

            return roleAppService.IsUserInRole(role.Id, user.Id);
        }

        public override string[] GetRolesForUser(string username)
        {
            var userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;

            var user = userAppService.GetUser(username);
            if (user == null)
                return new string[] {};

            return userAppService.GetUserRoles(user.Id).Select(r => r.RoleName).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotSupportedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotSupportedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotSupportedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotSupportedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotSupportedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var roleAppService = Container.Current.Resolve(typeof (IRoleAppService), null) as IRoleAppService;

            var role = roleAppService.GetRole(roleName);
            if (role == null)
                return new string[] {};

            return roleAppService.GetRoleUsers(role.Id).Select(u => u.UserName).ToArray();
        }

        public override string[] GetAllRoles()
        {
            var roleAppService = Container.Current.Resolve(typeof (IRoleAppService), null) as IRoleAppService;

            return roleAppService.GetAllRoles().Select(r => r.RoleName).ToArray();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotSupportedException();
        }

        public override string ApplicationName
        {
            get { return "Lgsoft RTQM"; }
            set { throw new NotSupportedException(); }
        }

        #endregion
    }
}