$(document).ready(function () {
    $("#menu2 li a").wrapInner('<span class="out"></span>');
    $("#menu2 li a").each(function () {
        $('<span class="over">' + $(this).text() + '</span>').appendTo(this);
    });
    $("#menu2 li a").hover(function () {
        $(".out", this).stop().animate({ 'top': '45px' }, 200); // 向下滑动 - 隐藏  
        $(".over", this).stop().animate({ 'top': '0px' }, 200); // 向下滑动 - 显示  
    }, function () {
        $(".out", this).stop().animate({ 'top': '0px' }, 200); // 向上滑动 - 显示  
        $(".over", this).stop().animate({ 'top': '-45px' }, 200); // 向上滑动 - 隐藏  
    });
});  