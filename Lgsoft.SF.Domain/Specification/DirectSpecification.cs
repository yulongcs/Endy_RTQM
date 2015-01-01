using System;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 直接规范实现了一个要求 Lambda 表达式的规范。
    /// </summary>
    /// <typeparam name="TEntity">实体对象类型。</typeparam>
    public class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region 私有成员

        readonly Expression<Func<TEntity, bool>> _matchingCriteria;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 DirectSpecification 的新实例。
        /// </summary>
        /// <param name="matchingCriteria">匹配的标准。</param>
        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
                throw new ArgumentNullException("matchingCriteria");

            _matchingCriteria = matchingCriteria;
        }

        #endregion

        #region 重写 Specification

        /// <summary>
        /// 获取满足当前规范的 Lambda 表达式。
        /// </summary>
        /// <returns>返回描述规范的 Lambda 表达式。</returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }

        #endregion
    }
}
