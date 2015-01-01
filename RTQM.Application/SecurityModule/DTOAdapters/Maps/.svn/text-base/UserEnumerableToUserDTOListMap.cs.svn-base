using System.Collections.Generic;
using AutoMapper;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.SecurityModule.DTOAdapters.Maps
{
    /// <summary>
    /// Enumerable[User] 映射到 List[UserDTO]。
    /// </summary>
    class UserEnumerableToUserDTOListMap : TypeMapConfigurationBase<IEnumerable<User>, List<UserDTO>>
    {
        #region Overrides of TypeMapConfigurationBase<IEnumerable<User>,List<UserDTO>>

        protected override void BeforeMap(ref IEnumerable<User> source)
        {
            var mapper = Mapper.CreateMap<User, UserDTO>();
            mapper.ForMember(dto => dto.ADAccount, opt => opt.MapFrom(u => u.RelationADAccount));
        }

        protected override void AfterMap(ref List<UserDTO> target, params object[] moreSources)
        {
            
        }

        protected override List<UserDTO> Map(IEnumerable<User> source)
        {
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(source);
        }

        #endregion
    }
}
