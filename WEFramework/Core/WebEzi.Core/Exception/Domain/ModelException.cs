using System;

namespace WebEzi.Core.Exception.Domain
{
    public class ModelException : DomainException
    {
        public ModelException(string message)
            : base(message)
        {
        }

        public ModelException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}