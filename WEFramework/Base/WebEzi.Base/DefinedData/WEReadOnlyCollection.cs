using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WebEzi.Base.DefinedData
{
    public class WEReadOnlyCollection<T> : ReadOnlyCollection<T>
    {
        public WEReadOnlyCollection(IList<T> list) : base(list)
        {
        }
    }
}
