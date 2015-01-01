using System.Collections.Generic;
using AutoMapper;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOAdapters.Maps
{
    class PurchaseOrderEnumerableToPurchaseOrderDTOListMap : TypeMapConfigurationBase<IEnumerable<PurchaseOrder>, List<PurchaseOrderDTO>>
    {
        #region Overrides of TypeMapConfigurationBase<IEnumerable<PurchaseOrder>,List<PurchaseOrderDTO>>

        protected override void BeforeMap(ref IEnumerable<PurchaseOrder> source)
        {
            var mapper = Mapper.CreateMap<PurchaseOrder, PurchaseOrderDTO>();
            mapper.ForMember(dto => dto.LineCount, opt => opt.MapFrom(po => po.ItemCount));
        }

        protected override void AfterMap(ref List<PurchaseOrderDTO> target, params object[] moreSources)
        {
            
        }

        protected override List<PurchaseOrderDTO> Map(IEnumerable<PurchaseOrder> source)
        {
            return Mapper.Map<IEnumerable<PurchaseOrder>, List<PurchaseOrderDTO>>(source);
        }

        #endregion
    }
}
