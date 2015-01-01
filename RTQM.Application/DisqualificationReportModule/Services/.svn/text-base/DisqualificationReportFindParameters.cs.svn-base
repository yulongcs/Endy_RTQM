using System;

namespace Lgsoft.RTQM.Application.DisqualificationReportModule.Services
{
    /// <summary>
    /// 来料不合格报告查询参数。
    /// </summary>
    public class DisqualificationReportFindParameters
    {
        /// <summary>
        /// 报告创建开始日期，指定 null 则忽略该参数。
        /// </summary>
        public DateTime? StartCreateDate { get; set; }

        /// <summary>
        /// 报告创建结束日期，指定 null 则忽略该参数。
        /// </summary>
        public DateTime? EndCreateDate { get; set; }

        /// <summary>
        /// 采购订单开始日期，指定 null 则忽略该参数。
        /// </summary>
        public DateTime? StartOrderDate { get; set; }

        /// <summary>
        /// 采购订单结束日期，指定 null 则忽略该参数。
        /// </summary>
        public DateTime? EndOrderDate { get; set; }

        /// <summary>
        /// 采购订单编号，指定 null 或空字符串则忽略该参数。
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 采购订单行物料编号，指定 null 或空字符串则忽略该参数。
        /// </summary>
        public string MaterialNo { get; set; }

        /// <summary>
        /// 采购订单行供应商名称，指定 null 或空字符串则忽略该参数。
        /// </summary>
        public string SupplierName { get; set; }
    }
}
