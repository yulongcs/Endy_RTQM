using System.ServiceModel.Dispatcher;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace WebEzi.Service.WCF.Client
{
    public interface IClientHandleFactory
    {
    }

    public interface IClientHandleFactory<T> : IClientHandleFactory
    {
    }

}
