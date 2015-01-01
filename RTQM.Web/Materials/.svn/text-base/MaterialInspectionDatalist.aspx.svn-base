<%@ Page Title="原材料订单详细信息" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="MaterialInspectionDatalist.aspx.cs" Inherits="Lgsoft.RTQM.MaterialInspectionDatalist" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/MaterialInspectionDatalist.css" rel="stylesheet" type="text/css" />
     <link href="/Content/themes/base/jquery-ui-1.8.17.custom.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="MID-title">
        物料检验数据信息</h2>
    <div class="MID-main">
        <div class="MID-SearchArea">
        <div class="MID-SearchItem">
                订单编号：<asp:TextBox ID="tbPoNo" CssClass="MID-SearchInput" runat="server"></asp:TextBox></div>
           <div class="MID-SearchItem" style="width: 315px">
                订单日期：从 <asp:TextBox ID="tbBeginDate" CssClass="MID-SearchInput" runat="server"></asp:TextBox> 至 <asp:TextBox ID="tbEndDate" CssClass="MID-SearchInput" runat="server"></asp:TextBox></div>
            <div class="MID-SearchItem">
                批   号：<asp:TextBox ID="tbSMVSNo" CssClass="MID-SearchInput" runat="server"></asp:TextBox></div>
            <div class="MID-SearchItem">
                物 料 号：<asp:TextBox ID="tbMaterialNo" CssClass="MID-SearchInput" runat="server"></asp:TextBox></div>
            <div class="MID-SearchItem">
                供应商：<asp:TextBox ID="tbSupplier" CssClass="MID-SearchInput" runat="server"></asp:TextBox></div>
            <div class="MID-SearchItem">
                合格率：   <asp:TextBox ID="tbMinConformance" CssClass="MID-ConformanceInput" runat="server"></asp:TextBox> % - <asp:TextBox ID="tbMaxConformance" CssClass="MID-ConformanceInput" runat="server"></asp:TextBox> % 
            </div>
            <div class="MID-select">
                <asp:Button ID="btSelect" runat="server" CssClass="selectBt" Text="查询" 
                    onclick="SelectClick" /></div></div>
                <div class="clear"></div>
                <div class="MID-OperationArea">
                <div class="MID-OperaText"> <asp:LinkButton ID="lkbtSetExcel" runat="server" 
                                    onclick="SetExcel">生成物料检验数据Excel报表</asp:LinkButton></div>
                </div>
            <div class="MID-view">
                
                    <table class="MID-viewTable">
                        <tr  class="th-title">
                        <th>
                                订单日期<asp:ImageButton ID="ImgBtDateSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtDateSortClick" />
                            </th>
                            <th>
                                订单编号<asp:ImageButton ID="ImgBtPoNoSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtPoNoSortClick" />
                            </th>
                            <th>
                                批号<asp:ImageButton ID="ImgBtSmvsSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtSmvsSortClick" />
                            </th>
                            <th>
                                物料编号<asp:ImageButton ID="ImgBtMaterialNoSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtMaterialNoSortClick" />
                            </th>
                            <th>
                                物料描述
                            </th>
                            <th>
                                供应商名称<asp:ImageButton ID="ImgBtSupplierSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtSupplierSortClick" />
                            </th>
                            <th>
                                物料类型
                            </th>
                            <th>
                                物料总量
                            </th>
                            <th>
                                入库总量
                            </th>
                            <th>
                                 合格率<asp:ImageButton ID="ImgBtConformanceSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtConformanceSortClick" />
                            </th>
                            <th>
                               缺陷描述
                            </th>
                            <th>
                                让步数量
                            </th>
                            <th>
                                返工数量
                            </th>
                            <th>
                                退货数量
                            </th>
                            <th> 报废数量</th>
                            <th>
                                操作
                            </th>
                        </tr>
                        <% foreach (var d in Data.CurrentPageDataSet)
                           {%>
  
                       
                        <tr>
                        <td class="MID-viewitem">
                                <%=string.Format("{0:yyyy/MM/dd}",d.OrderDate)%>
                            </td>
                            <td class="MID-viewitem0">
                                <%=d.OrderNo.Trim() %>
                            </td>
                            <td class="MID-viewitem1">
                               <%=d.BatchNo.Trim() %>
                            </td>
                            <td class="MID-viewitem2">
                                <%=d.MaterialNo.Trim( ) %>
                            </td>
                            <td class="MID-viewitem3">
                                <%=d.MaterialDescription.Trim() %>
                            </td>
                            <td class="MID-viewitem4">
                                <%=d.SupplierName.Trim() %>
                            </td>
                            <td class="MID-viewitem5">
                         <%=d.MaterialType== Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs.MaterialType.EPMaterial?"EP":"VI"%>
                            </td>
                            <td class="MID-viewitem6">
                                <%=d.Total %>
                            </td>
                            <td class="MID-viewitem7">
                               <%=d.QtyTotal %>
                            </td>
                            <td class="MID-viewitem8">
                              <%=(d.Conformance*100).ToString(".00")+"%" %>
                            </td>
                            <td class="MID-viewitem9">
                                <%=d.DefectDescrption.Trim() %>
                            </td>
                            <td class="MID-viewitem10">
                               <%=d.ConcessionCount %>
                            </td>
                            <td class="MID-viewitem11">
                                <%=d.ReworkCount  %>
                            </td>
                            <td class="MID-viewitem12">
                               <%=d.RejectionCount %>
                            </td>
                            <td class="MID-viewitem13">
                                <%=d.ScrapCount %>
                            </td>
                            <td class="MID-viewitem13" style="text-align: center" itemid="<%=d.Id%>">
                              <%--<span class="MID-Edit" >编辑</span>&nbsp; --%><span class="MID-Del">删除</span>&nbsp; <span class="MID-Report">不合格报告</span>
                            </td>
                        </tr>
                          <% } %>
                    </table>
                </div>
                 <div class="clear"></div>
                 <webdiyer:AspNetPager ID="AspNetPager1"  runat="server" FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" PrevPageText="上一页" CssClass="paginator" CurrentPageButtonClass="cpb"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到" OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
            </div>
     <script src="/Script/MaterialInspectionDatalist.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.17.js" type="text/javascript"></script>
</asp:Content>
