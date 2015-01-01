using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg
{
    /// <summary>
    /// 供应商。
    /// </summary>
    public class Supplier : Entity, IValidatableObject
    {
        /// <summary>
        /// 供应商名称。
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 供应商是否已经删除。
        /// </summary>
        public bool IsDelete { get; set; }

        public void Enable()
        {
            if (IsDelete)
                IsDelete = false;
        }

        public void Disable()
        {
            if (!IsDelete)
                IsDelete = true;
        }

        #region Implementation of IValidatableObject

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(SupplierName))
                validationResults.Add(new ValidationResult("供应商名称不能为空。", new[] {"SupplierName"}));

            return validationResults;
        }

        #endregion
    }
}
