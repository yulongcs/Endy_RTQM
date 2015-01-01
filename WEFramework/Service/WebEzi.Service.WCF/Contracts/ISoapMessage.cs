using System;

namespace WebEzi.Service.WCF.Contracts
{
    interface ISoapMessage
    {
        SoapExceptionType MessageType { get; }
        string Message { get;  }
        bool Result { get;  }

        void AppandMessage(string _Msg);
        void SetMessage(string _Msg);
        void SetResult(bool _Result);
    }
}
