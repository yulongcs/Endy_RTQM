$(function() {
    //选择引起相应过程/文件更改
    $("#mainContent_rblType_0").live("click", function() {
        $(".CCP-displayDiv").css({ "display": "block" }); //设置更改的过程/文件列表内容显示
    });
    //选择没有引起相应过程/文件更改
    $("#mainContent_rblType_1").live("click", function() {
        $(".CCP-displayDiv").css({ "display": "none" }); //设置更改的过程/文件列表内容隐藏
    });
    //评价按钮回传前验证
    $("#mainContent_btAdd").live("click", function() {
        if ($.trim($("#mainContent_tbEvaluation").val()) == "") {
            alert("措施有效性评价不能为空！");
            return false;
        }
        if (!$("#mainContent_rblType_0").attr("checked") && !$("#mainContent_rblType_1").attr("checked")) { //判断当前选择的是“是”还是“否”
            alert("请选择是否有此引起相应过程/文件更改！");
            return false;
        }
        if ($("#mainContent_rblType_0").attr("checked")) { //判断当前选择的是“是”还是“否”
            if ($.trim($("#mainContent_tbUpdateText").val()) == "") {
                alert("更改的过程/文件列表不能为空！");
                return false;
            }
        }
        //调用去除特殊字符方法，参数之间用“|”符号隔开
        filterHtmlTag('#mainContent_tbEvaluation|#mainContent_tbUpdateText');
        return true;

    });
    //清空按钮回传前验证
    $("#mainContent_btAdd").live("click", function() {
        //调用去除特殊字符方法，参数之间用“|”符号隔开
        filterHtmlTag('#mainContent_tbEvaluation|#mainContent_tbUpdateText');
        return true;
    });
});