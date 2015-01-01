<%@ Page Title="来料不合格信息" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="MaterialNonConformList.aspx.cs" Inherits="Lgsoft.RTQM.MaterialNonConformList" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/MaterialNonConformList.css" rel="stylesheet" type="text/css" />
      <link href="/Content/themes/base/jquery-ui-1.8.17.custom.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="MNCL-title">
        来料不合格信息列表</h2>
    <div class="MNCL-main">
        <div class="MNCL-SearchArea">
            <div class="MNCL-SearchItem" style="width: 315px">
                订单日期：从 <asp:TextBox ID="tbBeginDate" CssClass="MNCL-SearchInput" runat="server"></asp:TextBox>

                至
                <asp:TextBox ID="tbEndDate" CssClass="MNCL-SearchInput" runat="server"></asp:TextBox>
                </div>
            <div class="MNCL-SearchItem">
                订单编号：<asp:TextBox ID="tbPoNo" CssClass="MNCL-SearchInput" runat="server"></asp:TextBox></div>
            <div class="MNCL-SearchItem">
                供应商：<asp:TextBox ID="tbSupplier" CssClass="MNCL-SearchInput" runat="server"></asp:TextBox></div>
            <div class="MNCL-select">
                <asp:Button ID="btSelect" runat="server" CssClass="selectBt" Text="搜索" OnClick="SelectClick" /></div>
        </div>
        <div class="clear">
        </div>
        <div class="MNCL-view">
            <table class="MNCL-viewTable">
                <tr class="th-title">
                    <th>
                        创建日期
                    </th>
                    <th>
                        订单编号<asp:ImageButton ID="ImgBtPoNoSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtPoNoSortClick" />
                    </th>
                    <th>
                        物料编号<asp:ImageButton ID="ImgBtMaterialNoSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtMaterialNoSortClick" />
                    </th>
                    <th>
                        供应商名称<asp:ImageButton ID="ImgBtSupplierSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtSupplierSortClick" />
                    </th>
                    <th>
                        物料总量
                    </th>
                    <th>
                        缺陷数量
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <%foreach (var d in Data.CurrentPageDataSet)
                  {%>
                <tr>
                    <td class="MNCL-viewitem1">
                       <%=string.Format("{0:yyyy/MM/dd}", d.CreateDate)%>
                    </td>
                    <td class="MNCL-viewitem2">
                       <%=d.OrderNo.Trim() %>
                    </td>
                    <td class="MNCL-viewitem3">
                        <%=d.MaterialNo.Trim() %>
                    </td>
                    <td class="MNCL-viewitem4">
                        <%=d.SupplierName.Trim() %>
                    </td>
                    <td class="MNCL-viewitem5">
                        <%=d.Total %>
                    </td>
                    <td class="MNCL-viewitem6">
                        <%=d.DefectCount %>
                    </td>
                    <td class="MNCL-viewitem7" style="text-align: center" itemid="<%=d.Id%>">
                        <span class="MNCL-SetWord">打印</span>&nbsp; <span class="MNCL-Del">删除</span>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
        <div class="clear">
        </div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" CssClass="paginator"
            CurrentPageButtonClass="cpb" TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到"
            OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <script src="/Script/MaterialNonConformList.js" type="text/javascript"></script>
   <script src="/Scripts/jquery-ui-1.8.17.js" type="text/javascript"></script>
</asp:Content>
