using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lgsoft.RTQM.Application.DisqualificationReportModule.DTOs;
using Lgsoft.RTQM.Application.DisqualificationReportModule.Services;
using Lgsoft.RTQM.Utility;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Wuqi.Webdiyer;

namespace Lgsoft.RTQM
{
    public partial class MaterialNonConformList : System.Web.UI.Page
    {
        public PagedDataSet<DisqualificationReportDTO> Data;//数据集
        private int _pageIndex = 0;//翻页按钮当前的显示数
        private  int _pageSize = 30; //每页显示的数据
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SelData(string.Empty,DateTime.MinValue, DateTime.MaxValue, string.Empty,"None",true);//查询数据集
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //翻页事件
        protected void AspNetPager1PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            _pageIndex = e.NewPageIndex - 1;
            SelData();
        }
        //搜索按钮事件
        protected void SelectClick(object sender, EventArgs e)
        {
            try
            {
                string poNo = tbPoNo.Text.Trim();//订单编号
                DateTime beginDate = tbBeginDate.Text.Trim() == "" ? DateTime.MinValue : Convert.ToDateTime(tbBeginDate.Text.Trim());//设置开始时间
                DateTime endDate = tbEndDate.Text.Trim() == "" ? DateTime.MaxValue : Convert.ToDateTime(tbEndDate.Text.Trim());//设置截止时间
                string supplier = tbSupplier.Text.Trim();//供应商名称
                string sortFields = "None"; //按什么字段排序
                //设置ViewSate
                SetViewSatate(poNo, tbBeginDate.Text.Trim(), tbEndDate.Text.Trim(), supplier);
                //查询数据集
                SelData(poNo, beginDate, endDate, supplier,sortFields,true);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="poNo">订单编号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">截止时间</param>
        /// <param name="supplier">供应商</param>
        /// <param name="sortFields">排序字段 </param>
        /// <param name="sort">排序方式</param>
        protected void SelData(string poNo, DateTime  beginDate, DateTime endDate, string supplier, string sortFields, bool sort )
        {
            try
            {//获取数据集
                var qualificationReportAppService = Container.Current.Resolve(typeof(IDisqualificationReportAppService), null) as IDisqualificationReportAppService;
                var selData = new DisqualificationReportFindParameters();
                selData.OrderNo = poNo;
                selData.StartCreateDate = beginDate;
                selData.EndCreateDate = endDate;
                selData.SupplierName = supplier;
                DisqualificationReportListSortFields fields = GetSortFields(sortFields);//根据排序字段名称，返回排序类型数据
                if (qualificationReportAppService != null)
                {
                    Data = qualificationReportAppService.FindReports(_pageIndex, _pageSize, selData, fields, sort);
                }
                            //设置翻页控件的总数据数
                AspNetPager1.RecordCount = Data.DataCount;
                AspNetPager1.PageSize = _pageSize;
                AspNetPager1.CurrentPageIndex = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         protected void SelData()
         {
             try
             {
                 string poNo = ViewState["poNo"] == null ? "" : ViewState["poNo"].ToString().Trim();//订单编号
                 DateTime beginDate = ViewState["beginDate"] == null || ViewState["beginDate"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(tbBeginDate.Text.Trim());//开始时间
                 DateTime endDate = ViewState["endDate"] == null || ViewState["endDate"].ToString() == "" ? DateTime.MaxValue : Convert.ToDateTime(tbEndDate.Text.Trim());//截止时间
                 string supplier = ViewState["supplier"] == null ? "" : ViewState["supplier"].ToString().Trim();//供应商名称
                 string sortFields = ViewState["sortFields"] == null ? "None" : ViewState["sortFields"].ToString().Trim();//排序字段
                 bool sort = ViewState["sort"] == null ? true : Convert.ToBoolean(ViewState["sort"]); //排序方式
                 var qualificationReportAppService = Container.Current.Resolve(typeof(IDisqualificationReportAppService), null) as IDisqualificationReportAppService;
                 var selData = new DisqualificationReportFindParameters();
                 selData.OrderNo = poNo;
                 selData.StartCreateDate = beginDate;
                 selData.EndCreateDate = endDate;
                 selData.SupplierName = supplier;
                 DisqualificationReportListSortFields fields = GetSortFields(sortFields);//根据排序字段名称，返回排序类型数据
                 if (qualificationReportAppService != null)
                 {
                     Data = qualificationReportAppService.FindReports(_pageIndex, _pageSize, selData, fields, sort);
                 }
                 //设置翻页控件的总数据数
                 AspNetPager1.RecordCount = Data.DataCount;
                 AspNetPager1.PageSize = _pageSize;
                 AspNetPager1.CurrentPageIndex = 1;
            
             }
             catch (Exception ex)
             {

                 throw ex;
             }
         }

        protected DisqualificationReportListSortFields GetSortFields(string sortFields)
        {
            switch (sortFields.Trim())
            {
                case "OrderDate":
                    return DisqualificationReportListSortFields.OrderDate;//按订单编号排序
                case "OrderNo":
                    return DisqualificationReportListSortFields.OrderNo;//按订单编号
                case "MaterialNo":
                    return DisqualificationReportListSortFields.MaterialNo;//按物料编号
                case "SupplierName":
                    return DisqualificationReportListSortFields.SupplierName;//按供应商名称
                case "None":
                    return DisqualificationReportListSortFields.None; //没有排序
                    default:
                    return DisqualificationReportListSortFields.None;
            }
        }

        /// <summary>
        /// 设置ViewSatate
        /// </summary>
        /// <param name="poNo">订单编号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">截止时间</param>
        /// <param name="supplier">供应商名称</param>
        protected void SetViewSatate(string poNo, string beginDate, string endDate, string supplier)
        {
            ViewState["poNo"] = poNo;//订单编号
            ViewState["beginDate"] = beginDate;//开始时间
            ViewState["endDate"] = endDate;//截止时间
            ViewState["supplier"] = supplier;//供应商名称
        }
        /// <summary>
        /// 删除来料不合格信息
        /// </summary>
        /// <param name="id">来料不合格信息id</param>
        /// <returns>结果信息</returns>
        [WebMethod]
        public static string DelData(string id)
        {
            try
            {
                var qualificationReportAppService = Container.Current.Resolve(typeof(IDisqualificationReportAppService), null) as IDisqualificationReportAppService;
                Guid guid;
                if(Guid.TryParse(id,out guid))
                {
                    if (qualificationReportAppService != null)
                    {
                        qualificationReportAppService.RemoveReport(guid);
                    }
                }
                else
                {
                    return "删除失败";
                }
                return "删除成功!";
            }
            catch
            {

                return "删除失败";
            }
        }

        //按照订单编号排序
        protected void ImgBtPoNoSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "OrderNo";
            bool sort;
            if (ImgBtPoNoSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort = true;
                ImgBtPoNoSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort =false;
                ImgBtPoNoSort.ImageUrl = "~/Images/Descending.gif";
            }
            ViewState["sortFields"] = fields;
            ViewState["sort"] = sort;
            SelData();
        }

        //按照物料编号排序
        protected void ImgBtMaterialNoSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "MaterialNo";
            bool sort;
            if (ImgBtMaterialNoSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort =true;
                ImgBtMaterialNoSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort = false;
                ImgBtMaterialNoSort.ImageUrl = "~/Images/Descending.gif";
            }
            ViewState["sortFields"] = fields;
            ViewState["sort"] = sort;
            SelData();
        }
        //按照供应商排序
        protected void ImgBtSupplierSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "SupplierName";
            bool sort;
            if (ImgBtSupplierSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort = true;
                ImgBtSupplierSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort = false;
                ImgBtSupplierSort.ImageUrl = "~/Images/Descending.gif";
            }
            ViewState["sortFields"] = fields;
            ViewState["sort"] = sort;
            SelData();
        }

     
    }
}