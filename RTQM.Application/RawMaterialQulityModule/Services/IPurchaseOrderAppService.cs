using System;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.SF.Infrastructure.CrossCutting;

namespace Lgsoft.RTQM.Application.RawMaterialQulityModule.Services
{
    /// <summary>
    /// 采购订单应用服务。
    /// </summary>
    public interface IPurchaseOrderAppService
    {
        /// <summary>
        /// 创建采购订单信息。
        /// </summary>
        /// <param name="orderDTO">采购订单信息。</param>
        /// <returns>返回创建的采购订单信息。</returns>
        PurchaseOrderDTO CreateNewPurchaseOrder(PurchaseOrderDTO orderDTO);

        /// <summary>
        /// 删除采购订单信息。
        /// </summary>
        /// <param name="orderId">采购订单标识。</param>
        void RemovePurchaseOrder(Guid orderId);

        /// <summary>
        /// 指定的采购订单编号是否存在。
        /// </summary>
        /// <param name="orderNo">采购订单编号。</param>
        /// <returns>存在返回 true，否则返回 false。</returns>
        bool IsOrderNoExists(string orderNo);

        /// <summary>
        /// 根据采购订单标识获取采购订单信息。
        /// </summary>
        /// <param name="orderId">采购订单标识。</param>
        /// <returns>返回采购订单信息。</returns>
        PurchaseOrderDTO GetPurchaseOrder(Guid orderId);

        /// <summary>
        /// 分页查找采购订单信息。
        /// </summary>
        /// <param name="pageIndex">分页序号。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="findText">查询的内容，包括订单编号。</param>
        /// <param name="startDate">查询的开始日期。</param>
        /// <param name="endDate">查询的结束日期。</param>
        /// <param name="sortField">排序字段。</param>
        /// <param name="ascending">是否正序。</param>
        /// <returns>返回符合条件的分页采购订单信息集合。</returns>
        PagedDataSet<PurchaseOrderDTO> FindPurchaseOrders(int pageIndex, int pageSize, string findText,
                                                          DateTime startDate, DateTime endDate,
                                                          PurchaseOrderListSortFields sortField, bool ascending);

        /// <summary>
        /// 创建采购订单行信息。
        /// </summary>
        /// <param name="orderLineDTO">采购订单行信息。</param>
        /// <returns>返回创建的采购订单行信息。</returns>
        OrderLineDTO CreateNewOrderLine(OrderLineDTO orderLineDTO);

        /// <summary>
        /// 更新采购订单行信息。
        /// </summary>
        /// <param name="orderLineDTO">采购订单行信息。</param>
        OrderLineDTO UpdateOrderLine(OrderLineDTO orderLineDTO);

        /// <summary>
        /// 删除采购订单行信息。
        /// </summary>
        /// <param name="orderLineId">采购订单行标识。</param>
        void RemoveOrderLine(Guid orderLineId);

        /// <summary>
        /// 指定的批号是否存在。
        /// </summary>
        /// <param name="batchNo">批号。</param>
        /// <returns>存在返回 true，否则返回 false。</returns>
        bool IsBatchNoExists(string batchNo);

        /// <summary>
        /// 根据采购订单行标识获取采购订单行信息。
        /// </summary>
        /// <param name="orderLineId">采购订单行标识。</param>
        /// <returns>返回采购订单行信息。</returns>
        OrderLineDTO GetOrderLine(Guid orderLineId);

        /// <summary>
        /// 分页查找采购订单信息。
        /// </summary>
        /// <param name="pageIndex">分页序号。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="findParams">查询参数。</param>
        /// <param name="sortField">排序字段。</param>
        /// <param name="ascending">是否正序。</param>
        /// <returns>返回符合条件的分页采购订单行信息集合。</returns>
        PagedDataSet<OrderLineDTO> FindOrderLines(int pageIndex, int pageSize, OrderLineFindParameters findParams,
                                                  OrderLineListSortFields sortField, bool ascending);
    }
}