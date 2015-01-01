using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Application.BaseInfoModule.Services;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Wuqi.Webdiyer;
using Container = Lgsoft.RTQM.Utility.Container;

namespace Lgsoft.RTQM
{
    public partial class MaintainSupplier : System.Web.UI.Page
    {
        private int _pageIndex = 0;//翻页按钮当前的显示数
        private const int PageSize = 50; //每页显示的数据
        public PagedDataSet<SupplierDTO> Data;//数据集
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SelData(string.Empty);//查询数据集
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="supplier">供应商名称</param>
        protected void SelData(string supplier)
        {
            var supplierAppService =
                Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
            Data = supplierAppService.FindSuppliers(_pageIndex,PageSize, supplier);
            //设置翻页控件的总数据数
            AspNetPager1.RecordCount = Data.DataCount;
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.CurrentPageIndex = 1;
        }
        //翻页控件
        protected void AspNetPager1PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            _pageIndex = e.NewPageIndex - 1;
            string material = ViewState["supplier"] == null ? "" : ViewState["supplier"].ToString().Trim();//获取物料编号/描述
            SelData(material);//查询数据集
        }
        //搜索按钮事件
        protected void SearchClick(object sender, EventArgs e)
        {
            string material =tbSupplier.Text.Trim();//物料编号/描述
            ViewState["supplier"] = material;
            SelData(material);
        }

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="supplier">供应商名称</param>
        /// <returns>操作结果信息</returns>
        [WebMethod]
        public static string AddData(string supplier)
        {
            try
            {
                var supplierAppService =
                    Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
                if(supplierAppService.IsSupplierNameExists(supplier))
                {
                    return "供应商已经存在！";
                }
                SupplierDTO addData = new SupplierDTO() { Id = new Guid(), SupplierName = supplier };//设置添加的信息
                supplierAppService.CreateNewSupplier(addData);
                return "添加成功！";
            }
            catch (Exception ex)
            {

                return "添加失败！";
            }
        }

        /// <summary>
        /// 修改物料
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="supplier">供应商名称</param>
        /// <returns>操作结果</returns>
        [WebMethod]
        public static string UpdData(string id, string supplier)
        {
            try
            {
                var supplierAppService =
               Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
                if (supplierAppService.IsSupplierNameExists(supplier))
                {
                    return "供应商已经存在！";
                }
                SupplierDTO updData = new SupplierDTO() { Id = new Guid(id), SupplierName = supplier };//设置修改的信息
                supplierAppService.UpdateSupplier(updData);
                return "修改成功";
            }
            catch (Exception)
            {

                return "修改失败";
            }
        }
        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>操作结果</returns>
        [WebMethod]
        public static string DelData(string id)
        {
            try
            {
                var supplierAppService =
             Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
                supplierAppService.RemoveSupplier(new Guid(id));
                return "删除成功";
            }
            catch (Exception)
            {

                return "删除失败";
            }
        }
        /// <summary>
        /// 根据关键字查找供应商名称
        /// </summary>
        /// <param name="str">关键字</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetSupplier(string str)
        {
            try
            {
                var supplierAppService =
             Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
                string result = "";
                if (supplierAppService != null)
                {
                    var data = supplierAppService.FindMatchedSuppliers(10,str);
                    foreach (var d in data)
                    {
                        result += d.SupplierName + "|";
                    }
                }
                return result;
            }
            catch
            {

                return null;
            }
        }

    }
}