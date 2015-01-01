namespace WebEzi.Base.Exception
{
    public class PageParameterException : BaseException
    {
        public PageParameterException(string message)
            : base(message)
        {

        }

        public PageParameterException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
