using System;
using System.Collections.Generic;

namespace Lgsoft.RTQM.Application
{
    /// <summary>
    /// 数据验证异常。
    /// </summary>
    public class ApplicationValidationErrorsException : Exception
    {
        #region Properties

        private IEnumerable<string> _validationErrors;
        /// <summary>
        /// 获取验证错误信息。
        /// </summary>
        public IEnumerable<string> ValidationErrors
        {
            get
            {
                return _validationErrors;
            }
        }

        #endregion

        #region Constructor

        public ApplicationValidationErrorsException(IEnumerable<string> validationErrors)
            : base("数据验证异常，使用 ValidationErrors 属性了解更多信息。")
        {
            _validationErrors = validationErrors;
        }

        #endregion
    }
}
