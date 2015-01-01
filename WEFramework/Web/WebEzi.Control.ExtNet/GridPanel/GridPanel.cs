using System.ComponentModel;
using System.Web.UI;
using WebEzi.Base.DefinedData;
using WebEzi.Base.Exception;
using System.Web.UI.HtmlControls;

[assembly: WebResource("WebEzi.Control.ExtNet.GridPanel.Resource.CellTextSelection.css", "text/css")]

namespace WebEzi.Control.ExtNet
{
    [ToolboxData("<{0}:GridPanel runat=server></{0}:GridPanel>")]
    public class GridPanel : Ext.Net.GridPanel
    {
        #region Properties

        [Category("Config Options")]
        public bool EnableTextSelection
        {
            get
            {
                if (ViewState["EnableTextSelection"] == null)
                {
                    ViewState["EnableTextSelection"] = false;
                }
                return (bool)ViewState["EnableTextSelection"];
            }
            set { ViewState["EnableTextSelection"] = value; }
        }

        #endregion

        /// <summary>
        /// Gets the key of the selected row.
        /// </summary>
        public WEKey SelectedKey
        {
            get
            {
                if (this.SelectionModel.Primary == null)
                {
                    throw new ControlException("Please set a selection model.");
                }

                var selectionModel = this.SelectionModel.Primary as Ext.Net.RowSelectionModel;
                if (selectionModel.SelectedRows.Count > 0)
                {
                    return selectionModel.SelectedRows[0].RecordID;
                }

                return string.Empty;
            }
        }

        protected override void OnPreRender(System.EventArgs e)
        {
            if (this.Page != null)
            {
                if (this.EnableTextSelection)
                {
                    // Add css refernce
                    var css = new HtmlLink();
                    css.Href = Page.ClientScript.GetWebResourceUrl(typeof (GridPanel),
                                                                   "WebEzi.Control.ExtNet.GridPanel.Resource.CellTextSelection.css");
                    css.Attributes.Add("rel", "stylesheet");
                    css.Attributes.Add("type", "text/css");
                    Page.Header.Controls.Add(css);
                }
            }

            base.OnPreRender(e);
        }

        protected override void OnBeforeClientInit(Ext.Net.Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if(this.EnableTextSelection)
            {
                // remove unselec table
                var js =
                    "if ({view}.mainBody) { {view}.mainBody.select(\".x-grid3-cell-inner\").set({ unselectable: \"\" });}";

                this.Listeners.ViewReady.Handler += js.Replace("{view}", "this.view");
                if(this.View.Count == 0)
                {
                    var gridView = new GridView();
                    gridView.Listeners.Refresh.Handler += js.Replace("{view}", "this");

                    this.View.Add(gridView);
                }
                else
                {
                    this.View[0].Listeners.Refresh.Handler += js.Replace("{view}", "this");
                }
            }
        }
    }
}
