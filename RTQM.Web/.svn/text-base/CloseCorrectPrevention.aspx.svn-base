<%@ Page Title="纠正与预防措施有效性评价" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="CloseCorrectPrevention.aspx.cs" Inherits="Lgsoft.RTQM.CloseCorrectPrevention" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/CloseCorrectPrevention.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="CCP-title">
        纠正与预防措施有效性评价</h2>
    <div class="CCP-main">
         <div class="CCP-ItemTitle">
            措施有效性评价：</div> 
            <div class="CCP-ItemText">
            <asp:TextBox ID="tbEvaluation" runat="server" CssClass="CCP-TextArea" TextMode="MultiLine"></asp:TextBox>
           </div>
            <div class="CCP-mainItem">
            是否有此引起相应过程/文件更改：<asp:RadioButtonList ID="rblType" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>是</asp:ListItem>
                <asp:ListItem>否</asp:ListItem>
            </asp:RadioButtonList>
            </div>
            <div class="CCP-displayDiv">
            <div class="CCP-ItemTitle">
            更改的过程/文件列表：</div> 
            <div class="CCP-ItemText">
            <asp:TextBox ID="tbUpdateText" runat="server" CssClass="CCP-TextArea" TextMode="MultiLine"></asp:TextBox>
           </div>
        </div>
        <div class="CCP-mainBts">
            <div class="CCP-mainBtY">
                <asp:Button ID="btAdd" runat="server" Text="评价"
                    onclick="btAdd_Click"  /></div>
            <div class="CCP-mainBtN">
                <asp:Button ID="btEmpty" runat="server" Text="清空" onclick="btEmpty_Click"  /></div>
        </div>
    </div>
    <script src="Script/CloseCorrectPrevention.js" type="text/javascript"></script>
</asp:Content>
