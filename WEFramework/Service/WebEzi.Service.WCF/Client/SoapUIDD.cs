using System;
using System.ServiceModel;

using WebEzi.Service.WCF.Exception;
using WebEzi.Service.WCF.Contracts;

namespace WebEzi.Service.WCF.Client
{
    /// <summary>
    /// Client获取及设置SoapHeader Message
    /// </summary>
    public class SoapUIDD
    {
        #region Get IncomingMessageHeaders:SoapHeader,SoapMessage,CurrentLogin ; start
        public static SoapHeader GetInSoapHeader()
        {
            return GetInHeader<SoapHeader>(SoapNamespace.WebEziSoapHeader, SoapNamespace.WebEziNamespace);
        }

        public static CurrentLoginContract GetInCurrentLogin()
        {
            return GetInHeader<CurrentLoginContract>(SoapNamespace.WebEziCurrentLogin, SoapNamespace.WebEziNamespace);
        }

        public static SoapMessage GetInSoapMsg()
        {
            return GetInHeader<SoapMessage>(SoapNamespace.WebEziSoapMessage, SoapNamespace.WebEziNamespace);
        }

        public static T GetInHeader<T>(string Name, string Namespace)
        {
            var headers = OperationContext.Current.IncomingMessageHeaders;
            if (headers != null)
            {
                try
                {
                    var index = headers.FindHeader(Name, Namespace);
                    if (index > -1)
                        return headers.GetHeader<T>(index);
                }
                catch (MessageHeaderException ex)
                {
                    throw new WebEziSoapClientException(ex.Message);
                    //throw new SoapException(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    throw new WebEziSoapClientException(ex.Message);
                    //throw new SoapException(ex.Message);
                }
            }
            return default(T);
        }
        #endregion Get IncomingMessageHeaders:SoapHeader,SoapMessage,CurrentLogin ; end

        #region Get ReplyMessageHeaders:SoapHeader,SoapMessage,CurrentLogin ; start
        public static SoapHeader GetInSoapHeader(ref System.ServiceModel.Channels.Message reply)
        {
            return GetInHeader<SoapHeader>(ref reply,SoapNamespace.WebEziSoapHeader, SoapNamespace.WebEziNamespace);
        }

        public static CurrentLoginContract GetInCurrentLogin(ref System.ServiceModel.Channels.Message reply)
        {
            return GetInHeader<CurrentLoginContract>(ref reply, SoapNamespace.WebEziCurrentLogin, SoapNamespace.WebEziNamespace);
        }

        public static SoapMessage GetInSoapMsg(ref System.ServiceModel.Channels.Message reply)
        {
            return GetInHeader<SoapMessage>(ref reply, SoapNamespace.WebEziSoapMessage, SoapNamespace.WebEziNamespace);
        }

        public static T GetInHeader<T>(ref System.ServiceModel.Channels.Message reply, string Name, string Namespace)
        {
            var headers = reply.Headers;
            if (headers != null)
            {
                try
                {
                    var index = headers.FindHeader(Name, Namespace);
                    if (index > -1)
                        return headers.GetHeader<T>(index);
                }
                catch (MessageHeaderException ex)
                {
                    throw new WebEziSoapClientException(ex.Message);
                    //throw new SoapException(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    throw new WebEziSoapClientException(ex.Message);
                    //throw new SoapException(ex.Message);
                }
                catch (System.Exception ex)
                {
                    throw new WebEziSoapClientException(ex.Message);
                }

            }
            return default(T);
        }
        #endregion Get ReplyMessageHeaders:SoapHeader,SoapMessage,CurrentLogin ; end
    }
}
