namespace WebEzi.Base.Exception
{
    public class FileIOException : BaseException
    {
        public FileIOException(string message)
            : base(message)
        {

        }

        public FileIOException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
