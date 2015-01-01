using System;

namespace WebEzi.Base.Exception
{
    public class BaseException : ApplicationException
    {
        public BaseException(string message)
            : base(message)
        {

        }

        public BaseException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
