namespace WebEzi.Base.Exception
{
    public class DefinedDataException : BaseException
    {
        public DefinedDataException(string message)
            : base(message)
        {

        }

        public DefinedDataException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
