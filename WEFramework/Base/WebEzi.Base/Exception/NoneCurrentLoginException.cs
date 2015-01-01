using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebEzi.Base.Exception
{
    public class NoneCurrentLoginException : BaseException
    {
        public NoneCurrentLoginException(string message) : base(message)
        {
        }

        public NoneCurrentLoginException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
