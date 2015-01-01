using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEzi.Core.Domain;
using WebEzi.Core.Domain.Base;
using WebEzi.Core.Domain.Base.Application;
using WebEzi.Core.Domain.Base.ModelFactory;
using WebEzi.Core.Domain.Base.Service;

namespace DemoWebApp
{
    public class BaseUserControl : WebEzi.Web.ExtNet.BaseUserControl
    {
        #region Build Domain

        protected T BuildModelFactory<T>() where T : ModelFactoryBase
        {
            return DomainFactory.GetInstance().GetModelFactory<T>();
        }

        protected T BuildApplication<T>()
            where T : IApplication
        {
            return DomainFactory.GetInstance().GetApplication<T>();
        }

        protected T BuildService<T>() where T : ServiceBase
        {
            return DomainFactory.GetInstance().GetService<T>();
        }

        #endregion
    }
}