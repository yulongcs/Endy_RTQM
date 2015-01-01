using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using Ext.Net;
using WebEzi.Base;
using WebEzi.Base.DefinedData;
using WebEzi.Base.Exception;
using System.Threading;

namespace WebEzi.Web.ExtNet
{
    public abstract class BasePage : System.Web.UI.Page, IBasePage
    {
        public const string Parameter = "Parameter";

        #region Page Load

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            AfterInit();
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.CheckLogin();

            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CheckUserRights();

                this.BindPageParam();

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

        #region Current Login

        ICurrentLogin IBasePage.CurrentLogin
        {
            get { return this.GetCurrentLogin(); }
            set { this.SetCurrentLogin(value); }
        }

        protected abstract ICurrentLogin GetCurrentLogin();
        protected abstract void SetCurrentLogin(ICurrentLogin currentLogin);

        #endregion

        protected override void RaisePostBackEvent(System.Web.UI.IPostBackEventHandler sourceControl,
                                                   string eventArgument)
        {
            try
            {
                base.RaisePostBackEvent(sourceControl, eventArgument);
            }
            catch (ThreadAbortException ex)
            {
                //Ignore this kind of exception. This kind of exception can not be removed in Ext Ajax envirment
                //So we need to ignore it here.
                Console.WriteLine(ex);
            }
            catch (DataException ex)
            {
                ShowErrorMessage(ex);
            }
            catch (BusinessException ex)
            {
                ShowErrorMessage(ex);
            }
        }

        protected virtual void ShowErrorMessage(Exception ex)
        {
            Msg.Alert("Error", ex.Message);
        }

        protected virtual void BindPageParam()
        {
            // do nonthing
        }

        #region Check Login

        protected virtual void CheckLogin()
        {
            try
            {
                if(this.GetCurrentLogin() == null)
                {
                    this.PageTransfer(this.GetSessionExpiryUrl());
                }
            }
            catch (NoneCurrentLoginException)
            {
                this.PageTransfer(this.GetSessionExpiryUrl());
            }
        }

        protected abstract string GetSessionExpiryUrl();

        #endregion

        #region User Rights

        protected virtual void CheckUserRights()
        {
            // do nonthing
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

            // Request.ApplicationPath will return "/" + Visual Path of current application.
            // So if the site is deployed on the root path of a Web site, the Request.ApplicationPath is "/"
            // if there's any Visual Path, the Request.ApplicationPath is "/VisualPath", But without any ending backslash.
            if (this.Request.ApplicationPath != "/")
            {
                return this.Request.ApplicationPath + "/" + url;
            }
            else
            {
                return this.Request.ApplicationPath + url;
            }
        }

        #endregion

        #region Download

        public void DownloadDocument(WEFile file, string expectFileName)
        {
            this.DownloadDocument(file, expectFileName, false);
        }

        public void DownloadDocument(WEFile file, string expectFileName, bool isNeedDeleteFile)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();

            if (string.IsNullOrEmpty(expectFileName))
            {
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", file.FileName));
            }
            else
            {
                Response.AddHeader("content-disposition",
                                   string.Format("attachment;filename={0}{1}", expectFileName, file.Extension));
            }
            Response.AddHeader("Content-Length", new FileInfo(file.PhysicalPath).Length.ToString());
            switch (file.Extension.ToLower())
            {
                case ".doc":
                    Response.ContentType = "application/msword";
                    break;
                case ".docx":
                    Response.ContentType = "application/msword";
                    break;
                case ".pdf":
                    Response.ContentType = "application/vnd.pdf";
                    break;
                case ".zip":
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.ContentType = "application/octet-stream";
                    break;
            }
            Response.WriteFile(file.PhysicalPath);
            Response.Flush();
            Response.End();

            // Delete temporary file
            if (isNeedDeleteFile && File.Exists(file.PhysicalPath))
            {
                File.Delete(file.PhysicalPath);
            }
        }

        #endregion
    }

    public abstract class BasePage<T> : BasePage
        where T : IPageParameter, new()
    {
        public T Parameters
        {
            get
            {
                if (ViewState[Parameter] == null)
                {
                    ViewState[Parameter] = new T();
                }

                return (T)ViewState[Parameter];
            }
        }

        protected override void BindPageParam()
        {
            string query = Request.QueryString == null ? string.Empty : HttpUtility.UrlDecode(Request.QueryString.ToString());

            AppNavigate.BindPageParam(query, this.Parameters);
        }
    }
}
