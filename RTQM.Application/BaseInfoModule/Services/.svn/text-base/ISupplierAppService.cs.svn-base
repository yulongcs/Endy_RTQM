using System;
using System.Collections.Generic;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.SF.Infrastructure.CrossCutting;

namespace Lgsoft.RTQM.Application.BaseInfoModule.Services
{
    /// <summary>
    /// 供应商应用服务接口。
    /// </summary>
    public interface ISupplierAppService
    {
        /// <summary>
        /// 添加供应商信息。
        /// </summary>
        /// <param name="supplierDTO">供应商信息。</param>
        /// <returns>返回添加的供应商信息。</returns>
        SupplierDTO CreateNewSupplier(SupplierDTO supplierDTO);

        /// <summary>
        /// 更新供应商信息。
        /// </summary>
        /// <param name="supplierDTO">供应商信息。</param>
        SupplierDTO UpdateSupplier(SupplierDTO supplierDTO);

        /// <summary>
        /// 删除供应商信息。
        /// </summary>
        /// <param name="supplierId">供应商标识。</param>
        void RemoveSupplier(Guid supplierId);

        /// <summary>
        /// 指定的供应商名称是否存在。
        /// </summary>
        /// <param name="supplierName">供应商名称。</param>
        /// <returns>存在返回 true，否则返回 false。</returns>
        bool IsSupplierNameExists(string supplierName);

        /// <summary>
        /// 根据供应商名称获取供应商信息。
        /// </summary>
        /// <param name="supplierName">供应商名称。</param>
        /// <returns>返回供应商信息。</returns>
        SupplierDTO GetSupplier(string supplierName);

        /// <summary>
        /// 查找前 N 条符合供应商名称的物料信息。
        /// </summary>
        /// <param name="topN">指定要获取的条数。</param>
        /// <param name="supplierName">供应商名称。</param>
        /// <returns>返回符合条件的供应商信息列表。</returns>
        List<SupplierDTO> FindMatchedSuppliers(int topN, string supplierName);

        /// <summary>
        /// 分页查找供应商信息。
        /// </summary>
        /// <param name="pageIndex">分页序号。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="findText">查询的内容。</param>
        /// <returns>返回符合条件的分页供应商信息集合。</returns>
        PagedDataSet<SupplierDTO> FindSuppliers(int pageIndex, int pageSize, string findText);
    }
}
