using System;
using System.Web.Services;
using System.Web.UI;
using Lgsoft.RTQM.Application.BaseInfoModule.Services;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.Services;
using Lgsoft.RTQM.Utility;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Wuqi.Webdiyer;

namespace Lgsoft.RTQM
{
    public partial class MaterialsList : System.Web.UI.Page
    {
        public PagedDataSet<OrderLineDTO> Data; //查询数据集
        public PurchaseOrderDTO PurchaseData;//数据集
        public string PoNo; //订单编号
        public string PoDate; //订单日期
        public string PoId;//
        private int _pageIndex = 0; //翻页按钮当前的显示数
        private const int pageSize =12; //每页显示的数据
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //接收URL传过来的参数
                    string id = Request.QueryString["id"];
                    Guid guid;
                    if (id != null && Guid.TryParse(id.Trim(), out guid)) //判断id是正确
                    {
                        ViewState["PoId"] = id.Trim();
                        //获取订单信息
                        //获取订单物料数据集
                        SelData(guid, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "None", true);
                    }
                    else
                    {
                        Response.Redirect("PurchaseList.aspx");

                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void GetOrder(Guid guid)
        {
            // 获取 IPurchaseOrderAppService 接口的实例。
            var purchaseList =
          Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
            //根据条件获取数据集
            if (purchaseList != null)
            {
                PurchaseData = purchaseList.GetPurchaseOrder(guid);
            }
            
        }


        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="id">订单标识id</param>
        /// <param name="smvsNo">批号</param>
        /// <param name="materialNo">物料编号</param>
        /// <param name="supplier">供应商名称</param>
        /// <param name="minConformance">开始合格率</param>
        /// <param name="maxConformance">截止合格率</param>
        /// <param name="sortFields">排序方式，None:无，BatchNo:订单批号,Conformance：合格率,MaterialNo:物料编号，OrderDate:订单日期,SupplierName:供应商</param>
        /// <param name="sort">排序</param>
        protected void SelData(Guid id, string smvsNo, string materialNo, string supplier, string minConformance,
                               string maxConformance, string sortFields, bool sort)
        {
            try
            {
                GetOrder(id);//获取订单信息
                // 获取 IPurchaseOrderAppService 接口的实例。
                var supplierAppService =
                    Container.Current.Resolve(typeof (IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                var selData = new OrderLineFindParameters
                                  {

                                      OrderId = id,
                                      BatchNo = smvsNo.Trim(),
                                      MaterialNo = materialNo.Trim(),
                                      SupplierName = supplier.Trim(),
                                      LowConformance =
                                          minConformance.Trim() == ""
                                              ? float.MinValue
                                              : float.Parse(minConformance.Trim())/100,
                                      HighConformance =
                                          maxConformance.Trim() == ""
                                              ? float.MaxValue
                                              : float.Parse(maxConformance.Trim())/100
                                  };
               OrderLineListSortFields fields= GetSortFields(sortFields);//更加排序字段名称，返回排序类型数据
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
            string id = ViewState["PoId"].ToString().Trim();
            Guid guid;
            Guid.TryParse(id, out guid);
            GetOrder(guid);//获取订单信息
            string smvsNo = ViewState["smvsNo"] == null ? "" : ViewState["smvsNo"].ToString().Trim(); //批号
            string materialNo = ViewState["materialNo"] == null ? "" : ViewState["materialNo"].ToString().Trim(); //物料号
            string supplier = ViewState["supplier"] == null ? "" : ViewState["supplier"].ToString().Trim(); //供应商名称
            string minConformance = ViewState["minConformance"] == null
                                        ? ""
                                        : ViewState["minConformance"].ToString().Trim(); //合格率范围起始数
            string maxConformance = ViewState["maxConformance"] == null
                                        ? ""
                                        : ViewState["maxConformance"].ToString().Trim(); //合格率范围截止数
            string sortFields = ViewState["sortFields"] == null ? "None" : ViewState["sortFields"].ToString().Trim();
            bool sort = ViewState["sort"] == null ? true : Convert.ToBoolean(ViewState["sort"]); //排序方式
            try
            {
                // 获取 IPurchaseOrderAppService 接口的实例。
                var supplierAppService =
                    Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                var selData = new OrderLineFindParameters
                {
                    OrderId = guid,
                    BatchNo = smvsNo.Trim(),
                    MaterialNo = materialNo.Trim(),
                    SupplierName = supplier.Trim(),
                    LowConformance =
                        minConformance.Trim() == ""
                            ? float.MinValue
                            : float.Parse(minConformance.Trim())/100,
                    HighConformance =
                        maxConformance.Trim() == ""
                            ? float.MaxValue
                            : float.Parse(maxConformance.Trim())/100
                };
                OrderLineListSortFields fields = GetSortFields(sortFields);//根据排序字段名称，返回排序类型数据
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

        //根据排序字段名称，返回排序类型数据
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

                default:
                    return OrderLineListSortFields.None;
            }
        }

        //翻页控件
        protected void AspNetPager1PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            _pageIndex = e.NewPageIndex - 1;
            SelData();
        }

        //搜索按钮事件
        protected void BtSelectClick(object sender, EventArgs e)
        {
            try
            {
                string id = ViewState["PoId"].ToString().Trim();
                string smvsNo = tbSMVSNo.Text.Trim(); //批号
                string materialNo = tbMaterialNo.Text.Trim(); //物料号
                string supplier = tbSupplier.Text.Trim(); //供应商名称
                string minConformance = tbMinConformance.Text.Trim(); //合格率范围起始数
                string maxConformance = tbMaxConformance.Text.Trim(); //合格率范围截止数
                string sortFields = "None"; //按什么字段排序
                Guid guid;
                if (Guid.TryParse(id, out guid))
                {
                    //查询数据集
                    SelData(guid, smvsNo, materialNo, supplier, minConformance, maxConformance, sortFields, true);
                    //设置ViewSate
                    SetViewSatate(smvsNo, materialNo, supplier, minConformance, maxConformance);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据数据id删除数据
        /// </summary>
        /// <param name="id">物料ID</param>
        /// <returns>操作结果信息</returns>
        [WebMethod]
        public static string DelData(string id)
        {
            try
            {
                // 获取 IPurchaseOrderAppService 接口的实例。
                var supplierAppService =
                    Container.Current.Resolve(typeof (IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
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

        //
        /// <summary>
        /// 根据订单ID编辑物料
        /// </summary>
        /// <param name="id">物料标识id</param>
        /// <param name="smvsNo">批号</param>
        /// <param name="materialNo">物料编号 </param>
        /// <param name="supplierName">供应商名称</param>
        /// <param name="materialKind">物料类型</param>
        /// <param name="total">物料总量</param>
        /// <param name="defDes">缺陷描述</param>
        /// <param name="concessionSum">让步数量</param>
        /// <param name="reworkSum">返工数量</param>
        /// <param name="rejectionSum">退货数量</param>
        /// <param name="scrapCount">报废数量</param>
        [WebMethod]
        public static string UpdData(string id, string smvsNo, string materialNo, string supplierName, string materialKind,
                                     int total, string defDes, int concessionSum, int reworkSum, int rejectionSum, int scrapCount)
        {
            try
            {
                // 获取 IPurchaseOrderAppService 接口的实例。
                var purchaseOrder =
                    Container.Current.Resolve(typeof (IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                if (purchaseOrder != null)
                {
                    Guid guid;
                    if (Guid.TryParse(id, out guid)) //判断Guid是否正确
                    {
                        var updData = new OrderLineDTO();
                        updData.Id  = guid;
                        updData.BatchNo = smvsNo.Trim();
                        //根据物料编号查找物料的ID
                        var materialAppService =
              Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
                        if (materialAppService != null)
                        {
                         var material=materialAppService.GetMaterial(materialNo);
                            if(material!=null)
                            {
                                updData.MaterialId = material.Id;
                            }
                            else
                            {
                                return "物料不存在";
                            }
                        }
                        var supplierAppService =
                      Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
                        if (supplierAppService != null)
                        {
                            var supplier = supplierAppService.GetSupplier(supplierName);
                            if (supplier != null)
                            {
                                updData.SupplierId = supplier.Id;
                            }
                            else
                            {
                                return "供应商不存在";
                            }
                        }

                        if (materialKind.Trim() == "VI")
                        {
                            updData.MaterialType = MaterialType.VIMaterial;
                        }
                        else if (materialKind.Trim() == "EP")
                        {
                            updData.MaterialType = MaterialType.EPMaterial;
                        }
                        updData.Total = total;
                        updData.DefectDescrption = defDes;
                        updData.ConcessionCount = concessionSum;
                        updData.ReworkCount = reworkSum;
                        updData.RejectionCount = rejectionSum;
                        updData.ScrapCount = scrapCount;
                        purchaseOrder.UpdateOrderLine(updData);
                    }
                    else
                    {
                        return "修改失败！";
                    }
                }
                return "修改成功！";
            }
            catch
            {

                return "修改失败";
            }
        }

        /// <summary>
        /// 根据订单ID添加物料
        /// </summary>
        /// <param name="purchaseId">订单标识（Guid）</param>
        /// <param name="smvsNo">批号</param>
        /// <param name="materialNo">物料编号</param>
        /// <param name="supplierName">供应商名称</param>
        /// <param name="materialKind">物料类型</param>
        /// <param name="total">物料总量</param>
        /// <param name="defDes">缺陷描述</param>
        /// <param name="concessionSum">让步数量</param>
        /// <param name="reworkSum">返工数量</param>
        /// <param name="rejectionSum">退货数量</param>
        /// <param name="scrapCount">报废数量 </param>
        [WebMethod]
        public static string AddData(string purchaseId, string smvsNo, string materialNo, string supplierName,
                                     string materialKind, int total, string defDes, int concessionSum, int reworkSum,
                                     int rejectionSum, int scrapCount)
        {
            try
            {
                var purchaseOrder =
                    Container.Current.Resolve(typeof (IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                var addData = new OrderLineDTO();
                if (purchaseOrder != null)
                {
                    Guid purchaseGuid;
                    if (!Guid.TryParse(purchaseId.Trim(), out purchaseGuid))
                    {
                        return "订单错误";
                    }
                    addData.OrderId = purchaseGuid;
                    if(purchaseOrder.IsBatchNoExists(smvsNo))
                    {
                        return "批号已经存在";
                    }
                    addData.BatchNo = smvsNo.Trim();

                    var materialAppService =
               Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
                    if (materialAppService != null)
                    {
                        var material = materialAppService.GetMaterial(materialNo);
                        if (material != null)
                        {
                            addData.MaterialId = material.Id;
                        }
                        else
                        {
                            return "物料不存在";
                        }
                    }
                    var supplierAppService =
                  Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
                    if (supplierAppService != null)
                    {
                        var supplier = supplierAppService.GetSupplier(supplierName);
                        if (supplier != null)
                        {
                            addData.SupplierId = supplier.Id;
                        }
                        else
                        {
                            return "供应商不存在";
                        }
                    }
                    if (materialKind.Trim() == "VI")
                    {
                        addData.MaterialType = MaterialType.VIMaterial;
                    }
                    else if (materialKind.Trim() == "EP")
                    {
                        addData.MaterialType = MaterialType.EPMaterial;
                    }
                    addData.Total = total;
                    addData.DefectDescrption = defDes;
                    addData.ConcessionCount = concessionSum;
                    addData.ReworkCount = reworkSum;
                    addData.RejectionCount = rejectionSum;
                    addData.ScrapCount = scrapCount;
                    purchaseOrder.CreateNewOrderLine(addData);
                }
                return "添加成功";
            }
            catch
            {

                return "添加失败";
            }
        }
        /// <summary>
        /// 设置ViewSate
        /// </summary>
        /// <param name="smvsNo">批号</param>
        /// <param name="materialNo">物料号</param>
        /// <param name="supplier">供应商名称</param>
        /// <param name="minConformance">合格率范围起始值</param>
        /// <param name="maxConformance">合格率范围截止值</param>
        public void SetViewSatate(string smvsNo, string materialNo, string supplier, string minConformance,
                                  string maxConformance)
        {
            ViewState["smvsNo"] = smvsNo; //批号
            ViewState["materialNo"] = materialNo; //物料号
            ViewState["supplier"] = supplier; //供应商名称
            ViewState["minConformance"] = minConformance; //合格率范围起始数
            ViewState["maxConformance"] = maxConformance; //合格率范围截止数
        }

        //按照批号排序
        protected void ImgBtSmvsSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "BatchNo";
            bool sort;
            if (ImgBtSmvsSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort = true;
                ImgBtSmvsSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort = false;
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

        //按照合格率排序
        protected void ImgBtConformanceSortClick(object sender, ImageClickEventArgs e)
        {
            string fields = "Conformance";
            bool sort;
            if (ImgBtConformanceSort.ImageUrl == "~/Images/Descending.gif")
            {
                sort = true;
                ImgBtConformanceSort.ImageUrl = "~/Images/Ascending.gif";
            }
            else
            {
                sort = false;
                ImgBtConformanceSort.ImageUrl = "~/Images/Descending.gif";
            }
            ViewState["sortFields"] = fields;
            ViewState["sort"] = sort;
            SelData();
        }

        [WebMethod]
        public static string GetSData(string supplierName)
        {
            var supplierAppService =
                  Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
            if (supplierAppService != null)
            {
                var supplier = supplierAppService.GetSupplier(supplierName);
                if (supplier != null)
                {
                    return "notNull";
                }
                else
                {
                    return "Null";
                }
            }
            else {
                return "Null";
            }
        } 
        
    }
}