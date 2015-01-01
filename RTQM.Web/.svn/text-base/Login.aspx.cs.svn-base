using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Lgsoft.RTQM.Utility;
using Lgsoft.RTQM.Application.SecurityModule.Services;

namespace Lgsoft.RTQM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetData(string username, string password)
        { 
            try 
            {
                var userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
                if (userAppService.CheckUserPassword(username, password))
                    return "登录成功！";
                else {
                    return "用户名密码错误！";
                }
            }
            catch
            {
                return "操作失败！";
            }
        }

        protected void loginBtn_OnClick(object sender, EventArgs e)
        {
            var userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
            var username_txt = username.Text;
            var password_txt = password.Text;
            try 
            {
                if (userAppService.CheckUserPassword(username_txt, password_txt))
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(username_txt, false);
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(username_txt, false);
                }
                else
                {
                    error.Text = "用户名密码错误！";
                }
            }
            catch {
                error.Text = "系统错误！";
            }
        }
    }
}