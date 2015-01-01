using System.Collections;
using System.Runtime.Serialization;

using WebEzi.Core;
using WebEzi.Base.DefinedData;
using WebEzi.Base.Const;
using WebEzi.Core.Domain.Base.Model;


using WebEzi.Service.WCF.Exception;
namespace WebEzi.Service.WCF.Contracts
{
    [DataContract(Name = SoapNamespace.WebEziSoapMessage, Namespace = SoapNamespace.WebEziNamespace)]
    public partial class SoapMessage : ISoapMessage
    {
        [DataMember]
        public SoapExceptionType MessageType { get; set; }
        [DataMember]
        public bool Result { get;private set; }
        [DataMember]
        public string Message { get;private set; }
    }

    public partial class SoapMessage
    {
        public SoapMessage()
        {
            Result = true;
        }
        public SoapMessage(string _message)
        {
            Result = false;
            Message = _message;
            MessageType = SoapExceptionType.Null;
        }
        public void SetMessage(string _message)
        {
            Message = _message;
        }
        public void AppandMessage(string _message)
        {
            if (string.IsNullOrEmpty(Message))
                Message = _message;
            else
                Message += _message;
        }
        public void SetErrorResult(string _message)
        {
            if (Result)
            {
                Result = false;
            }
            AppandMessage(_message);
        }
        public void SetResult(bool _result)
        {
            Result = _result;
        }

        public void Throw(ref System.ServiceModel.Channels.Message reply)
        {
            //reply.IsFault
            throw new WebEziSoapClientException(this.Message, this.MessageType);
        }

        public void Throw()
        {
            if (!Result)
            {
                throw new WebEziSoapClientException(this.Message, this.MessageType);
            }
        }
 
    }
}
