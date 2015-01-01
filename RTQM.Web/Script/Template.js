$(function () {
    setRighMainWidth(); //设置页面大小
    $.easing.def = "easeOutBounce";
    $('.TP-menuItemTitle').click(function (e) {
        var dropDown = $(this).next();
        $('.TP-menuItemArea').not(dropDown).slideUp('slow');
        dropDown.slideToggle('slow');
        e.preventDefault();
    });
});
$(window).resize(function () {//监听浏览器变化的事件
    setRighMainWidth();//设置页面大小
});
function setRighMainWidth() {
    var width = $(this).width() - 180;
    $('.TP-rightmain').css('width', width);
}




/**
*去除特殊字符
*@param e：对象，如#id，.class,
*@return 
*/
function filterHtmlTag(e) {
    var arr = e.split("|");
    for(var i=0;i<=arr.length;i++) {
         $(arr[i]).val($.trim($(arr[i]).val().replace("<", "").replace(">", "")));
     }
   }

