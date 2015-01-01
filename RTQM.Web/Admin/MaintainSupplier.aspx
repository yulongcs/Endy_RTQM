<%@ Page Title="供应商信息维护" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="MaintainSupplier.aspx.cs" Inherits="Lgsoft.RTQM.MaintainSupplier" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/MaintainSupplier.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="MS-title">
        供应商信息维护</h2>
    <div class="MS-main">
        <div class="clear">
        </div>
        <div class="MS-menu">
            <div class="MS-menuItem">
                供应商名称：<asp:TextBox ID="tbSupplier" CssClass="MS-Supplier" runat="server"></asp:TextBox>
            </div>
            <div class="MS-select">
                <asp:Button ID="btSearch" runat="server" Text="搜索" OnClick="SearchClick" />
            </div>
        </div>
        <div class="MS-view">
            <div class="th-title-holder clearfix">
                <div class="th-title-name fl">
                供应商名称
                </div>
                <div class="th-title-op fl">
                    操作
                </div>
            </div>
            <div class="ms-viewTable-holder">
                <table class="MS-viewTable">
                    <%foreach (var d in Data.CurrentPageDataSet)
                      { %>
                    <tr>
                        <td class="MS-viewitem1">
                            <%=d.SupplierName.Trim() %>
                        </td>
                        <td class="MS-viewitem2" style="text-align: center" itemid="<%=d.Id%>">
                            <span class="MS-Edit">编辑</span>&nbsp; <span class="MS-Del">删除</span>
                        </td>
                    </tr>
                    <% } %>
                </table>
            </div>
            <div class="add-holder clearfix">
                <div class="MS-viewitem1 fl">
                    <input id="AddSupplier" class="MS-viewTableInput"></input>
                </div>
                <div class="MS-viewitem3 fl" style="text-align: center">
                    <span class="MS-Add">添加</span>&nbsp; <span class="MS-Clear">清空</span>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" PrevPageText="上一页" CssClass="paginator" CurrentPageButtonClass="cpb"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到" OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <script src="/Script/MaintainSupplier.js" type="text/javascript"></script>
</asp:Content>
