using System;
using System.Collections.Generic;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.SF.Infrastructure.CrossCutting;

namespace Lgsoft.RTQM.Application.BaseInfoModule.Services
{
    /// <summary>
    /// 物料应用服务接口。
    /// </summary>
    public interface IMaterialAppService
    {
        /// <summary>
        /// 添加物料信息。
        /// </summary>
        /// <param name="materialDTO">物料信息。</param>
        /// <returns>返回添加的物料信息。</returns>
        MaterialDTO CreateNewMaterial(MaterialDTO materialDTO);

        /// <summary>
        /// 更新物料信息。
        /// </summary>
        /// <param name="materialDTO">物料信息。</param>
        MaterialDTO UpdateMaterial(MaterialDTO materialDTO);

        /// <summary>
        /// 删除物料信息。
        /// </summary>
        /// <param name="materialId">物料标识。</param>
        void RemoveMaterial(Guid materialId);

        /// <summary>
        /// 指定的物料编号是否存在。
        /// </summary>
        /// <param name="materialNo">物料编号。</param>
        /// <returns>存在返回 true，否则返回 false。</returns>
        bool IsMaterialNoExists(string materialNo);

        /// <summary>
        /// 根据物料编号获取物料信息。
        /// </summary>
        /// <param name="materialNo">物料编号。</param>
        /// <returns>返回物料信息。</returns>
        MaterialDTO GetMaterial(string materialNo);

        /// <summary>
        /// 查找前 N 条符合物料编号的物料信息。
        /// </summary>
        /// <param name="topN">指定要获取的条数。</param>
        /// <param name="materialNo">物料编号。</param>
        /// <returns>返回符合条件的物料信息列表。</returns>
        List<MaterialDTO> FindMatchedMaterials(int topN, string materialNo);

        /// <summary>
        /// 分页查找物料信息。
        /// </summary>
        /// <param name="pageIndex">分页序号。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="findText">查询的内容。</param>
        /// <returns>返回符合条件的分页物料信息集合。</returns>
        PagedDataSet<MaterialDTO> FindMaterials(int pageIndex, int pageSize, string findText);
    }
}
