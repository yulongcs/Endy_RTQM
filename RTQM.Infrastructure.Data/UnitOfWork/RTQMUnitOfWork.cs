using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork.Mapping;

namespace Lgsoft.RTQM.Infrastructure.Data.UnitOfWork
{
    public class RTQMUnitOfWork : DbContext, IRTQMUnitOfWork
    {
        #region Implementation of IRTQMUnitOfWork

        private IDbSet<Material> _materials;
        public IDbSet<Material> Materials
        {
            get
            {
                if (_materials == null)
                    _materials = Set<Material>();
                return _materials;
            }
        }

        private IDbSet<Supplier> _suppliers;
        public IDbSet<Supplier> Suppliers
        {
            get
            {
                if (_suppliers == null)
                    _suppliers = Set<Supplier>();
                return _suppliers;
            }
        }

        private IDbSet<PurchaseOrder> _purchaseOrders;
        public IDbSet<PurchaseOrder> PurchaseOrders
        {
            get
            {
                if (_purchaseOrders == null)
                    _purchaseOrders = Set<PurchaseOrder>();
                return _purchaseOrders;
            }
        }

        private IDbSet<OrderLine> _orderLines;
        public IDbSet<OrderLine> OrderLines
        {
            get
            {
                if (_orderLines == null)
                    _orderLines = Set<OrderLine>();
                return _orderLines;
            }
        }

        #endregion

        #region Implementation of ISql

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region Implementation of IQueryableUnitOfWork

        public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            Entry(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            Entry(item).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            Entry(original).CurrentValues.SetValues(current);
        }

        #endregion

        #region Implementation of IUnitOfWork

        public void Commit()
        {
            SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed;

            do
            {
                saveFailed = false;
                try
                {
                    SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                        .ForEach(entry =>
                                     {
                                         entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                                     });
                }
            } while (saveFailed);
        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new MaterialEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new SupplierEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PurchaseOrderEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new OrderLineEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new DisqualificationReportEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FileEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new UserEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityTypeConfiguration());
        }

        #endregion
    }
}
