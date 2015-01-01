using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebEzi.Service.WCF.Exception
{
    /// <summary>
    /// Interrupt operation in advance
    /// </summary>
    public class WebEziSoapInterruptException : WebEziSoapException
    {
        public SoapExceptionType ExceptionType { get; set; }

        public WebEziSoapInterruptException(string message, SoapExceptionType exceptiontype) : base(message) { ExceptionType = exceptiontype; }
        
        public WebEziSoapInterruptException(string message) : base(message) { }
        public WebEziSoapInterruptException(string message, System.Exception inner) : base(message, inner) { }
    }
}
