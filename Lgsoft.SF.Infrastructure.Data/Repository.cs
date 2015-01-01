using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Lgsoft.SF.Domain;
using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.SF.Infrastructure.Data
{
    /// <summary>
    /// Repository base class
    /// </summary>
    /// <typeparam name="TEntity">The type of underlying entity in this repository</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        #region Members

        readonly IQueryableUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository Members

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {
            if (item != null)
                GetSet().Add(item); // add new item in this set
            else
            {
                // TODO: Log
            }
        }

        public virtual void Remove(TEntity item)
        {
            if (item != null)
            {
                //attach item if not exist
                _unitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
            else
            {
                // TODO: Log
            }
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != null)
                _unitOfWork.Attach(item);
            else
            {
                // TODO: Log
            }
        }

        public virtual void Modify(TEntity item)
        {
            if (item != null)
                _unitOfWork.SetModified(item);
            else
            {
                // TODO: Log
            }
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _unitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual TEntity Get(Guid id)
        {
            if (id != Guid.Empty)
                return GetSet().Find(id);
            return null;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification)
        {
            return GetSet().Where(specification.SatisfiedBy())
                           .AsEnumerable();
        }

        public virtual IEnumerable<TEntity> GetPaged<TProperty>(int pageIndex, int pageSize,
                                                                ISpecification<TEntity> specification,
                                                                Expression<Func<TEntity, TProperty>> orderByExpression,
                                                                bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.Where(specification.SatisfiedBy())
                    .OrderBy(orderByExpression)
                    .Skip(pageSize*pageIndex)
                    .Take(pageSize)
                    .AsEnumerable();
            }
            else
            {
                return set.Where(specification.SatisfiedBy())
                    .OrderByDescending(orderByExpression)
                    .Skip(pageSize*pageIndex)
                    .Take(pageSize)
                    .AsEnumerable();
            }
        }

        #endregion

        #region Private Methods

        IDbSet<TEntity> GetSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }

        #endregion
    }
}
