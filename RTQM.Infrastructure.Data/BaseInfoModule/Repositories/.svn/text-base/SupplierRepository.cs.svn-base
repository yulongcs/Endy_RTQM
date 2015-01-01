using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork;
using Lgsoft.SF.Infrastructure.Data;

namespace Lgsoft.RTQM.Infrastructure.Data.BaseInfoModule.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private IRTQMUnitOfWork _rtqmUnitOfWork;

        public SupplierRepository(IRTQMUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rtqmUnitOfWork = unitOfWork;
        }
    }
}
