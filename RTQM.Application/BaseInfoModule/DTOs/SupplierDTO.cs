using System;

namespace Lgsoft.RTQM.Application.BaseInfoModule.DTOs
{
    /// <summary>
    /// 供应商信息。
    /// </summary>
    public class SupplierDTO
    {
        /// <summary>
        /// 供应商标识。
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 供应商名称。
        /// </summary>
        public string SupplierName { get; set; }
    }
}
