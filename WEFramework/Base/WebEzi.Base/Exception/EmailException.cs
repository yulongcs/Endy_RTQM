namespace WebEzi.Base.Exception
{
    public class EmailException : BaseException
    {
        public EmailException(string message)
            : base(message)
        {

        }

        public EmailException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
