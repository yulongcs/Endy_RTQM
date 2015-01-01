namespace WebEzi.Base.Exception
{
    public class ControlException : BaseException
    {
        public ControlException(string message)
            : base(message)
        {

        }

        public ControlException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}
