using System.ComponentModel;
using System.Web.UI;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:LinkButton runat=server></{0}:Button>")]
    public class LinkButton : Ext.Net.LinkButton, IValidator
    {
        protected override void OnBeforeClientInit(Ext.Net.Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (!string.IsNullOrEmpty(ValidatorForm))
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
    }
}
