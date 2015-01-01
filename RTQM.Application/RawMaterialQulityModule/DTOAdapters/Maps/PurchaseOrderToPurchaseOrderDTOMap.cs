using AutoMapper;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOAdapters.Maps
{
    class PurchaseOrderToPurchaseOrderDTOMap : TypeMapConfigurationBase<PurchaseOrder, PurchaseOrderDTO>
    {
        #region Overrides of TypeMapConfigurationBase<PurchaseOrder,PurchaseOrderDTO>

        protected override void BeforeMap(ref PurchaseOrder source)
        {
            var mapper = Mapper.CreateMap<PurchaseOrder, PurchaseOrderDTO>();
            mapper.ForMember(dto => dto.LineCount, opt => opt.MapFrom(po => po.ItemCount));
        }

        protected override void AfterMap(ref PurchaseOrderDTO target, params object[] moreSources)
        {
            
        }

        protected override PurchaseOrderDTO Map(PurchaseOrder source)
        {
            return Mapper.Map<PurchaseOrder, PurchaseOrderDTO>(source);
        }

        #endregion
    }
}
