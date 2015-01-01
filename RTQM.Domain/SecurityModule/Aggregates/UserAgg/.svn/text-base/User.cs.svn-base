using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg
{
    /// <summary>
    /// 用户。
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// 用户名。
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户关联的 AD 账号。
        /// </summary>
        public string RelationADAccount { get; set; }

        /// <summary>
        /// 真实姓名。
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 所在部门。
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 电子邮箱。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 创建日期。
        /// </summary>
        public DateTime CreateDate { get; set; }

        private HashSet<Role> _roles;
        public virtual ICollection<Role> Roles
        {
            get
            {
                if (_roles == null)
                    _roles = new HashSet<Role>();

                return _roles;
            }
            set
            {
                _roles = new HashSet<Role>(value);
            }
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password", "不能设置空密码。");

            var md5 = MD5.Create();

            var pwdMd5Bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            Password = Convert.ToBase64String(pwdMd5Bytes);
        }

        public bool CheckPassword(string password)
        {
            var md5 = MD5.Create();

            var currentPwdMd5Bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            return Convert.ToBase64String(currentPwdMd5Bytes) == Password;
        }

        public void AddRoleToUser(Role role)
        {
            if (!Roles.Contains(role))
                Roles.Add(role);
        }

        public void RemoveRoleFromUser(Role role)
        {
            if (Roles.Contains(role))
                Roles.Remove(role);
        }
    }
}
