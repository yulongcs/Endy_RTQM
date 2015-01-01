using System;

namespace Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg
{
    public static class UserFactory
    {
        public static User CreateUser(string userName, string adAccount, string realName,
                                      string department, string email)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("用户名或密码不能为空。");

            if (adAccount == null)
                adAccount = string.Empty;
            if (realName == null)
                realName = string.Empty;
            if (department == null)
                department = string.Empty;
            if (email == null)
                email = string.Empty;

            var user = new User
                           {
                               UserName = userName,
                               RelationADAccount = adAccount,
                               RealName = realName,
                               Department = department,
                               Email = email,
                           };

            return user;
        }
    }
}
