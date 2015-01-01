using System.Collections.Generic;
using AutoMapper;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.SecurityModule.DTOAdapters.Maps
{
    /// <summary>
    /// IEnumerable[Role] 映射到 List[RoleDTO]。
    /// </summary>
    class RoleEnumerableToRoleDTOListMap : TypeMapConfigurationBase<IEnumerable<Role>, List<RoleDTO>>
    {
        #region Overrides of TypeMapConfigurationBase<IEnumerable<Role>,List<RoleDTO>>

        protected override void BeforeMap(ref IEnumerable<Role> source)
        {
            Mapper.CreateMap<Role, RoleDTO>();
        }

        protected override void AfterMap(ref List<RoleDTO> target, params object[] moreSources)
        {
            
        }

        protected override List<RoleDTO> Map(IEnumerable<Role> source)
        {
            return Mapper.Map<IEnumerable<Role>, List<RoleDTO>>(source);
        }

        #endregion
    }
}
