var validateRecord; //措施验证记录
var sign; //验证人
var date;//验证日期
$(function () {
    //列表数据项编辑
    $(".VM-Eidt").live("click", function () {
        validateRecord = $.trim($(this).parent().parent().find(".VM-viewitem4").html()); //措施验证记录
        sign = $.trim($(this).parent().parent().find(".VM-viewitem5").html()); //验证人
        date = $.trim($(this).parent().parent().find(".VM-viewitem6").html()); //验证日期
        $(this).parent().parent().find(".VM-viewitem4").html('<input type="text" class="VM-viewTableInput" id="tbUpdValidateRecord" value="' + validateRecord + '"/>'); //措施验证记录文本框
        $(this).parent().parent().find(".VM-viewitem5").html('<input type="text" class="VM-viewTableInput" id="tbUpdSign" value="' + sign + '"/>'); //验证人文本框
        $(this).parent().parent().find(".VM-viewitem6").html('<input type="text" class="VM-viewTableInput" id="tbUpdDate" value="' + date + '"/>'); //验证日期文本框
        $(this).parent().html('<span class="VM-Update" >修改</span>&nbsp; <span class="VM-Cancel">取消</span>');
    });
    //列表数据更新
    $(".VM-Update").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        if ($.trim($("#tbUpdValidateRecord").val()) == "") {
            alert("措施验证记录不能为空！");
            return;
        }
        validateRecord = $.trim($("#tbUpdValidateRecord").val()); //获取修改措施验证记录
        if ($.trim($("#tbUpdSign").val()) == "") {
            alert("验证人不能为空！");
            return;
        }
        sign = $.trim($("#tbUpdSign").val()); //获取修改验证人
        if ($.trim($("#tbUpdDate").val()) == "") {
            alert("验证人不能为空！");
            return;
        }
        date = $.trim($("#tbUpdDate").val()); //获取修改验证日期
                if (window.confirm("请确认是否修改？")) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "VerificationMeasures.aspx/UpdData", //POST页面及调用的方法名
                        data: "{id:" + id + ",validateRecord:'" + validateRecord + "',sign:'" + sign + "',date:'" + date + "'}", //传参
                        dataType: 'json',
                        success: function (result) {
                            alert(result.d);
                            window.location.href = window.location.href;
                        }
                    });
                }
    });
    //取消列表数据修改
    $(".VM-Cancel").live("click", function () {
        $(this).parent().parent().find(".VM-viewitem4").html(validateRecord);
        $(this).parent().parent().find(".VM-viewitem5").html(sign);
        $(this).parent().parent().find(".VM-viewitem6").html(date);
        $(this).parent().html('<span class="VM-Eidt">编辑</span>');
    });

    //列表纠正和预防措施验证
    $(".VM-Verify").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        if ($.trim($(this).parent().parent().find(".VM-viewitem4").find("input").val()) == "") {
            alert("措施验证记录不能为空！");
            return;
        }
        validateRecord = $.trim($(this).parent().parent().find(".VM-viewitem4").find("input").val()); //获取修改措施验证记录
        if ($.trim($(this).parent().parent().find(".VM-viewitem5").find("input").val()) == "") {
            alert("验证人不能为空！");
            return;
        }
        sign = $.trim($(this).parent().parent().find(".VM-viewitem5").find("input").val()); //获取修改验证人
        if ($.trim($(this).parent().parent().find(".VM-viewitem6").find("input").val()) == "") {
            alert("验证人不能为空！");
            return;
        }
        date = $.trim($(this).parent().parent().find(".VM-viewitem6").find("input").val()); //获取修改验证日期
        if (window.confirm("请确认是否提交验证？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "VerificationMeasures.aspx/VerifyData", //POST页面及调用的方法名
                data: "{id:" + id + ",validateRecord:'" + validateRecord + "',sign:'" + sign + "',date:'" + date + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
});