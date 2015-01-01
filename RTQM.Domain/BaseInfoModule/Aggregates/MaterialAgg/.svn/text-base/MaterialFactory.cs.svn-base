using System;

namespace Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg
{
    public static class MaterialFactory
    {
        public static Material CreateMaterial(string materialNo, string materialDescrption)
        {
            if (string.IsNullOrWhiteSpace(materialNo))
                throw new ArgumentNullException("materialNo", "物料编号不能为空。");

            var material = new Material
                               {
                                   MaterialNo = materialNo,
                                   MaterialDescrption = materialDescrption,
                               };

            material.Enable();

            return material;
        }
    }
}
