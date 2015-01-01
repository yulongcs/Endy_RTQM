using System.Collections.Generic;
using AutoMapper;
using Lgsoft.RTQM.Application.DisqualificationReportModule.DTOs;
using Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.DisqualificationReportModule.DTOAdapters.Maps
{
    class DisqualificationReportEnumerableToDisqualificationReportListMap : TypeMapConfigurationBase<IEnumerable<DisqualificationReport>, List<DisqualificationReportDTO>>
    {
        #region Overrides of TypeMapConfigurationBase<IEnumerable<DisqualificationReport>,List<DisqualificationReportDTO>>

        protected override void BeforeMap(ref IEnumerable<DisqualificationReport> source)
        {
            Mapper.CreateMap<DisqualificationReport, DisqualificationReportDTO>();
        }

        protected override void AfterMap(ref List<DisqualificationReportDTO> target, params object[] moreSources)
        {
            
        }

        protected override List<DisqualificationReportDTO> Map(IEnumerable<DisqualificationReport> source)
        {
            return Mapper.Map<IEnumerable<DisqualificationReport>, List<DisqualificationReportDTO>>(source);
        }

        #endregion
    }
}
