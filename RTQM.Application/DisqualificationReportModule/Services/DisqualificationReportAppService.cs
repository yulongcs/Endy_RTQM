using System;
using System.Collections.Generic;
using System.Linq;
using Lgsoft.RTQM.Application.DisqualificationReportModule.DTOs;
using Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;
using Lgsoft.SF.Domain;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.DisqualificationReportModule.Services
{
    public class DisqualificationReportAppService : IDisqualificationReportAppService
    {
        private readonly ITypeAdapter _typeAdapter;
        private readonly IDisqualificationReportRepository _reportRepository;
        private readonly IOrderLineRepository _orderLineRepository;

        public DisqualificationReportAppService(ITypeAdapter typeAdapter,
                                                IDisqualificationReportRepository reportRepository,
                                                IOrderLineRepository orderLineRepository)
        {
            _typeAdapter = typeAdapter;
            _reportRepository = reportRepository;
            _orderLineRepository = orderLineRepository;
        }

        #region Implementation of IDisqualificationReportAppService

        public DisqualificationReportDTO CreateNewReport(Guid orderLineId, DisqualificationReportDTO reportDTO)
        {
            if (orderLineId == Guid.Empty)
                return null;
            if (reportDTO == null)
                return null;

            var orderLine = _orderLineRepository.GetIncludeAllInfo(orderLineId);
            if (orderLine == null)
                return null;

            var report = DisqualificationReportFactory.CreateReport(orderLine, reportDTO.DefectFindIn,
                                                                    reportDTO.DefectDescription,
                                                                    (int) reportDTO.DisposalOption,
                                                                    reportDTO.DisposalView,
                                                                    (int) reportDTO.DisposalAdvanceOption,
                                                                    reportDTO.UseDepartmentView, reportDTO.Decision);
            report.Id = IdentityGenerator.NewSequentialGuid();

            _reportRepository.Add(report);

            _reportRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<DisqualificationReport, DisqualificationReportDTO>(report);
        }

        public DisqualificationReportDTO UpdateReport(DisqualificationReportDTO reportDTO)
        {
            if (reportDTO == null || reportDTO.Id == Guid.Empty)
                return null;

            var orderLine = _orderLineRepository.GetIncludeAllInfo(reportDTO.OrderId);
            if (orderLine == null)
                return null;

            var persisted = _reportRepository.Get(reportDTO.Id);

            if (persisted == null)
                return null;

            var current = DisqualificationReportFactory.CreateReport(orderLine, reportDTO.DefectFindIn,
                                                                     reportDTO.DefectDescription,
                                                                     (int)reportDTO.DisposalOption,
                                                                     reportDTO.DisposalView,
                                                                     (int)reportDTO.DisposalAdvanceOption,
                                                                     reportDTO.UseDepartmentView, reportDTO.Decision);
            current.Id = reportDTO.Id;

            _reportRepository.Merge(persisted, current);

            _reportRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<DisqualificationReport, DisqualificationReportDTO>(persisted);
        }

        public void RemoveReport(Guid reportId)
        {
            if (reportId == Guid.Empty)
                return;

            var report = _reportRepository.Get(reportId);

            if (report != null)
            {
                _reportRepository.Remove(report);

                _reportRepository.UnitOfWork.Commit();
            }
        }

        public DisqualificationReportDTO GetReport(Guid reportId)
        {
            if (reportId == Guid.Empty)
                return null;

            var report = _reportRepository.Get(reportId);

            return report != null ? _typeAdapter.Adapt<DisqualificationReport, DisqualificationReportDTO>(report) : null;
        }

        public PagedDataSet<DisqualificationReportDTO> FindReports(int pageIndex, int pageSize,
                                                                   DisqualificationReportFindParameters findParams,
                                                                   DisqualificationReportListSortFields sortField,
                                                                   bool @ascending)
        {
            var spec = DisqualificationReportSpecifications.CreateDate(findParams.StartCreateDate,
                                                                       findParams.EndCreateDate)
                       &
                       DisqualificationReportSpecifications.OrderDate(findParams.StartOrderDate, findParams.EndOrderDate)
                       & DisqualificationReportSpecifications.OrderNo(findParams.OrderNo)
                       & DisqualificationReportSpecifications.MaterialNo(findParams.MaterialNo)
                       & DisqualificationReportSpecifications.SupplierName(findParams.SupplierName);

            IEnumerable<DisqualificationReport> reports;
            switch (sortField)
            {
                case DisqualificationReportListSortFields.OrderDate:
                    reports = _reportRepository.GetPaged(pageIndex, pageSize, spec, dr => dr.OrderDate, ascending);
                    break;
                case DisqualificationReportListSortFields.OrderNo:
                    reports = _reportRepository.GetPaged(pageIndex, pageSize, spec, dr => dr.OrderNo, ascending);
                    break;
                case DisqualificationReportListSortFields.MaterialNo:
                    reports = _reportRepository.GetPaged(pageIndex, pageSize, spec, dr => dr.MaterialNo, ascending);
                    break;
                case DisqualificationReportListSortFields.SupplierName:
                    reports = _reportRepository.GetPaged(pageIndex, pageSize, spec, dr => dr.SupplierName, ascending);
                    break;
                default:
                    reports = _reportRepository.GetPaged(pageIndex, pageSize, spec, dr => dr.CreateDate, true);
                    break;
            }

            var count = _reportRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return new PagedDataSet<DisqualificationReportDTO>
                       {
                           PageIndex = pageIndex,
                           PageSize = pageSize,
                           DataCount = count,
                           CurrentPageDataSet =
                               _typeAdapter.Adapt
                               <IEnumerable<DisqualificationReport>, List<DisqualificationReportDTO>>(reports),
                       };
        }

        #endregion
    }
}
