using AutoMapper;
using Lgsoft.RTQM.Application.FileModule.DTOs;
using Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.FileModule.DTOAdapters.Maps
{
    class FileToFileDTOMap : TypeMapConfigurationBase<File, FileDTO>
    {
        #region Overrides of TypeMapConfigurationBase<File,FileDTO>

        protected override void BeforeMap(ref File source)
        {
            var mapper = Mapper.CreateMap<File, FileDTO>();
            mapper.ForMember(dto => dto.FileFullName, opt => opt.MapFrom(f => f.GetFileName()));
        }

        protected override void AfterMap(ref FileDTO target, params object[] moreSources)
        {
            
        }

        protected override FileDTO Map(File source)
        {
            return Mapper.Map<File, FileDTO>(source);
        }

        #endregion
    }
}
