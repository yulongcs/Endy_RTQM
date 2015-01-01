using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lgsoft.RTQM.Application.DisqualificationReportModule.DTOs;
using Lgsoft.RTQM.Application.DisqualificationReportModule.Services;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.Services;
using Lgsoft.RTQM.Utility;

namespace Lgsoft.RTQM
{
    public partial class AddMaterialNonConform : System.Web.UI.Page
    {
        public OrderLineDTO Data;//数据集
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
                        ViewState["orderId"] = id.Trim();//采购订单当行标识ID
                        GetOrderLineInfor(guid);
                    }
                    else
                    {
                        Response.Redirect("MaterialNonConformList.aspx");

                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void GetOrderLineInfor(Guid guid)
        {
            try
            {
                       var orderline =
          Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
                if (orderline != null)
                {
                    Data = orderline.GetOrderLine(guid);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void AddData(object sender, EventArgs e)
        {
            try
            {
                var disqualificationReportAppService =
        Container.Current.Resolve(typeof(IDisqualificationReportAppService), null) as
        IDisqualificationReportAppService;
                Guid orderLineId;
                if (ViewState["orderId"] != null && Guid.TryParse(ViewState["orderId"].ToString(), out orderLineId))
                {
                    var addData = new DisqualificationReportDTO();
                    addData.DefectFindIn = tbDecision.Text.Trim();//不合格发现在
                    addData.DefectDescription = tbDefectDes.Text.Trim();//不合格描述
                    addData.DisposalOption = GetDisposalOptions(rblProcessOptions.SelectedValue.Trim());//处理意见选项
                    addData.DisposalView = tbDecision.Text.Trim();//处理意见内容
                    addData.UseDepartmentView = tbHandleSubsequent.Text.Trim();//使用部门意见
                    // addData.DisposalAdvanceOption = GetDisposalAdvanceOptions(cblOpinion.SelectedValue.Trim());//处置部门意见

                 //   addData.DisposalAdvanceOption = DisposalAdvanceOptions.NeedCauseAnalysis | DisposalAdvanceOptions.NeedPreventiveAction;
                    for (int i = 0; i < cblOpinion.Items.Count; i++)//遍历所选内容
                    {
                        if (cblOpinion.Items[i].Selected)
                        {
                            addData.DisposalAdvanceOption |=GetDisposalAdvanceOptions(cblOpinion.Items[i].Text.Trim()) ;
                        }
                    }
                    addData.Decision = tbDecision.Text.Trim();//决定
                    if (disqualificationReportAppService != null)
                    { disqualificationReportAppService.CreateNewReport(orderLineId, addData); }
                }
                Response.Redirect("MaterialNonConformList.aspx");
            }
            catch (Exception)
            {
                
                throw;
            }
    
        }
        //获取处理意见
        protected DisposalOptions GetDisposalOptions(string strOptions)
        {
            switch (strOptions)
            {
                case "让步":
                    return DisposalOptions.Concession;
                case "返工":
                    return DisposalOptions.Rework;
                case "报废":
                    return DisposalOptions.Scrap;
                case "退货":
                    return DisposalOptions.Rejection;
                case "其他":
                    return DisposalOptions.Other;
                default:
                    return DisposalOptions.Other;
            }
        }
        protected DisposalAdvanceOptions GetDisposalAdvanceOptions(string strOptions)
        {
            switch (strOptions)
            {

                case "需要工艺试验":
                    return DisposalAdvanceOptions.NeedTechnologyTest;
                case "需要原因分析":
                    return DisposalAdvanceOptions.NeedCauseAnalysis;
                case "需要纠正措施":
                    return DisposalAdvanceOptions.NeedRemedialAction;
                case "需要预防措施":
                    return DisposalAdvanceOptions.NeedPreventiveAction;
                default:
                    return DisposalAdvanceOptions.NeedCauseAnalysis;
            }
        }

    }
}