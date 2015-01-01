var MaterialNo; //物料编号
var Materialtext; //物料描述
var obj;
$(function () {
    //列表偶数行样式
    $('.MM-viewTable tr:even').css({ background: '#d8f0ef' });

    //搜索时数据回传
    $("#mainContent_tbSearch").live("click", function () {
        //回传前验证，去除特殊字符
        filterHtmlTag("#mainContent_tbMaterial|#mainContent_tbAddMaterialNo|#mainContent_tbAddMaterialtext");
    });
    //编辑列表数据
    $(".MM-Edit").live("click", function () {
        MaterialNo = $.trim($(this).parent().parent().find(".MM-viewitem1").html()); //获取当前行的物料编号
        Materialtext = $.trim($(this).parent().parent().find(".MM-viewitem2").html()); //获取当前行的物料描述
        $(this).parent().parent().find(".MM-viewitem1").html('<input type="text" class="MM-viewTableInput" id="tbMaterialNo" value="' + MaterialNo + '"/>'); //设置物料编号为可编辑
        $(this).parent().parent().find(".MM-viewitem2").html('<input type="text" class="MM-viewTableInput" id="tbMaterialtext" value="' + Materialtext + '"/>'); //设置物料描述为可编辑
        $(this).parent().html('<span class="MM-UpdData" >修改</span>&nbsp; <span class="MM-Cancel">取消</span>');
        obj = this;
    });
    //列表数据更新
    $(".MM-UpdData").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id
        if ($.trim($("#tbMaterialNo").val()) == "") {
            alert("物料编号不能为空！");
            return;
        }
        MaterialNo = $.trim($("#tbMaterialNo").val()); //获取修改物料编号
        if ($.trim($("#tbMaterialtext").val()) == "") {
            alert("物料描述不能为空！");
            return;
        }
        Materialtext = $.trim($("#tbMaterialtext").val()); //获取修改物料描述
        if (window.confirm("你确定要修改吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "MaintainMaterial.aspx/UpdData", //POST页面及调用的方法名
                data: "{id:'" + id + "',materialNo:'" + MaterialNo + "',materialtext:'" + Materialtext + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //列表数据取消编辑
    $(".MM-Cancel").live("click", function () {
        window.location.href = window.location.href;
    });


    //列表数据删除
    $(".MM-Del").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "MaintainMaterial.aspx/DelData", //POST页面及调用的方法名
                data: "{id:'" + id + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //添加数据
    $(".MM-Add").live("click", function () {
        if ($.trim($("#AddMaterialNo").val()) == "") {
            alert("物料编号不能为空！");
            return;
        }
        MaterialNo = $.trim($("#AddMaterialNo").val()); //获取添加物料编号
        if ($.trim($("#AddMaterialtext").val()) == "") {
            alert("物料描述不能为空！");
            return;
        }
        Materialtext = $.trim($("#AddMaterialtext").val()); //获取添加物料描述
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "MaintainMaterial.aspx/AddData", //POST页面及调用的方法名
            data: "{materialNo:'" + MaterialNo + "',materialtext:'" + Materialtext + "'}", //传参
            dataType: 'json',
            success: function (result) {
                alert(result.d);
                window.location.href = window.location.href;
            }
        });
    });
});
$(".MM-Clear").live("click", function () {
    $("#AddMaterialNo").val("");
    $("#AddMaterialtext").val("");
});
//还原列表中的内容为不可编辑
function Reduction(obj) {
    $(obj).parent().parent().find(".MM-viewitem1").html(MaterialNo); //还原列表物料编号
    $(obj).parent().parent().find(".MM-viewitem2").html(Materialtext); //还原列表物料描述
    $(obj).parent().html('<span class="MM-Edit">编辑</span>&nbsp; <span class="MM-Del">删除</span>');
}