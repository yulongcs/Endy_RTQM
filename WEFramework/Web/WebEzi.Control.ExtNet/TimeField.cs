using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace WebEzi.Control.ExtNet
{
  
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TimeField runat=server></{0}:TimeField>")]
    public class TimeField : CompositeControl, INamingContainer
    {

        //Constants for TimeFiled.
        private const string AM = "AM";
        private const string PM = "PM";
        private const int NOON_HOURS = 12;


        private readonly ComboBox _cboHour;
        private readonly NumberField _txtMinute;
        private readonly ComboBox _cboTimeSpace;
        private readonly Label _lblMinute;

        public TimeField()
        {
            _cboHour = new ComboBox();
            _cboHour.DirectEvents.Change.Event += new ComponentDirectEvent.DirectEventHandler(ChangeEvent);

            _txtMinute = new NumberField();
            _txtMinute.DirectEvents.Change.Event += new ComponentDirectEvent.DirectEventHandler(ChangeEvent);

            _cboTimeSpace = new ComboBox();
            _cboTimeSpace.DirectEvents.Change.Event += new ComponentDirectEvent.DirectEventHandler(ChangeEvent);

            _lblMinute = new Label();
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            var table = new Table();
            table.Attributes.Add("cellpadding", "0");
            table.Attributes.Add("cellspacing", "0");
            var row = new TableRow();
            table.Rows.Add(row);

            //Space Cell
            var spaceCell = new TableCell();
            spaceCell.Text = "&nbsp;";
            var spaceCell1 = new TableCell();
            spaceCell1.Text = "&nbsp;";
            var spaceCell2 = new TableCell();
            spaceCell2.Text = "&nbsp;";

            // Hour
            var hourCell = new TableCell();
            row.Cells.Add(hourCell);
            _cboHour.Items.Add(new Ext.Net.ListItem(NOON_HOURS + ":00", NOON_HOURS.ToString()));
            for (int i = 1; i < NOON_HOURS; i++)
            {
                _cboHour.Items.Add(new Ext.Net.ListItem(i.ToString() + ":00", i.ToString()));
            }
            _cboHour.Width = new Unit(this.Width.Value/3);
            _cboHour.Editable = false;
            hourCell.Controls.Add(_cboHour);

            //add space
            row.Cells.Add(spaceCell);

            // Minute
            var minuteCellText = new TableCell();
            row.Cells.Add(minuteCellText);
            _lblMinute.Text = "Minute";
            _lblMinute.Width = new Unit(this.Width.Value/5);
            minuteCellText.Controls.Add(_lblMinute);

            //add space
            row.Cells.Add(spaceCell1);

            var minuteCell = new TableCell();
            row.Cells.Add(minuteCell);
            _txtMinute.MinValue = 0;
            _txtMinute.MaxValue = 59;
            _txtMinute.MaxLength = 2;
            _txtMinute.AllowDecimals = false;
            //The server NumberField AllowNegative property has been removed in Ext 2.2. Now just set up MinValue to 0.
            //_txtMinute.AllowNegative = false;
            _txtMinute.Width = new Unit(this.Width.Value/6.5);
            minuteCell.Controls.Add(_txtMinute);

            //add space
            row.Cells.Add(spaceCell2);

            // Time space
            var timeSpaceCell = new TableCell();
            row.Cells.Add(timeSpaceCell);
            _cboTimeSpace.Items.Add(new Ext.Net.ListItem(AM, AM));
            _cboTimeSpace.Items.Add(new Ext.Net.ListItem(PM, PM));
            _cboTimeSpace.Width = new Unit(this.Width.Value/4);
            _cboTimeSpace.Editable = false;
            timeSpaceCell.Controls.Add(_cboTimeSpace);

            this.Controls.Add(table);
            ChildControlsCreated = true;
        }

        private void ChangeEvent(object sender, DirectEventArgs e)
        {
            this.OnTimeChanged(e);
        }

        #region Properties

        public TimeSpan? SelectedTime
        {
            get {
                this.EnsureChildControls();

                if (string.IsNullOrEmpty(_cboHour.SelectedItem.Value) ||
                    string.IsNullOrEmpty(_txtMinute.RawText) ||
                    string.IsNullOrEmpty(_cboTimeSpace.SelectedItem.Value))
                {
                    return null;
                }
                else
                {
                    int iHour = Transfer12HTo24H(int.Parse(_cboHour.SelectedItem.Value), _cboTimeSpace.SelectedItem.Value);
                    int iMin = (int)_txtMinute.Number;
                    return new TimeSpan(iHour, iMin, 0);
                }
            }
            set
            {
                this.EnsureChildControls();

                if (value != null)
                {
                    TimeSpan aTime = value.Value;
                    int hour12;
                    string ns;

                    Transfer24HTo12H(aTime.Hours, out hour12, out ns);

                    _cboHour.SelectedItem.Value = hour12.ToString();
                    _txtMinute.Text = aTime.Minutes.ToString();
                    _cboTimeSpace.SelectedItem.Value = ns;
                }
            }
        }

        /// <summary>
        /// The logic is:
        /// if ns=AM: if(hour=12) 24H = 0;  or  24H = hour;
        /// if ns=PM; if(hour=12) 24H = 12; or 24H = hour+12;
        /// </summary>
        /// <param name="hour">12 hours nunber:(1-12)</param>
        /// <param name="ns">AM or PM</param>
        /// <returns></returns>
        private int Transfer12HTo24H(int hour, string ns)
        {
            //The default value;
            int H24 = 0;

            //the hour must within [1,12]
            if (hour >= 1 && hour <= 12)
            {
                if (ns.Equals(AM)) 
                {
                    H24 = hour == 12 ? 0 : hour;
                }
                else if (ns.Equals(PM))
                {
                    H24 = hour == 12 ? 12 : hour + 12;
                }
            }

            return H24;
        }

        /// <summary>
        ///  The logic is:
        ///  if(hour24 = 0) hour12 = 12 and ns = AM;
        ///  if(hour24 in [1,11]) hour12 = hour24 and ns = AM;
        ///  if(hour24 = 12) hour12 = 12 and ns = PM;
        ///  if(hour24 in [13,23]) hour12 = hour24-12 and ns = PM;
        /// </summary>
        /// <param name="hour24">the 24 hours, (0-23)</param>
        /// <param name="hour12">output the 12 hours</param>
        /// <param name="ns">output the noon string (AM or PM)</param>
        /// <returns></returns>
        private void Transfer24HTo12H(int hour24,out int hour12,out string ns)
        {
            //defualt value;
            hour12 = 12;
            ns = AM;

            if(hour24 >= 0 && hour24 <= 23)
            {
                if (hour24 == 0) { hour12 = 12; ns = AM; }
                if (hour24 >= 1 && hour24 <= 11) { hour12 = hour24; ns = AM; }
                if (hour24 >= 12) { hour12 = 12; ns = PM; }
                if (hour24 >= 13 && hour24 <= 23) { hour12 = hour24-12; ns = PM; }
            }

        }

        public bool AllowBlank
        {
            get { return _cboHour.AllowBlank; }
            set 
            {
                _cboHour.AllowBlank = value;
                _txtMinute.AllowBlank = value;
                _cboTimeSpace.AllowBlank = value;
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Time Chnaged Evnet
        /// </summary>
        public event ComponentDirectEvent.DirectEventHandler TimeChanged;
        protected void OnTimeChanged(DirectEventArgs e)
        {
            if (TimeChanged != null) TimeChanged(this, e);
        }

        #endregion

        #region Methods

        public void Clear()
        {
            _cboHour.Clear();
            _txtMinute.Clear();
            _cboTimeSpace.Clear();
        }

        #endregion
    }

}
