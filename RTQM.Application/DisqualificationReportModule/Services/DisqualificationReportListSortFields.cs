namespace Lgsoft.RTQM.Application.DisqualificationReportModule.Services
{
    /// <summary>
    /// 来料不合格报告列表排序字段。
    /// </summary>
    public enum DisqualificationReportListSortFields
    {
        /// <summary>
        /// 无排序字段。
        /// </summary>
        None,

        /// <summary>
        /// 按采购订单日期排序。
        /// </summary>
        OrderDate,

        /// <summary>
        /// 按采购订单编号排序。
        /// </summary>
        OrderNo,

        /// <summary>
        /// 按采购订单行物料编号排序。
        /// </summary>
        MaterialNo,

        /// <summary>
        /// 按采购订单行供应商名称排序。
        /// </summary>
        SupplierName,
    }
}
