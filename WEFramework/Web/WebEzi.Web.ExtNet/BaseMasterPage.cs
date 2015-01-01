using System;
using Ext.Net;

namespace WebEzi.Web.ExtNet
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        #region Page Load

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            AfterInit();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadPage();
            }

            if (!X.IsAjaxRequest)
            {
                this.AjaxLoadPage();
            }
        }

        protected virtual void AfterInit()
        {
            //
        }

        protected virtual void LoadPage()
        {
            //
        }

        protected virtual void AjaxLoadPage()
        {
        }

        #endregion

        #region Page Transfer

        protected virtual void PageTransfer(string url)
        {
            PageTransfer(url, null);
        }

        protected virtual void PageTransfer(string url, IPageParameter param)
        {
            this.Response.Redirect(this.GetPageUrl(url, param));
        }

        protected virtual void ParentPageTransfer(string url, BaseControl control)
        {
            this.ParentPageTransfer(url, null, control);
        }

        protected virtual void ParentPageTransfer(string url, IPageParameter param, BaseControl control)
        {
            control.AddScript("parent.window.location.href='" + this.GetPageUrl(url, param) + "'");
        }

        protected string GetPageUrl(string url)
        {
            return this.GetPageUrl(url, null);
        }

        protected string GetPageUrl(string url, IPageParameter param)
        {
            if (param != null)
            {
                var paramString = AppNavigate.GetParamString(param);

                url = url + paramString;
            }

            return this.Request.ApplicationPath + url;
        }

        #endregion
    }
}
