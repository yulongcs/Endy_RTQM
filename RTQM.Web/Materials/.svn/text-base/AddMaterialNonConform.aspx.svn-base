<%@ Page Title="创建来料不合格信息" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AddMaterialNonConform.aspx.cs" Inherits="Lgsoft.RTQM.AddMaterialNonConform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/AddMaterialNonConform.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
  <h2 class="AMNC-title">
        创建来料不合格信息</h2>
        <div class="AMNC-main">
        <div class="AMNC-BasicInfor">
            <div class="AMNC-BasicInforItem">物料编号：<span class="AMNC-MaterialNo"><%=Data.MaterialNo.Trim() %></span></div>
            <div class="AMNC-BasicInforItem">物料描述：<span class="AMNC-MaterialDes"><%=Data.MaterialDescription.Trim() %></span></div>
            <div class="AMNC-BasicInforItem">供应商名称：<span class="AMNC-Supplier"><%=Data.SupplierName.Trim() %></span></div>
            <div class="AMNC-BasicInforItem">订单编号：<span class="AMNC-PoNo"><%=Data.OrderNo %></span></div>
            <div class="AMNC-BasicInforItem">物料总数：<span class="AMNC-Total"><%=Data.Total %></span></div>
            <div class="AMNC-BasicInforItem">缺陷数量：<span class="AMNC-DefectNo"><%=Data.Total-Data.QtyTotal%></span></div>
        </div>
        <div class="AMNC-AddInfor">
            <div class="AMNC-AddInforItem">不合格发现在：<asp:TextBox ID="tbDefect" CssClass="AMNC-AddInput" runat="server" TextMode="MultiLine"></asp:TextBox></div>
            <div class="AMNC-AddInforItem">不合格描述：<asp:TextBox ID="tbDefectDes" CssClass="AMNC-AddInput" runat="server" TextMode="MultiLine"></asp:TextBox></div>
            <div class="AMNC-AddInforItem">处理意见选项：<asp:RadioButtonList ID="rblProcessOptions" 
                    runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>让步</asp:ListItem>
                    <asp:ListItem>返工</asp:ListItem>
                    <asp:ListItem>返修</asp:ListItem>
                    <asp:ListItem>报废</asp:ListItem>
                    <asp:ListItem>退货</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:RadioButtonList> </div>
            <div class="AMNC-AddInforItem">处理意见内容：<asp:TextBox ID="tbProcessContent" CssClass="AMNC-AddInput" runat="server" TextMode="MultiLine"></asp:TextBox></div>
                       <div class="AMNC-AddInforItem">处理意见后续：<asp:CheckBoxList ID="cblOpinion" 
                    runat="server" RepeatDirection="Horizontal">
                <asp:ListItem>需要工艺试验</asp:ListItem>
                <asp:ListItem>需要原因分析</asp:ListItem>
                <asp:ListItem>需要纠正措施</asp:ListItem>
                <asp:ListItem>需要预防措施</asp:ListItem>
                </asp:CheckBoxList>
              </div>
            <div class="AMNC-AddInforItem">使用部门意见：<asp:TextBox ID="tbHandleSubsequent" CssClass="AMNC-AddInput" runat="server" TextMode="MultiLine"></asp:TextBox></div>
            <div class="AMNC-AddInforItem">决定：<asp:TextBox ID="tbDecision" CssClass="AMNC-AddInput" runat="server" TextMode="MultiLine"></asp:TextBox></div>
        </div>
        <div class="AMNC-Bts"><div class="AMNC-Bt"><asp:Button ID="btAdd" runat="server" Text="添加" OnClick="AddData" /></div>
        <div class="AMNC-Bt" style="float:right"><asp:Button ID="btReset" runat="server" Text="清空" /></div></div>
        </div>
    <script src="/Script/AddMaterialNonConform.js" type="text/javascript"></script>
</asp:Content>
