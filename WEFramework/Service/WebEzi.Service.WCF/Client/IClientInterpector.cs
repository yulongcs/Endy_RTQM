using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using WebEzi.Service.WCF.Contracts;

namespace WebEzi.Service.WCF.Client
{
    public interface IClientInterpector
    {
        void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters);
        void AfterReceiveReply(ref Message reply, object correlationState);
        void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior);
        void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher);
        void Validate(ServiceEndpoint serviceEndpoint);
        object BeforeSendRequest(ref Message request, IClientChannel channel);
        
        bool IsCache { get; }
        string CacheMessage { get; }
        void SetCache(string strCacheMessage);
        WebEzi.Base.ICurrentLogin ICurrentLogin { get; set; }
        SoapHeader SoapHeader { get; set; }
        SoapMessage SoapMessage{get;set;}
    }
}
