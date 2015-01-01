using System;
using Ext.Net;
using Ext.Net.Utilities;


namespace DemoWebApp.ASPX.Examples
{
    public partial class TreePanelView : System.Web.UI.Page
    {
        private int NewIndex
        {
            get
            {
                return (int)(Session["newIndex"] ?? 1);
            }
            set
            {
                Session["newIndex"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void ChangeItem()
        {
            if (TreePanel1.CheckedNodes != null)
            {
                foreach (SubmittedNode node in this.TreePanel1.CheckedNodes)
                {
                    var rec = GetNodeById(treeStore1, node.NodeID);
                    rec.Set("name", "Changed Item");
                    rec.SetIcon(Icon.ApplicationFormEdit);
                    rec.Commit();
                }
            }
        }

        [DirectMethod]
        public void AddChild()
        {
            TreePanel1.GetRootNode().AppendChild(new Node
            {
                NodeID = (++NewIndex).ToString(),
                CustomAttributes = { new ConfigItem("name", "Item " + NewIndex, ParameterMode.Value) },
                AllowDrag = false,
                EmptyChildren = true,
                Leaf = true,
                Checked = false,
                Icon = Icon.Application
            });
        }

        [DirectMethod]
        public void RemoveChild()
        {
            TreePanel1.GetRootNode().RemoveChild(GetNodeById(treeStore1, NewIndex--));
        }

        /// <summary>
        /// Get proxy instance for node with passed id
        /// </summary>
        /// <param name="store">TreeStore reference</param>
        /// <param name="id">Node id</param>
        /// <returns>NodeProxy</returns>
        public static NodeProxy GetNodeById(object store, object id)
        {
            return new NodeProxy(store, "getNodeById({0})".FormatWith(JSON.Serialize(id)));
        }
    }
}