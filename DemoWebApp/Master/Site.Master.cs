using System;
using Ext.Net;

namespace DemoWebApp.Master
{
    public partial class Site : BaseMasterPage
    {
        protected void Home_Click(object sender, DirectEventArgs e)
        {
            PageTransfer(SiteMapping.ASPX.Home);
        }

        protected void Department_Click(object sender, EventArgs e)
        {
            PageTransfer(SiteMapping.ASPX.Department.CustomerList);
        }

        protected void User_Click(object sender, EventArgs e)
        {
            PageTransfer(SiteMapping.ASPX.User.UserList);
        }

        protected void Logout_Click(object sender, DirectEventArgs e)
        {
            PageTransfer(SiteMapping.ASPX.Login);
        }
    }
}