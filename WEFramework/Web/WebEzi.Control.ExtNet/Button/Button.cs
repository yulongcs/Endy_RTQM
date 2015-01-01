using System.ComponentModel;
using System.Web.UI;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Button runat=server></{0}:Button>")]
    public class Button : Ext.Net.Button, IValidator
    {
        protected override void OnBeforeClientInit(Ext.Net.Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if(this.NeedGridRecord)
            {
                this.GenerateSelectionJsCode();
            }

            if(!string.IsNullOrEmpty(ValidatorForm))
            {
                this.Listeners.Click.Handler =
                    ValidatorUtil.GenerateValidatorJsCode(ValidatorForm, this.InvalidHandle, this.Listeners.Click.Handler);
            }
        }

        #region Properties

        [Category("Config Options")]
        public string ValidatorForm
        {
            get
            {
                if (ViewState["ValidatorForm"] == null)
                {
                    ViewState["ValidatorForm"] = string.Empty;
                }
                return ViewState["ValidatorForm"].ToString();
            }
            set { ViewState["ValidatorForm"] = value; }
        }

        [Category("Config Options")]
        public string InvalidHandle
        {
            get
            {
                if (ViewState["InvalidHandle"] == null)
                {
                    ViewState["InvalidHandle"] = string.Empty;
                }
                return ViewState["InvalidHandle"].ToString();
            }
            set { ViewState["InvalidHandle"] = value; }
        }

        [DefaultValue(false)]
        public bool NeedGridRecord
        {
            get
            {
                if(ViewState["NeedGridRecord"] == null)
                {
                    ViewState["NeedGridRecord"] = false;
                }
                return (bool) ViewState["NeedGridRecord"];
            }

            set
            {
                ViewState["NeedGridRecord"] = value;
            }
        }

        [Category("Config Options")]
        public bool EnableReadonlyRight
        {
            get
            {
                if (ViewState["EnableReadonlyRight"] == null)
                {
                    ViewState["EnableReadonlyRight"] = true;
                }
                return (bool)ViewState["EnableReadonlyRight"];
            }
            set { ViewState["EnableReadonlyRight"] = value; }
        }

        #endregion

        private void GenerateSelectionJsCode()
        {
            // Have to select a record in the grid first.
            string js = @"var selectCount = {0}.getSelectionModel().getCount();if(selectCount==0){ Ext.MessageBox.show({ title: 'Warning', msg: '{1}', buttons: Ext.MessageBox.OK });return false;} ";

            js = js.Replace("{0}", this.Parent.Parent.ClientID);
            js = js.Replace("{1}", "Please select a record.");

            this.Listeners.Click.Handler = js + this.Listeners.Click.Handler;
        }
    }
}
