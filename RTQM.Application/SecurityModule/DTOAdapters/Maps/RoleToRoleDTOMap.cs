using AutoMapper;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.SecurityModule.DTOAdapters.Maps
{
    /// <summary>
    /// Role 映射到 RoleDTO。
    /// </summary>
    class RoleToRoleDTOMap : TypeMapConfigurationBase<Role, RoleDTO>
    {
        #region Overrides of TypeMapConfigurationBase<Role,RoleDTO>

        protected override void BeforeMap(ref Role source)
        {
            Mapper.CreateMap<Role, RoleDTO>();
        }

        protected override void AfterMap(ref RoleDTO target, params object[] moreSources)
        {
            
        }

        protected override RoleDTO Map(Role source)
        {
            return Mapper.Map<Role, RoleDTO>(source);
        }

        #endregion
    }
}
