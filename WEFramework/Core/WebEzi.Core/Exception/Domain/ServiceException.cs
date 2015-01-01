namespace WebEzi.Core.Exception.Domain
{
    public class ServiceException : DomainException
    {
        public ServiceException(string message)
            : base(message)
        {

        }

        public ServiceException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}