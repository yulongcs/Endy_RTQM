namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 复合规范的基类。
    /// </summary>
    /// <typeparam name="TEntity">实体对象类型。</typeparam>
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
         where TEntity : class
    {
        #region 属性

        /// <summary>
        /// 获取左操作规范。
        /// </summary>
        public abstract ISpecification<TEntity> LeftSideSpecification { get; }

        /// <summary>
        /// 获取右操作规范。
        /// </summary>
        public abstract ISpecification<TEntity> RightSideSpecification { get; }

        #endregion
    }
}
