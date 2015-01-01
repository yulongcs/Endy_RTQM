using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Lgsoft.RTQM
{
    public partial class ComplaintList : System.Web.UI.Page
    {
        private int _pageIndex = 0;//翻页按钮当前的显示数
        private const int PageSize = 30; //每页显示的数据
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //翻页控件
        protected void AspNetPager1PageChanging(object src, PageChangingEventArgs e)
        {
            //设置翻页控件的总数据数
            //AspNetPager1.RecordCount = Data.DataCount;
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.CurrentPageIndex = 1;
        }
        /// <summary>
        /// 根据ID删除用户投诉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        public static string DelData(int id)
        {
            try
            {
                return  "删除成功！";
            }
            catch
            {
                return  "删除失败！";
            }
        }
    }
}