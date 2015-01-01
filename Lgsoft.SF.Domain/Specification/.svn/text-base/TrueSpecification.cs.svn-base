using System;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 求真规范。
    /// </summary>
    /// <typeparam name="TEntity">业务对象类型。</typeparam>
    public class TrueSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region 重写 Specification

        /// <summary>
        /// 获取满足当前规范的 Lambda 表达式。
        /// </summary>
        /// <returns>返回描述规范的 Lambda 表达式。</returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            Expression<Func<TEntity, bool>> trueExpression = t => true;
            return trueExpression;
        }

        #endregion
    }
}
