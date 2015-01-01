using WebEzi.Base.Exception;

namespace WebEzi.Core.Exception.Domain
{
    public class DomainException : BusinessException
    {
        public DomainException(string message)
            : base(message)
        {

        }

        public DomainException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}