$(document).ready(function () {

    //数据提交前验证
    $("#AP-Add").live("click", function () {
        if ($.trim($.trim($("#PoNo").val())) == "") {
            alert("订单编号不能为空！");
            return;
        }
        var poNo = $.trim($("#PoNo").val());
        if ($.trim($("#Date").val()) == "") {
            alert("订单日期不能为空！");
            return;
        }
        var date = $.trim($("#Date").val());
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "AddPurchase.aspx/AddData", //POST页面及调用的方法名
            data: "{poNo:'" + poNo + "',date:'" + date + "'}", //传参
            dataType: 'json',
            success: function (result) {
                alert(result.d);
                if ($.trim(result.d) == "添加成功！") {
                    window.location.href = "PurchaseList.aspx";
                }

            }
        });
    });
    //清空数据
    $("#AP-Empty").live("click", function () {
        $("#PoNo").val("");
        $("#Date").val("");
    });

});

