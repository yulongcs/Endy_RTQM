$(function () {
    //查看用户投诉详细信息
    $(".CPI-show").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        alert("查看" + id);
    });
    //处理用户投诉信息
    $(".CPI-handle").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        alert("处理" + id);
    });
    //删除用户投诉信息
    $(".CPI-DelItem").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "ComplaintList.aspx/DelData", //POST页面及调用的方法名
                data: "{id:" + id + "}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //搜索回传前验证
    $("#mainContent_btSelect").live("click", function () {
        //去除回传input中的特殊字符，解决浏览器安全问题
        filterHtmlTag("#mainContent_tbCustomer");
    });
    //添加回传前验证
    $("#mainContent_BtAdd").live("click", function () {
        //去除回传input中的特殊字符，解决浏览器安全问题
        filterHtmlTag("#mainContent_tbCustomer");
    });
});