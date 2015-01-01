using System.Collections.Generic;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg
{
    /// <summary>
    /// 角色。
    /// </summary>
    public class Role : Entity
    {
        public string RoleName { get; set; }

        public string Description { get; set; }

        private HashSet<User> _users;
        public virtual ICollection<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new HashSet<User>();
                
                return _users;
            }
            set
            {
                _users = new HashSet<User>(value);
            }
        }

        public void AddUserToRole(User user)
        {
            if (!Users.Contains(user))
                Users.Add(user);
        }

        public void RemoveUserFromRole(User user)
        {
            if (Users.Contains(user))
                Users.Remove(user);
        }
    }
}
