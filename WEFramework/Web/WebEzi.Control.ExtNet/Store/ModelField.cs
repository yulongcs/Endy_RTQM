using System.ComponentModel;
using System.Web.UI;
using Ext.Net;

namespace WebEzi.Control.ExtNet
{

    /// <summary>
    /// RecordField has been renamed to ModelField and must be defined in Model.
    /// </summary>

    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ModelField runat=server></{0}:ModelField>")]
    public sealed class ModelField  : Ext.Net.ModelField 
    {
        public ModelField()
        {
            if (this.Type == ModelFieldType.String)
            {
                this.SortType = SortTypeMethod.AsUCText;
            }
        }
    }
}
