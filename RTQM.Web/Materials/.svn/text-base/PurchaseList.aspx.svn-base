<%@ Page Title="原材料采购订单列表" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="PurchaseList.aspx.cs" Inherits="Lgsoft.RTQM.PurchaseList" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/PurchaseList.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jquery.nyroModal/styles/nyroModal.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery-ui-1.8.17.custom.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="PL-title">
        原材料采购订单列表</h2>
    <div class="PL-main">
        <div class="clear">
        </div>
        <div class="PL-menu">
            <div class="PL-menuItem">
                采购订单号：<asp:TextBox ID="tbPoNo" CssClass="PL-PoNo" runat="server"></asp:TextBox>
            </div>
            <div class="PL-menuItem" style="width: 350px">
                采购日期：从
                <asp:TextBox ID="tbBeginDate" CssClass="PL-PoDate" runat="server"></asp:TextBox>
                至
                <asp:TextBox ID="tbEndDate" CssClass="PL-PoDate" runat="server"></asp:TextBox>
            </div>
            <div class="PL-select">
                <asp:Button ID="tbSearch" runat="server" Text="搜索" OnClick="SearchClick" />
            </div>
            <div class="PL-select">
                <a class="nm" href="AddPurchase.aspx" style="font-size: 12px;">添加</a>
            </div>
        </div>
        <div class="PL-view">
            <table class="PL-viewTable">
                <tr>
                    <th class="th-title">
                        订单日期
                        <asp:ImageButton ID="ImgBtSort" BorderStyle="None" runat="server" ImageUrl="~/Images/Descending.gif"
                            Style="width: 8px; height: 11px" OnClick="ImgBtSortClick" />
                    </th>
                    <th class="th-title">
                        订单编号
                    </th>
                    <th class="th-title">
                        数量
                    </th>
                    <th class="th-title">
                        操作
                    </th>
                </tr>
                <% foreach (var d in Data.CurrentPageDataSet)
                   {%>
                <tr>
                    <td class="PL-viewitem1">
                        <%=string.Format("{0:yyyy/MM/dd}", d.OrderDate)%>
                    </td>
                    <td class="PL-viewitem2">
                        <%=d.OrderNo.Trim() %>
                    </td>
                    <td class="PL-viewitem3">
                        <%=d.LineCount %>
                    </td>
                    <td class="PL-viewitem4" style="text-align: center">
                        <span class="PL-id">
                            <%=d.Id  %></span> <span class="PL-itemEdit">编辑</span>&nbsp; <span class="PL-itemDel">
                                删除</span>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
        <div class="clear">
        </div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" PrevPageText="上一页" CssClass="paginator" CurrentPageButtonClass="cpb"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到" OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Script/PurchaseList.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.nyroModal/js/jquery.nyroModal.custom.js" type="text/javascript"></script>
    <!--[if IE 6]>
	<script type="text/javascript" src="/Scripts/jquery.nyroModal/js/jquery.nyroModal-ie6.min.js"></script>
<![endif]-->
    <script src="/Scripts/jquery-ui-1.8.17.js" type="text/javascript"></script>
    <script src="/Script/AddPurchase.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".nm").nm({ sizes: {
                minW: 360,
                minH: 202
            }
            });
            $(".PL-PoDate").datepicker({ autoSize: true });
        });
    </script>
</asp:Content>
