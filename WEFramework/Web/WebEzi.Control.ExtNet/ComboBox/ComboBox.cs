using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using Ext.Net;
using WebEzi.Base.DefinedData;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Combobox runat=server></{0}:Combobox>")]
    public class ComboBox : BaseComboBox
    {
        private FieldTrigger _clearTrigger;

        #region Properties

        [Category("Config Options")]
        public bool AllowShowClearTrigger
        {
            get
            {
                if (ViewState["AllowShowClearTrigger"] == null)
                {
                    ViewState["AllowShowClearTrigger"] = false;
                }
                return (bool)ViewState["AllowShowClearTrigger"];
            }
            set { ViewState["AllowShowClearTrigger"] = value; }
        }

        public ComponentDirectEvent.DirectEventHandler OnClearTriggerClick
        {
            set { this.DirectEvents.TriggerClick.Event += new ComponentDirectEvent.DirectEventHandler(value); }
        }

        #endregion

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            if (this.AllowShowClearTrigger)
            {
                // Add trigger
                if (_clearTrigger == null)
                {
                    _clearTrigger = new FieldTrigger();
                }

                _clearTrigger.Qtip = "Clear";
                _clearTrigger.Icon = TriggerIcon.Clear;
                this.Triggers.Add(_clearTrigger);
                
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.AllowShowClearTrigger)
            {
                // Add combobox client js
                this.Listeners.TriggerClick.Handler += "this.reset();";
                this.ForceSelection = false;
                this.Listeners.Blur.Handler += "if(this.selectedIndex<0){this.reset();}";
            }
        }

        #region Event

        //public event ComponentDirectEvent.DirectEventHandler ClearTriggerClick;
        //protected void OnClearTriggerClick(DirectEventArgs e)
        //{
        //    if (ClearTriggerClick != null) ClearTriggerClick(this, e);
        //}

        //void TriggerClick_Event(object sender, DirectEventArgs e)
        //{
        //    OnClearTriggerClick(e);
        //}

        #endregion
    }
}
