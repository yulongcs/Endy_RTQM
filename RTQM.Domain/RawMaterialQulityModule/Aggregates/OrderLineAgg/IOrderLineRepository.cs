using System;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg
{
    /// <summary>
    /// 采购订单行仓库。
    /// </summary>
    public interface IOrderLineRepository : IRepository<OrderLine>
    {
        OrderLine GetIncludeAllInfo(Guid orderLineId);
    }
}
