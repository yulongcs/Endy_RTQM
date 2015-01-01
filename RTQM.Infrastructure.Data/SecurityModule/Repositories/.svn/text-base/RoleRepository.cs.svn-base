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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IRTQMUnitOfWork _rtqmUnitOfWork;

        public RoleRepository(IRTQMUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rtqmUnitOfWork = unitOfWork;
        }

        #region Implementation of IRoleRepository

        public IEnumerable<User> GetRoleUsers(Guid roleId)
        {
            var role = GetRoleWithUsers(roleId);

            return role != null ? role.Users : new Collection<User>().AsEnumerable();
        }

        public Role GetRoleWithUsers(Guid roleId)
        {
            return GetSetWithUsers().Where(r => r.Id == roleId).SingleOrDefault();
        }

        #endregion

        private IQueryable<Role> GetSetWithUsers()
        {
            return _rtqmUnitOfWork.CreateSet<Role>().Include(r => r.Users);
        }
    }
}
