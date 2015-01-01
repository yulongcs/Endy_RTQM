using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:EmailTextField runat=server></{0}:EmailTextField>")]
    public class EmailTextField : Ext.Net.TextField
    {
        protected override void OnBeforeClientInit(Ext.Net.Observable sender)
        {
            base.OnBeforeClientInit(sender);

            this.Vtype = "email";
        }
    }
}
