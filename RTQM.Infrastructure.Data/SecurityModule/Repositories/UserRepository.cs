using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork;
using Lgsoft.SF.Infrastructure.Data;

namespace Lgsoft.RTQM.Infrastructure.Data.SecurityModule.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IRTQMUnitOfWork _rtqmUnitOfWork;

        public UserRepository(IRTQMUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rtqmUnitOfWork = unitOfWork;
        }

        #region Implementation of IUserRepository

        public IEnumerable<Role> GetUserRoles(Guid userId)
        {
            var user = GetUserWithRoles(userId);

            return user != null ? user.Roles : new Collection<Role>().AsEnumerable();
        }

        public User GetUserWithRoles(Guid userId)
        {
            return GetSetWithRoles().Where(u => u.Id == userId).SingleOrDefault();
        }

        #endregion

        private IQueryable<User> GetSetWithRoles()
        {
            return _rtqmUnitOfWork.CreateSet<User>().Include(u => u.Roles);
        }
    }
}
