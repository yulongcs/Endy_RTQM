<%@ Page Title="生成供应商质量报告" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="SupplierQualityReport.aspx.cs" Inherits="Lgsoft.RTQM.SupplierQualityReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/SupplierQualityReport.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery-ui-1.8.17.custom.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="SQR-title">
        生成供应商质量报告</h2>
    <div class="SQR-main">
        <div style="height: 30px;">
        </div>
        <div class="SQR-Date">
            <label class="s-d-label">
                选择日期：</label>
            从<asp:TextBox ID="tbBeginDate" CssClass="SQR-SearchInput" runat="server"></asp:TextBox>至
            <asp:TextBox ID="tbEndDate" CssClass="SQR-SearchInput" runat="server"></asp:TextBox>
        </div>
        <div class="SQR-OperationArea clearfix">
            <label class="s-d-label">
                选择供应商：
            </label>
            <div class="SQR-OperationItem shixjStyle">
                <%--<asp:ListBox ID="listbSuppliers" CssClass="s-o-listbox" runat="server"  SelectionMode="Multiple">
                </asp:ListBox>--%>
                <%--<asp:CheckBoxList runat="server" ID="cbl_supplierList" CssClass="s-o-listbox" ClientIDMode="Static">
                </asp:CheckBoxList>--%>
                <ul id="supplierList" class="supplierList clearfix">
                    <% foreach (var supplier in suppliers)
                       {%>
                    <li class="fl">
                        <input class="checkbox" type="checkbox" id="<%=supplier.Id %>" sName="<%=supplier.SupplierName %>" />
                        <label for="<%=supplier.Id %>" title="<%=supplier.SupplierName %>">
                            <%=supplier.SupplierName %></label>
                    </li>
                    <%} %>
                </ul>
            </div>
            <%--<div class="SQR-OperationItem">
                <div class="SQR-Operationbt">
                    <asp:Button CssClass="btn" ID="btAdd" runat="server" Text="添加>>" OnClick="AddClick" /></div>
                <div class="SQR-Operationbt">
                    <asp:Button CssClass="btn" ID="btDel" runat="server" Text="<<移除" OnClick="DelClick" /></div>
            </div>
            <div class="SQR-OperationItem">
                <asp:ListBox ID="listbSelSuppliers" CssClass="s-o-listbox" runat="server" SelectionMode="Multiple">
                </asp:ListBox>
            </div>--%>
        </div>
        <div class="SQR-OperationArea h25">
            <label class="s-d-label">
                物料类型：
            </label>
            <div class="SQR-OperationItem">
                <select id="sel_wlType">
                    <option selected="selected" value="EP">EP</option>
                    <option value="VI">VI</option>
                </select>
            </div>
        </div>
        <div class="SQR-OperationArea h45">
            <label class="s-d-label">
                导出方式：
            </label>
            <div class="SQR-OperationItem">
                <select id="sel_dcType">
                    <option selected="selected" value="m">按月导出</option>
                    <option value="w">按周导出</option>
                    <option value="d">按日导出</option>
                </select>
            </div>
        </div>
        <div class="SQR-Bts">
            <asp:HiddenField ID="hf_supplierList" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hf_wlType" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hf_dcType" runat="server" ClientIDMode="Static" />
            <asp:Button ID="btGeneration" CssClass="s-b-btn" runat="server" Text="生成Excel报表" OnClick="GenerationClick"
                ClientIDMode="Static" /></div>
    </div>
    <script src="/Script/SupplierQualityReport.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.17.js" type="text/javascript"></script>
    <script>
        $(function () {
            $("#btGeneration").bind("click", function () {
                var supplierId = "";
                //合成供应商id列表数据串
                $("#supplierList li").find("input:checked").each(function () {
                    supplierId += ($(this).attr("sName") + "/");
                });
                $("#hf_supplierList").val(supplierId);
                $("#hf_wlType").val($("#sel_wlType").val());
                $("#hf_dcType").val($("#sel_dcType").val());
                //return false;
            });
        });
    </script>
</asp:Content>
