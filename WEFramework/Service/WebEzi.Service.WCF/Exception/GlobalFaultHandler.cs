using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace WebEzi.Service.WCF.Exception
{
    /// <summary>
    /// 自定义错误处理器（继承自System.ServiceModel.Dispatcher.IErrorHandler）
    /// </summary>
    public class GlobalFaultHandler : IErrorHandler
    {
        /// <summary>
        /// log4net
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(GlobalFaultHandler));

        /// <summary>
        /// After the exception is returned to the client is invoked
        /// </summary>
        /// <param name="error">异常</param>
        /// <returns></returns>
        public bool HandleError(System.Exception error)
        {
            //log.Error("WCF Service Exception", error);

            // true - 已处理
            return true;
        }

        /// <summary>
        /// After an exception occurs, before the exception information is returned to the called
        /// </summary>
        /// <param name="error">exception</param>
        /// <param name="version">MessageVersion</param>
        /// <param name="fault">MessageFault return</param>
        public void ProvideFault(System.Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            // log4net WebEziSoapServerException,SoapException
            WebEzi.Service.WCF.Contracts.SoapMessage message = new Contracts.SoapMessage(error.Message);
            if (error.GetType().Equals(typeof(WebEziSoapInterruptException)))
            {
                if (!message.MessageType.Equals(SoapExceptionType.Null))
                {
                    log.Error("WCF Service Exception", error);
                }
                //Conventions Exception Handling
                //message.MessageType = SoapExceptionType.RequestBusinessException;
            }
            else
            {
                log.Error("WCF Service Exception", error);
            }
            WebEzi.Service.WCF.Server.SoapUIDD.SetOut(message);
            var newEx = new FaultException(string.Format("WCF Service Exception: {0}", error.TargetSite.Name));
            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }
    }
}
