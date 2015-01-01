using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lgsoft.RTQM
{
    public partial class VerificationMeasures : System.Web.UI.Page
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
        //发送E-mail
        protected void SetEmail(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///验证 纠正和预防措施
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="validateRecord">措施验证记录</param>
        /// <param name="sign">验证人</param>
        /// <param name="date">验证日期</param>
        [WebMethod]
        public static string VerifyData(int id, string validateRecord, string sign, string date)
        {
            try
            {
                return "验证成功";
            }
            catch
            {
                return "验证失败";
            }
        }

        /// <summary>
        ///修改纠正和预防措施
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="validateRecord">措施验证记录</param>
        /// <param name="sign">验证人</param>
        /// <param name="date">验证日期</param>
        [WebMethod]
        public static string UpdData(int id, string validateRecord, string sign, string date)
        {
            try
            {
                return "修改成功"; 
            }
            catch
            {

                return "修改失败";
            }
        }
    }

    
}