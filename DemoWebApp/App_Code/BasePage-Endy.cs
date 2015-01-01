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
    public class BasePage : WebEzi.Web.ExtNet.BasePage
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

        protected override WebEzi.Base.ICurrentLogin GetCurrentLogin()
        {
            return null;
        }

        protected override void SetCurrentLogin(WebEzi.Base.ICurrentLogin currentLogin)
        {
        }

        protected override string GetSessionExpiryUrl()
        {
            return string.Empty;
        }
    }
}