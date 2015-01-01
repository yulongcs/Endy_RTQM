using System;

using System.ServiceModel;
using WebEzi.Service.WCF.Contracts;

namespace WebEzi.Service.WCF.Exception
{
    public class WebEziSoapServerException : WebEziSoapException
    {
        public SoapExceptionType ExceptionType { get; set; }

        public WebEziSoapServerException(string message, SoapExceptionType exceptiontype) : base(message) { ExceptionType = exceptiontype; }

        public WebEziSoapServerException(string message) : base(message) { }
        public WebEziSoapServerException(string message, System.Exception inner) : base(message, inner) { }
    }
}


