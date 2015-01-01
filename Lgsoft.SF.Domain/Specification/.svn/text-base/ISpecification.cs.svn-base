using System;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// “规范模式”接口。
    /// </summary>
    /// <typeparam name="TEntity">用于规范的实体类型。</typeparam>
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 检查当前规范要满足的特定 Lambda 表达式。
        /// </summary>
        /// <returns>返回 Lambda 表达式。</returns>
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
