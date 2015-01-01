using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork;
using Lgsoft.SF.Infrastructure.Data;

namespace Lgsoft.RTQM.Infrastructure.Data.BaseInfoModule.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private IRTQMUnitOfWork _rtqmUnitOfWork;

        public MaterialRepository(IRTQMUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rtqmUnitOfWork = unitOfWork;
        }
    }
}
