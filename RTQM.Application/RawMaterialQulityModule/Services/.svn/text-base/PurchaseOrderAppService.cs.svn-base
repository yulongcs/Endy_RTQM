using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.SF.Domain;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.RawMaterialQulityModule.Services
{
    public class PurchaseOrderAppService : IPurchaseOrderAppService
    {
        private readonly ITypeAdapter _typeAdapter;
        private readonly IPurchaseOrderRepository _orderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly ISupplierRepository _supplierRepository;

        public PurchaseOrderAppService(ITypeAdapter typeAdapter, IPurchaseOrderRepository orderRepository,
                                       IOrderLineRepository orderLineRepository, IMaterialRepository materialRepository,
                                       ISupplierRepository supplierRepository)
        {
            _typeAdapter = typeAdapter;
            _orderRepository = orderRepository;
            _orderLineRepository = orderLineRepository;
            _materialRepository = materialRepository;
            _supplierRepository = supplierRepository;
        }

        #region Implementation of IPurchaseOrderAppService

        public PurchaseOrderDTO CreateNewPurchaseOrder(PurchaseOrderDTO orderDTO)
        {
            if (orderDTO == null)
                return null;

            var order = PurchaseOrderFactory.CreatePurchaseOrder(orderDTO.OrderNo, orderDTO.OrderDate);
            order.Id = IdentityGenerator.NewSequentialGuid();

            _orderRepository.Add(order);

            _orderRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<PurchaseOrder, PurchaseOrderDTO>(order);
        }

        public void RemovePurchaseOrder(Guid orderId)
        {
            if (orderId == Guid.Empty)
                return;

            var order = _orderRepository.Get(orderId);

            if (order != null)
            {
                _orderRepository.Remove(order);

                _orderRepository.UnitOfWork.Commit();
            }
        }

        public bool IsOrderNoExists(string orderNo)
        {
            var spec = PurchaseOrderSpecifications.OrderNoExactMatching(orderNo);

            var count = _orderRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return count > 0;
        }

        public PurchaseOrderDTO GetPurchaseOrder(Guid orderId)
        {
            if (orderId == Guid.Empty)
                return null;

            var order = _orderRepository.Get(orderId);

            return order != null ? _typeAdapter.Adapt<PurchaseOrder, PurchaseOrderDTO>(order) : null;
        }

        public PagedDataSet<PurchaseOrderDTO> FindPurchaseOrders(int pageIndex, int pageSize, string findText,
                                                                 DateTime startDate, DateTime endDate,
                                                                 PurchaseOrderListSortFields sortField, bool @ascending)
        {
            var spec = PurchaseOrderSpecifications.OrderNo(findText)
                       & PurchaseOrderSpecifications.OrderDate(startDate, endDate);

            IEnumerable<PurchaseOrder> orders;
            switch (sortField)
            {
                case PurchaseOrderListSortFields.OrderDate:
                    orders = _orderRepository.GetPaged(pageIndex, pageSize, spec, po => po.OrderDate, ascending);
                    break;
                default:
                    orders = _orderRepository.GetPaged(pageIndex, pageSize, spec, po => po.Id, ascending);
                    break;
            }

            var count = _orderRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return new PagedDataSet<PurchaseOrderDTO>
                       {
                           PageIndex = pageIndex,
                           PageSize = pageSize,
                           DataCount = count,
                           CurrentPageDataSet =
                               _typeAdapter.Adapt<IEnumerable<PurchaseOrder>, List<PurchaseOrderDTO>>(orders),
                       };
        }

        public OrderLineDTO CreateNewOrderLine(OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null)
                return null;

            var order = _orderRepository.Get(orderLineDTO.OrderId);
            var material = _materialRepository.Get(orderLineDTO.MaterialId);
            var supplier = _supplierRepository.Get(orderLineDTO.SupplierId);

            if (order == null || material == null || supplier == null)
                return null;

            var orderLine = OrderLineFactory.CreateOrderLine(order, material, supplier, orderLineDTO.BatchNo,
                                                             (int)orderLineDTO.MaterialType, orderLineDTO.DefectDescrption,
                                                             orderLineDTO.Total, orderLineDTO.ConcessionCount,
                                                             orderLineDTO.ReworkCount, orderLineDTO.RejectionCount,
                                                             orderLineDTO.ScrapCount);
            orderLine.Id = IdentityGenerator.NewSequentialGuid();

            using (var transaction = new TransactionScope())
            {
                _orderLineRepository.Add(orderLine);
                order.IncreaseItemCount();

                _orderLineRepository.UnitOfWork.Commit();
                _orderRepository.UnitOfWork.Commit();

                transaction.Complete();
            }
            return _typeAdapter.Adapt<OrderLine, OrderLineDTO>(orderLine);
        }

        public OrderLineDTO UpdateOrderLine(OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null || orderLineDTO.Id == Guid.Empty)
                return null;

            var persisted = _orderLineRepository.Get(orderLineDTO.Id);

            if (persisted == null)
                return null;

            var order = _orderRepository.Get(persisted.OrderId);
            var material = _materialRepository.Get(orderLineDTO.MaterialId);
            var supplier = _supplierRepository.Get(orderLineDTO.SupplierId);

            if (order == null || material == null || supplier == null)
                return null;

            var current = OrderLineFactory.CreateOrderLine(order, material, supplier, orderLineDTO.BatchNo,
                                                           (int)orderLineDTO.MaterialType, orderLineDTO.DefectDescrption,
                                                           orderLineDTO.Total, orderLineDTO.ConcessionCount,
                                                           orderLineDTO.ReworkCount, orderLineDTO.RejectionCount,
                                                           orderLineDTO.ScrapCount);
            current.Id = orderLineDTO.Id;

            _orderLineRepository.Merge(persisted, current);

            _orderLineRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<OrderLine, OrderLineDTO>(persisted);
        }

        public void RemoveOrderLine(Guid orderId)
        {
            if (orderId == Guid.Empty)
                return;

            var orderLine = _orderLineRepository.Get(orderId);

            if (orderLine != null)
            {
                var order = _orderRepository.Get(orderLine.OrderId);

                using (var transaction = new TransactionScope())
                {
                    _orderLineRepository.Remove(orderLine);
                    order.DecreaseItemCount();

                    _orderLineRepository.UnitOfWork.Commit();
                    _orderRepository.UnitOfWork.Commit();

                    transaction.Complete();
                }
            }
        }

        public bool IsBatchNoExists(string batchNo)
        {
            var spec = OrderLineSpecifications.BatchNoExactMatching(batchNo);

            var count = _orderLineRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return count > 0;
        }

        public OrderLineDTO GetOrderLine(Guid orderLineId)
        {
            if (orderLineId == Guid.Empty)
                return null;

            var orderLine = _orderLineRepository.Get(orderLineId);

            return orderLine != null ? _typeAdapter.Adapt<OrderLine, OrderLineDTO>(orderLine) : null;
        }

        public PagedDataSet<OrderLineDTO> FindOrderLines(int pageIndex, int pageSize, OrderLineFindParameters findParams,
                                                         OrderLineListSortFields sortField, bool @ascending)
        {
            var spec = OrderLineSpecifications.OrderId(findParams.OrderId)
                       & OrderLineSpecifications.OrderNo(findParams.OrderNo)
                       & OrderLineSpecifications.OrderDate(findParams.StartOrderDate, findParams.EndOrderDate)
                       & OrderLineSpecifications.BatchNo(findParams.BatchNo)
                       & OrderLineSpecifications.MaterialNo(findParams.MaterialNo)
                       & OrderLineSpecifications.SupplierName(findParams.SupplierName)
                       & OrderLineSpecifications.Conformance(findParams.LowConformance, findParams.HighConformance);

            IEnumerable<OrderLine> orderLines;
            switch (sortField)
            {
                case OrderLineListSortFields.OrderNo:
                    orderLines = _orderLineRepository.GetPaged(pageIndex, pageSize, spec, ol => ol.Order.OrderNo,
                                                               ascending);
                    break;
                case OrderLineListSortFields.OrderDate:
                    orderLines = _orderLineRepository.GetPaged(pageIndex, pageSize, spec, ol => ol.Order.OrderDate,
                                                               ascending);
                    break;
                case OrderLineListSortFields.BatchNo:
                    orderLines = _orderLineRepository.GetPaged(pageIndex, pageSize, spec, ol => ol.BatchNo, ascending);
                    break;
                case OrderLineListSortFields.MaterialNo:
                    orderLines = _orderLineRepository.GetPaged(pageIndex, pageSize, spec, ol => ol.Material.MaterialNo,
                                                               ascending);
                    break;
                case OrderLineListSortFields.SupplierName:
                    orderLines = _orderLineRepository.GetPaged(pageIndex, pageSize, spec, ol => ol.Supplier.SupplierName,
                                                               ascending);
                    break;
                case OrderLineListSortFields.Conformance:
                    orderLines = _orderLineRepository.GetPaged(pageIndex, pageSize, spec,
                                                               ol => ol.InspectResult.Conformance, ascending);
                    break;
                default:
                    orderLines = _orderLineRepository.GetPaged(pageIndex, pageSize, spec, ol => ol.Id, ascending);
                    break;
            }

            var count = _orderLineRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return new PagedDataSet<OrderLineDTO>
                       {
                           PageIndex = pageIndex,
                           PageSize = pageSize,
                           DataCount = count,
                           CurrentPageDataSet =
                               _typeAdapter.Adapt<IEnumerable<OrderLine>, List<OrderLineDTO>>(orderLines),
                       };
        }

        #endregion
    }
}
