using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lgsoft.RTQM
{
    public partial class CauseAnalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //接收URL传过来的参数
                    string id = Request.QueryString["id"];
                    ViewState["PoId"] = id;
                    if (id == null)
                    {
                       // Response.Redirect("CorrectPreventionList.aspx");
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //添加纠正和预防原因分析及处理信息
        protected void AddClick(object sender, EventArgs e)
        {
            tbTempMeasure.Text = "";
            tbCauseAnalysis.Text = "";
        }
        //清空信息
        protected void EmptyClick(object sender, EventArgs e)
        {
            
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
        //根据数据id删除数据
        [WebMethod]
        public static string UpdData(int id, string action,string responsible,string deadline)
        {
            try
            {
                return id+action+responsible+deadline;
            }
            catch
            {

                return "修改失败";
            }
        }

        protected void AddMaterialClick(object sender, EventArgs e)
        {
            
        }
    }
}