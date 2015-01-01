var UpdSMVSNo; //批号
var UpdMaterialNo; //物料编号
var UpdMaterialDes; //物料描述
var UpdSupplierName; //供应商名称
var UpdMaterialKind; // 物料类型
var UpdTotal; //物料总量
var UpdincomeTotal; //入库总量 7
var Updconformance; //合格率 8
var UpdDefDes; //缺陷描述
var UpdConcessionSum; //让步数量
var UpdReworkSum; //退货数量
var UpdRejectionSum; //返工数量
var UpdScrapCount; //报废数量
var supplierId = ""; //供应商id;
var materialId = ""; //物料id;
$(function () {
    $("#AddSMVSNo")[0].focus();
    //列表偶数行样式
    $('.ML-viewTable tr:even').css({ background: '#d8f0ef' });

    //搜索提交前去除“<”、“>”特殊符号，保证http的传输安全
    $('#mainContent_btSelect').live("click", function () {
        if (!isNaN($.trim($("#mainContent_tbMinConformance").val())) && !isNaN($.trim($("#mainContent_tbMaxConformance").val()))) {
            //调用去除特殊字符方法，参数之间用“|”符号隔开
            filterHtmlTag('#mainContent_tbSMVSNo|#mainContent_tbMaterialNo|#mainContent_tbSupplier|#mainContent_tbMinConformance|#mainContent_tbMaxConformance|#mainContent_ddlkind');
            return true;


        } else {
            alert("合格率必须为整数！");
            return false;
        }

    });
    //列表数据项编辑
    $(".ML-Edit").live("click", function () {
        //        UpdSMVSNo = $.trim($(this).parent().parent().find(".ML-viewitem1").html());
        UpdMaterialNo = $.trim($(this).parent().parent().find(".ML-viewitem2").html());
        UpdMaterialDes = $.trim($(this).parent().parent().find(".ML-viewitem3").html());
        UpdSupplierName = $.trim($(this).parent().parent().find(".ML-viewitem4").html());
        UpdMaterialKind = $.trim($(this).parent().parent().find(".ML-viewitem5").html());
        UpdTotal = $.trim($(this).parent().parent().find(".ML-viewitem6").html());
        UpdincomeTotal = $.trim($(this).parent().parent().find(".ML-viewitem7").html());
        Updconformance = $.trim($(this).parent().parent().find(".ML-viewitem8").html());
        UpdDefDes = $.trim($(this).parent().parent().find(".ML-viewitem9").html());
        UpdConcessionSum = $.trim($(this).parent().parent().find(".ML-viewitem10").html());
        UpdReworkSum = $.trim($(this).parent().parent().find(".ML-viewitem11").html());
        UpdRejectionSum = $.trim($(this).parent().parent().find(".ML-viewitem12").html());
        UpdScrapCount = $.trim($(this).parent().parent().find(".ML-viewitem13").html());
        //  $(this).parent().parent().find(".ML-viewitem1").html('<input type="text" class="ML-viewTableInput" id="tbUpdSMVSNo" value="' + UpdSMVSNo + '"/>');
        $(this).parent().parent().find(".ML-viewitem2").html('<input type="text" fl="1" class="ML-viewTableInput" id="tbUpdMaterialNo" value="' + UpdMaterialNo + '"/>');
        $(this).parent().parent().find(".ML-viewitem3").html('<input type="text"  id="tbUpdMaterialDes" readonly="readonly" value="' + UpdMaterialDes + '"/>');
        $(this).parent().parent().find(".ML-viewitem4").html('<input type="text"fl="2" class="ML-viewTableInput" id="tbUpdSupplierName" value="' + UpdSupplierName + '"/>');
        if (UpdMaterialKind == "EP") {
            $(this).parent().parent().find(".ML-viewitem5").html('<select fl="3" id="tbUpdMaterialKind"fl="1" class="ML-viewTableInput"><option selected="selected">EP</option><option>VI</option></select>');
        }
        else {
            $(this).parent().parent().find(".ML-viewitem5").html('<select fl="3" id="tbUpdMaterialKind"fl="1" class="ML-viewTableInput"><option>EP</option><option selected="selected">VI</option></select>');
        }
        $(this).parent().parent().find(".ML-viewitem6").html('<input type="text" fl="4" class="ML-viewTableInput" id="tbUpdTotal" value="' + UpdTotal + '"/>');
        $(this).parent().parent().find(".ML-viewitem7").html('');
        $(this).parent().parent().find(".ML-viewitem8").html('');
        $(this).parent().parent().find(".ML-viewitem9").html('<input type="text" fl="5" class="ML-viewTableInput" id="tbUpdDefDes" value="' + UpdDefDes + '"/>');
        $(this).parent().parent().find(".ML-viewitem10").html('<input type="text" fl="6" class="ML-viewTableInput" id="tbUpdConcessionSum" value="' + UpdConcessionSum + '"/>');
        $(this).parent().parent().find(".ML-viewitem11").html('<input type="text" fl="7" class="ML-viewTableInput" id="tbUpdReworkSum" value="' + UpdReworkSum + '"/>');
        $(this).parent().parent().find(".ML-viewitem12").html('<input type="text" fl="8" class="ML-viewTableInput" id="tbUpdRejectionSum" value="' + UpdRejectionSum + '"/>');
        $(this).parent().parent().find(".ML-viewitem13").html('<input type="text" fl="9" class="ML-viewTableInput" id="tbUpdScrapCount" value="' + UpdScrapCount + '"/>');

        $(this).parent().html('<span class="ML-Update" >修改</span>&nbsp; <span class="ML-Cancel">取消</span>');


    });

    //列表数据更新
    $(".ML-Update").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id并转换为整型
        //        //验证批号是否为空，并赋值
        //        if ($.trim($("#tbUpdSMVSNo").val()) == "") {
        //            alert("批号不能为空！");
        //            return;
        //        }
        UpdSMVSNo = $.trim($(this).parent().parent().find(".ML-viewitem1").html());
        //验证物料编号是否为空，并赋值
        if ($.trim($("#tbUpdMaterialNo").val()) == "") {
            alert("物料编号不能为空！");
            return;
        }
        UpdMaterialNo = $.trim($("#tbUpdMaterialNo").val());
        //验证物料描述是否为空，并赋值
        if ($.trim($("#tbUpdMaterialDes").val()) == "") {
            alert("物料描述不能为空！");
            return;
        }
        UpdMaterialDes = $.trim($("#tbUpdMaterialDes").val());
        //验证供应商名称是否为空，并赋值
        if ($.trim($("#tbUpdSupplierName").val()) == "") {
            alert("供应商不能为空！");
            return;
        }
        UpdSupplierName = $.trim($("#tbUpdSupplierName").val());
        //验证物料类型是否为空，并赋值
        if ($.trim($("#tbUpdMaterialKind").val()) == "") {
            alert("物料类型不能为空！");
            return;
        }
        UpdMaterialKind = $.trim($("#tbUpdMaterialKind").val());
        //验证物料总量是否为空，并转换为整型赋值
        if ($.trim($("#tbUpdTotal").val()) == "") {
            alert("物料总量不能为空！");
            return;
        }
        UpdTotal = $.trim($("#tbUpdTotal").val()) * 1;
        if (isNaN(UpdTotal)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("物料总量必须为整数");
            return;
        }
        //验证缺陷是否为空，并赋值
        //        if ($.trim($("#tbUpdDefDes").val()) == "") {
        //            alert("缺陷描述不能为空！");
        //            return;
        //        }
        UpdDefDes = $.trim($("#tbUpdDefDes").val());
        //验证让步数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdConcessionSum = $.trim($("#tbUpdConcessionSum").val()) == "" ? 0 : $.trim($("#tbUpdConcessionSum").val()) * 1;
        if (isNaN(UpdConcessionSum)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("让步数量必须为整数");
            return;
        }
        //验证返工数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdReworkSum = $.trim($("#tbUpdReworkSum").val()) == "" ? 0 : $.trim($("#tbUpdReworkSum").val()) * 1;
        if (isNaN(UpdReworkSum)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("返工数量必须为整数");
            return;
        }
        //验证退货数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdRejectionSum = $.trim($("#tbUpdRejectionSum").val()) == "" ? 0 : $.trim($("#tbUpdRejectionSum").val()) * 1;
        if (isNaN(UpdRejectionSum)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("退货数量必须为整数");
            return;
        }
        //验证报废数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdScrapCount = $.trim($("#tbUpdScrapCount").val()) == "" ? 0 : $.trim($("#tbUpdScrapCount").val()) * 1;
        if (isNaN(UpdScrapCount)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("报废数量必须为整数");
            return;
        }

        if (window.confirm("请确认是否修改？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "/Materials/MaterialsList.aspx/UpdData", //POST页面及调用的方法名
                data: "{id:'" + id + "',smvsNo:'" + UpdSMVSNo + "',materialNo:'" + UpdMaterialNo + "',supplierName:'" + UpdSupplierName + "',materialKind:'" + UpdMaterialKind + "',total:" + UpdTotal + ",defDes:'" + UpdDefDes + "',concessionSum:" + UpdConcessionSum + ",reworkSum:" + UpdReworkSum + ",rejectionSum:" + UpdRejectionSum + ",scrapCount:" + UpdScrapCount + "}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //列表数据删除
    $(".ML-Del").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id并转换为整型
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "/Materials/MaterialsList.aspx/DelData", //POST页面及调用的方法名
                data: "{id:'" + id + "'}", //传参
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    if ($.trim(result.d) == "删除成功！") {
                        window.location.href = window.location.href;
                    }
                }
            });
        }
    });

    //列表数据取消编辑
    $(".ML-Cancel").live("click", function () {
        window.location.href = window.location.href;
    });

    //物料不合格报告
    $(".ML-Report").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid"));
        window.location.href = "AddMaterialNonConform.aspx?id=" + id;
    });
    //添加物料
    $(".ML-Add").live("click", function () {
        //验证批号是否为空，并赋值
        if ($.trim($("#AddSMVSNo").val()) == "") {
            alert("批号不能为空！");
            return;
        }
        UpdSMVSNo = $.trim($("#AddSMVSNo").val());
        //验证物料编号是否为空，并赋值
        if ($.trim($("#AddMaterialNo").val()) == "") {
            alert("物料编号不能为空！");
            return;
        }
        UpdMaterialNo = $.trim($("#AddMaterialNo").val());
        //验证物料描述是否为空，并赋值
        if ($.trim($("#AddMaterialDes").val()) == "") {
            alert("物料描述不能为空！");
            return;
        }
        UpdMaterialDes = $.trim($("#AddMaterialDes").val());
        //验证供应商名称是否为空，并赋值
        if ($.trim($("#AddSupplierName").val()) == "") {
            alert("供应商不能为空！");
            return;
        }
        UpdSupplierName = $.trim($("#AddSupplierName").val());
        //验证物料类型是否为空，并赋值
        if ($.trim($("#AddMaterialKind").val()) == "") {
            alert("物料类型不能为空！");
            return;
        }
        UpdMaterialKind = $.trim($("#AddMaterialKind").val());
        //验证物料总量是否为空，并转换为整型赋值
        if ($.trim($("#AddTotal").val()) == "") {
            alert("物料总量不能为空！");
            return;
        }
        UpdTotal = $.trim($("#AddTotal").val()) * 1;
        if (isNaN(UpdTotal)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("物料总量必须为整数");
            return;
        }
        //验证缺陷是否为空，并赋值
        //        if ($.trim($("#AddDefDes").val()) == "") {
        //            alert("缺陷描述不能为空！");
        //            return;
        //        }
        UpdDefDes = $.trim($("#AddDefDes").val());
        //验证让步数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdConcessionSum = $.trim($("#AddConcessionSum").val()) == "" ? 0 : $.trim($("#AddConcessionSum").val()) * 1;
        if (isNaN(UpdConcessionSum)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("让步数量必须为整数");
            return;
        }
        //验证返工数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdReworkSum = $.trim($("#AddReworkSum").val()) == "" ? 0 : $.trim($("#AddReworkSum").val()) * 1;
        if (isNaN(UpdReworkSum)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("返工数量必须为整数");
            return;
        }
        //验证退货数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdRejectionSum = $.trim($("#AddRejectionSum").val()) == "" ? 0 : $.trim($("#AddRejectionSum").val()) * 1;
        if (isNaN(UpdRejectionSum)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("退货数量必须为整数");
            return;
        }
        //验证报废数量是否为空，如果为空赋值为0，否：将值转换为整型
        UpdScrapCount = $.trim($("#AddScrapCount").val()) == "" ? 0 : $.trim($("#AddScrapCount").val()) * 1;
        if (isNaN(UpdScrapCount)) { //判断字符串是否为整数,当前为非整数,!isNaN(UpdTotal)为整数
            alert("报废数量必须为整数");
            return;
        }
        var purchaseId = $.trim($("#PurchaseId").html()); //订单id
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/Materials/MaterialsList.aspx/AddData", //POST页面及调用的方法名
            data: "{purchaseId:'" + purchaseId + "',smvsNo:'" + UpdSMVSNo + "',materialNo:'" + UpdMaterialNo + "',supplierName:'" + UpdSupplierName + "',materialKind:'" + UpdMaterialKind + "',total:" + UpdTotal + ",defDes:'" + UpdDefDes + "',concessionSum:" + UpdConcessionSum + ",reworkSum:" + UpdReworkSum + ",rejectionSum:" + UpdRejectionSum + ",scrapCount:" + UpdScrapCount + "}", //传参
            dataType: 'json',
            success: function (result) {
                alert(result.d);
                if ($.trim(result.d) == "添加成功") {
                    window.location.href = window.location.href;
                }
            }
        });
    });

    //添加物料编号下列效果

    //添加物料编号input的keyup事件
    $("#AddMaterialNo").live("keyup", function () {
        GetMaterialsNo($.trim($(this).val()));
        $("#AddMaterialNo").autocomplete({
            source: availableTags
        });
    });
    //添加物料编号input的change事件
    $("#AddMaterialNo").live("keypress", function (event) {
        if (event.keyCode == 13) {
            GetMaterialDescrption($.trim($(this).val()), "#AddMaterialDes");
        }
    }).live("blur", function () {
        //alert(availableTags);
        GetMaterialDescrption($.trim($(this).val()), "#AddMaterialDes");

    });

    //添加供应商下列效果
    $("#AddSupplierName").autocomplete({
        source: supplier
    });
    //添加供应商input的keyup事件
    $("#AddSupplierName").live("keyup", function () {
        GetSupplier($.trim($(this).val()));
        $("#AddSupplierName").autocomplete({
            source: supplier
        });
    });

    GetMaterialsNo("");
    GetSupplier("");
    //修改物料编号下列效果
    $("#tbUpdMaterialNo").autocomplete({
        source: availableTags
    });
    //修改物料编号input的keyup事件
    $("#tbUpdMaterialNo").live("keyup", function () {
        GetMaterialsNo($.trim($(this).val()));
        $("#tbUpdMaterialNo").autocomplete({
            source: availableTags
        });
    });
    //修改物料编号input的change事件
    $("#tbUpdMaterialNo").live("keypress", function (event) {
        if (event.keyCode == 13) {

            GetMaterialDescrption($.trim($(this).val()), "#tbUpdMaterialDes");
        }
    });

    //修改供应商下列效果
    $("#tbUpdSupplierName").autocomplete({
        source: supplier
    });
    //修改供应商input的keyup事件
    $("#tbUpdSupplierName").live("keyup", function () {
        GetSupplier($.trim($(this).val()));
        $("#tbUpdSupplierName").autocomplete({
            source: supplier
        });
    });

    $("input").live("keypress", function (event) {
        if (event.keyCode == 13) return false;

    });

    //$('#textbox').trigger("focus"); //获取焦点
    // $('#textbox').trigger("blur"); //失去焦点
    var i = 1;
    $(".addInput").each(function () {
        $(this).attr("flag", i);
        i++;
    });
    //按回车焦点移动到下一个元素
    $(".addInput").keypress(function (event) {
        if (event.keyCode == 13) {
            var n = $(this).attr("flag") * 1;
            $(".addInput").eq(n).trigger("focus");
        }
    });

    $(".ML-viewTableInput").live("keypress", function (event) {
        if (event.keyCode == 13) {
            var n = $(this).attr("fl") * 1;
            $(".ML-viewTableInput").eq(n).trigger("focus");
            return false;
        }
    });

    $("#AddSupplierName").live("blur", function () {
        var supplierName = $("#AddSupplierName").val();
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/Materials/MaterialsList.aspx/GetSData", //POST页面及调用的方法名
            data: "{supplierName:'" + supplierName + "'}", //传参
            dataType: 'json',
            success: function (result) {
                if (result.d.toString() == "Null" && $("#AddSupplierName").val() != "") {
                    alert("供应商不存在！")
                }
            }
        });
    });
    $("#AddScrapCount").live("keypress", function (event) {
        if (event.keyCode == 13) {
            $(".ML-Add").click();
        }
    });
});
var availableTags = [""]; //异步返回物料号下拉框数据集
var materialDescrption; //自动获取的物料描述
var supplier = [""]; //异步返回供应商下拉框数据集
//根据物料编号字符联想查询的对应数据
function GetMaterialsNo(str) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Admin/MaintainMaterial.aspx/GetMaterialsNo", //POST页面及调用的方法名
        data: "{str:'" + str + "'}", //传参
        dataType: 'json',
        success: function (result) {
            availableTags = result.d.toString().split("|");
            $("#AddMaterialNo").autocomplete({
                source: availableTags
            });
        }
    });
}

//根据物料编号获取物料描述
function GetMaterialDescrption(str, obj) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Admin/MaintainMaterial.aspx/GetMaterialDescrption", //POST页面及调用的方法名
        data: "{materialNo:'" + str + "'}", //传参
        dataType: 'json',
        success: function (result) {
            if (($.trim(result.d)) == "" && !$("#AddMaterialNo").val() == "") {
                alert("未找到相应的物料编号！");
            }
            else {
                $(obj).val($.trim(result.d));
            }
        }
    });
}


//AddSupplierName
//根据物料编号字符联想查询的对应数据
function GetSupplier(str) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Admin/MaintainSupplier.aspx/GetSupplier", //POST页面及调用的方法名
        data: "{str:'" + str + "'}", //传参 
        dataType: 'json',
        success: function (result) {
            supplier = result.d.toString().split("|");
            $("#AddSupplierName").autocomplete({
                source: supplier
            });
        }
    });

}