using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lgsoft.RTQM.Application.BaseInfoModule.Services;
using Lgsoft.RTQM.Utility;


namespace Lgsoft.RTQM
{
    public partial class SupplierQualityReport : System.Web.UI.Page
    {
        public List<Application.BaseInfoModule.DTOs.SupplierDTO> suppliers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var supplierAppService =
               Container.Current.Resolve(typeof(ISupplierAppService), null) as ISupplierAppService;
                if (supplierAppService != null)
                {
                    suppliers = supplierAppService.FindSuppliers(0, int.MaxValue, string.Empty).CurrentPageDataSet;
                }
            }
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GenerationClick(object sender, EventArgs e)
        {
            var d1 = Convert.ToDateTime(tbBeginDate.Text);
            var d2 = Convert.ToDateTime(tbEndDate.Text);
            var supplierList = hf_supplierList.Value;
            string[] suppliers = supplierList.Split(new Char[] { '/' });
            var wlType = Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.EPMaterial;
            switch (hf_wlType.Value)
            {
                case "EP": wlType = Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.EPMaterial;
                    break;
                case "VI": wlType = Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.VIMaterial;
                    break;
            }
            var dcType = Utility.Export.DateRoundTypes.Day;
            switch (hf_dcType.Value)
            {
                case "m": dcType = Utility.Export.DateRoundTypes.Month;
                    break;
                case "w": dcType = Utility.Export.DateRoundTypes.Week;
                    break;
                case "d": dcType = Utility.Export.DateRoundTypes.Day;
                    break;
            }

            var excelStream = Lgsoft.RTQM.Utility.Export.SupplierQualityReportUtility.SupplierQualityReportToExcel(d1, d2, suppliers, wlType, dcType);
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            var downloadFile = MapPath("~/Temp/" + fileName);
            var fileStream = new FileStream(downloadFile, FileMode.Create, FileAccess.Write);
            excelStream.Position = 0;
            excelStream.CopyTo(fileStream);
            excelStream.Close();
            fileStream.Close();
            Response.Redirect("~/Temp/" + fileName);
        }
    }
}