using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg
{
    /// <summary>
    /// 物料。
    /// </summary>
    public class Material : Entity, IValidatableObject
    {
        /// <summary>
        /// 物料编号。
        /// </summary>
        public string MaterialNo { get; set; }

        /// <summary>
        /// 物料描述。
        /// </summary>
        public string MaterialDescrption { get; set; }

        /// <summary>
        /// 物料是否已经删除。
        /// </summary>
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// 将物料设置为未删除。
        /// </summary>
        public void Enable()
        {
            if (IsDeleted)
                IsDeleted = false;
        }

        /// <summary>
        /// 将物料设置为已删除。
        /// </summary>
        public void Disable()
        {
            if (!IsDeleted)
                IsDeleted = true;
        }

        #region Implementation of IValidatableObject

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(MaterialNo))
                validationResults.Add(new ValidationResult("物料编号不能为空。", new[] {"MaterialNo"}));

            return validationResults;
        }

        #endregion
    }
}
