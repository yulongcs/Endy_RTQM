using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebEzi.Base.Const;

namespace WebEzi.Base.Extra
{
    public static class ExtraEnum
    {
        public static string ToConstString(this Enum value)
        {
            return ConstFactory.ConvertToString(value);
        }
    }
}
