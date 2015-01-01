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
    public partial class RoleManage : System.Web.UI.Page
    {
        public List<Application.SecurityModule.DTOs.RoleDTO> AllRoles;
        public IRoleAppService roleAppService = Container.Current.Resolve(typeof(IRoleAppService), null) as IRoleAppService;
        public string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            AllRoles = roleAppService.GetAllRoles();
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                userId = Request.QueryString["id"];
            }
        }

        [WebMethod]
        public static string AddData(string roleIds, string Id)
        {
            try
            {
                var userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
                string[] roles = roleIds.Split(new Char []{','});
                Guid[] rIds = new Guid[roles.Length - 1];
                var i = 0;
                foreach (var role in roles) 
                {
                    if (!String.IsNullOrEmpty(role)) {
                        rIds[i] = new Guid(role);
                        i++;
                    }
                }
                userAppService.SetUserRoles(new Guid(Id), rIds);
                return "操作成功！";
            }
            catch
            {
                return "操作失败！";
            }
        }
    }
}