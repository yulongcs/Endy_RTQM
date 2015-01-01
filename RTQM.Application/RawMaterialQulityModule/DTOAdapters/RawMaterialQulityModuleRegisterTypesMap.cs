using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOAdapters.Maps;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOAdapters
{
    public class RawMaterialQulityModuleRegisterTypesMap : RegisterTypesMap
    {
        public RawMaterialQulityModuleRegisterTypesMap()
        {
            RegisterMap(new PurchaseOrderToPurchaseOrderDTOMap());
            RegisterMap(new PurchaseOrderEnumerableToPurchaseOrderDTOListMap());
            RegisterMap(new OrderLineToOrderLineDTOMap());
            RegisterMap(new OrderLineEnumeralbeToOrderLineDTOListMap());
        }
    }
}
