using System.Collections.Generic;
using AutoMapper;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.BaseInfoModule.DTOAdapters.Maps
{
    class SupplierEnumerableToSupplierDTOListMap : TypeMapConfigurationBase<IEnumerable<Supplier>, List<SupplierDTO>>
    {
        #region Overrides of TypeMapConfigurationBase<IEnumerable<Supplier>,List<SupplierDTO>>

        protected override void BeforeMap(ref IEnumerable<Supplier> source)
        {
            Mapper.CreateMap<Supplier, SupplierDTO>();
        }

        protected override void AfterMap(ref List<SupplierDTO> target, params object[] moreSources)
        {
            
        }

        protected override List<SupplierDTO> Map(IEnumerable<Supplier> source)
        {
            return Mapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(source);
        }

        #endregion
    }
}
