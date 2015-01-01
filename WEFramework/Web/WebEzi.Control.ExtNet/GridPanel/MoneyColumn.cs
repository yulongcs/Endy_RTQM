using System.ComponentModel;
using System.Web.UI;
using Ext.Net;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Column runat=server></{0}:Column>")]
    public class MoneyColumn : Ext.Net.Column
    {
        public MoneyColumn()
        {
            base.Renderer.Handler = "if(value==null){return 'N/A';}else{return Ext.util.Format.usMoney(value);}";
        }
    }
}
