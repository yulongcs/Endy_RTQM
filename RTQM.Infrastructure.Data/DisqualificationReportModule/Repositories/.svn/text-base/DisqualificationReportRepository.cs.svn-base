using Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork;
using Lgsoft.SF.Infrastructure.Data;

namespace Lgsoft.RTQM.Infrastructure.Data.DisqualificationReportModule.Repositories
{
    public class DisqualificationReportRepository : Repository<DisqualificationReport>, IDisqualificationReportRepository
    {
        private IRTQMUnitOfWork _rtqmUnitOfWork;

        public DisqualificationReportRepository(IRTQMUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rtqmUnitOfWork = unitOfWork;
        }
    }
}
