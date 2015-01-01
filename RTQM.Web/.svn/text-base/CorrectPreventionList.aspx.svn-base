<%@ Page Title="纠正与预防信息" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="CorrectPreventionList.aspx.cs" Inherits="Lgsoft.RTQM.CorrectPreventionList" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/CorrectPreventionList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<h2 class="CPL-title">纠正与预防信息</h2>
<div class="CPL-main" >
<div class="CPL-SearchArea">
<%--  <div class="CPL-SearchItem">措施类型：<asp:DropDownList ID="ddlType" runat="server">
      <asp:ListItem>纠正措施</asp:ListItem>
      <asp:ListItem>预防措施</asp:ListItem>
      </asp:DropDownList>
  </div>--%>
   <div class="CPL-SearchItem" style="width: 290px">创建日期：从 <asp:TextBox ID="tbBeiginDate" CssClass="CPL-PoDate" runat="server"></asp:TextBox>
          <img src="Images/textdate-delete.png"  id="Date-Empry1" class="Date-Empty"/> 至 <asp:TextBox ID="tbEndDate" CssClass="CPL-PoDate" runat="server"></asp:TextBox> <img src="Images/textdate-delete.png" id="Date-Empry2"  class="Date-Empty" /></div>
   <%--   <div class="CPL-SearchItem">责任部门：<asp:DropDownList ID="ddlDepartment" runat="server">
       <asp:ListItem>部门名称</asp:ListItem>
      </asp:DropDownList> </div> --%>
      <div class="CPL-SearchItem" style="width: 200px">过程状态：<asp:DropDownList ID="ddlProcessState" runat="server">
      <asp:ListItem>待工作组处理</asp:ListItem>
      <asp:ListItem>待QA经理处理</asp:ListItem>
      <asp:ListItem>待QA工程师检查</asp:ListItem>
      <asp:ListItem>已关闭</asp:ListItem>
      </asp:DropDownList>
  </div>
  <div class="CPL-select">
                <asp:Button ID="btSelect" runat="server" CssClass="selectBt" Text="搜索" 
                    onclick="SelectClick" /></div>  
  <div class="CPL-select">
                <asp:Button ID="btAdd" runat="server" CssClass="selectBt" Text="创建" OnClick="AddClick"/></div>
</div>
<div class="CPL-view">
  <table class="CPL-viewTable">
     <tr><th>创建日期<asp:ImageButton ID="ImgDateSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgDateSortClick" /></th><th>工作组<asp:ImageButton ID="ImgBtDepartmentSort" BorderStyle="None" runat="server" 
                  ImageUrl="~/Images/Descending.gif" style="width: 8px; height: 11px" 
                  onclick="ImgBtDepartmentSortClick" /></th><th>措施类型</th><th>过程状态</th><th>上一步骤完成时间</th><th>操作</th></tr>
     <tr><td class="CPI-viewitem1">2011-12-10</td><td class="CPI-viewitem2">工作组</td><td class="CPI-viewitem3">纠正</td><td class="CPI-viewitem4">待工作组处理</td><td class="CPI-viewitem5">2012-10-12</td><td class="CPI-viewitem6" style="text-align:center" itemid="123"><span class="CPI-show">查看</span>&nbsp;<span class="CPI-handle">处理</span>&nbsp;<span class="CPI-delItem">删除</span></td></tr>
     <tr><td class="CPI-viewitem1">2011-12-10</td><td class="CPI-viewitem2">工作组</td><td class="CPI-viewitem3">纠正</td><td class="CPI-viewitem4">待QA经理处理</td><td class="CPI-viewitem5">2012-10-12</td><td class="CPI-viewitem6" style="text-align:center" itemid="123"><span class="CPI-show">查看</span>&nbsp;<span class="CPI-handle">处理</span>&nbsp;<span class="CPI-delItem">删除</span></td></tr>
     <tr><td class="CPI-viewitem1">2011-12-10</td><td class="CPI-viewitem2">工作组</td><td class="CPI-viewitem3">预防</td><td class="CPI-viewitem4">待QA工程师处理</td><td class="CPI-viewitem5">2012-10-12</td><td class="CPI-viewitem6" style="text-align:center" itemid="123"><span class="CPI-show">查看</span>&nbsp;<span class="CPI-handle">处理</span>&nbsp;<span class="CPI-delItem">删除</span></td></tr>
     <tr><td class="CPI-viewitem1">2011-12-10</td><td class="CPI-viewitem2">工作组</td><td class="CPI-viewitem3">预防</td><td class="CPI-viewitem4">已关闭</td><td class="CPI-viewitem5">2012-10-12</td><td class="CPI-viewitem6" style="text-align:center" itemid="123"><span class="CPI-show">查看</span>&nbsp;<span class="CPI-handle">处理</span>&nbsp;<span class="CPI-delItem">删除</span></td></tr>
     
   
  </table>
</div>
<div class="clear"></div>
        <webdiyer:AspNetPager ID="AspNetPager1" AlwaysShow="True" runat="server" 
        FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" PrevPageText="上一页" CssClass="paginator" CurrentPageButtonClass="cpb"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到" 
        OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
</div>
    <script src="Script/CorrectPreventionList.js" type="text/javascript"></script>
</asp:Content>
