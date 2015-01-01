using AutoMapper;
using Lgsoft.RTQM.Application.DisqualificationReportModule.DTOs;
using Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.DisqualificationReportModule.DTOAdapters.Maps
{
    class DisqualificationReportToDisqualificationReportDTOMap : TypeMapConfigurationBase<DisqualificationReport, DisqualificationReportDTO>
    {
        #region Overrides of TypeMapConfigurationBase<DisqualificationReport,DisqualificationReportDTO>

        protected override void BeforeMap(ref DisqualificationReport source)
        {
            Mapper.CreateMap<DisqualificationReport, DisqualificationReportDTO>();
        }

        protected override void AfterMap(ref DisqualificationReportDTO target, params object[] moreSources)
        {
            
        }

        protected override DisqualificationReportDTO Map(DisqualificationReport source)
        {
            return Mapper.Map<DisqualificationReport, DisqualificationReportDTO>(source);
        }

        #endregion
    }
}
