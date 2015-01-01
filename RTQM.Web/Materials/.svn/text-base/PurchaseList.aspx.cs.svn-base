using System;
using System.Web.Services;
using System.Web.UI;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.Services;
using Lgsoft.RTQM.Utility;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Wuqi.Webdiyer;

namespace Lgsoft.RTQM
{
    public partial class PurchaseList : Page
    {
        public PagedDataSet<PurchaseOrderDTO> Data;//数据集
        private int _pageIndex=0;//翻页按钮当前的显示数
        private const int pageSize = 12; //每页显示的数据
        protected void Page_Load(object sender, EventArgs e)
        {
                try
                {
                    if (ViewState["sort"] == null)
                    {
                        //查询数据集
                        SelData(string.Empty, DateTime.MinValue, DateTime.MaxValue, false);
                    }
                    else {
                        //查询数据集
                        SelData(string.Empty, DateTime.MinValue, DateTime.MaxValue, Convert.ToBoolean(ViewState["sort"]));
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
        }

        //搜索按钮事件
        protected void SearchClick(object sender, EventArgs e)
        {
            string poNo = tbPoNo.Text.Trim();
            DateTime beginDate = tbBeginDate.Text.Trim() == "" ? DateTime.MinValue : Convert.ToDateTime(tbBeginDate.Text.Trim());
            DateTime endDate = tbEndDate.Text.Trim() == "" ? DateTime.MaxValue : Convert.ToDateTime(tbEndDate.Text.Trim());
            //查询数据集
            SelData(poNo, beginDate, endDate, true);
            //设置viewstate
            SetViewSatate(poNo, tbBeginDate.Text.Trim(), tbEndDate.Text.Trim());
        }

        //翻页控件
        protected void AspNetPager1PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            _pageIndex = e.NewPageIndex - 1;
            SelData();
        }

        /// <summary>
        /// 根据订单编号、开始时间、截止时间、排列方式搜索数据
        /// </summary>
        /// <param name="poNo">订单编号</param>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        /// <param name="sort">排序方式</param>
        protected void SelData(string poNo, DateTime beginDate, DateTime endDate, bool sort)
        {
            try
            {
                // 获取 IPurchaseOrderAppService 接口的实例。
                var purchaseOrderAppService =
              Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                //根据条件获取数据集
                if (purchaseOrderAppService != null)
                {
                    Data = purchaseOrderAppService.FindPurchaseOrders(_pageIndex, pageSize, poNo, beginDate, endDate,
                                                               PurchaseOrderListSortFields.OrderDate, sort);
                }
                     //设置翻页控件的总数据数
                AspNetPager1.RecordCount = Data.DataCount;
                AspNetPager1.PageSize = pageSize;
                AspNetPager1.CurrentPageIndex = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据ViewState查询数据
        /// </summary>
          protected void SelData()
          {
              try
              {
                  string poNo = ViewState["page_PoNo"] == null ? "" : ViewState["page_PoNo"].ToString().Trim();
                  DateTime beginDate = ViewState["page_BeginDate"] == null || ViewState["page_BeginDate"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(tbBeginDate.Text.Trim());
                  DateTime endDate = ViewState["page_EndDate"] == null || ViewState["page_EndDate"].ToString() == "" ? DateTime.MaxValue : Convert.ToDateTime(tbEndDate.Text.Trim());
                  bool sort = Convert.ToBoolean(ViewState["sort"]);
                  // 获取 IPurchaseOrderAppService 接口的实例。
                  var supplierAppService =
                Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                  //根据条件获取数据集
                  if (supplierAppService != null)
                  {
                      Data = supplierAppService.FindPurchaseOrders(_pageIndex, pageSize, poNo, beginDate, endDate,
                                                                 PurchaseOrderListSortFields.OrderDate, sort);

                  }
                  //设置翻页控件的总数据数
                  AspNetPager1.RecordCount = Data.DataCount;
                  AspNetPager1.PageSize = pageSize;
                  AspNetPager1.CurrentPageIndex = 1;
              }
              catch (Exception ex)
              {
                  
                  throw ex;
              }
          }

        /// <summary>
        /// 根据数据id删除数据
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <returns></returns>
        [WebMethod]
        public static string DelData(string id)
        {
            try
            {
                // 获取 IPurchaseOrderAppService 接口的实例。
                var supplierAppService =
              Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                if (supplierAppService != null)
                {
                    supplierAppService.RemovePurchaseOrder(new Guid(id));
                }
                return "删除成功！";
            }
            catch
            {

                return "删除失败";
            }
        }

        //排序按钮
        protected void ImgBtSortClick(object sender, ImageClickEventArgs e)
        {
         if(ImgBtSort.ImageUrl=="~/Images/Descending.gif")
          {
              ViewState["sort"] = true;
              ImgBtSort.ImageUrl = "~/Images/Ascending.gif";
              //ViewState["sort"] = true;
          }
          else
          {
              ViewState["sort"] = false;
              ImgBtSort.ImageUrl = "~/Images/Descending.gif";
              //ViewState["sort"] = false;
          }
         SelData();
        }

       /// <summary>
        /// 设置ViewSate
       /// </summary>
       /// <param name="poNo">订单编号</param>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">截止时间</param>
        public void SetViewSatate(string poNo,string beginDate,string endDate)
        {
            ViewState["page_PoNo"] = poNo;
            ViewState["page_BeginDate"] = beginDate;
            ViewState["page_EndDate"] = endDate;
        }


    }
}