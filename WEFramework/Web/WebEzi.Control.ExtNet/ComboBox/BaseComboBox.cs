using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using WebEzi.Base.DefinedData;
using System.Collections;


namespace WebEzi.Control.ExtNet
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Combobox runat=server></{0}:Combobox>")]
    public abstract class BaseComboBox : Ext.Net.ComboBox
    {
        #region Properties

        [Category("Config Options")]
        public bool AllowShowTip
        {
            get
            {
                if (ViewState["AllowShowTip"] == null)
                {
                    ViewState["AllowShowTip"] = false;
                }
                return (bool)ViewState["AllowShowTip"];
            }
            set { ViewState["AllowShowTip"] = value; }
        }

        public bool IsSelected
        {
            get { return !string.IsNullOrEmpty(this.SelectedItem.Value); }
        }

        #endregion

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            // If not defin the store in the page, default generate the store
            if (this.Store.Count == 0)
            {
                // Generate store
                //14.1 RecordField has been renamed to ModelField and must be defined in Model. in Ext 2.2
                var store = new Store();
                Ext.Net.Model model = new Ext.Net.Model();
                model.Fields.Add("Text");
                model.Fields.Add("Value");
                model.IDProperty = "Value";
                store.Model.Add(model);
                this.Store.Add(store);

                // Set display and value field
                this.DisplayField = "Text";
                this.ValueField = "Value";
            }

            // If not defin the template in the page and allow show tip, use defualt template
            // ComboBox .Template has been removed. Use ComboBox ListConfig.Tpl and ListConfig.ItemTpl.
            if (this.AllowShowTip && string.IsNullOrEmpty(this.ListConfig.Tpl.Html))
            {
                var templateHtml =
                    "<tpl for=\".\"><div class=\"x-combo-list-item\"  ext:qtip=\"{{Text}}\">{{Text}}</div></tpl>";
                this.ListConfig.Tpl.Html = templateHtml.Replace("{Text}", this.DisplayField);

                //ComboBox .ItemSelector has been removed. Use ComboBox ListConfig.ItemSelector.
                this.ListConfig.ItemSelector = "div.x-combo-list-item";
            }
        }

        public void DataBind<T>(IList<T> items) 
        {
            var store = this.Store[0];
            if(store is Store)
            {
                ((Store)store).DataBind(items);
            }
            else
            {
                store.DataSource = items;
                store.DataBind();
            }
            this.SelectedItem.Value = null;
        }
    }
}
