$(function () {
    $('#mainContent_btAdd').live("click", function () {
        //调用去除特殊字符方法，参数之间用“|”符号隔开
        filterHtmlTag('#mainContent_tbDefect|#mainContent_tbDefectDes|#mainContent_tbProcessContent|#mainContent_tbHandleSubsequent|#mainContent_tbDecision');
    });
    $('#mainContent_btReset').live("click", function () {
        //调用去除特殊字符方法，参数之间用“|”符号隔开
        filterHtmlTag('#mainContent_tbDefect|#mainContent_tbDefectDes|#mainContent_tbProcessContent|#mainContent_tbHandleSubsequent|#mainContent_tbDecision');
    });
});