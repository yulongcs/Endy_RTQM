using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel;

using WebEzi.Service.WCF.Contracts;

namespace WebEzi.Service.WCF.Client
{
    public abstract class BaseClientInterpector : IClientMessageInspector, IEndpointBehavior, IClientInterpector
    {
        #region Properties
        /// <summary>
        /// 是否启用factory缓存，启用后，CurrentLogin将依据HttpContext.Current取值
        /// </summary>
        public bool IsCache { get; private set; }
        /// <summary>
        /// CurrentLogin config： AppSettings.Session.CurrentLogin
        /// </summary>
        public string CacheMessage { get; private set; }

        /// <summary>
        /// Client Security authentication information
        /// </summary>
        public SoapHeader SoapHeader { get; set; }

        /// <summary>
        /// Custom header
        /// </summary>
        public SoapMessage SoapMessage { get; set; }
        public WebEzi.Base.ICurrentLogin ICurrentLogin { get; set; }

        #endregion Properties

        #region Behavior
        public void SetCache(string strCacheMessage)
        {
            this.IsCache = true;
            this.CacheMessage = strCacheMessage;
        }
        #endregion Behavior

        #region Implementation for IClientMessageInspector
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            SoapMessage = WebEzi.Service.WCF.Client.SoapUIDD.GetInSoapMsg(ref reply);
            if (SoapMessage != null)
            {
                SoapMessage.Throw();
            }
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            #region CurrentLogin special use start
            #endregion  CurrentLogin special use end

            #region
            /*
            MessageHeader<WebEziSoapHeader> webeziHeader = new System.ServiceModel.MessageHeader<WebEziSoapHeader>(_SoapHeader);            
            MessageHeader untypedWebeziHeader = webeziHeader.GetUntypedHeader(SoapNamespace.WebEziSoapHeader, SoapNamespace.WebEziNamespace);
            //if(request.Headers.Contains())
            request.Headers.Add(untypedWebeziHeader);*/
            #endregion

            request.Headers.Add(System.ServiceModel.Channels.MessageHeader.CreateHeader(SoapNamespace.WebEziSoapHeader, SoapNamespace.WebEziNamespace, SoapHeader));
            request.Headers.Add(System.ServiceModel.Channels.MessageHeader.CreateHeader(SoapNamespace.WebEziCurrentLogin, SoapNamespace.WebEziNamespace, ICurrentLogin));
            request.Headers.Add(System.ServiceModel.Channels.MessageHeader.CreateHeader(SoapNamespace.WebEziSoapMessage, SoapNamespace.WebEziNamespace, SoapMessage));
            return null;
        }
        #endregion

        #region Implementation for IEndpointBehavior
        public void AddBindingParameters(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
        {
            behavior.MessageInspectors.Add(this);
        }

        public void ApplyDispatchBehavior(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint) { }
        #endregion
    }
}
