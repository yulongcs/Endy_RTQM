using System;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg
{
    /// <summary>
    /// 不合格报告。
    /// </summary>
    public class DisqualificationReport : Entity
    {
        /// <summary>
        /// 报告创建日期。
        /// </summary>
        public DateTime CreateDate { get; internal set; }

        /// <summary>
        /// 报告的采购订单标识。
        /// </summary>
        public Guid OrderId { get; internal set; }

        /// <summary>
        /// 报告的采购订单行标识。
        /// </summary>
        public Guid OrderLineId { get; internal set; }

        /// <summary>
        /// 报告的采购订单日期。
        /// </summary>
        public DateTime OrderDate { get; internal set; }

        /// <summary>
        /// 报告的采购订单编号。
        /// </summary>
        public string OrderNo { get; internal set; }

        /// <summary>
        /// 报告的采购订单行物料编号。
        /// </summary>
        public string MaterialNo { get; internal set; }

        /// <summary>
        /// 报告的采购订单行供应商名称。
        /// </summary>
        public string SupplierName { get; internal set; }

        /// <summary>
        /// 采购订单行物料总数。
        /// </summary>
        public int Total { get; internal set; }

        /// <summary>
        /// 采购订单行物料缺陷总数。
        /// </summary>
        public int DefectCount { get; internal set; }

        /// <summary>
        /// 采购订单行物料入库总数。
        /// </summary>
        public int QtyCount { get; internal set; }

        /// <summary>
        /// 不合格发现在。
        /// </summary>
        public string DefectFindIn { get; set; }

        /// <summary>
        /// 不合格描述。
        /// </summary>
        public string DefectDescription { get; set; }

        /// <summary>
        /// 处置方式。
        /// </summary>
        public int DisposalOption { get; set; }

        /// <summary>
        /// 处置意见。
        /// </summary>
        public string DisposalView { get; set; }

        /// <summary>
        /// 后置处置方式。
        /// </summary>
        public int DisposalAdvanceOption { get; set; }

        /// <summary>
        /// 使用部门意见。
        /// </summary>
        public string UseDepartmentView { get; set; }

        /// <summary>
        /// 决定。
        /// </summary>
        public string Decision { get; set; }
    }
}
