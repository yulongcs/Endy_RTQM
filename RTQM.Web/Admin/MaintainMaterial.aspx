<%@ Page Title="物料信息维护" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="MaintainMaterial.aspx.cs" Inherits="Lgsoft.RTQM.MaintainMaterial" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/MaintainMaterial.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="MM-title">
        物料信息维护</h2>
    <div class="MM-main">
        <div class="clear">
        </div>
        <div class="MM-menu">
            <div class="MM-menuItem">
                物料编号/描述：<asp:TextBox ID="tbMaterial" CssClass="MM-MaterialNo" runat="server"></asp:TextBox>
            </div>
            <div class="MM-select">
                <asp:Button ID="btSearch" runat="server" Text="搜索" OnClick="SearchClick" />
            </div>
        </div>
        <div class="MM-view">
            <div class="mm-v-title-holder clearfix">
                <div class="th-title-no fl">
                    物料编号
                </div>
                <div class="th-title-text fl">
                    物料描述
                </div>
                <div class="th-title-op fl">
                    操作
                </div>
            </div>
            <div class="mm-viewTable-holder">
                <table class="MM-viewTable">
                    <% foreach (var d in Data.CurrentPageDataSet)
                        { %>
                    <tr>
                        <td class="MM-viewitem1">
                            <%=d.MaterialNo.Trim() %>
                        </td>
                        <td class="MM-viewitem2">
                            <%=d.MaterialDescrption.Trim() %>
                        </td>
                        <td class="MM-viewitem3" style="text-align: center" itemid="<%=d.Id.ToString().Trim()%>">
                            <span class="MM-Edit">编辑</span>&nbsp; <span class="MM-Del">删除</span>
                        </td>
                    </tr>
                <% } %>
                </table>
            </div>
            <div class="op-holder clearfix">
                <div class="op-h-no fl">
                    <input id="AddMaterialNo" class="MM-viewTableInput"/>
                </div>
                <div class="op-h-text fl">
                        <input id="AddMaterialtext" class="MM-viewTableInput"/>
                </div>
                <div class="op-h-op fl" style="text-align: center">
                        <span class="MM-Add">添加</span>&nbsp; <span class="MM-Clear">清空</span>   
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" CssClass="paginator"
            CurrentPageButtonClass="cpb" TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到"
            OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <script src="/Script/MaintainMaterial.js" type="text/javascript"></script>
</asp:Content>
