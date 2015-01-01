using System;

namespace Lgsoft.RTQM.Application.RawMaterialQulityModule.Services
{
    /// <summary>
    /// 采购订单行查询参数。
    /// </summary>
    public class OrderLineFindParameters
    {
        /// <summary>
        /// 采购订单标识，指定 null 则忽略该参数。
        /// </summary>
        public Guid? OrderId { get; set; }

        /// <summary>
        /// 采购订单编号，指定 null 或空字符串则忽略该参数。
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 采购订单开始日期，指定 null 则忽略该参数。
        /// </summary>
        public DateTime? StartOrderDate { get; set; }

        /// <summary>
        /// 采购订单结束日期，指定 null 则忽略该参数。
        /// </summary>
        public DateTime? EndOrderDate { get; set; }

        /// <summary>
        /// 采购订单行批号，指定 null 或空字符串则忽略该参数。
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 采购订单行物料编号，指定 null 或空字符串则忽略该参数。
        /// </summary>
        public string MaterialNo { get; set; }

        /// <summary>
        /// 采购订单行供应商名称，指定 null 或空字符串则忽略该参数。
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 采购订单行合格率低值，指定 null 则忽略该参数。
        /// </summary>
        public float? LowConformance { get; set; }

        /// <summary>
        /// 采购订单行合格率高值，指定 null 则忽略该参数。
        /// </summary>
        public float? HighConformance { get; set; }
    }
}
