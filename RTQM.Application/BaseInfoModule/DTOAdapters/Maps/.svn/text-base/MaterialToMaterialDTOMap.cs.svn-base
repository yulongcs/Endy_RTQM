using AutoMapper;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.BaseInfoModule.DTOAdapters.Maps
{
    class MaterialToMaterialDTOMap : TypeMapConfigurationBase<Material, MaterialDTO>
    {
        #region Overrides of TypeMapConfigurationBase<Material,MaterialDTO>

        protected override void BeforeMap(ref Material source)
        {
            Mapper.CreateMap<Material, MaterialDTO>();
        }

        protected override void AfterMap(ref MaterialDTO target, params object[] moreSources)
        {
            
        }

        protected override MaterialDTO Map(Material source)
        {
            return Mapper.Map<Material, MaterialDTO>(source);
        }

        #endregion
    }
}
