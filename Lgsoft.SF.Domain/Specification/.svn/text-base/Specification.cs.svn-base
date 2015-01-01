using System;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 用于实体规范的基类。
    /// </summary>
    /// <typeparam name="TEntity">用于规范的实体类型。</typeparam>
    public abstract class Specification<TEntity>
        : ISpecification<TEntity>
        where TEntity : class
    {
        #region Implementation of ISpecification<TEntity>

        public abstract Expression<Func<TEntity, bool>> SatisfiedBy();

        #endregion

        #region 重载运算符

        /// <summary>
        /// And 运算符。
        /// </summary>
        /// <param name="leftSideSpecification">AND 运算符的左操作规范。</param>
        /// <param name="rightSideSpecification">AND 运算符的右操作规范。</param>
        /// <returns>返回新的规范。</returns>
        public static Specification<TEntity> operator &(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
        {
            return new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }
        /// <summary>
        /// Or 运算符。
        /// </summary>
        /// <param name="leftSideSpecification">OR 运算符的左操作规范。</param>
        /// <param name="rightSideSpecification">OR 运算符的右操作规范。</param>
        /// <returns>返回新的规范。</returns>
        public static Specification<TEntity> operator |(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
        {
            return new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }
        /// <summary>
        /// Not 运算符。
        /// </summary>
        /// <param name="specification">否定的规范。</param>
        /// <returns>返回新的规范。</returns>
        public static Specification<TEntity> operator !(Specification<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }

        /// <summary>
        /// 重载 false 运算符，只用于支持 AND 和 OR 运算符。
        /// </summary>
        /// <param name="specification">规范实例。</param>
        /// <returns>参考 C# false 运算符。</returns>
        public static bool operator false(Specification<TEntity> specification)
        {
            return false;
        }
        /// <summary>
        /// 重载 true 运算符，只用于支持 AND 和 OR 运算符。
        /// </summary>
        /// <param name="specification">规范实例。</param>
        /// <returns>参考 C# false 运算符。</returns>
        public static bool operator true(Specification<TEntity> specification)
        {
            return true;
        }

        #endregion
    }
}
