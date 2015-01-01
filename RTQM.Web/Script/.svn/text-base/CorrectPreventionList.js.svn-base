$(function () {
    //设置日期控件文本框
    SetDateInput('#mainContent_tbBeiginDate', "#Date-Empry1", '#mainContent_tbEndDate', "#Date-Empry2");
    //列表偶数行样式
    $('.CPL-viewTable tr:even').css({ background: '#d8f0ef' });
    //删除列表中的数据
    $('.CPI-delItem').live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "CorrectPreventionList.aspx/DelData", //POST页面及调用的方法名
                data: "{id:" + id + "}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //查看列表中的数据
    $('.CPI-show').live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        alert("查看数据ID="+id);
    });
    //查看处理列表中的数据
    $('.CPI-handle').live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")) * 1; //获取id并转换为整型
        alert("处理数据ID=" + id);
    });
});