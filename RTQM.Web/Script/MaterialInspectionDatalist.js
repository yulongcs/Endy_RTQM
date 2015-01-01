$(function () {
    $("#mainContent_tbBeginDate").datepicker({ autoSize: true });
    $("#mainContent_tbEndDate").datepicker({ autoSize: true });

    //搜索提交前去除“<”、“>”特殊符号，保证http的传输安全
    $('#mainContent_btSelect').live("click", function() {
        //调用去除特殊字符方法，参数之间用“|”符号隔开
        if (!isNaN($.trim($("#mainContent_tbMinConformance").val())) && !isNaN($.trim($("#mainContent_tbMaxConformance").val()))) {
            filterHtmlTag('#mainContent_tbPoNo|#mainContent_tbBeginDate|#mainContent_tbEndDate|#mainContent_tbSMVSNo|#mainContent_tbMaterialNo|#mainContent_tbMinConformance|#mainContent_tbMaxConformance|#mainContent_tbSupplier');
            return true;
        } else {
            alert("合格率必须为整数！");
            return false;
        }
    });

   //根据id删除列表数据
    $(".MID-Del").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid")); //获取id
        if (window.confirm("你确定要删除吗？")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "MaterialInspectionDatalist.aspx/DelData",
                data: "{id:'" + id + "'}",
                dataType: 'json',
                success: function (result) {
                    alert(result.d);
                    window.location.href = window.location.href;
                }
            });
        }
    });
    //物料不合格报告
    $(".MID-Report").live("click", function () {
        var id = $.trim($(this).parent().attr("itemid"));
        window.location.href = "AddMaterialNonConform.aspx?id=" + id;
    });
    //列表偶数行样式
    $('.MID-viewTable tr:even').css({ background: '#d8f0ef' });
});
