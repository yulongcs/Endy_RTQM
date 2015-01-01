using System.Collections.Generic;
using AutoMapper;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.BaseInfoModule.DTOAdapters.Maps
{
    class MaterialEnumerableToMaterialDTOListMap : TypeMapConfigurationBase<IEnumerable<Material>, List<MaterialDTO>>
    {
        #region Overrides of TypeMapConfigurationBase<IEnumerable<Material>,List<MaterialDTO>>

        protected override void BeforeMap(ref IEnumerable<Material> source)
        {
            Mapper.CreateMap<Material, MaterialDTO>();
        }

        protected override void AfterMap(ref List<MaterialDTO> target, params object[] moreSources)
        {
            
        }

        protected override List<MaterialDTO> Map(IEnumerable<Material> source)
        {
            return Mapper.Map<IEnumerable<Material>, List<MaterialDTO>>(source);
        }

        #endregion
    }
}
