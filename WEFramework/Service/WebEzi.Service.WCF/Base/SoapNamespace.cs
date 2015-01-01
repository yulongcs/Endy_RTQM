namespace WebEzi.Service.WCF//.Base
{
    /// <summary>
    /// 定义 MessageHeader NameAndNamespace
    /// </summary>
    public static partial class SoapNamespace
    {
        public const string WebEziNamespace = "WebEziHeader";
        public const string WebEziSoapHeader = "WebEziSoapHeader";
        public const string WebEziSoapMessage = "WebEziSoapMessage";
        public const string WebEziException = "WebEziException";
        public const string WebEziCurrentLogin = "WebEziCurrentLogin";

        public const string WebEziSoapFault = "WebEziSoapFault";

        //ESB
        public const string WebEziEsbLogin = "WebEziEsbLogin";
        public const string WebEziEsbServiceContractNamespace = "http://www.webezi.com.au/esb";
    }

    public static partial class SoapNamespace
    {
        public const string WebEziUserID = "WebEziUserID";
    }

    public static partial class SoapNamespace
    {
        internal const string WebEziSoapFaultContract = "WebEziSoapFaultContract"; 
    }
}
