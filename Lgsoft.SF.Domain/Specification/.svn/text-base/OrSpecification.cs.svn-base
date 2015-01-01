using System;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 逻辑 OR 规范。
    /// </summary>
    /// <typeparam name="TEntity">实体对象类型。</typeparam>
    public class OrSpecification<TEntity> : CompositeSpecification<TEntity>
         where TEntity : class
    {
        #region 私有成员

        private readonly ISpecification<TEntity> _rightSideSpecification;
        private readonly ISpecification<TEntity> _leftSideSpecification;

        #endregion

        #region 公开构造方法

        /// <summary>
        /// 初始化 OrSpecification 的新实例。
        /// </summary>
        /// <param name="leftSide">左操作规范。</param>
        /// <param name="rightSide">右操作规范。</param>
        public OrSpecification(ISpecification<TEntity> leftSide, ISpecification<TEntity> rightSide)
        {
            if (leftSide == null)
                throw new ArgumentNullException("leftSide");

            if (rightSide == null)
                throw new ArgumentNullException("rightSide");

            _leftSideSpecification = leftSide;
            _rightSideSpecification = rightSide;
        }

        #endregion

        #region 重写 CompositeSpecification

        /// <summary>
        /// 获取左操作规范。
        /// </summary>
        public override ISpecification<TEntity> LeftSideSpecification
        {
            get { return _leftSideSpecification; }
        }

        /// <summary>
        /// 获取右操作规范。
        /// </summary>
        public override ISpecification<TEntity> RightSideSpecification
        {
            get { return _rightSideSpecification; }
        }
        /// <summary>
        /// 获取满足当前规范的 Lambda 表达式。
        /// </summary>
        /// <returns>返回描述规范的 Lambda 表达式。</returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            var left = _leftSideSpecification.SatisfiedBy();
            var right = _rightSideSpecification.SatisfiedBy();

            return (left.Or(right));
        }

        #endregion
    }
}
