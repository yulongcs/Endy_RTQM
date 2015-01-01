using System;
using Ext.Net;

namespace DemoWebApp.ASPX.Examples
{
    public partial class TreePanel : System.Web.UI.Page
    {
        private int NewIndex
        {
            get
            {
                return (int)(Session["newIndex"] ?? 1);
            }
            set
            {
                Session["newIndex"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //(iframeControl.FindControl("btnNew") as Ext.Net.Button).DirectClick += new ComponentDirectEvent.DirectEventHandler(TreePanel_DirectClick);
        }

        void TreePanel_DirectClick(object sender, DirectEventArgs e)
        {
            
        }

    }
}