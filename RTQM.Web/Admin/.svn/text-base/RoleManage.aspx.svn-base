<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="Lgsoft.RTQM.Admin.RoleManage" %>
<link href="/Styles/RoleManage.css" rel="stylesheet" type="text/css" />
<div class="role-holder">
    <h2 class="f14">修改权限:</h2>
    <ul class="r-h-roleList clearfix">
        <%foreach (var role in AllRoles) {%> 
        <li class="r-h-rl-item">
            <label class="f14" for="<%=role.Id %>"><%=role.RoleName %></label>
            <input class="roleCheck" id="<%=role.Id %>" type="checkbox" <%if(roleAppService.IsUserInRole(role.Id,new Guid(userId))){%>checked="checked"<%} %> />
        </li>
        <% } %>
    </ul>
    <div class="r-h-submit">
        <input id="add-btn" type="submit" value="确定" />
    </div>
    <input type="text" id="Id" value="<%=userId %>" style="display:none;" />
</div>
<script>
    $(function () {
        $("#add-btn").bind("click", function () {
            var Id = $("#Id").val();
            var roleIds = "";
            $(".roleCheck:checked").each(function () {
                roleIds += $(this).attr("id") + ",";
            });
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "RoleManage.aspx/AddData", //POST页面及调用的方法名
                data: "{roleIds:'" + roleIds +
                        "',Id:'" + Id + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    if ($.trim(result.d) == "操作成功！") {
                        window.location.href = "UserManage.aspx";
                    }
                }
            });
        });
    });
</script>