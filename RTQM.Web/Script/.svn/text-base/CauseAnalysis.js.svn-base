var UpdAction; //措施内容
var UpdResponsible; //责任部门
var UpdDeadline;//完成期限
$(function () {
    //添加按钮回传验证
    $("#mainContent_btAdd").live("click", function () {
        if ($.trim($("#mainContent_tbTempMeasure").val()) == "") {
            alert("临时性措施不能为空！");
            return false;
        }
        if ($.trim($("#mainContent_tbCauseAnalysis").val()) == "") {
            alert("分析原因不能为空！");
            return false;
        }
        //调用去除特殊字符方法,解决浏览器安全问题
        filterHtmlTag('#mainContent_tbTempMeasure|#mainContent_tbCauseAnalysis');
        return true;
    });
    //清除按钮回传验证
    $("#mainContent_btEmpty").live("click", function () {
        //调用去除特殊字符方法,解决浏览器安全问题
        filterHtmlTag('#mainContent_tbTempMeasure|#mainContent_tbCauseAnalysis');
    });
    //添加按钮回传
    $("#mainContent_lkbtAddMaterial").live("click", function () {
        if ($.trim($("#mainContent_tbAddAction").val()) == "") {
            alert("措施内容不能为空！");
            return false;
        }
        if ($.trim($("#mainContent_tbAddResponsible").val()) == "") {
            alert("责任部门不能为空！");
            return false;
        }
        if ($.trim($("#mainContent_tbAddDeadline").val()) == "") {
            alert("完成期限不能为空！");
            return false;
        }
        //调用去除特殊字符方法,解决浏览器安全问题
        filterHtmlTag('#mainContent_tbAddAction|#mainContent_tbAddResponsible|#mainContent_tbAddDeadline');

        return true;
    });

    //编辑列表信息
    $(".CA-Edit").live("click", function () {
        UpdAction = $.trim($(this).parent().parent().find(".CA-viewitem1").html()); //获取列表中的措施内容信息
        UpdResponsible = $.trim($(this).parent().parent().find(".CA-viewitem2").html()); //获取列表中的责任部门信息
        UpdDeadline = $.trim($(this).parent().parent().find(".CA-viewitem3").html()); //获取列表中的完成期限信息
        $(this).parent().parent().find(".CA-viewitem1").html('<input type="text" class="CA-viewTableInput" id="tbUpdAction" value="' + UpdAction + '"/>');
        $(this).parent().parent().find(".CA-viewitem2").html('<input type="text" class="CA-viewTableInput" id="tbUpdResponsible" value="' + UpdResponsible + '"/>');
        $(this).parent().parent().find(".CA-viewitem3").html('<input type="text" class="CA-viewTableInput" id="tbUpdDeadline" value="' + UpdDeadline + '"/>');
        $(this).parent().html('<span class="CA-Update" >修改</span>&nbsp; <span class="CA-Cancel">取消</span>');
    });
    //修改列表信息
    $(".CA-Update").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        if ($.trim($("#tbUpdAction").val()) == "") {
            alert("措施内容不能为空！");
            return;
        }
        UpdAction = $.trim($("#tbUpdAction").val()); //获取修改后的措施内容信息
        if ($.trim($("#tbUpdResponsible").val()) == "") {
            alert("责任部门不能为空！");
            return;
        }
        UpdResponsible = $.trim($("#tbUpdResponsible").val()); //获取修改后的责任部门信息
        if ($.trim($("#tbUpdDeadline").val()) == "") {
            alert("完成期限不能为空！");
            return;
        }
        UpdDeadline = $.trim($("#tbUpdDeadline").val()); //获取修改后的完成期限信息
        if (window.confirm("请确认是否修改？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "CauseAnalysis.aspx/UpdData", //POST页面及调用的方法名
                data: "{id:" + id + ",action:'" + UpdAction + "',responsible:'" + UpdResponsible + "',deadline:'" + UpdDeadline + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //取消编辑
    $(".CA-Cancel").live("click", function () {
        $(this).parent().parent().find(".CA-viewitem1").html(UpdAction);
        $(this).parent().parent().find(".CA-viewitem2").html(UpdResponsible);
        $(this).parent().parent().find(".CA-viewitem3").html(UpdDeadline);
        $(this).parent().html('<span class="CA-Edit">编辑</span>&nbsp;<span class="CA-Del">删除</span>');
    });

    //删除列表信息
    $(".CA-Del").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "CauseAnalysis.aspx/DelData", //POST页面及调用的方法名
                data: "{id:" + id + "}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
});