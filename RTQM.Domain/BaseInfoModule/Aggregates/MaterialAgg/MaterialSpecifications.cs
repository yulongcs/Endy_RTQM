using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg
{
    public static class MaterialSpecifications
    {
        public static Specification<Material> MaterialNo(string materialNo)
        {
            var specification = EnabledMaterial();

            if (!string.IsNullOrWhiteSpace(materialNo))
            {
                specification &=
                    new DirectSpecification<Material>(m => m.MaterialNo.ToLower().Contains(materialNo.ToLower()));
            }

            return specification;
        }

        public static Specification<Material> InAllTextFields(string findText)
        {
            var specification = EnabledMaterial();

            if (!string.IsNullOrWhiteSpace(findText))
            {
                specification &= (
                                     new DirectSpecification<Material>(
                                         m => m.MaterialNo.ToLower().Contains(findText.ToLower()))
                                     |
                                     new DirectSpecification<Material>(
                                         m => m.MaterialDescrption.ToLower().Contains(findText.ToLower())));
            }

            return specification;
        }

        public static Specification<Material> EnabledMaterial()
        {
            return new DirectSpecification<Material>(m => m.IsDeleted == false);
        }

        public static Specification<Material> MaterialNoExactMatching(string materialNo)
        {
            if (!string.IsNullOrWhiteSpace(materialNo))
            {
                return new DirectSpecification<Material>(m => m.MaterialNo.ToLower() == materialNo.ToLower());
            }
            else
            {
                return new NotSpecification<Material>(new TrueSpecification<Material>());
            }
        }
    }
}
