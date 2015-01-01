using System.Collections.Generic;
using Ext.Net;

namespace DemoWebApp.ASPX.Examples
{
    public partial class OrderPanel : BasePage
    {
        #region Variable

        /// <summary>
        /// Set Add Panel button, Panel and database field relationship.
        /// </summary>
        private IEnumerable<PageControlFlag> PageControlFlags
        {
            get
            {
                return new List<PageControlFlag>
                    {
                        new PageControlFlag {MenuItem = chkMenu1, Panel = Panel1, DbFlag = "1"},
                        new PageControlFlag {MenuItem = chkMenu2, Panel = Panel2, DbFlag = "2"},
                        new PageControlFlag {MenuItem = chkMenu3, Panel = Panel3, DbFlag = "3"}
                    };
            }
        }

        #endregion

        #region Load Page

        protected override void LoadPage()
        {
            var dbFlagList=new List<string>{"1","2"};

            ShowPageControl(dbFlagList);
        }

        #endregion

        #region Event

        /// <summary>
        /// after set show panel,save the panel flag to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SaveSetting_Click(object sender, DirectEventArgs e)
        {
            var dbFlagList = new List<string>();
            foreach (var pl in plOrder.Items)
            {
                if (!pl.Hidden)
                {
                    foreach (var pcf in PageControlFlags)
                    {
                        if (pcf.MenuItem.ID.Equals(pl.ID))
                        {
                            dbFlagList.Add(pcf.DbFlag);
                        }
                    }
                }
            }

            //Save the show panel flag to database.
        }

        /// <summary>
        /// Add panel item ,show panel,and hide menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MenuItem_Click(object sender, DirectEventArgs e)
        {
            var menuItem = sender as CheckMenuItem;
            if (menuItem == null) return;
            foreach (var pcf in PageControlFlags)
            {
                if (pcf.MenuItem.ID.Equals(menuItem.ID))
                {
                    pcf.MenuItem.Hidden = true;
                    pcf.Panel.Hidden = false;
                }
            }

            //Set menu item,if no item,show No Item.
            SetMenuItem();
        }

        /// <summary>
        /// close child panel, show menu item in add panel button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChildPanel_Close(object sender, DirectEventArgs e)
        {
            var closeTool = sender as Tool;
            if (closeTool == null) return;
            AbstractContainer childPanel = closeTool.OwnerCt;
            foreach (var pcf in PageControlFlags)
            {
                if (pcf.Panel.ID.Equals(childPanel.ID))
                {
                    pcf.MenuItem.Hidden = false;
                    pcf.MenuItem.Checked = false;
                    pcf.Panel.Hidden = true;
                }
            }
            //Set menu item,if no item,show No Item.
            SetMenuItem();
        }

        #endregion

        #region Method

        /// <summary>
        /// Set the panel,menu item show or hide by db flag field.
        /// </summary>
        /// <param name="dbFlagList"></param>
        private void ShowPageControl(List<string> dbFlagList)
        {
            foreach (var flag in PageControlFlags)
            {
                if (dbFlagList.Contains(flag.DbFlag))
                {
                    flag.MenuItem.Hidden = true;
                    flag.Panel.Hidden = false;
                }
                else
                {
                    flag.MenuItem.Hidden = false;
                    flag.Panel.Hidden = true;
                }
            }
        }

        /// <summary>
        /// Set menu item,if no item,show No Item.
        /// </summary>
        private void SetMenuItem()
        {
            var flag = 0;
            foreach (var menu in btAddPanel.Menu)
            {
                foreach (var it in menu.Items)
                {
                    if (!it.Hidden)
                    {
                        flag++;
                    }
                }
            }
            menuNoItem.Hidden = flag != 0;
        }

        #endregion

        protected override void CheckLogin()
        {
        }

    }

    //Set the map of Menu item, panel, field 
    public class PageControlFlag
    {
        public CheckMenuItem MenuItem { get; set; }
        public Panel Panel { get; set; }
        public string DbFlag { get; set; }
    }

    
}