<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lgsoft.RTQM.Login" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>系统-登录</title>
    <link href="/Styles/base.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="logo-holder clearfix">
        <div class="TP-top-logo fl">
            <img src="/Images/logo.jpg" alt="logo" /></div>
        <h1 class="f24 fl">实时质量管理监控系统</h1>
    </div>
    <div class="main-holder bc clearfix">
        <div class="login-holder fr">
            <form method="post" runat="server" >
                <h2 class="f16">登录</h2>
                <div class="l-h-item">
                    <label>用户名</label>
                    <%--<input type="text" id="username" class="username" />--%>
                    <asp:TextBox runat="server" ID="username" CssClass="username" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="l-h-item">
                    <label>密码</label>
                    <%--<input type="password" id="password" class="password" />--%>
                    <asp:TextBox runat="server" ID="password" CssClass="password" TextMode="Password"></asp:TextBox>
                </div>
                <%--<input id="loginBtn" class="loginBtn" type="button" value="登录" />--%>
                <asp:Button runat="server" ID="loginBtn" ClientIDMode="Static" CssClass="loginBtn" Text="登录" OnClick="loginBtn_OnClick" />
                <asp:Label runat="server" ID="error" CssClass="loginError"></asp:Label>
            </form>
        </div>
        <div class="introduction-holder fl">
            <h1 class="f18">账号登录</h1>
            <p class="i-h-text">请使用管理员添加分配的用户名账号登录该系统。</p>
            <p class="i-h-text">在右侧登录，或者<span>联系管理员</span>开通账号。</p>
            <ul class="i-h-list">
                <li class="clearfix">
                    <img src="Images/yc.png" alt="原材料订单管理" class="fl" />
                    <h2 class="f16">原材料订单管理</h2>
                    <p>轻松实现管理原材料订单</p>
                </li>
                <li class="clearfix">
                    <img src="Images/rp.png" class="fl"  />
                    <h2 class="f16">质量报告</h2>
                    <p>轻松导出，方便统计</p>
                </li>
                <li class="clearfix">
                    <img src="Images/bh.png" alt="不合格报告" class="fl"  />
                    <h2 class="f16">来料不合格报告</h2>
                    <p>及时记录，以备查询</p>
                </li>
            </ul>
        </div>
    </div>
    <div class="footer-holder">
        <ul class="f-h-copyright bc clearfix">
            <li class="fl">版权所有© 2012 LG Soft</li>
            <li class="fl">服务条款</li>
            <li class="fl">隐私权政策</li>
            <li class="fl">帮助</li>
        </ul>
    </div>
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#loginBtn").bind("click", function () {
                var input_username = $("#username");
                var input_password = $("#password");
                var username = $.trim(input_username.val());
                var password = $.trim(input_password.val());
                input_username.focusout(function () {
                    if ($.trim(input_username.val()) != "")
                        input_username.removeClass("error");
                });
                input_password.focusout(function () {
                    if ($.trim(input_password.val()) != "")
                        input_password.removeClass("error");
                });
                if (username == "") {
                    input_username.addClass("error");
                    input_username.focus();
                    return false;
                }
                if (password == "") {
                    input_password.addClass("error");
                    input_password.focus();
                    return false;
                }
//                $.ajax({
//                    type: "POST",
//                    contentType: "application/json",
//                    url: "Login.aspx/GetData", //POST页面及调用的方法名
//                    data: "{username:'" + username +
//                        "',password:'" + password + "'}", //传参
//                    dataType: 'json',
//                    success: function (result) {
//                        if ($.trim(result.d) == "登录成功！") {
//                            window.location.href = "/Materials/PurchaseList.aspx";
//                        }
//                        if ($.trim(result.d) == "用户名密码错误！") {
//                            if ($(".loginError").length <= 0) {
//                                $(".login-holder").append("<div class='loginError'>用户名密码错误！</div>");
//                            }
//                        }
//                        else {
//                            alert($.trim(result.d));
//                        }
//                    }
//                });
            });
        });
</script>
</body>
</html>
