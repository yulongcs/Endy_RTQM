using WebEzi.Base.Const;
using WebEzi.Base.DefinedData;

namespace WebEzi.Service.WCF
{
    public enum SoapExceptionType
    {
        Null,
        [ConstAttribute("NOT SPECIFIED")]
        NotSpecified,
        [ConstAttribute("NEED TO DETERMINE")]
        NeedToDetermine,
        [ConstAttribute("EXCEPTION OCCURS BEFORE SEND REQUEST")]
        BeforeSendRequest,
        [ConstAttribute("HEADER RETURN")]
        HeaderRetrun,
        [ConstAttribute("HEADER EXCEPTION")]
        HeaderException,
        [ConstAttribute("SERVER EXCEPTION")]
        ServerException,
        [ConstAttribute("SERVER EXCEPTION CONTROLLED")]
        ServerExceptionControlled,
        [ConstAttribute("SERVER EXCEPTION UNCONTROLLED")]
        ServerExceptionUncontrolled,
        [ConstAttribute("REQUEST EXCEPTION")]
        RequestException,
        [ConstAttribute("REQUEST BUSINESS EXCEPTION")]
        RequestBusinessException,
        [ConstAttribute("CLIENT")]
        Client
    }		

}
