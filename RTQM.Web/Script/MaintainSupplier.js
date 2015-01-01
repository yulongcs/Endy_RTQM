var Supplier; //供应商名称
$(function () {
    //列表偶数行样式
    $('.MS-viewTable tr:even').css({ background: '#d8f0ef' });

    //搜索时数据回传
    $("#mainContent_btSearch").live("click", function () {
        //回传前验证，去除特殊字符
        filterHtmlTag("#mainContent_tbSupplier|#mainContent_tbAddSupplier");
    });
    //编辑列表数据
    $(".MS-Edit").live("click", function () {
        Supplier = $.trim($(this).parent().parent().find(".MS-viewitem1").html()); //获取当前行的供应商名称
        $(this).parent().parent().find(".MS-viewitem1").html('<input type="text" class="MS-viewTableInput" id="tbSupplier" value="' + Supplier + '"/>'); //设置供应商为可编辑
        $(this).parent().html('<span class="MS-UpdData" >修改</span>&nbsp; <span class="MS-Cancel">取消</span>');
    });
    //列表数据更新
    $(".MS-UpdData").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id
        if ($.trim($("#tbSupplier").val()) == "") {
            alert("供应商名称不能为空！");
            return;
        }
        Supplier = $.trim($("#tbSupplier").val()); //获取修改物料编号
        if (window.confirm("你确定要修改吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "MaintainSupplier.aspx/UpdData", //POST页面及调用的方法名
                data: "{id:'" + id + "',supplier:'" + Supplier + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //列表数据取消编辑
    $(".MS-Cancel").live("click", function () {
        window.location.href = window.location.href;
    });
    //列表数据删除
    $(".MS-Del").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "MaintainSupplier.aspx/DelData", //POST页面及调用的方法名
                data: "{id:'" + id + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //添加供应商
    $(".MS-Add").live("click", function () {
        if ($.trim($("#AddSupplier").val()) == "") {
            alert("供应商名称不能为空！");
            return;
        }
        Supplier = $.trim($("#AddSupplier").val());
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "MaintainSupplier.aspx/AddData", //POST页面及调用的方法名
            data: "{supplier:'" + Supplier + "'}", //传参
            dataType: 'json',
            success: function (result) {
                alert(result.d);
                window.location.href = window.location.href;
            }
        });
    });
    //清空添加的input内容
    $(".MS-Clear").live("click", function () {
        $("#AddSupplier").val("");
    });
});