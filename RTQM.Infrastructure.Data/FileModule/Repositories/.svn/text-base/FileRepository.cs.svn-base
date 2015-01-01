using Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork;
using Lgsoft.SF.Infrastructure.Data;

namespace Lgsoft.RTQM.Infrastructure.Data.FileModule.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        private IRTQMUnitOfWork _rtqmUnitOfWork;

        public FileRepository(IRTQMUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rtqmUnitOfWork = unitOfWork;
        }
    }
}
