using Lgsoft.RTQM.Application.FileModule.DTOAdapters.Maps;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.FileModule.DTOAdapters
{
    public class FileModuleRegisterTypesMap : RegisterTypesMap
    {
        public FileModuleRegisterTypesMap()
        {
            RegisterMap(new FileToFileDTOMap());
        }
    }
}
