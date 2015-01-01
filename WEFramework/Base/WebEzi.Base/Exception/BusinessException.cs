namespace WebEzi.Base.Exception
{
    public class BusinessException : BaseException
    {
        public BusinessException(string message)
            : base(message)
        {

        }

        public BusinessException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
