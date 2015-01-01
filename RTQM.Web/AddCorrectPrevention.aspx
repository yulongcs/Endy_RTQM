<%@ Page Title="创建纠正与预防报告" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AddCorrectPrevention.aspx.cs" Inherits="Lgsoft.RTQM.AddCorrectPrevention" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/AddCorrectPrevention.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="ACP-title">
        创建纠正与预防报告</h2>
    <div class="ACP-main">
        <div class="ACP-mainItem">
            措施类型：<asp:RadioButtonList ID="rblType" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>纠正措施</asp:ListItem>
                <asp:ListItem>预防措施</asp:ListItem>
            </asp:RadioButtonList>
            </div>
        <div class="ACP-mainItem">
            职责部门：<asp:DropDownList ID="ddlDepart" runat="server">
            <asp:ListItem >PA部门</asp:ListItem>
            <asp:ListItem >QA部门</asp:ListItem>
            </asp:DropDownList>
           </div>
             <div class="ACP-ItemTitle">
            (潜在)不合理描述：</div> 
            <div class="ACP-ItemText">
            <asp:TextBox ID="tbUnreasonText" runat="server" CssClass="ACP-Unreson" TextMode="MultiLine"></asp:TextBox>
           </div>
        <div class="ACP-mainBts">
            <div class="ACP-mainBtY">
                <asp:Button ID="btAdd" runat="server" Text="添加并发送邮件给工作组经理" OnClientClick="return demo()" onclick="AddClick" /></div>
            <div class="ACP-mainBtN">
                <asp:Button ID="btEmpty" runat="server" Text="清空" onclick="EmptyClick" /></div>
        </div>
    </div>
    <script language="javascript">
        $(function () {
            $('#mainContent_btAdd').live("click", function () {
                //调用去除特殊字符方法,解决浏览器安全问题
                filterHtmlTag('#mainContent_tbUnreasonText');
            });
            $("#mainContent_btEmpty").live("click", function () {
                //调用去除特殊字符方法,解决浏览器安全问题
                filterHtmlTag('#mainContent_tbUnreasonText');
            });
        });
    </script>
</asp:Content>
