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
    public partial class AddUser : Page
    {
        public Application.SecurityModule.DTOs.UserDTO User = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserAppService userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                User = userAppService.GetUser(new Guid(Request.QueryString["id"]));
            }
        }

        [WebMethod]
        public static string AddEditData(string userName, string userPw, string userAd, string userRname, string userDep, string userEmail, string Id)
        {
            try
            {
                var userAppService = Container.Current.Resolve(typeof(IUserAppService), null) as IUserAppService;
                Application.SecurityModule.DTOs.UserDTO user;
                if (Id == "")
                {
                    user = new Application.SecurityModule.DTOs.UserDTO
                    {
                        Id = Guid.NewGuid(),
                        UserName = userName.Trim(),
                        Password = userPw.Trim(),
                        RealName = userRname.Trim(),
                        ADAccount = userAd.Trim(),
                        Department = userDep.Trim(),
                        Email = userEmail.Trim(),
                        CreateDate = DateTime.Now
                    };
                    userAppService.CreateNewUser(user);
                }
                else
                {
                    user = userAppService.GetUser(new Guid(Id));
                    user.UserName = userName.Trim();
                    user.RealName = userRname.Trim();
                    user.ADAccount = userAd.Trim();
                    user.Department = userDep.Trim();
                    user.Email = userEmail.Trim();
                    userAppService.UpdateUser(user);
                    
                }
                return "操作成功！";
            }
            catch
            {
                return "操作失败！";
            }
        }
    }
}