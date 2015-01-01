 $(document).ready(function () {
    //编辑物料，根据id添加订单中的物料
    $(".PL-itemEdit").live("click", function () {
        var id = $.trim($(this).parent().find(".PL-id").html());
        window.location.href = "MaterialsList.aspx?id=" + id;
    });

    //异步交互，执行删除数据功能
    $(".PL-itemDel").live("click", function () {
        var id = $.trim($(this).parent().find(".PL-id").html());
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "PurchaseList.aspx/DelData",//POST页面及调用的方法名
                data: "{id:'" + id + "'}",//传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //提交前去除“<”、“>”特殊符号，保证http的传输安全
    $('#mainContent_tbSearch').live("click", function () {
        //调用去除特殊字符方法，参数之间用“|”符号隔开
        filterHtmlTag('#mainContent_tbPoNo|mainContent_tbBeginDate|mainContent_tbEndDate');
    });
    //列表偶数行样式
    $('.PL-viewTable tr:even').css({ background: '#d8f0ef' });
});

