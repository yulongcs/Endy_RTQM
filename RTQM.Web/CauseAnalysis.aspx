<%@ Page Title="纠正和预防原因分析及处理" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="CauseAnalysis.aspx.cs" Inherits="Lgsoft.RTQM.CauseAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/CauseAnalysis.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<h2 class="CA-title">
       纠正和预防原因分析及处理</h2>
       <div class="CA-main">
          <div class="CA-itemTitle">临时性措施：</div>
          <div class="CA-itemText">
          <asp:TextBox ID="tbTempMeasure" runat="server" CssClass="CA-TextArea" TextMode="MultiLine"></asp:TextBox>
          </div>
          <div class="CA-itemTitle">分析原因：</div>
          <div class="CA-itemText">
          <asp:TextBox ID="tbCauseAnalysis" runat="server" CssClass="CA-TextArea" TextMode="MultiLine"></asp:TextBox>
          </div>
          <div class="CA-itemTitle">可供选择的措施：</div>
          <div class="CA-view">
             <table class="CA-viewTable">
                 <tr><th>措施内容</th><th>责任部门</th><th>完成期限</th><th>操作</th></tr>
                 <tr><td class="CA-viewitem1">措施内容</td><td class="CA-viewitem2">责任部门</td><td class="CA-viewitem3">完成期限</td><td class="CA-viewitem4" style="text-align:center" itemid="123"><span class="CA-Edit">编辑</span>&nbsp;<span class="CA-Del">删除</span></td></tr>
               
                 <tr><td class="CA-viewitem1"> <asp:TextBox ID="tbAddAction" CssClass="CA-viewTableInput" runat="server"></asp:TextBox> </td><td class="CA-viewitem2"> <asp:TextBox ID="tbAddResponsible" CssClass="CA-viewTableInput" runat="server"></asp:TextBox> </td><td class="CA-viewitem3"> <asp:TextBox ID="tbAddDeadline" CssClass="CA-viewTableInput" runat="server"></asp:TextBox> </td><td class="CA-viewitem4" style="text-align:center"> <asp:LinkButton ID="lkbtAddMaterial" runat="server" 
                                    onclick="AddMaterialClick">添加</asp:LinkButton> </td></tr>
             </table>
          </div>
          <div class="clear"></div>
          <div class="CA-mainBts">
            <div class="CA-mainBtY">
                <asp:Button ID="btAdd" runat="server" Text="添加并发送邮件给QA经理" onclick="AddClick" /></div>
            <div class="CA-mainBtN">
                <asp:Button ID="btEmpty" runat="server" Text="清空" onclick="EmptyClick" /></div>
        </div>
       </div>
    <script src="Script/CauseAnalysis.js" type="text/javascript"></script>
</asp:Content>
