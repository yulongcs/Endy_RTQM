namespace WebEzi.Base.Exception
{
    public class DataBaseException : BaseException
    {
        public DataBaseException(string message)
            : base(message)
        {

        }

        public DataBaseException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
