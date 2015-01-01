using System;
using System.Collections.Generic;
using System.Linq;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.SF.Domain;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.BaseInfoModule.Services
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly ITypeAdapter _typeAdapter;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierAppService(ITypeAdapter typeAdapter, ISupplierRepository materialRepository)
        {
            _typeAdapter = typeAdapter;
            _supplierRepository = materialRepository;
        }

        #region Implementation of ISupplierAppService

        public SupplierDTO CreateNewSupplier(SupplierDTO supplierDTO)
        {
            if (supplierDTO == null)
                return null;

            var supplier = SupplierFactory.CreateSupplier(supplierDTO.SupplierName);
            supplier.Id = IdentityGenerator.NewSequentialGuid();

            _supplierRepository.Add(supplier);

            _supplierRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<Supplier, SupplierDTO>(supplier);
        }

        public SupplierDTO UpdateSupplier(SupplierDTO supplierDTO)
        {
            if (supplierDTO == null || supplierDTO.Id == Guid.Empty)
                return null;

            var persisted = _supplierRepository.Get(supplierDTO.Id);

            if (persisted == null)
                return null;

            var current = SupplierFactory.CreateSupplier(supplierDTO.SupplierName);
            current.Id = supplierDTO.Id;

            _supplierRepository.Merge(persisted, current);

            _supplierRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<Supplier, SupplierDTO>(persisted);
        }

        public void RemoveSupplier(Guid supplierId)
        {
            if (supplierId == Guid.Empty)
                return;

            var supplier = _supplierRepository.Get(supplierId);

            if (supplier != null)
            {
                supplier.Disable();

                _supplierRepository.UnitOfWork.Commit();
            }
        }

        public bool IsSupplierNameExists(string supplierName)
        {
            var spec = SupplierSpecifications.SupplierNameExactMatching(supplierName);

            var count = _supplierRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return count > 0;
        }

        public SupplierDTO GetSupplier(string supplierName)
        {
            var spec = SupplierSpecifications.SupplierNameExactMatching(supplierName);

            var supplier = _supplierRepository.AllMatching(spec).SingleOrDefault();

            return supplier != null ? _typeAdapter.Adapt<Supplier, SupplierDTO>(supplier) : null;
        }

        public List<SupplierDTO> FindMatchedSuppliers(int topN, string supplierName)
        {
            var spec = SupplierSpecifications.SupplierName(supplierName);

            var suppliers = _supplierRepository.GetPaged(0, topN, spec, m => m.SupplierName, true);

            return _typeAdapter.Adapt<IEnumerable<Supplier>, List<SupplierDTO>>(suppliers);
        }

        public PagedDataSet<SupplierDTO> FindSuppliers(int pageIndex, int pageSize, string findText)
        {
            var spec = SupplierSpecifications.SupplierName(findText);

            var suppliers = _supplierRepository.GetPaged(pageIndex, pageSize, spec, m => m.Id, true);
            var count = _supplierRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return new PagedDataSet<SupplierDTO>
                       {
                           PageIndex = pageIndex,
                           PageSize = pageSize,
                           DataCount = count,
                           CurrentPageDataSet =
                               _typeAdapter.Adapt<IEnumerable<Supplier>, List<SupplierDTO>>(suppliers),
                       };
        }

        #endregion
    }
}
