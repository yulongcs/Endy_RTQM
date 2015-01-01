using System;
using System.Web.Services;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.Services;
using Lgsoft.RTQM.Utility;

namespace Lgsoft.RTQM
{
    public partial class AddPurchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="poNo">订单编号</param>
        /// <param name="date">订单创建日期</param>
        /// <returns></returns>
        [WebMethod]
        public static string AddData(string poNo, string date)
        {
            try
            {
                var supplierAppService =
               Container.Current.Resolve(typeof(IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
               if(supplierAppService != null && supplierAppService.IsOrderNoExists(poNo.Trim()))
               {
                   return "订单编号已经存在！";
               }
                var addData = new PurchaseOrderDTO
                                  {
                                      Id = Guid.NewGuid(),
                                      OrderNo = poNo.Trim(),
                                      OrderDate = Convert.ToDateTime(date.Trim())
                                  };
                if (supplierAppService != null)
                {
                    supplierAppService.CreateNewPurchaseOrder(addData);
                }
                return "添加成功！";
            }
            catch
            {

                return "添加失败！";
            }
        }


    }
}