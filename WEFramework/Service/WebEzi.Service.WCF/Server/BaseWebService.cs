using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using WebEzi.Service.WCF.Exception;
namespace WebEzi.Service.WCF.Server
{
    /// <summary>
    /// The base of the webservice
    /// </summary>
    [GlobalFaultHandlerBehaviourAttribute(typeof(GlobalFaultHandler))]
    public abstract class BaseWebService : IBaseWebService
    {
    }
}