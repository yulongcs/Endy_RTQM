$(function () {
    //提交回传前验证
    $("#mainContent_btAdd").live("click", function () {
        if ($("#mainContent_tbUnreasonText").val() == "") {
            alert("质保部的调查结果不能为空");
            return false;
        }
        filterHtmlTag("#mainContent_tbUnreasonText"); //去除特殊字符
        return true;
    });
    //清空回传前验证
    $("mainContent_btEmpty").live("click", function() {
        filterHtmlTag("#mainContent_tbUnreasonText");//去除特殊字符
    });

});