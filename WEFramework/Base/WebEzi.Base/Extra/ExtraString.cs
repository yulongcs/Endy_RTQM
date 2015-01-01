using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebEzi.Base.Const;

namespace WebEzi.Base.Extra
{
    public static class ExtraString
    {
        public static T ToConstEnum<T>(this String value)
        {
            return ConstFactory.ConvertToEnum<T>(value);
        }
    }
}
