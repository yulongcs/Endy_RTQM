using System;

namespace WebEzi.Core.Exception.Domain
{
    public class StopUsingModelException : ModelException
    {
        public StopUsingModelException(string message, Type type) : base(message)
        {
        }

        public StopUsingModelException(string message, Type type, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
