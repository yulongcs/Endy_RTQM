using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lgsoft.RTQM
{
    public partial class AddComplaint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //添加数据
        protected void AddClick(object sender, EventArgs e)
        {
            string customer = tbCustomer.Text.Trim();//顾客名称
            string contact = tbContact.Text.Trim();//联系人
            string happenDate = tbHappenDate.Text.Trim();//发生日期
            string phone = tbPhone.Text.Trim();//电话号码
            string fax = tbFax.Text.Trim();//传真
            string productType = tbProductType.Text.Trim();//产品型号
            string count = tbCount.Text.Trim();//数量
            string productNo = tbProductNo.Text.Trim();//产品制造号
            string supplyDate = tbSupplyDate.Text.Trim();//供货日期
            string complaint = tbComplaint.Text.Trim();//顾客投诉/反馈详情及要求
            string tsPosition = rblTsPosition.SelectedValue.Trim();//TS立场
            string tsPositionText = tbTsPositionText.Text.Trim();//TS立场说明
        }
        //清空数据
        protected void EmptyClick(object sender, EventArgs e)
        {
            tbCustomer.Text="";//顾客名称
            tbContact.Text="";//联系人
            tbHappenDate.Text="";//发生日期
            tbPhone.Text="";//电话号码
            tbFax.Text="";//传真
            tbProductType.Text="";//产品型号
            tbCount.Text="";//数量
            tbProductNo.Text="";//产品制造号
            tbSupplyDate.Text="";//供货日期
            tbComplaint.Text="";//顾客投诉/反馈详情及要求
            rblTsPosition.Items.Clear();//TS立场
            tbTsPositionText.Text = "";//TS立场说明
        }
    }
}