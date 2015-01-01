using AutoMapper;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.SecurityModule.DTOAdapters.Maps
{
    /// <summary>
    /// User 映射到 UserDTO。
    /// </summary>
    class UserToUserDTOMap : TypeMapConfigurationBase<User, UserDTO>
    {
        #region Overrides of TypeMapConfigurationBase<User,UserDTO>

        protected override void BeforeMap(ref User source)
        {
            var mapper = Mapper.CreateMap<User, UserDTO>();
            mapper.ForMember(dto => dto.ADAccount, opt => opt.MapFrom(u => u.RelationADAccount));
        }

        protected override void AfterMap(ref UserDTO target, params object[] moreSources)
        {
            
        }

        protected override UserDTO Map(User source)
        {
            return Mapper.Map<User, UserDTO>(source);
        }

        #endregion
    }
}
