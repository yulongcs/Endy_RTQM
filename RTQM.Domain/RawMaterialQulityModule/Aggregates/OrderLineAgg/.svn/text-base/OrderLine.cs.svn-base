using System;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg
{
    /// <summary>
    /// 采购订单行。
    /// </summary>
    public class OrderLine : Entity
    {
        /// <summary>
        /// 批号。
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 所属采购订单标识。
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// 所属采购订单。
        /// </summary>
        public virtual PurchaseOrder Order { get; private set; }

        /// <summary>
        /// 物料标识。
        /// </summary>
        public Guid MaterialId { get; set; }

        /// <summary>
        /// 物料。
        /// </summary>
        public virtual Material Material { get; private set; }

        /// <summary>
        /// 供应商标识。
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// 供应商。
        /// </summary>
        public virtual Supplier Supplier { get; private set; }

        /// <summary>
        /// 物料类型。
        /// </summary>
        public int MaterialType { get; set; }

        /// <summary>
        /// 物料检验结果。
        /// </summary>
        public virtual InspectResult InspectResult { get; set; }

        public void SetOrder(PurchaseOrder order)
        {
            if (order == null || order.IsTransient())
                throw new ArgumentNullException("order", "不能设置空的或临时的采购订单。");

            OrderId = order.Id;
            Order = order;
        }

        public void SetMaterial(Material material)
        {
            if (material == null || material.IsTransient())
                throw new ArgumentNullException("material", "不能设置空的或临时的物料。");

            MaterialId = material.Id;
            Material = material;
        }

        public void SetSupplier(Supplier supplier)
        {
            if (supplier == null || supplier.IsTransient())
                throw new ArgumentNullException("supplier", "不能设置空的或临时的供应商。");

            SupplierId = supplier.Id;
            Supplier = supplier;
        }
    }
}
