using System;

namespace Lgsoft.RTQM.Application.SecurityModule.DTOs
{
    /// <summary>
    /// 用户信息。
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// 用户标识。
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名。
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 关联的 AD 账号。
        /// </summary>
        public string ADAccount { get; set; }

        /// <summary>
        /// 真实姓名。
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 所属部门。
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 电子邮件。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 创建日期。
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
