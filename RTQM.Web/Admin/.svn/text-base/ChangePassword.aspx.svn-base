<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Lgsoft.RTQM.Admin.ChangePassword" %>
<link href="/Styles/AddUser.css" rel="stylesheet" type="text/css" />
<div class="cp-holder">
    <h2 class="f14">修改密码：</h2>
    <div class="au-h-name clearfix">
        <label class="fl">用户名：</label>
        <input class="fl" type="text" value="<%=User.UserName %>" readonly="readonly" />
    </div>
    <form id="changePasswordForm" method="post" action="UserManage.aspx">
        <div class="au-h-pw clearfix">
            <label class="fl">新密码：</label>
            <input id="userPw" name="userPw" class="fl" type="password" />
        </div>
        <div class="au-h-pw clearfix">
            <label class="fl">确定密码：</label>
            <input id="userPwC"  name="userPwC" class="fl" type="password" />
        </div>
        <div class="au-h-submit">
            <input id="add-btn" type="submit" value="确定" />
        </div>
    </form>
    <input type="text" id="Id" value="<%=User.Id.ToString() %>" style="display:none;" />
</div>
<script>
    $(function () {
        //表单jquery验证
        $("#changePasswordForm").validate({
            rules: {
                'userPw': {
                    required: true,
                    maxlength: 50
                },
                'userPwC': {
                    equalTo: "#userPw"
                }
            },
            messages: {
                'userPw': {
                    required: "不能为空",
                    maxlength: "不能超过50位"
                },
                'userPwC': {
                    equalTo: "两次输入不一致"
                }
            },
            submitHandler: function (form) {
                var userPw = $("#userPw").val();
                var Id = $("#Id").val();
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "ChangePassword.aspx/ChangeData",
                    data: "{userPw:'" + userPw +
                     "',Id:'" + Id + "'}",
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

