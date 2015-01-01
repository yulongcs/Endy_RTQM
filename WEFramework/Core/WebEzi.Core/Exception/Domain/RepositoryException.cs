namespace WebEzi.Core.Exception.Domain
{
    public class RepositoryException : DomainException
    {
        public RepositoryException(string message)
            : base(message)
        {

        }

        public RepositoryException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}