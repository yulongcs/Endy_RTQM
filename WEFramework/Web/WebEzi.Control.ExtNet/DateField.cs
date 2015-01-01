using System.ComponentModel;
using System.Web.UI;
using System;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:DateField runat=server></{0}:DateField>")]
    public class DateField : Ext.Net.DateField
    {
        public DateField()
        {
            this.AltFormats = "d/m/Y|d-m-y|d-m-Y|d/m|d-m|dm|dmy|dmY|d|Y-m-d|dmY";
            this.Format = "d/M/yyyy";
        }

        #region Properties

        public new DateTime? SelectedDate
        {

            get
            {
                
                if (base.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return base.SelectedDate;
                }
            }
            set 
            {
                if (value.HasValue)
                {
                    base.SelectedDate = value.Value;
                }
                else 
                {
                    this.Reset();
                }
            }
        }

        #endregion
    }
}
