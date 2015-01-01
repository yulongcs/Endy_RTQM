using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Diagnostics;

using System.ServiceModel;
using System.ServiceModel.Channels;


using WebEzi.Service.WCF.Contracts;
using WebEzi.Service.WCF.Exception;


namespace WebEzi.Service.WCF.Server
{
    /// <summary>
    /// Server 获取及设置SoapHeader Message
    /// </summary>
    public class SoapUIDD
    {
        #region Server Throw Exception 

        /// <summary>
        /// Throw a type "WebEziSoapInterruptException" exception using default message, no logging
        /// </summary>
        public static void Throw()
        {
            Throw("Server Exception!");
        }

        /// <summary>
        /// Throw a type "WebEziSoapInterruptException" exception, no logging
        /// </summary>
        /// <param name="strMessage">exception message</param>
        public static void Throw(string strMessage)
        {
            throw new WebEziSoapInterruptException(strMessage, SoapExceptionType.Null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="soapExceptionType"></param>
        public static void Throw(string strMessage, SoapExceptionType soapExceptionType)
        {
            throw new WebEziSoapInterruptException(strMessage, soapExceptionType);
        }

        #endregion Server Throw Exception

        #region Set OutgoingMessageHeaders :SoapHeader,SoapMessage,CurrentLogin ; start

        public static void SetOut(SoapHeader header)
        {
            SetOut<SoapHeader>(header, SoapNamespace.WebEziSoapHeader, SoapNamespace.WebEziNamespace);
            return;
        }

        public static void SetOut(SoapMessage soapMsg)
        {
            SetOut<SoapMessage>(soapMsg, SoapNamespace.WebEziSoapMessage, SoapNamespace.WebEziNamespace);
            return;
        }

        public static void SetOut(CurrentLoginContract currentLogin)
        {
            SetOut<CurrentLoginContract>(currentLogin, SoapNamespace.WebEziCurrentLogin, SoapNamespace.WebEziNamespace);
            return;
        }

        /// <summary>
        /// Set OutgoingMessageHeaders
        /// </summary>
        /// <typeparam name="T">MessageHeader Type</typeparam>
        /// <param name="t">MessageHeader Value</param>
        /// <param name="Name">MessageHeader Name</param>
        /// <param name="Namespace">MessageHeader Namespace</param>
        private static void SetOut<T>(T t, string Name, string Namespace)
        {
            var index = OperationContext.Current.OutgoingMessageHeaders.FindHeader(Name, Namespace);
            if (index > -1)
            {
                //If it already exists in OutgoingMessageHeaders , remove and then add it
                OperationContext.Current.OutgoingMessageHeaders.RemoveAt(index);
            }
            MessageHeader<T> headerT = new MessageHeader<T>(t);
            MessageHeader untypedheaderT = headerT.GetUntypedHeader(SoapNamespace.WebEziSoapMessage, SoapNamespace.WebEziNamespace);
            OperationContext.Current.OutgoingMessageHeaders.Add(untypedheaderT);

            return;
        }
        #endregion  Set OutgoingMessageHeaders :SoapHeader,SoapMessage,CurrentLogin ; end

        #region Get IncomingMessageHeaders:SoapHeader,SoapMessage,CurrentLogin ; start
        public static SoapHeader GetInSoapHeader()
        {
            return GetInHeader<SoapHeader>(SoapNamespace.WebEziSoapHeader, SoapNamespace.WebEziNamespace);
        }

        /// <summary>
        /// WebEzi.Service.WCF.Contracts.CurrentLogin Get
        /// </summary>
        /// <returns></returns>
        public static CurrentLoginContract GetInCurrentLogin()
        {
            return GetInHeader<CurrentLoginContract>(SoapNamespace.WebEziCurrentLogin, SoapNamespace.WebEziNamespace);
        }
        public static SoapMessage GetInSoapMsg()
        {
            return GetInHeader<SoapMessage>(SoapNamespace.WebEziSoapMessage, SoapNamespace.WebEziNamespace);
        }

        public static T GetInHeader<T>(string Name,string Namespace)
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
                    throw new WebEziSoapServerException(ex.Message);
                    //throw new SoapException(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    throw new WebEziSoapServerException(ex.Message);
                    //throw new SoapException(ex.Message);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                
            }
            return default(T);



        }
        #endregion Get IncomingMessageHeaders:SoapHeader,SoapMessage,CurrentLogin ; end

    }
}
