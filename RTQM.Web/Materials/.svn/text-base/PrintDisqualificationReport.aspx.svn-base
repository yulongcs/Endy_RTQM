<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintDisqualificationReport.aspx.cs" Inherits="Lgsoft.RTQM.PrintDisqualificationReport" %>
<%@ Import Namespace="Lgsoft.RTQM.Application.DisqualificationReportModule.DTOs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打印不合格报告</title>
    <style type="text/css">
 body{ padding: 0px;margin: 0px;font-size: 12px;font-family:宋体}
p.MsoNormal{margin:0px;text-align: left;font-size:12px;}
.PDR-main{width:723px; margin:0px auto}
.PDR-enfont{ font-family: Arial, sans-serif;text-indent: 1em}
.PDR-cnfont{ font-family: 宋体;text-indent: 1em}
.PDR-leftTd{border: solid #000 2px;padding:0 10px}
.PDR-middleTd{ border: solid #000 2px;border-left: none;border-right: solid #000 1px;width: 290px;padding:0 10px}
.PDR-rightTd{ border: solid #000 2px;border-left: none;padding:0 10px}
.PDR-viewtable{ width: 586px; border-collapse: collapse; border: none}
.PDR-viewtable tr td{ border: solid #000 1px}
    </style>
    
    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("input").attr("disabled", "disabled");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
   
    <div>
    </div>
    <div class="PDR-main">
        <div style="width: 100px; height:30px;float:right">
        <img align="absmiddle" src="/Images/print_ico.gif">
        <a href="javascript:window.print();" style="text-decoration:none;color:#333333;">打印</a>
        </div>
        <div style=" clear:both"></div>
        <table style='border-collapse: collapse; border: none'>
            <tr style='height:40px'>
                <td class="PDR-leftTd" rowspan="5"  style='width:120px;vertical-align: middle'>
                    <p class="MsoNormal"style="text-align:center">
                        <span class="PDR-enfont">Nonconforming description</span>
                        <span class="PDR-cnfont">不合格描述（发现部门）</span></p>
                    </td>

                <td class="PDR-middleTd" >
                    <p class="MsoNormal"><span class="PDR-enfont">Material description</span></p>
                    <p class="MsoNormal"><span >名称:</span><span><%=OrderlineData.MaterialDescription.Trim()%></span></p>
                </td>
                <td  class="PDR-rightTd">
                    <p class="MsoNormal"><span class="PDR-enfont">Material No.</span></p>
                    <p class="MsoNormal"><span>图号:</span><span><%=OrderlineData.MaterialNo.Trim() %></span></p>
                </td>
            </tr>
            <tr style='height: 26.45pt'>
                 <td class="PDR-middleTd" >
                    <p class="MsoNormal"><span class="PDR-enfont">Supplier</span></p>
                    <p class="MsoNormal"><span >供应商:</span><span><%=OrderlineData.SupplierName.Trim() %></span></p>
                </td>
                <td  class="PDR-rightTd">
                    <p class="MsoNormal"><span class="PDR-enfont">Supplier's order No.</span></p>
                    <p class="MsoNormal"><span>供应商订单号:</span><span><%=OrderlineData.OrderNo.Trim() %></span></p>
                </td>
            </tr>
            <tr style='height: 29.35pt'>
                <td class="PDR-middleTd">
                    <p class="MsoNormal"><span class="PDR-enfont">Purchase Qty</span></p>
                    <p class="MsoNormal"><span >数量:</span><span><%=OrderlineData.Total %></span></p>
                </td>
                <td  class="PDR-rightTd">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                    <p class="MsoNormal"><span class="PDR-enfont">Defect Qty </span></p>
                    <p class="MsoNormal"><span>缺陷数量:</span><span><%=OrderlineData.Total-OrderlineData.QtyTotal %></span></p>
                </td>
            </tr>

            <tr style='height: 22.9pt'>
              <td  class="PDR-rightTd"width="586px" colspan="2">
                    <p class="MsoNormal"><span class="PDR-enfont">NCR found</span></p>
                    <p class="MsoNormal"><span>不合格发现在:</span><span><%=Data.DefectFindIn.Trim()%></span></p>
                </td>
            </tr>
            <tr style='height: 67.45pt'>
              <td  class="PDR-rightTd"width="586px" colspan="2" valign="top">
                    <p class="MsoNormal"><span class="PDR-enfont">Nonconforming description:</span></p>
                    <p class="MsoNormal"><span>不合格描述:</span>
                    <span><%=Data.DefectDescription.Trim()%></span></p>
                </td>
            </tr>
            <tr style='height: 160px'>
                <td class="PDR-leftTd" rowspan="3" style='width:120px;vertical-align: middle'>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
                   <p class="MsoNormal"style="text-align:center">
                        <span class="PDR-enfont">Nonconforming disposal suggestion</span>
                        <span class="PDR-cnfont">不合格处置意见 (QA)</span></p>
                    </td>

             <td class="PDR-rightTd"width="586px" colspan="2" valign="top">
             <p class="MsoNormal"><span class="PDR-enfont">Disposal Suggestion:</span></p>
             <p class="MsoNormal"><span class="PDR-cnfont">处置意见：</span></p>

                 <p class="MsoNormal" style="width: 300px; margin:0px auto"><span class="PDR-enfont" ><asp:CheckBox ID="cbConcession" runat="server" Enabled="True"/> Concession 让步（需填写让步原因如下）</span></p>
                 <p class="MsoNormal" style="width: 300px; margin:0px auto"><span class="PDR-enfont" ><asp:CheckBox ID="cbRework" runat="server" Enabled="True" /> Rework 返工 / Repair 返修  （填写返修要求如下）</span></p>
                 <p class="MsoNormal" style="width: 300px; margin:0px auto"><span class="PDR-enfont" ><asp:CheckBox ID="cbScrap" runat="server" Enabled="True"/> Scrap 报废     Rejection 退货     Other 其它 </span></p>
                 
               <table class="PDR-viewtable">
                   <tr><td rowspan="2">
                       <asp:CheckBox ID="ckNeedTechnologyTest" runat="server" /></td><td>Technical test </td><td rowspan="2"><asp:CheckBox ID="ckNeedCauseAnalysis" runat="server" /> </td ><td>Cause analysis </td><td rowspan="2"><asp:CheckBox ID="ckNeedRemedialAction" runat="server" /></td><td>Corrective actions</td><td rowspan="2"><asp:CheckBox ID="ckNeedPreventiveAction" runat="server" /></td><td>Preventive actions</td></tr>
                   <tr><td>需要工艺试验 </td><td>需要原因分析 </td><td>需要纠正措施</td><td>需要预防措施</td></tr>
                  
               </table>
          </td>
            </tr>
            <tr>
                 <td  class="PDR-rightTd" width="586px" colspan="2" valign="top">
                     <p class="MsoNormal"><span class="PDR-enfont">Use department suggestion:</span><span style="font-size: 11px">(For concession if need)</span></p>
                     <p class="MsoNormal"><span>使用部门意见:</span><span style="font-size: 11px"> ( 对零部件让步而言,必要时)</span></p>
                     <p><%=Data.UseDepartmentView.Trim()%></p>
                  </td>
            </tr>
            <tr style='height: 54.75pt'>
                 <td  class="PDR-rightTd"width="586px" colspan="2" valign="top">
                     <p class="MsoNormal"><span class="PDR-enfont">Resolution:</span><span style="font-size: 10px"> (by QA Manager only when QA engineer disagrees with responsible or when lot troubes appear)</span></p>
                     <p class="MsoNormal"><span>决定:</span><span style="font-size: 11px"> （当QA工程师与责任部门意见不同时或出现批量不合格时由质量经理作决定）</span>
                    <p><%=Data.Decision%></p>
                </td>
            </tr>
        
   <%--         <tr >
                <td width="641" colspan="3" style=' border: solid windowtext 2px;padding:0 10px'>
                    <p class="MsoNormal">
                        <span lang="EN-US" style='font-size: 12px; font-family: "Arial","sans-serif"'>Remarks</span></p>
                    <p class="MsoNormal">
                        <span style='font-size: 12px; font-family: 宋体'>备注</span></p>
                </td>
            </tr>--%>
               
        </table>
    </div>
    </form>
</body>
</html>
