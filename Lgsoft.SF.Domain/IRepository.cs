using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.SF.Domain
{
    /// <summary>
    /// “仓库模式”接口。
    /// </summary>
    /// <typeparam name="TEntity">用于仓库的实体类型。</typeparam>
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// 获取当前仓库的工作单元。
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 添加实体对象到仓库。
        /// </summary>
        /// <param name="item">要添加的实体对象。</param>
        void Add(TEntity item);

        /// <summary>
        /// 从仓库删除实体对象。
        /// </summary>
        /// <param name="item">要删除的实体对象。</param>
        void Remove(TEntity item);

        /// <summary>
        /// 在仓库中跟踪一个实体对象的状态。
        /// </summary>
        /// <param name="item">要附加的实体对象。</param>
        void TrackItem(TEntity item);

        /// <summary>
        /// 在仓库中将一个实体对象设置为已更改。
        /// </summary>
        /// <param name="item">要设置的实体对象。</param>
        void Modify(TEntity item);
        
        /// <summary>
        /// 将实体对象的更改设置到仓库中。
        /// </summary>
        /// <param name="persisted">已持久化的实体对象。</param>
        /// <param name="current">拥有更改的实体对象。</param>
        void Merge(TEntity persisted, TEntity current);

        /// <summary>
        /// 通过实体标识获取实体对象。
        /// </summary>
        /// <param name="id">实体标识。</param>
        /// <returns>返回实体对象。</returns>
        TEntity Get(Guid id);

        /// <summary>
        /// 获取仓库中所有的实体对象。
        /// </summary>
        /// <returns>返回包括所有实体对象的枚举集合。</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 获取所有满足规范要求的实体对象。
        /// </summary>
        /// <param name="specification">要满足的规范要求。</param>
        /// <returns>返回满足规范要求的实体对象的枚举集合。</returns>
        IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification);

        /// <summary>
        /// 分页获取满足规范要求的实体对象并对结果进行排序。
        /// </summary>
        /// <typeparam name="TProperty">排序属性的类型。</typeparam>
        /// <param name="pageIndex">分页序号，从0开始。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="specification">要满足的规范要求。</param>
        /// <param name="orderByExpression">指定排序属性的表达式。</param>
        /// <param name="ascending">是否正序排序。</param>
        /// <returns>返回满足规范要求并经过排序的实体对象的枚举集合。</returns>
        IEnumerable<TEntity> GetPaged<TProperty>(int pageIndex, int pageSize, ISpecification<TEntity> specification,
                                                 Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);
    }
}
