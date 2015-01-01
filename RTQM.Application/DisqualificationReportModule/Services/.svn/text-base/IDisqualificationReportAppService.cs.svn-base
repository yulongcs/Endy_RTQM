using System;
using Lgsoft.RTQM.Application.DisqualificationReportModule.DTOs;
using Lgsoft.SF.Infrastructure.CrossCutting;

namespace Lgsoft.RTQM.Application.DisqualificationReportModule.Services
{
    /// <summary>
    /// 来料不合格报告应用服务。
    /// </summary>
    public interface IDisqualificationReportAppService
    {
        /// <summary>
        /// 创建来料不合格报告信息。
        /// </summary>
        /// <param name="orderLineId">用于创建报告的采购订单行标识。</param>
        /// <param name="reportDTO">报告信息。</param>
        /// <returns>返回创建的来料不合格报告。</returns>
        DisqualificationReportDTO CreateNewReport(Guid orderLineId, DisqualificationReportDTO reportDTO);

        /// <summary>
        /// 更新来料不合格报告信息。
        /// </summary>
        /// <param name="reportDTO">报告信息。</param>
        DisqualificationReportDTO UpdateReport(DisqualificationReportDTO reportDTO);

        /// <summary>
        /// 删除来料不合格报告信息。
        /// </summary>
        /// <param name="reportId">报告标识。</param>
        void RemoveReport(Guid reportId);

        /// <summary>
        /// 获取来料不合格报告信息。
        /// </summary>
        /// <param name="reportId">报告标识。</param>
        /// <returns>返回来料不合格报告信息。</returns>
        DisqualificationReportDTO GetReport(Guid reportId);

        /// <summary>
        /// 分页查询来料不合格报告信息。
        /// </summary>
        /// <param name="pageIndex">分页序号。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="findParams">查询参数。</param>
        /// <param name="sortField">排序字段。</param>
        /// <param name="ascending">是否正序。</param>
        /// <returns>返回符合条件的分页不合格报告集合。</returns>
        PagedDataSet<DisqualificationReportDTO> FindReports(int pageIndex, int pageSize,
                                                            DisqualificationReportFindParameters findParams,
                                                            DisqualificationReportListSortFields sortField,
                                                            bool ascending);
    }
}
