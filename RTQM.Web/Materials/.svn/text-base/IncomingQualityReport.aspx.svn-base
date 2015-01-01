<%@ Page Title="采购物料质量报告" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="IncomingQualityReport.aspx.cs" Inherits="Lgsoft.RTQM.IncomingQualityReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .IQR-title
        {
            height: 30px;
            line-height: 30px;
            font-weight: bold;
            font-size: 14px;
        }
        .IQR-main
        {
            width: 350px;
            height: 280px;
            border: solid 2px #099;
            margin: 50px auto;
            border: solid 4px #CCC;
        }
        .IQR-itemtext
        {
            width: 100px;
            float: left;
            height: 20px;
            line-height: 20px;
            margin: 55px 0px 10px 50px;
            display: inline;
            text-align: right;
        }
        .IQR-item
        {
            width: 100px;
            height: 20px;
            float: left;
            margin: 55px 0px 10px 10px;
            display: inline;
            line-height: 20px;
        }
        .IQR-bt
        {
            width: 160px;
            margin: 20px auto;
        }
        #TP-menuItemArea1
        {
            display: block;
        }
        #IncomingQualityReport
        {
            color: #099;
        }
        .btn
        {
            width: 140px;
            height: 24px;
            margin-top: 15px;
        }
        .txt_limit
        {
            width: 80px;
            height: 20px;
            line-height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="IQR-title">
        生成采购物料质量报告</h2>
    <div class="IQR-main">
        <form id="iqr_form">
        <div class="IQR-itemtext">
            选择物料类型：</div>
        <div class="IQR-item">
            <asp:DropDownList ID="ddlMaterialType" Width="100px" runat="server">
                <asp:ListItem Value="EP">EP</asp:ListItem>
                <asp:ListItem Value="VI">VI</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="IQR-itemtext">
            质量控制限：</div>
        <div class="IQR-item">
            <asp:TextBox CssClass="txt_limit" runat="server" name="txt_limit" ID="txt_limit">97.5</asp:TextBox>%
            <asp:Label ID="errorTxt" runat="server" style="color:Red;"></asp:Label>
        </div>
        <div class="clear">
        </div>
        <div class="IQR-bt">
            <asp:Button ID="btSubmit" CssClass="btn" runat="server" Text="生成采购物料质量报告" OnClick="btSubmit_Click" />
        </div>
        </form>
    </div>
</asp:Content>
