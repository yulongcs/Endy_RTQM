using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg
{
    /// <summary>
    /// 采购订单。
    /// </summary>
    public class PurchaseOrder : Entity, IValidatableObject
    {
        /// <summary>
        /// 采购订单编号。
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 采购订单日期。
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 采购订单中条目总数。
        /// </summary>
        public int ItemCount { get; internal set; }

        public void IncreaseItemCount()
        {
            ItemCount++;
        }

        public void DecreaseItemCount()
        {
            ItemCount--;
        }

        #region Implementation of IValidatableObject

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(OrderNo))
                results.Add(new ValidationResult("采购订单编号不能空。", new[] {"OrderNo"}));

            return results;
        }

        #endregion
    }
}
