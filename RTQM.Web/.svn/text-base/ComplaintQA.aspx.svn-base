<%@ Page Title="投诉处理QA阶段" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ComplaintQA.aspx.cs" Inherits="Lgsoft.RTQM.ComplaintQA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/ComplaintQA.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="CQA-title">
        创建纠正与预防报告</h2>
    <div class="CQA-main">
     
        <div class="CQA-ItemTitle">
            质保部的调查结果：</div> 
            <div class="CQA-ItemText">
            <asp:TextBox ID="tbUnreasonText" runat="server" CssClass="CQA-textarea" TextMode="MultiLine"></asp:TextBox>
           </div>
              <div class="CQA-mainItem">
            责任方：<asp:RadioButtonList ID="rblType" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>本公司</asp:ListItem>
                <asp:ListItem>顾客</asp:ListItem>
                 <asp:ListItem>其它</asp:ListItem>
            </asp:RadioButtonList>
            </div>
            <div class="clear"></div>
        <div class="CQA-mainBts">
            <div class="CQA-mainBtY">
                <asp:Button ID="btAdd" runat="server" Text="提交并发送邮件"  onclick="AddClick" /></div>
            <div class="CQA-mainBtN">
                <asp:Button ID="btEmpty" runat="server" Text="清空" onclick="EmptyClick" /></div>
        </div>
    </div>
    <script src="Script/ComplaintQA.js" type="text/javascript"></script>
</asp:Content>
