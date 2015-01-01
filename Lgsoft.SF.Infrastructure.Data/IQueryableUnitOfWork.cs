using System.Data.Entity;
using Lgsoft.SF.Domain;

namespace Lgsoft.SF.Infrastructure.Data
{
    /// <summary>
    /// Entity Framework 对 UnitOfWork 的实现。
    /// </summary>
    public interface IQueryableUnitOfWork : IUnitOfWork, ISql
    {
        /// <summary>
        /// 从上下文中返回指定实体类型的 IDbSet 对象。
        /// </summary>
        /// <typeparam name="TEntity">实体类型。</typeparam>
        /// <returns>返回该实体类型的 IDbSet 对象。</returns>
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        /// <summary>
        /// 将实体对象附加到 ObjectStateManager 中。
        /// </summary>
        /// <typeparam name="TEntity">实体类型。</typeparam>
        /// <param name="item">实体对象。</param>
        void Attach<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// 设置实体对象为已更改。
        /// </summary>
        /// <typeparam name="TEntity">实体类型。</typeparam>
        /// <param name="item">实体对象。</param>
        void SetModified<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// 将当前实体对象值应用到原始实体对象上。
        /// </summary>
        /// <typeparam name="TEntity">实体类型。</typeparam>
        /// <param name="original">原始实体对象。</param>
        /// <param name="current">当前实体对象。</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
    }
}
