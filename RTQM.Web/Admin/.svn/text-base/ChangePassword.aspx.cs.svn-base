using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Lgsoft.RTQM.Utility;
using Lgsoft.RTQM.Application.SecurityModule.Services;

namespace Lgsoft.RTQM.Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public Application.SecurityModule.DTOs.UserDTO User;
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserAppService userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                User = userAppService.GetUser(new Guid(Request.QueryString["id"]));
            }
        }
        [WebMethod]
        public static string ChangeData(string userPw, string Id)
        {
            try
            {
                var userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
                userAppService.SetUserPassword(new Guid(Id), userPw);
                return "操作成功！";
            }
            catch
            {
                return "操作失败！";
            }
        }
    }
}