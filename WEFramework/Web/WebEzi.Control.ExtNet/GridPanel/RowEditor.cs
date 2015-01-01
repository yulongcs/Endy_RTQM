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
    /// <summary>
    /// The RowEditor plugin has been removed in ext 2.2;
    /// Use the RowEditing plugin. Use its Edit event instead of the RowEditor AfterEdit one.
    /// Use its SaveBtnText property instead of the RowEditor SaveText.
    /// </summary>
    [ToolboxData("<{0}:RowEditor runat=server></{0}:RowEditor>")]
    public class RowEditor 
    {
    }
}
