using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEzi.Core.Domain;
using WebEzi.Core.Domain.Base;
using WebEzi.Core.Domain.Base.Application;
using WebEzi.Core.Domain.Base.Service;


namespace DemoWebApp
{
    public class BasePage : WebEzi.Web.ExtNet.BasePage
    {
        #region Build Domain

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

        #region Set/Get CurrentLogin

        private readonly static string SESSION_CURRENTLOGIN = "WebEziWebAppCurrentLogin";

        protected override WebEzi.Base.ICurrentLogin GetCurrentLogin()
        {
            return (WebEzi.Base.ICurrentLogin)Session[SESSION_CURRENTLOGIN];
        }

        protected override void SetCurrentLogin(WebEzi.Base.ICurrentLogin currentLogin)
        {
            if (Session.IsReadOnly)
                throw new Exception("The session is readonly while page is trying to store current login information!");
            Session[SESSION_CURRENTLOGIN] = currentLogin;
        }

        protected override string GetSessionExpiryUrl()
        {
            return SiteMapping.ASPX.Login;
        }

        #endregion
    }
}