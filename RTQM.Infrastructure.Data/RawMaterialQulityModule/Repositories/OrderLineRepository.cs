using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork;
using Lgsoft.SF.Domain.Specification;
using Lgsoft.SF.Infrastructure.Data;

namespace Lgsoft.RTQM.Infrastructure.Data.RawMaterialQulityModule.Repositories
{
    public class OrderLineRepository : Repository<OrderLine>, IOrderLineRepository
    {
        private readonly IRTQMUnitOfWork _rtqmUnitOfWork;

        public OrderLineRepository(IRTQMUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rtqmUnitOfWork = unitOfWork;
        }

        public override IEnumerable<OrderLine> GetPaged<TProperty>(int pageIndex, int pageSize,
                                                                   ISpecification<OrderLine> specification,
                                                                   Expression<Func<OrderLine, TProperty>>
                                                                       orderByExpression, bool ascending)
        {
            var set = _rtqmUnitOfWork.CreateSet<OrderLine>();

            if (ascending)
            {
                return set.Include(ol => ol.Order).Include(ol => ol.Material).Include(ol => ol.Supplier)
                    .Where(specification.SatisfiedBy())
                    .OrderBy(orderByExpression)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .AsEnumerable();
            }
            return set.Include(ol => ol.Order).Include(ol => ol.Material).Include(ol => ol.Supplier)
                .Where(specification.SatisfiedBy())
                .OrderByDescending(orderByExpression)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .AsEnumerable();
        }

        public OrderLine GetIncludeAllInfo(Guid orderLineId)
        {
            if (orderLineId != Guid.Empty)
                return
                    _rtqmUnitOfWork.CreateSet<OrderLine>().Include(ol => ol.Order).Include(ol => ol.Material).Include(
                        ol => ol.Supplier).FirstOrDefault(ol => ol.Id == orderLineId);
            return null;
        }
    }
}
