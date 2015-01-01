<%@ Page Title="用户投诉信息" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ComplaintList.aspx.cs" Inherits="Lgsoft.RTQM.ComplaintList" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager, Version=7.3.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/ComplaintList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<h2 class="CL-title">用户投诉信息</h2>
<div class="CL-main" >
<div class="CL-SearchArea">
   <div class="CL-SearchItem" style="width: 290px">创建日期：从 <asp:TextBox ID="tbBeiginDate" CssClass="CL-PoDate" runat="server"></asp:TextBox>
          <img src="Images/textdate-delete.png"  id="Date-Empry1" class="Date-Empty"/> 至 <asp:TextBox ID="tbEndDate" CssClass="CL-PoDate" runat="server"></asp:TextBox> <img src="Images/textdate-delete.png" id="Date-Empry2"  class="Date-Empty" /></div>
   <div class="CL-SearchItem" style="width: 290px">发生日期：从 <asp:TextBox ID="TextBox1" CssClass="CL-PoDate" runat="server"></asp:TextBox>
          <img src="Images/textdate-delete.png"  id="Img1" class="Date-Empty"/> 至 <asp:TextBox ID="TextBox2" CssClass="CL-PoDate" runat="server"></asp:TextBox> <img src="Images/textdate-delete.png" id="Img2"  class="Date-Empty" /></div>
      <div class="CL-SearchItem">顾客名称：<asp:TextBox ID="tbCustomer" CssClass="CL-SearchInput" runat="server"></asp:TextBox></div> 
       <div class="CL-SearchItem" style="width: 200px">过程状态：<asp:DropDownList ID="ddlProcessState" runat="server">
      <asp:ListItem>待工作组处理</asp:ListItem>
      <asp:ListItem>待QA经理处理</asp:ListItem>
      <asp:ListItem>待QA工程师检查</asp:ListItem>
      <asp:ListItem>已关闭</asp:ListItem>
      </asp:DropDownList>
  </div>
    <div class="CL-select">
                <asp:Button ID="BtAdd" runat="server" CssClass="selectBt" Text="添加" /></div>
    <div class="CL-select">
                <asp:Button ID="btSelect" runat="server" CssClass="selectBt" Text="搜索" /></div>
  </div>

<div class="CL-view">
  <table class="CL-viewTable">
     <tr><th>创建日期</th><th>发生日期</th><th>顾客名称</th><th>联系人</th><th>电话号码</th><th>产品型号</th><th>数量</th><th>产品制造号</th><th>供货日期</th><th>过程状态</th><th>上一步骤完成时间</th><th>操作</th></tr>
     <tr><td class="CPI-viewitem1">2011-12-10</td><td class="CPI-viewitem2">2011-12-</td><td class="CPI-viewitem3">aaa</td><td class="CPI-viewitem4">bbbbbbb</td><td class="CPI-viewitem5">13123456788</td><td class="CPI-viewitem6">cccccc</td><td class="CPI-viewitem7">100</td><td class="CPI-viewitem8">c-12121</td><td class="CPI-viewitem9">2012-12-10</td><td class="CPI-viewitem10">待--处理</td><td class="CPI-viewitem11">2011-12-12 12:12:12</td>  <td class="CPI-viewitem12" style="text-align:center" itemid="123"><span class="CPI-show">查看</span>&nbsp;<span class="CPI-handle">处理</span>&nbsp;<span class="CPI-DelItem">删除</span></td></tr>
  </table>
</div>
<div class="clear"></div>
        <webdiyer:AspNetPager ID="AspNetPager1" AlwaysShow="True" runat="server" FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" PrevPageText="上一页" CssClass="paginator" CurrentPageButtonClass="cpb"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="跳转到" OnPageChanging="AspNetPager1PageChanging">
        </webdiyer:AspNetPager>
</div>
    <script src="Script/ComplaintList.js" type="text/javascript"></script>
</asp:Content>
