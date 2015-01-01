using System.Collections.Generic;
using WebEzi.Base.DefinedData;

namespace WebEzi.Core.Domain.Base.Model
{
    public interface IAggregateRoot : IModel
    {
        WEKey Key { get; }

        bool IsExist { get; }

        IList<EntityModelBase> DeletedEntityModelCollection { get; }
    }
}
