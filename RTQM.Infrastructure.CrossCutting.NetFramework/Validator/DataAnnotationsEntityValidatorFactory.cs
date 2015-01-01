using Lgsoft.SF.Infrastructure.CrossCutting.Validator;

namespace Lgsoft.RTQM.Infrastructure.CrossCutting.NetFramework.Validator
{
    /// <summary>
    /// Data Annotations based entity validator factory
    /// </summary>
    public class DataAnnotationsEntityValidatorFactory
        :IEntityValidatorFactory
    {
        /// <summary>
        /// Create a entity validator
        /// </summary>
        /// <returns></returns>
        public IEntityValidator Create()
        {
            return new DataAnnotationsEntityValidator();
        }
    }
}
