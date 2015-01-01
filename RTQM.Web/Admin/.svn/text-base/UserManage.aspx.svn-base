<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="Lgsoft.RTQM.Admin.UserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/UserManage.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jquery.nyroModal/styles/nyroModal.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="title-holder f14 clearfix"><h2 class="fl">用户管理</h2><a id="add-link" class="add-link fr" href="AddUser.aspx">添加用户</a></div>
    <div class="list-holder bc">
        <ul id="l-h-header" class="clearfix">
            <li class="l-h-h-name fl">用户名</li>
            <li class="l-h-h-bgLine fl"></li>
            <li class="l-h-h-ad fl">AD账号</li>
            <li class="l-h-h-bgLine fl"></li>
            <li class="l-h-h-rName fl">真实姓名</li>
            <li class="l-h-h-bgLine fl"></li>
            <li class="l-h-h-department fl">所属部门</li>
            <li class="l-h-h-bgLine fl"></li>
            <li class="l-h-h-email fl">电子邮件</li>
            <li class="l-h-h-bgLine fl"></li>
            <li class="l-h-h-createDate fl">创建日期</li>
            <li class="l-h-h-bgLine fl"></li>
            <li class="l-h-h-op fl">操作</li>
        </ul>
        <ul id="l-h-list">
        <% foreach (var user in AllUser){ %>
            <li class="l-h-l-item clearfix">
                <p class="l-h-l-i-name fl" title="<%=user.UserName %>"><%=user.UserName %></p>
                <p class="l-h-l-i-ad fl" title="<%=user.ADAccount %>"><%=user.ADAccount %></p>
                <p class="l-h-l-i-rName fl" title="<%=user.RealName %>"><%=user.RealName %></p>
                <p class="l-h-l-i-department fl" title="<%=user.Department %>"><%=user.Department %></p>
                <p class="l-h-l-i-email fl" title="<%=user.Email %>"><%=user.Email %></p>
                <p class="l-h-l-i-createDate fl"><%=user.CreateDate %></p>
                <p class="l-h-l-i-op fl">
                    <a class="link-del" href="AddUser.aspx?id=<%=user.Id %>">编辑</a>
                    <a class="link-rPw" href="ChangePassword.aspx?id=<%=user.Id %>">修改密码</a>
                    <a class="link-role" href="RoleManage.aspx?id=<%=user.Id %>">修改权限</a>
                    <a class="link-edit">删除</a>
                    <input type="text" class="userId" value="<%=user.Id.ToString() %>" style="display:none;" />
                </p>
            </li>
        <% } %>
        </ul>
    </div>
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.nyroModal/js/jquery.nyroModal.custom.js" type="text/javascript"></script>
    <!--[if IE 6]>
	    <script type="text/javascript" src="/Scripts/jquery.nyroModal/js/jquery.nyroModal-ie6.min.js"></script>
    <![endif]-->
    <script type="text/javascript" src="/Scripts/jquery.validate.min.js"></script>
    <script>
        $(function () {
            $("#add-link").nm({
                sizes: {
                    minW: 420,
                    minH: 380
                }
            });
            $(".link-del").nm({
                sizes: {
                    minW: 420,
                    minH: 380
                }
            });
            $(".link-rPw").nm({
                sizes: {
                    minW: 420,
                    minH: 295
                }
            });
            $(".link-role").nm({
                sizes: {
                    minW: 420,
                    minH: 380
                }
            });
            $(".link-edit").bind("click", function () {
                if (confirm("确定删除该用户吗？")) {
                    var Id = $(this).next(".userId").val();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "UserManage.aspx/DelData", //POST页面及调用的方法名
                        data: "{Id:'" + Id + "'}", //传参
                        dataType: 'json',
                        success: function (result) {
                            if ($.trim(result.d) == "删除成功！") {
                                window.location.href = "UserManage.aspx";
                            }
                            else {
                                alert("操作失败");
                                window.location.href = "UserManage.aspx";
                            }
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
