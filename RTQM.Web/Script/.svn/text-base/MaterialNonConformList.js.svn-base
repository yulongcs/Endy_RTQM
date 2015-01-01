$(function () {
    $("#mainContent_tbBeginDate").datepicker({ autoSize: true });
    $("#mainContent_tbEndDate").datepicker({ autoSize: true });
    //列表偶数行样式
    $('.MNCL-viewTable tr:even').css({ background: '#d8f0ef' });

    //搜索提交前去除“<”、“>”特殊符号，保证http的传输安全
    $('#mainContent_btSelect').live("click", function () {
        //调用去除特殊字符方法，参数之间用“|”符号隔开
        filterHtmlTag('#mainContent_tbBeginDate|#mainContent_tbEndDate|#mainContent_tbPoNo|#mainContent_tbSupplier');
    });
    //打印文档
    $(".MNCL-SetWord").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id并转换为整型
        //window.location.href = "PrintDisqualificationReport.aspx?id=" + id;
        window.open("PrintDisqualificationReport.aspx?id=" + id);
    });
    //删除指定条数
    $(".MNCL-Del").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id并转换为整型
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "MaterialNonConformList.aspx/DelData", //POST页面及调用的方法名
                data: "{id:'" + id + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    if ($.trim(result.d) == "删除成功!") {
                        window.location.href = window.location.href;
                    }
                }
            });
        }
    });
});