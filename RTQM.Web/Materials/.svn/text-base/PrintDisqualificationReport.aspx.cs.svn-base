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
using Lgsoft.SF.Infrastructure.CrossCutting;

namespace Lgsoft.RTQM
{
    public partial class PrintDisqualificationReport : System.Web.UI.Page
    {
        public OrderLineDTO OrderlineData;
        public DisqualificationReportDTO Data;
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

                        var qualificationReportAppService =
                            Container.Current.Resolve(typeof(IDisqualificationReportAppService), null) as
                            IDisqualificationReportAppService;
                        if (qualificationReportAppService != null)
                        {
                           Data=qualificationReportAppService.GetReport(guid);
                            SetDisposalAdvanceOption();
                            SetDisposalOption();
                        }
                        var orderAppService =
                            Container.Current.Resolve(typeof (IPurchaseOrderAppService), null) as
                            IPurchaseOrderAppService;
                        if (orderAppService != null)
                        {
                            OrderlineData=orderAppService.GetOrderLine(Data.OrderLineId) ;
                        }
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
        protected void SetDisposalAdvanceOption()
        {
            //多选项去除
               if ((Data.DisposalAdvanceOption & DisposalAdvanceOptions.NeedTechnologyTest) > 0)
                {
                    ckNeedTechnologyTest.Checked = true;
                }
               if ((Data.DisposalAdvanceOption & DisposalAdvanceOptions.NeedCauseAnalysis)>0)
                {
                    ckNeedCauseAnalysis.Checked = true;    
                }
               if ((Data.DisposalAdvanceOption & DisposalAdvanceOptions.NeedRemedialAction)>0)
                {
                    ckNeedRemedialAction.Checked = true;
                }
               if ((Data.DisposalAdvanceOption & DisposalAdvanceOptions.NeedPreventiveAction)>0)
                {
                    ckNeedPreventiveAction.Checked = true;
                }
         
        }

        protected void SetDisposalOption()
        {

            switch (Data.DisposalOption)
                {
                    case DisposalOptions.Concession:
                        cbConcession.Checked =true;
                        return;
                        case DisposalOptions.Rework:
                        cbRework.Checked = true;
                        return;
                    default:
                        cbScrap.Checked = true;
                        return;
                }
            
        }

    }
}