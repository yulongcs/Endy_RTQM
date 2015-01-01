using System;
using System.Collections.Generic;
using System.Linq;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.SF.Domain;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.BaseInfoModule.Services
{
    public class MaterialAppService : IMaterialAppService
    {
        private readonly ITypeAdapter _typeAdapter;
        private readonly IMaterialRepository _materialRepository;

        public MaterialAppService(ITypeAdapter typeAdapter, IMaterialRepository materialRepository)
        {
            _typeAdapter = typeAdapter;
            _materialRepository = materialRepository;
        }

        #region Implementation of IMaterialAppService

        public MaterialDTO CreateNewMaterial(MaterialDTO materialDTO)
        {
            if (materialDTO == null)
                return null;

            var material = MaterialFactory.CreateMaterial(materialDTO.MaterialNo, materialDTO.MaterialDescrption);
            material.Id = IdentityGenerator.NewSequentialGuid();

            _materialRepository.Add(material);

            _materialRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<Material, MaterialDTO>(material);
        }

        public MaterialDTO UpdateMaterial(MaterialDTO materialDTO)
        {
            if (materialDTO == null || materialDTO.Id == Guid.Empty)
                return null;

            var persisted = _materialRepository.Get(materialDTO.Id);

            if (persisted == null)
                return null;

            var current = MaterialFactory.CreateMaterial(materialDTO.MaterialNo, materialDTO.MaterialDescrption);
            current.Id = materialDTO.Id;

            _materialRepository.Merge(persisted, current);

            _materialRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<Material, MaterialDTO>(persisted);
        }

        public void RemoveMaterial(Guid materialId)
        {
            if (materialId == Guid.Empty)
                return;

            var material = _materialRepository.Get(materialId);
            
            if (material != null)
            {
                material.Disable();

                _materialRepository.UnitOfWork.Commit();
            }
        }

        public bool IsMaterialNoExists(string materialNo)
        {
            var spec = MaterialSpecifications.MaterialNoExactMatching(materialNo);

            var count = _materialRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return count > 0;
        }

        public MaterialDTO GetMaterial(string materialNo)
        {
            var spec = MaterialSpecifications.MaterialNoExactMatching(materialNo);

            var material = _materialRepository.AllMatching(spec).SingleOrDefault();

            return material != null ? _typeAdapter.Adapt<Material, MaterialDTO>(material) : null;
        }

        public List<MaterialDTO> FindMatchedMaterials(int topN, string materialNo)
        {
            var spec = MaterialSpecifications.MaterialNo(materialNo);

            var materials = _materialRepository.GetPaged(0, topN, spec, m => m.MaterialNo, true);

            return _typeAdapter.Adapt<IEnumerable<Material>, List<MaterialDTO>>(materials);
        }

        public PagedDataSet<MaterialDTO> FindMaterials(int pageIndex, int pageSize, string findText)
        {
            var spec = MaterialSpecifications.InAllTextFields(findText);

            var materials = _materialRepository.GetPaged(pageIndex, pageSize, spec, m => m.Id, true);
            var count = _materialRepository.GetAll().AsQueryable().Count(spec.SatisfiedBy());

            return new PagedDataSet<MaterialDTO>
                       {
                           PageIndex = pageIndex,
                           PageSize = pageSize,
                           DataCount = count,
                           CurrentPageDataSet =
                               _typeAdapter.Adapt<IEnumerable<Material>, List<MaterialDTO>>(materials),
                       };
        }

        #endregion
    }
}
