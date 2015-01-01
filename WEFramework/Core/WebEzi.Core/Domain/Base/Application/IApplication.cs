using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Model;

namespace WebEzi.Core.Domain.Base.Application
{
    public interface IApplication
    {
        IAggregateRoot GetByKey(WEKey key);
    }

    public interface IApplication<T> : IApplication
        where T : IAggregateRoot
    {
        new T GetByKey(WEKey key);
    }
}
