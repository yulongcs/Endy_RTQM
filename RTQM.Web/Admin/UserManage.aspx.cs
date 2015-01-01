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
    public partial class UserManage : Page
    {
        public List<Application.SecurityModule.DTOs.UserDTO> AllUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            var userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
            if (!IsPostBack) {
               AllUser = userAppService.GetAllUsers();
            }
        }

        [WebMethod]
        public static string DelData(string Id) {
            try
            {
                IUserAppService userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
                userAppService.RemoveUser(new Guid(Id));
                return "删除成功！";
            }
            catch {
                return "删除失败！";
            }
            
        }
    }
}