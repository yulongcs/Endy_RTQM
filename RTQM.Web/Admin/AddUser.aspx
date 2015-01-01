<%@ Page Title="添加用户" Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Lgsoft.RTQM.Admin.AddUser" %>
<link href="/Styles/AddUser.css" rel="stylesheet" type="text/css" />
<div class="addUser-holder">
    <h2 class="f14"><%=(User == null) ? "添加用户" : "修改用户"%>：</h2>
    <form id="addEditUserForm" method="post" action="UserManage.aspx">
        <div class="au-h-name clearfix">
            <label class="fl">用户名：</label>
            <input id="userName" name="userName" class="fl" type="text" value="<%=(User==null)?"":User.UserName %>" <%=(User==null)?"":"readonly" %> />
        </div>
        <%if (User == null)
          {%> 
        <div class="au-h-pw clearfix">
            <label class="fl">用户密码：</label>
            <input id="userPw" name="userPw" class="fl" type="password" />
        </div>
        <div class="au-h-pw clearfix">
            <label class="fl">确定密码：</label>
            <input id="userPwC" name="userPwC" class="fl" type="password" />
        </div>
          <%} %>
        <div class="au-h-ad clearfix">
            <label class="fl">AD账号：</label>
            <input id="userAd" name="userAd" class="fl" type="text" value="<%=(User==null)?"":User.ADAccount %>" />
        </div>
        <div class="au-h-rName clearfix">
            <label class="fl">真实姓名：</label>
            <input id="userRname" name="userRname" class="fl" type="text" value="<%=(User==null)?"":User.RealName %>" />
        </div>
        <div class="au-h-department clearfix">
            <label class="fl">所属部门：</label>
            <input id="userDep" name="userDep" class="fl" type="text" value="<%=(User==null)?"":User.Department %>" />
        </div>
        <div class="au-h-email clearfix">
            <label class="fl">电子邮件：</label>
            <input id="userEmail" name="userEmail" class="fl" type="text" value="<%=(User==null)?"":User.Email %>" />
        </div>
        <input type="text" id="Id" value="<%=(User==null)?"":User.Id.ToString() %>" style="display:none;" />
        <div class="au-h-submit">
            <input id="add-btn" type="submit" value="确定" />
        </div>
    </form>
</div>
<script>
    $(function () {
        //表单jquery验证
        $("#addEditUserForm").validate({
            rules: {
                'userName': {
                    required: true,
                    maxlength: 20
                },
                'userPw': {
                    required: true,
                    maxlength: 50
                },
                'userPwC': {
                    equalTo: "#userPw"
                },
                'userAd': {
                    maxlength: 50
                },
                'userRname': {
                    maxlength: 20
                },
                'userDep': {
                    maxlength: 20
                },
                'userEmail': {
                    email: true,
                    maxlength: 50
                }
            },
            messages: {
                'userName': {
                    required: "不能为空",
                    maxlength: "不能超过20位"
                },
                'userPw': {
                    required: "不能为空",
                    maxlength: "不能超过50位"
                },
                'userPwC': {
                    equalTo: "两次输入不一致"
                },
                'userAd': {
                    maxlength: "不能超过50位"
                },
                'userRname': {
                    maxlength: "不能超过20位"
                },
                'userDep': {
                    maxlength: "不能超过20位"
                },
                'userEmail': {
                    email: "格式不正确",
                    maxlength: "不能超过50位"
                }
            },
            submitHandler: function (form) {
                var userName = $("#userName").val();
                var userPw = $("#userPw").val();
                var userAd = $("#userAd").val();
                var userRname = $("#userRname").val();
                var userDep = $("#userDep").val();
                var userEmail = $("#userEmail").val();
                userAd = userAd.replace(/\\/g, '\\\\');
                var Id = $("#Id").val();
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "AddUser.aspx/AddEditData", //POST页面及调用的方法名
                    data: "{userName:'" + userName +
                     "',userPw:'" + userPw +
                     "',userAd:'" + userAd +
                     "',userRname:'" + userRname +
                     "',userDep:'" + userDep +
                     "',userEmail:'" + userEmail +
                     "',Id:'" + Id + "'}", //传参
                    dataType: 'json',
                    success: function (result) {
                        alert(result.d);
                        if ($.trim(result.d) == "操作成功！") {
                            window.location.href = "UserManage.aspx";
                        }
                    }
                });
            }
        });
    });
</script>
