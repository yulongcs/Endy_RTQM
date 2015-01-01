using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lgsoft.RTQM.Biz.Common;
using Wuqi.Webdiyer;

namespace Lgsoft.RTQM
{
    public partial class CorrectPreventionList : System.Web.UI.Page
    {
        private int _pageIndex = 0;//翻页按钮当前的显示数
        private const int PageSize = 50; //每页显示的数据
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SelData(DateTime.MinValue, DateTime.MaxValue, "", OrderDirection.Descending); //查询数据集:开始日期、截止日期,过程状态，排序方式
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //翻页控件
        protected void AspNetPager1PageChanging(object src, PageChangingEventArgs e)
        {
            try
            {
                DateTime beginDate = ViewState["beginDate"] == null
                                         ? DateTime.MinValue
                                         : Convert.ToDateTime(ViewState["beginDate"].ToString().Trim());//开始时间
                DateTime endDate = ViewState["endDate"] == null
                                       ? DateTime.MaxValue
                                       : Convert.ToDateTime(ViewState["endDate"].ToString().Trim());//截止时间
                string processState = ViewState["processState"] == null
                                          ? ""
                                          : ViewState["processState"].ToString().Trim(); //过程状态
                OrderDirection sort = OrderDirection.Descending; //排序方式
                SelData( beginDate, endDate, processState, sort); //查询数据集

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //搜索按钮事件
        protected void SelectClick(object sender, EventArgs e)
        {
            try
            {
               // string type = ddlType.SelectedValue.Trim(); //措施类型
                DateTime beginDate = tbBeiginDate.Text.Trim() == ""
                                         ? DateTime.MinValue
                                         : Convert.ToDateTime(tbBeiginDate.Text.Trim()); //开始日期
                DateTime endDate = tbEndDate.Text.Trim() == ""
                                       ? DateTime.MaxValue
                                       : Convert.ToDateTime(tbEndDate.Text.Trim()); //截止日期
               // string department = ddlDepartment.SelectedValue.Trim(); //部门名称
                string processState = ddlProcessState.SelectedValue.Trim(); //过程状态
                OrderDirection sort = OrderDirection.Descending; //排序方式
                SelData( beginDate, endDate,  processState, sort); //查询数据集
                SetViewState(tbBeiginDate.Text.Trim(), tbEndDate.Text.Trim(),processState);
                    //设置页面搜索viewState值

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //跳转创建纠正与预防报告
        protected void AddClick(object sender,EventArgs e)
        {
            Response.Redirect("AddCorrectPrevention.aspx");
        }

        /// <summary>
        /// 搜索数据集
        /// </summary>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        /// <param name="processState">过程状态</param>
        /// <param name="sort">排序类型</param>
        protected void SelData(DateTime beginDate, DateTime endDate, string processState, OrderDirection sort)
        {
            //设置翻页控件的总数据数
            //AspNetPager1.RecordCount = Data.DataCount;
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.CurrentPageIndex = 1;
        }
        /// <summary>
        /// 设置搜索ViewState
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">截止时间</param>
        /// <param name="processState">过程状态</param>
        protected void SetViewState(string beginDate, string endDate, string processState)
        {

            ViewState["beginDate"] = beginDate;
            ViewState["endDate"] = endDate;
            ViewState["processState"] = processState;
        }
        //根据数据id删除数据
        [WebMethod]
        public static string DelData(int id)
        {
            try
            {
                //var pod = IoCFactory.Resolve<IPurchaseOrderItemData>();
                //pod.DeletePurchaseOrderItem(id);
                return "删除成功！";
            }
            catch
            {

                return "删除失败";
            }
        }
        //根据日期排序
        protected void ImgDateSortClick(object sender, ImageClickEventArgs e)
        {
            OrderDirection sort;
            if (ImgDateSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort = OrderDirection.Ascending;
                ImgDateSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort = OrderDirection.Descending;
                ImgDateSort.ImageUrl = "~/Images/Descending.gif";
            }
        }

        //根据工作组排序
        protected void ImgBtDepartmentSortClick(object sender, ImageClickEventArgs e)
        {
            OrderDirection sort;
            if (ImgBtDepartmentSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort = OrderDirection.Ascending;
                ImgBtDepartmentSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort = OrderDirection.Descending;
                ImgBtDepartmentSort.ImageUrl = "~/Images/Descending.gif";
            }
        }
    }
}