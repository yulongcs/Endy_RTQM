using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.Services;
using Lgsoft.RTQM.Utility;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Wuqi.Webdiyer;

namespace Lgsoft.RTQM
{
    public partial class MaterialInspectionDatalist : System.Web.UI.Page
    {
        public PagedDataSet<OrderLineDTO> Data; //查询数据集
        public string PoNo;//订单编号
        public string PoDate;//订单日期
        private int _pageIndex = 0;//翻页按钮当前的显示数
        private const int pageSize = 10; //每页显示的数据
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //查询数据集
                SelData(string.Empty, DateTime.MinValue, DateTime.MaxValue, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "None", true);
   
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
                string poNo = tbPoNo.Text.Trim(); //订单编号
                DateTime beginDate = tbBeginDate.Text.Trim() == "" ? DateTime.MinValue : Convert.ToDateTime(tbBeginDate.Text.Trim()); //开始时间
                DateTime endDate =tbEndDate.Text.Trim()==""?DateTime.MaxValue:Convert.ToDateTime(tbEndDate.Text.Trim()); //截止时间
                string smvsNo = tbSMVSNo.Text.Trim(); //批号
                string materialNo = tbMaterialNo.Text.Trim(); //物料号
                string supplier = tbSupplier.Text.Trim(); //供应商名称
                string minConformance = tbMinConformance.Text.Trim(); //合格率范围起始数
                string maxConformance = tbMaxConformance.Text.Trim(); //合格率范围截止数
                string sortFields = "None";//排序字段
                bool sort = true;//排序方式
                //查询数据集
                SelData(poNo,beginDate,endDate,smvsNo,materialNo,supplier,minConformance,maxConformance,sortFields,sort);
                SetViewSatate(poNo, tbBeginDate.Text.Trim(), tbEndDate.Text.Trim(), smvsNo, materialNo, supplier, minConformance, maxConformance);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //翻页控件
        protected void AspNetPager1PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            _pageIndex = e.NewPageIndex - 1;
            SelData();
        }

        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="poNo">订单编号</param>
        /// <param name="beginDate">订单开始日期</param>
        /// <param name="endDate">订单截止日期</param>
        /// <param name="smvsNo">批号</param>
        /// <param name="materialNo">物料编号</param>
        /// <param name="supplier">供应商名称</param>
        /// <param name="minConformance">开始合格率</param>
        /// <param name="maxConformance">截止合格率</param>
        /// <param name="sortFields">排序方式，None:无，BatchNo:订单批号,Conformance：合格率,MaterialNo:物料编号，OrderDate:订单日期,SupplierName:供应商</param>
        /// <param name="sort">排序</param>
        protected void SelData(string poNo, DateTime beginDate, DateTime endDate, string smvsNo, string materialNo, string supplier, string minConformance, string maxConformance, string sortFields, bool sort)
        {
            try
            {//获取数据集
                 // 获取 IPurchaseOrderAppService 接口的实例。
                var supplierAppService =
              Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                var selData = new OrderLineFindParameters();
                selData.OrderNo = poNo;
                selData.StartOrderDate = beginDate;
                selData.EndOrderDate = endDate;
                selData.BatchNo = smvsNo.Trim();
                selData.MaterialNo = materialNo.Trim();
                selData.SupplierName = supplier.Trim();
                selData.LowConformance = minConformance.Trim() == "" ? float.MinValue : float.Parse(minConformance.Trim())/100;
                selData.HighConformance = maxConformance.Trim() == "" ? float.MaxValue : float.Parse(maxConformance.Trim())/100;
                OrderLineListSortFields fields = GetSortFields(sortFields);//更加排序字段名称，返回排序类型数据
                if (supplierAppService != null)
                {
                    Data = supplierAppService.FindOrderLines(_pageIndex, pageSize, selData, fields, sort);
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
                string poNo = ViewState["poNo"] == null ? "" : ViewState["poNo"].ToString().Trim();//订单编号
                DateTime beginDate = ViewState["beginDate"] == null || ViewState["beginDate"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(tbBeginDate.Text.Trim());//开始时间
                DateTime endDate = ViewState["endDate"] == null || ViewState["endDate"].ToString() == "" ? DateTime.MaxValue : Convert.ToDateTime(tbEndDate.Text.Trim());//截止时间
                string smvsNo = ViewState["smvsNo"] == null ? "" : ViewState["smvsNo"].ToString().Trim();//批号
                string materialNo = ViewState["materialNo"] == null ? "" : ViewState["materialNo"].ToString().Trim();//物料号
                string supplier = ViewState["supplier"] == null ? "" : ViewState["supplier"].ToString().Trim();//供应商名称
                string minConformance = ViewState["minConformance"] == null ? "" : ViewState["minConformance"].ToString().Trim();//合格率范围起始数
                string maxConformance = ViewState["maxConformance"] == null ? "" : ViewState["maxConformance"].ToString().Trim();//合格率范围截止数
                string sortFields = ViewState["sortFields"] == null ? "None" : ViewState["sortFields"].ToString().Trim();
                bool sort = ViewState["sort"] == null ? true : Convert.ToBoolean(ViewState["sort"]); //排序方式
                // 获取 IPurchaseOrderAppService 接口的实例。
                var supplierAppService =
              Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                var selData = new OrderLineFindParameters();
                selData.OrderNo = poNo;
                selData.StartOrderDate = beginDate;
                selData.EndOrderDate = endDate;
                selData.BatchNo = smvsNo.Trim();
                selData.MaterialNo = materialNo.Trim();
                selData.SupplierName = supplier.Trim();
                selData.LowConformance = minConformance.Trim() == "" ? float.MinValue : float.Parse(minConformance.Trim())/100;
                selData.HighConformance = maxConformance.Trim() == "" ? float.MaxValue : float.Parse(maxConformance.Trim())/100;
                OrderLineListSortFields fields = GetSortFields(sortFields);//更加排序字段名称，返回排序类型数据
                if (supplierAppService != null)
                {
                    Data = supplierAppService.FindOrderLines(_pageIndex, pageSize, selData, fields, sort);
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
        //更加排序字段名称，返回排序类型数据
        public OrderLineListSortFields GetSortFields(string sortFields)
        {
            switch (sortFields.Trim())
            {
                case "None":
                    return OrderLineListSortFields.None; //无排序

                case "BatchNo":
                    return OrderLineListSortFields.BatchNo; //按订单批号排序

                case "Conformance":
                    return OrderLineListSortFields.Conformance; //按合格率排序

                case "MaterialNo":
                    return OrderLineListSortFields.MaterialNo; //按物料编号排序

                case "OrderDate":
                    return OrderLineListSortFields.OrderDate; //按订单日期排序

                case "SupplierName":
                    
                    return OrderLineListSortFields.SupplierName; //按供应商排序
                case "OrderNo":
                    return OrderLineListSortFields.OrderNo;//按照订单编号排序
                default:
                    return OrderLineListSortFields.None;
            }
        }
        /// <summary>
        /// 设置ViewSate
        /// </summary>
        /// <param name="poNo"> 订单编号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">截止时间</param>
        /// <param name="smvsNo">批号</param>
        /// <param name="materialNo">物料号</param>
        /// <param name="supplier">供应商名称</param>
        /// <param name="minConformance">合格率范围起始值</param>
        /// <param name="maxConformance">合格率范围截止值</param>
        protected void SetViewSatate(string poNo,string beginDate,string endDate,string smvsNo, string materialNo, string supplier, string minConformance, string maxConformance)
        {
            ViewState["poNo"] = poNo;//订单编号
            ViewState["beginDate"] = beginDate;//开始时间
            ViewState["endDate"] = endDate;//截止时间
            ViewState["smvsNo"] = smvsNo;//批号
            ViewState["materialNo"] = materialNo;//物料号
            ViewState["supplier"] = supplier;//供应商名称
            ViewState["minConformance"] = minConformance;//合格率范围起始数
            ViewState["maxConformance"] = maxConformance;//合格率范围截止数
        }
        /// <summary>
        /// 删除物料信息
        /// </summary>
        /// <param name="id">物料id</param>
        /// <returns>结果信息</returns>
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
                    Guid guid;
                    if (Guid.TryParse(id, out guid)) //判断Guid是否正确
                    {
                        supplierAppService.RemoveOrderLine(guid);
                    }
                    else
                    {
                        return "删除失败！";
                    }
                }
                return "删除成功！";
            }
            catch
            {

                return "删除失败";
            }
        }
        //按照批号排序
        protected void ImgBtSmvsSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "BatchNo";
            bool sort;
            if (ImgBtSmvsSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort =false;
                ImgBtSmvsSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort =true;
                ImgBtSmvsSort.ImageUrl = "~/Images/Descending.gif";
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
                sort = true;
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
                sort =true;
                ImgBtSupplierSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort =false;
                ImgBtSupplierSort.ImageUrl = "~/Images/Descending.gif";
            }
            ViewState["sortFields"] = fields;
            ViewState["sort"] = sort;
            SelData();
        }
        //按照合格率排序
        protected void ImgBtConformanceSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "Conformance";
            bool sort;
            if (ImgBtConformanceSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort =false;
                ImgBtConformanceSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort =true;
                ImgBtConformanceSort.ImageUrl = "~/Images/Descending.gif";
            }
            ViewState["sortFields"] = fields;
            ViewState["sort"] = sort;
            SelData();
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

        //按照订单日期排序
        protected void ImgBtDateSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "OrderDate";
            bool sort;
            if (ImgBtDateSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort = false;
                ImgBtDateSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort =true;
                ImgBtDateSort.ImageUrl = "~/Images/Descending.gif";
            }
            ViewState["sortFields"] = fields;
            ViewState["sort"] = sort;
            SelData();
        }
        //生成Exel文件
        protected void SetExcel(object sender, EventArgs e)
        {
            PagedDataSet<OrderLineDTO> setExcelData = null;
            string poNo = ViewState["poNo"] == null ? "" : ViewState["poNo"].ToString().Trim();//订单编号
            DateTime beginDate = ViewState["beginDate"] == null || ViewState["beginDate"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(tbBeginDate.Text.Trim());//开始时间
            DateTime endDate = ViewState["endDate"] == null || ViewState["endDate"].ToString() == "" ? DateTime.MaxValue : Convert.ToDateTime(tbEndDate.Text.Trim());//截止时间
            string smvsNo = ViewState["smvsNo"] == null ? "" : ViewState["smvsNo"].ToString().Trim();//批号
            string materialNo = ViewState["materialNo"] == null ? "" : ViewState["materialNo"].ToString().Trim();//物料号
            string supplier = ViewState["supplier"] == null ? "" : ViewState["supplier"].ToString().Trim();//供应商名称
            string minConformance = ViewState["minConformance"] == null ? "" : ViewState["minConformance"].ToString().Trim();//合格率范围起始数
            string maxConformance = ViewState["maxConformance"] == null ? "" : ViewState["maxConformance"].ToString().Trim();//合格率范围截止数
            string sortFields = ViewState["sortFields"] == null ? "None" : ViewState["sortFields"].ToString().Trim();
            bool sort = ViewState["sort"] == null ? true : Convert.ToBoolean(ViewState["sort"]); //排序方式
            // 获取 IPurchaseOrderAppService 接口的实例。
            var supplierAppService =
          Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
            var selData = new OrderLineFindParameters();
            selData.OrderNo = poNo;
            selData.StartOrderDate = beginDate;
            selData.EndOrderDate = endDate;
            selData.BatchNo = smvsNo.Trim();
            selData.MaterialNo = materialNo.Trim();
            selData.SupplierName = supplier.Trim();
            selData.LowConformance = minConformance.Trim() == "" ? float.MinValue : float.Parse(minConformance.Trim()) / 100;
            selData.HighConformance = maxConformance.Trim() == "" ? float.MaxValue : float.Parse(maxConformance.Trim()) / 100;
            OrderLineListSortFields fields = GetSortFields(sortFields);//更加排序字段名称，返回排序类型数据
            if (supplierAppService != null)
            {
                setExcelData = supplierAppService.FindOrderLines(0, int.MaxValue, selData, fields, sort);
            }
            if(setExcelData.DataCount==0)
            {
  
                Response.Write("<script>alert('没有导出数据，无法导出！')</script>");
                return;
            }
            var dataToExportSource = setExcelData.CurrentPageDataSet;
            var dataToExport = (from line in dataToExportSource
                               select new
                                          {
                                              line.OrderNo,
                                              OrderDate = line.OrderDate.ToShortDateString(),
                                              line.BatchNo,
                                              line.MaterialNo,
                                              line.MaterialDescription,
                                              line.SupplierName,
                                              MaterialType = line.MaterialType == MaterialType.EPMaterial ? "EP" : "VI",
                                              line.Total,
                                              line.DefectDescrption,
                                              line.ConcessionCount,
                                              line.ReworkCount,
                                              line.RejectionCount,
                                              line.ScrapCount,
                                              line.QtyTotal,
                                              Conformance = (line.Conformance*100).ToString(".00") + "%",
                                          }).ToList();

            var fieldMap = new Dictionary<string, string>();
            fieldMap.Add("BatchNo", "批号");
            fieldMap.Add("MaterialDescription", "物料描述");
            fieldMap.Add("OrderNo", "订单编号");
            fieldMap.Add("OrderDate", "订单日期");
            fieldMap.Add("MaterialNo", "物料编号");
            fieldMap.Add("SupplierName", "供应商名称");
            fieldMap.Add("MaterialType", "物料类型");
            fieldMap.Add("Total", "物料总数");
            fieldMap.Add("DefectDescrption", "缺陷描述");
            fieldMap.Add("ConcessionCount", "让步数量");
            fieldMap.Add("ReworkCount", "返工数量");
            fieldMap.Add("RejectionCount", "退货数量");
            fieldMap.Add("ScrapCount", "报废数量");
            fieldMap.Add("QtyTotal", "入库总数");
            fieldMap.Add("Conformance", "合格率");
            
        
            var s = ListExportUtility.ListExport(dataToExport, fieldMap);
            if (s != null)
            {
                s.Position = 0;
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".csv";
                var downloadFile = MapPath("~/Temp/" + fileName);
                var fileStream = new FileStream(downloadFile, FileMode.Create, FileAccess.Write);
                s.CopyTo(fileStream);
                s.Close();
                fileStream.Close();

                Response.Redirect("~/Temp/" + fileName);
            }
        }
    }
}