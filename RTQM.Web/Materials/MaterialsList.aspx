<%@ Page Title="编辑原材料订单信息" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="MaterialsList.aspx.cs" Inherits="Lgsoft.RTQM.MaterialsList" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--页面样式-->
    <link href="/Styles/MaterialsList.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery-ui-1.8.17.custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="ML-title f14">
        编辑原材料订单信息列表</h2>
    <div class="ML-main">
        <div class="ML-infor">

            <div class="ML-inforItem">
                订单号:<span class="ML-PoNo"><%=PurchaseData.OrderNo.Trim()%></span></div>
            <div class="ML-inforItem">
                订单日期:<span class="ML-PoDate"><%=string.Format("{0:yyyy/MM/dd}",PurchaseData.OrderDate)%></span></div>
                <span id="PurchaseId" style="display:none"><%=PurchaseData.Id%></span>
        </div>
        <div class="ML-Search">
            <div class="ML-SearchItem">
                批号：<asp:TextBox ID="tbSMVSNo" CssClass="ML-SearchInput"  runat="server"></asp:TextBox></div>
            <div class="ML-SearchItem">
                物料号：<asp:TextBox ID="tbMaterialNo" CssClass="ML-SearchInput" runat="server"></asp:TextBox></div>
            <div class="ML-SearchItem">
                供应商：<asp:TextBox ID="tbSupplier" CssClass="ML-SearchInput" runat="server"></asp:TextBox></div>
            <div class="ML-SearchItem">
                合格率：
                <asp:TextBox ID="tbMinConformance" CssClass="ML-ConformanceInput" runat="server"></asp:TextBox> % - <asp:TextBox ID="tbMaxConformance" CssClass="ML-ConformanceInput" runat="server"></asp:TextBox> % 
            </div>
            <div class="ML-select">
               <asp:Button ID="btSelect" runat="server" Text="搜索" onclick="BtSelectClick" /></div>
                </div>
            <div class="ML-view">
                    <table class="ML-viewTable">
                        <tr>
                            <th class="th-title">
                                批号<asp:ImageButton ID="ImgBtSmvsSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtSmvsSortClick" />
                            </th>
                            <th class="th-title">
                                物料编号<asp:ImageButton ID="ImgBtMaterialNoSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtMaterialNoSortClick" />
                            </th>
                            <th class="th-title">
                                物料描述
                            </th>
                            <th class="th-title">
                                供应商名称<asp:ImageButton ID="ImgBtSupplierSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtSupplierSortClick" />
                            </th>
                            <th class="th-title">
                                物料类型
                            </th>
                            <th class="th-title">
                                物料总量
                            </th>
                            <th class="th-title">
                                入库总量
                            </th>
                            <th class="th-title">
                                 合格率<asp:ImageButton ID="ImgBtConformanceSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtConformanceSortClick" />
                            </th>
                            <th class="th-title">
                               缺陷描述
                            </th>
                            <th class="th-title">
                                让步数量
                            </th>
                            <th class="th-title">
                                返工数量
                            </th>
                            <th class="th-title">
                                退货数量
                            </th>
                            <th class="th-title">
                                报废数量
                            </th>
                            <th class="th-title">
                                操作
                            </th>
                        </tr>
                         <% foreach (var d in Data.CurrentPageDataSet)
                            {%> 
                        <tr>
                            <td class="ML-viewitem1">
                                <%=d.BatchNo.Trim() %>
                            </td>
                            <td class="ML-viewitem2">
                                <%=d.MaterialNo.Trim() %>
                            </td>
                            <td class="ML-viewitem3">
                                 <%=d.MaterialDescription.Trim() %>
                            </td>
                            <td class="ML-viewitem4">
                                 <%=d.SupplierName.Trim() %>
                            </td>
                            <td class="ML-viewitem5">
                                 <%=d.MaterialType== Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.EPMaterial?"EP":"VI"%>
                            </td>
                            <td class="ML-viewitem6">
                                <%=d.Total%>
                            </td>
                            <td class="ML-viewitem7">
                                <%=d.QtyTotal%>
                            </td>
                            <td class="ML-viewitem8">
                               <%=(d.Conformance * 100).ToString(".00") + "%"%>
                            </td>
                            <td class="ML-viewitem9">
                                <%=d.DefectDescrption.Trim() %>
                            </td>
                            <td class="ML-viewitem10">
                                <%=d.ConcessionCount%>
                            </td>
                            <td class="ML-viewitem11">
                                <%=d.ReworkCount %>
                            </td>
                            <td class="ML-viewitem12">
                                <%=d.RejectionCount%>
                            </td>
                            <td class="ML-viewitem13">
                                <%=d.ScrapCount %>
                            </td>
                            <td class="ML-viewitem14" style="text-align: center" itemid="<%=d.Id.ToString()%>">
                                <span class="ML-Edit" >编辑</span>&nbsp; <span class="ML-Del">删除</span>&nbsp; <span class="ML-Report">不合格报告</span>
                            </td>
                        </tr>
                    <%} %>

                        <tr>
                            <td class="ML-viewitem1">
                                <input class="addInput" id="AddSMVSNo"/>
                            </td>
                            <td class="ML-viewitem2">
                                <input class="addInput" id="AddMaterialNo" />

                            </td>
                            <td class="ML-viewitem3">
                                <input id="AddMaterialDes" readonly="readonly" />

                            </td>
                            <td class="ML-viewitem4">
                                <input class="addInput" id="AddSupplierName" />

                            </td>
                            <td class="ML-viewitem5">
                                 <select class="addInput" id="AddMaterialKind" ><option>EP</option><option>VI</option></select>
                            </td>
                            <td class="ML-viewitem6">
                                <input class="addInput" id="AddTotal" />

                            </td>
                            <td class="ML-viewitem7">
                               
                            </td>
                             <td class="ML-viewitem8"> 
                           
                            </td>
                            <td class="ML-viewitem9">
                                <input class="addInput" id="AddDefDes"/>

                            </td>
                            <td class="ML-viewitem10">
                                <input class="addInput" id="AddConcessionSum" />

                            </td>
                            <td class="ML-viewitem11">
                                <input class="addInput" id="AddReworkSum" />

                            </td>
                            <td class="ML-viewitem12">
                                <input class="addInput" id="AddRejectionSum" />

                            </td>
                             <td class="ML-viewitem13">
                                <input class="addInput" id="AddScrapCount" />

                            </td>
                            <td class="ML-viewitem14" style="text-align: center">
                             <span class="ML-Add" >添加</span>
                    
                            </td>
                        </tr>
                    </table>
               
            </div>
            <div class="clear"></div>
        <webdiyer:AspNetPager ID="AspNetPager1"  runat="server" FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" PrevPageText="上一页" CssClass="paginator" CurrentPageButtonClass="cpb"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到" OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
    </div>   
     <script src="/Script/MaterialsList.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.17.js" type="text/javascript"></script>
</asp:Content>
