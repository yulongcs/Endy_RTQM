using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Application.BaseInfoModule.Services;
using Lgsoft.RTQM.Utility;
using Lgsoft.SF.Infrastructure.CrossCutting;
using Wuqi.Webdiyer;

namespace Lgsoft.RTQM
{
    public partial class MaintainMaterial : System.Web.UI.Page
    {
        private int _pageIndex = 0;//翻页按钮当前的显示数
        private const int PageSize = 50; //每页显示的数据
        public PagedDataSet<MaterialDTO> Data;//数据集
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    SelData(string.Empty);//查询数据集
                }
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
            string material = ViewState["material"] == null ? "" : ViewState["material"].ToString().Trim();//获取物料编号/描述
            SelData(material);//查询数据集
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="material">物料编号/描述</param>
        protected void SelData(string material)
        {
            var materialAppService =
                Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
            Data = materialAppService.FindMaterials(_pageIndex, PageSize, material);
            //设置翻页控件的总数据数
            AspNetPager1.RecordCount = Data.DataCount;
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.CurrentPageIndex = 1;
        }

        //查询物料信息
        protected void SearchClick(object sender, EventArgs e)
        {
            string material = tbMaterial.Text.Trim();//物料编号/描述
            SelData(material);
            ViewState["material"] = material;
        }
        /// <summary>
        /// 添加物料
        /// </summary>
        /// <param name="materialNo">物料编号</param>
        /// <param name="materialtext">物料描述</param>
        /// <returns>操作结果</returns>
        [WebMethod]
        public static string AddData(string materialNo, string materialtext)
        {
            try
            {
                var materialAppService =
                    Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
                //根据添加的物料编号查找是否已经存在
                if (materialAppService.IsMaterialNoExists(materialNo))
                {
                    return "物料编号已经存在！";
                }
                var addData = new MaterialDTO { MaterialNo = materialNo, Id = new Guid(), MaterialDescrption = materialtext };//设置添加的信息
                materialAppService.CreateNewMaterial(addData);//添加信息
                return "添加成功";
            }
            catch (Exception)
            {

                return "添加失败";
            }
        }
        /// <summary>
        /// 修改物料
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="materialNo">物料编号</param>
        /// <param name="materialtext">物料描述</param>
        /// <returns>操作结果</returns>
        [WebMethod]
        public static string UpdData(string id, string materialNo, string materialtext)
        {
            try
            {
                var materialAppService =
                    Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
                var updData = new MaterialDTO { MaterialNo = materialNo, Id = new Guid(id), MaterialDescrption = materialtext };//设置添加的信息
                materialAppService.UpdateMaterial(updData);
                return "修改成功";
            }
            catch (Exception)
            {

                return "修改失败";
            }
        }
        /// <summary>
        /// 删除物料
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>操作结果</returns>
        [WebMethod]
        public static string DelData(string id)
        {
            try
            {
                var materialAppService =
             Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
                materialAppService.RemoveMaterial(new Guid(id));
                return "删除成功";
            }
            catch (Exception)
            {

                return "删除失败";
            }
        }
        /// <summary>
        /// 根据物料编号字符联想查询的对应数据
        /// </summary>
        /// <param name="str">输入字符</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetMaterialsNo(string str)
        {
            try
            {
                var materialAppService =
                Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
                string result = "";
                if (materialAppService != null)
                {
                    var data = materialAppService.FindMatchedMaterials(10, str);
                    foreach (var d in data)
                    {
                        result += d.MaterialNo.Trim() + "|";
                    }
                }
                return result;
            }
            catch
            {

                return null;
            }
        }
        /// <summary>
        /// 根据物料编号获取物料描述
        /// </summary>
        /// <param name="materialNo"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetMaterialDescrption(string materialNo)
        {
            try
            {
                string result = "";
                var materialAppService =
               Container.Current.Resolve(typeof(IMaterialAppService), null) as IMaterialAppService;
                if (materialAppService != null)
                {
                    var data = materialAppService.GetMaterial(materialNo);
                    result = data.MaterialDescrption;
                }
                return result;
            }
            catch (Exception)
            {

                return "";
            }

        }
    }
}