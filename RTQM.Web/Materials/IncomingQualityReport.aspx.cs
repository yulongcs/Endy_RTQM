using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Lgsoft.RTQM
{
    public partial class IncomingQualityReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorTxt.Text = "";
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            var ddlMaterial = ddlMaterialType.SelectedValue;
            var materialType = Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.EPMaterial;
            switch (ddlMaterial)
            {
                case "EP": materialType = Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.EPMaterial;
                    break;
                case "VI": materialType = Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.VIMaterial;
                    break;
            }
            if (!IsNumber(txt_limit.Text)) {
                errorTxt.Text = "请输入合法数字";
                return;
            }
            errorTxt.Text = "";
            var limit = Convert.ToSingle(txt_limit.Text);
            var excelStream = Lgsoft.RTQM.Utility.Export.RawMaterialQualityReportUtility.RawMaterialQulityReportToExcel(materialType, limit);
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            var downloadFile = MapPath("~/Temp/" + fileName);
            var fileStream = new FileStream(downloadFile, FileMode.Create, FileAccess.Write);
            excelStream.Position = 0;
            excelStream.CopyTo(fileStream);
            excelStream.Close();
            fileStream.Close();
            Response.Redirect("~/Temp/" + fileName);
        }

        public bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber) &&
            !objTwoMinusPattern.IsMatch(strNumber) &&
            objNumberPattern.IsMatch(strNumber);
        }
    }
}