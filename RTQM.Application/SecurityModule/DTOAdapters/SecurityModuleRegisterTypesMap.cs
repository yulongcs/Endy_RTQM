using Lgsoft.RTQM.Application.SecurityModule.DTOAdapters.Maps;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.SecurityModule.DTOAdapters
{
    /// <summary>
    /// 安全模块类型映射注册类。
    /// </summary>
    public class SecurityModuleRegisterTypesMap : RegisterTypesMap
    {
        /// <summary>
        /// 通过构造函数注册类型映射。
        /// </summary>
        public SecurityModuleRegisterTypesMap()
        {
            RegisterMap(new UserToUserDTOMap());
            RegisterMap(new UserEnumerableToUserDTOListMap());
            RegisterMap(new RoleToRoleDTOMap());
            RegisterMap(new RoleEnumerableToRoleDTOListMap());
        }
    }
}
