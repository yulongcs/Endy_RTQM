using AutoMapper;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOAdapters.Maps
{
    class OrderLineToOrderLineDTOMap : TypeMapConfigurationBase<OrderLine, OrderLineDTO>
    {
        #region Overrides of TypeMapConfigurationBase<OrderLine,OrderLineDTO>

        protected override void BeforeMap(ref OrderLine source)
        {
            var mapper = Mapper.CreateMap<OrderLine, OrderLineDTO>();
            mapper.ForMember(dto => dto.DefectDescrption, opt => opt.MapFrom(ol => ol.InspectResult.DefectDescrption));
            mapper.ForMember(dto => dto.ConcessionCount, opt => opt.MapFrom(ol => ol.InspectResult.ConcessionCount));
            mapper.ForMember(dto => dto.RejectionCount, opt => opt.MapFrom(ol => ol.InspectResult.RejectionCount));
            mapper.ForMember(dto => dto.ReworkCount, opt => opt.MapFrom(ol => ol.InspectResult.ReworkCount));
            mapper.ForMember(dto => dto.ScrapCount, opt => opt.MapFrom(ol => ol.InspectResult.ScrapCount));
            mapper.ForMember(dto => dto.Total, opt => opt.MapFrom(ol => ol.InspectResult.Total));
            mapper.ForMember(dto => dto.QtyTotal, opt => opt.MapFrom(ol => ol.InspectResult.QtyTotal));
            mapper.ForMember(dto => dto.Conformance, opt => opt.MapFrom(ol => ol.InspectResult.Conformance));
            mapper.ForMember(dto => dto.OrderNo, opt => opt.MapFrom(ol => ol.Order.OrderNo));
            mapper.ForMember(dto => dto.OrderDate, opt => opt.MapFrom(ol => ol.Order.OrderDate));
            mapper.ForMember(dto => dto.MaterialNo, opt => opt.MapFrom(ol => ol.Material.MaterialNo));
            mapper.ForMember(dto => dto.MaterialDescription, opt => opt.MapFrom(ol => ol.Material.MaterialDescrption));
            mapper.ForMember(dto => dto.SupplierName, opt => opt.MapFrom(ol => ol.Supplier.SupplierName));
        }

        protected override void AfterMap(ref OrderLineDTO target, params object[] moreSources)
        {
            
        }

        protected override OrderLineDTO Map(OrderLine source)
        {
            return Mapper.Map<OrderLine, OrderLineDTO>(source);
        }

        #endregion
    }
}
