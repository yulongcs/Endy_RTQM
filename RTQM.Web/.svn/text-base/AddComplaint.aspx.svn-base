<%@ Page Title="创建投诉报告" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AddComplaint.aspx.cs" Inherits="Lgsoft.RTQM.AddComplaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/AddComplaint.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="AC-title">
        创建原材料采购订单</h2>
    <div class="AC-main">
        <div class="AC-mainItem">
            <div class="AC-mainitemTitle">顾客名称：</div><asp:TextBox ID="tbCustomer" runat="server"></asp:TextBox></div>
            <div class="AC-mainItem">
            <div class="AC-mainitemTitle">联 系 人：</div><asp:TextBox ID="tbContact" runat="server"></asp:TextBox></div>
            <div class="AC-mainItem">
            <div class="AC-mainitemTitle">发生日期：</div><asp:TextBox ID="tbHappenDate" runat="server"></asp:TextBox></div>
            <div class="AC-mainItem">
            <div class="AC-mainitemTitle">电话号码：</div><asp:TextBox ID="tbPhone" runat="server"></asp:TextBox></div>
            <div class="AC-mainItem">
            <div class="AC-mainitemTitle">传真号码：</div><asp:TextBox ID="tbFax" runat="server"></asp:TextBox></div>
            <div class="AC-mainItem">
            <div class="AC-mainitemTitle">产品型号：</div><asp:TextBox ID="tbProductType" runat="server"></asp:TextBox></div>
            <div class="AC-mainItem">
            <div class="AC-mainitemTitle">数量：</div><asp:TextBox ID="tbCount" runat="server"></asp:TextBox></div>
            <div class="AC-mainItem">
            <div class="AC-mainitemTitle">产品制造号：</div><asp:TextBox ID="tbProductNo" runat="server"></asp:TextBox></div>
        <div class="AC-mainItem">
           <div class="AC-mainitemTitle"> 供货日期：</div><asp:TextBox ID="tbSupplyDate" runat="server"></asp:TextBox></div>
       <div class="clear"></div>
                <div class="AC-ItemTitle">顾客投诉/反馈详情及要求：</div>
                <div class="AC-ItemText"> <asp:TextBox ID="tbComplaint" CssClass="AC-Textarea" runat="server" TextMode="MultiLine"></asp:TextBox></div>
          
           <div class="AC-ItemTitle">TS立场：</div>
                <div class="AC-ItemText" style="height:30px">
                    <asp:RadioButtonList ID="rblTsPosition" runat="server" 
                        RepeatDirection="Horizontal" Width="483px">
                        <asp:ListItem>收到退回品，查明原因，再处理</asp:ListItem>
                        <asp:ListItem>先发退赔品给顾客</asp:ListItem>
                        <asp:ListItem>其它</asp:ListItem>
                        
                    </asp:RadioButtonList></div>
          
          <div class="AC-ItemTitle">TS立场说明：</div>
                <div class="AC-ItemText"> <asp:TextBox ID="tbTsPositionText" CssClass="AC-Textarea" runat="server" TextMode="MultiLine"></asp:TextBox></div>
          <div class="clear"></div>
        <div class="AC-mainBts">
            <div class="AC-mainBtY">
                <asp:Button ID="btAdd" runat="server" Text="创建并向PT部门发送邮件"  onclick="AddClick" /></div>
            <div class="AC-mainBtN">
                <asp:Button ID="btEmpty" runat="server" Text="清空" onclick="EmptyClick" /></div>
        </div>
    </div>
    <script src="Script/AddComplaint.js" type="text/javascript"></script>
</asp:Content>
