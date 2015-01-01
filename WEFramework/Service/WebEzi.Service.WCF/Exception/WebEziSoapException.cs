using System;
namespace WebEzi.Service.WCF.Exception
{
    public class WebEziSoapException : ApplicationException
    {
        WebEzi.Service.WCF.SoapExceptionType ExceptionType { get; set; }

        public WebEziSoapException(string message)
            : base(message)
        {

        }

        public WebEziSoapException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
    }
}