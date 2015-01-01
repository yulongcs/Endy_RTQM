using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Parameter = Ext.Net.Parameter;

namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:InsertTriggerComboBox runat=server></{0}:InsertTriggerComboBox>")]
    public class InsertTriggerComboBox : BaseComboBox
    {
        private FieldTrigger _insertTrigger = new FieldTrigger();
        private ToolTip _toolTip = new ToolTip();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _toolTip = new ToolTip();
            _toolTip.Html = "Click Plus icon to insert record";
            _toolTip.Target = "#{" + this.ID + "}";
            _toolTip.Disabled = true;
            _toolTip.Anchor = "bottom";
            this.Controls.Add(_toolTip);

            // Add trigger
            _insertTrigger.Qtip = "Click Plus icon to insert record";
            _insertTrigger.Icon = TriggerIcon.SimpleAdd;
            _insertTrigger.HideTrigger = true;
            this.Triggers.Add(_insertTrigger);
     
            // Add direct event
            this.DirectEvents.TriggerClick.Event += new ComponentDirectEvent.DirectEventHandler(TriggerClick_Event);
            this.DirectEvents.TriggerClick.ExtraParams.Add(new Ext.Net.Parameter("FreeText", "this.getRawValue()",
                                                                                 ParameterMode.Raw));

        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            // Set properties
            this.MinChars = 1;
            //66.  ComboBox Mode has need renamed to QueryMode. in 2.2
            this.QueryMode = DataLoadMode.Local;
            this.ForceSelection = true;

            // Add tooltip client js
            _toolTip.Listeners.BeforeShow.Handler = "return !#{" + this.ID + "}.getTrigger(0).hidden;";

            // Add combobox client js
            this.Listeners.Select.Handler += "this.getTrigger(0).hide();#{" + _toolTip.ID + "}.disable();";
            this.Listeners.BeforeQuery.Handler +=
                "this.getTrigger(0)[this.getRawValue().toString().length == 0 ? 'hide' : 'show']();if(this.getRawValue().toString().length==0){#{" + _toolTip.ID + "}.disable();}else{#{" + _toolTip.ID + "}.show();}";
            this.Listeners.TriggerClick.Handler += "this.getTrigger(0).hide();#{" + _toolTip.ID + "}.disable();";
            this.Listeners.Blur.Handler += "this.getTrigger(0).hide();#{" + _toolTip.ID + "}.disable();";
        }

        private void TriggerClick_Event(object sender, DirectEventArgs e)
        {
            OnDirectInsertRecord(e);
        }

        #region Event

        /// <summary>
        /// Insert Record Evnet
        /// </summary>
        public event ComponentDirectEvent.DirectEventHandler DirectInsertRecord;

        protected void OnDirectInsertRecord(DirectEventArgs e)
        {
            if (DirectInsertRecord != null) DirectInsertRecord(this, e);
        }

        #endregion
    }
}
