using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 将原始规范使用 NOT 逻辑运算符转换为相反规范。
    /// </summary>
    /// <typeparam name="TEntity">实体对象类型。</typeparam>
    public class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region 私有成员

        readonly Expression<Func<TEntity, bool>> _originalCriteria;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 NotSpecification 的新实例。
        /// </summary>
        /// <param name="originalSpecification">原始规范。</param>
        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {

            if (originalSpecification == null)
                throw new ArgumentNullException("originalSpecification");

            _originalCriteria = originalSpecification.SatisfiedBy();
        }

        /// <summary>
        /// 初始化 NotSpecification 的新实例。
        /// </summary>
        /// <param name="originalSpecification">原始规范。</param>
        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            if (originalSpecification == null)
                throw new ArgumentNullException("originalSpecification");

            _originalCriteria = originalSpecification;
        }

        #endregion

        #region 重写 Specification

        /// <summary>
        /// 获取满足当前规范的 Lambda 表达式。
        /// </summary>
        /// <returns>返回描述规范的 Lambda 表达式。</returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(_originalCriteria.Body),
                                                         _originalCriteria.Parameters.Single());
        }

        #endregion
    }
}
