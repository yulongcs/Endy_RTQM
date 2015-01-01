using System;
using System.ComponentModel;
using System.Web.UI;
using Ext.Net;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:WebEziMoneyTextField runat=server></{0}:WebEziMoneyTextField>")]
    [Description(
        "Basic text field. Can be used as a direct replacement for traditional text inputs, or as the base class for more sophisticated input controls (like Ext.form.TextArea and Ext.form.ComboBox)."
        )]
    public class MoneyTextField : Ext.Net.TextField
    {
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);
            string jsCode =
                @"if(newValue!=''){ var val =newValue.replace(/[,]/g,'');   item.setValue(Ext.util.Format.usMoney(val.replace(/[$]/g, '')));}";
            this.Listeners.Change.Handler = jsCode + this.Listeners.Change.Handler;

            if (this.AllowNegative)
            {
                this.MaskRe = "/[0-9\\$\\.\\-]/";
                this.Regex = "/\\$[(0-9)\\$\\.]/";
            }
            else
            {
                this.MaskRe = "/[0-9\\$\\.]/";
                this.Regex = "/^\\$[(0-9)\\$\\.]/";
            }

            this.MaxLength = 20;
        }

        /// <summary>
        /// Render this component as lable.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("AllowNegative")]
        public virtual bool AllowNegative
        {
            get
            {
                object obj = this.ViewState["AllowNegative"];
                return (obj == null) ? true : (bool) obj;
            }
            set { this.ViewState["AllowNegative"] = value; }
        }

        /// <summary>
        /// Maximum input field length allowed (defaults to Number.MAX_VALUE).
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(24)]
        [Description("Maximum input field length allowed (defaults to Number.MAX_VALUE).")]
        public override int MaxLength
        {
            get
            {
                object obj = this.ViewState["MaxLength"];
                return (obj == null) ? 23 : (int) obj;
            }
            set { this.ViewState["MaxLength"] = value; }
        }

        public decimal? Money
        {
            get
            {
                decimal? money = null;
                if(!string.IsNullOrEmpty(this.Text))
                {
                    money = decimal.Parse(this.Text.Replace("$", "").Replace(",", ""));
                }
                return money;
            }
            set { this.Text = value.HasValue ? value.Value.ToString("C") : string.Empty; }
        }
    }
}
