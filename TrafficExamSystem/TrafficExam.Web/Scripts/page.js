
//当前页码
var pageIndex = 1;

//总页数
var pageCount = 1;

//总记录数
var spanRowCount = 0;


function DisabledPageBtn(actionName)
{

   
    if (actionName == "All")
    {
        $("#page-up-4").hide();
        $("#page-up-3").hide();
        $("#page-up-2").hide();
        $("#page-up-1").hide();
        $("#page-cur").text(pageIndex).addClass("currentPageNum");
        $("#page-down-1").hide();
        $("#page-down-2").hide();
        $("#page-down-3").hide();
        $("#page-down-4").hide();
    }


    //当前页为第一页
    else if (actionName == "First")
    {
        $("#page-up-4").hide();
        $("#page-up-3").hide();
        $("#page-up-2").hide();
        $("#page-up-1").hide();
        $("#page-cur").text(pageIndex).addClass("currentPageNum");
        $("#page-down-1").show().text(pageIndex + 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 1); });
        if (pageCount > 2)
        {
            $("#page-down-2").show().text(pageIndex + 2).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 2); });
        }
        else
        {
            $("#page-down-2").hide();
        }
        if (pageCount > 3)
        {
            $("#page-down-3").show().text(pageIndex + 3).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 3); });
        }
        else
        {
            $("#page-down-3").hide();
        }
        if (pageCount > 4)
        {
            $("#page-down-4").show().text(pageIndex + 4).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 4); });
        }
        else
        {
            $("#page-down-4").hide();
        }
    }

    //当前页为第二页
    else if (actionName == "Second")
    {
        $("#page-up-4").hide();
        $("#page-up-3").hide();
        $("#page-up-2").hide();
        $("#page-up-1").show().text(pageIndex - 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 1); });
        $("#page-cur").text(pageIndex).addClass("currentPageNum");
        if (pageCount > 2)
        {
            $("#page-down-1").show().text(pageIndex + 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 1); });
        }
        else
        {
            $("#page-down-1").hide();
        }
        if (pageCount > 3)
        {
            $("#page-down-2").show().text(pageIndex + 2).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 2); });
        }
        else
        {
            $("#page-down-2").hide();
        }
        if (pageCount > 4)
        {
            $("#page-down-3").show().text(pageIndex + 3).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 3); });
        }
        else
        {
            $("#page-down-3").hide();
        }
        $("#page-down-4").hide();
    }

    //当前页为倒数二页
    else if (actionName == "Skip")
    {
        $("#page-up-4").hide();
        if (pageCount > 4)
        {
            $("#page-up-3").show().text(pageIndex - 3).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 3); });
        }
        else
        {
            $("#page-up-3").hide();
        }
        if (pageCount > 2)
        {
            $("#page-up-2").show().text(pageIndex - 2).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 2); });
        }
        else
        {
            $("#page-up-2").hide();
        }
        $("#page-up-1").show().text(pageIndex - 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 1); });
        $("#page-cur").text(pageIndex).addClass("currentPageNum");
        $("#page-down-1").show().text(pageIndex + 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 1); });
        $("#page-down-2").hide();
        $("#page-down-3").hide();
        $("#page-down-4").hide();
    }

    //当前页为最后一页
    else if (actionName == "Last")
    {
        if (pageCount > 4)
        {
            $("#page-up-4").show().text(pageIndex - 4).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 4); });
        }
        else
        {
            $("#page-up-4").hide();
        }
        if (pageCount > 3)
        {
            $("#page-up-3").show().text(pageIndex - 3).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 3); });
        }
        else
        {
            $("#page-up-3").hide();
        }
        if (pageCount > 2)
        {
            $("#page-up-2").show().text(pageIndex - 2).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 2); });
        }
        else
        {
            $("#page-up-2").hide();
        }
        $("#page-up-1").show().text(pageIndex - 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 1); });
        $("#page-cur").text(pageIndex).addClass("currentPageNum");
        $("#page-down-1").hide();
        $("#page-down-2").hide();
        $("#page-down-3").hide();
        $("#page-down-4").hide();
    }

    //当前页为中间页
    else
    {
        $("#page-up-4").hide();
        $("#page-up-3").hide();
        $("#page-up-2").show().text(pageIndex - 2).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 2); });
        $("#page-up-1").show().text(pageIndex - 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex - 1); });
        $("#page-cur").text(pageIndex).addClass("currentPageNum");
        $("#page-down-1").show().text(pageIndex + 1).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 1); });
        $("#page-down-2").show().text(pageIndex + 2).addClass("pageNum").unbind().click(function () { LoadPage(false, pageIndex + 2); });
        $("#page-down-3").hide();
        $("#page-down-4").hide();
    }

    //事件绑定
    //上一页
    $('div[class="pageUp"]').unbind().click(function ()
    {
        pageIndex = pageIndex - 1;
        LoadPage(false, pageIndex);
    });

    //下一页
    $('div[class="pageDown"]').unbind().click(function ()
    {
        pageIndex = pageIndex + 1;
        LoadPage(false, pageIndex);
    });


    //按钮高亮效果
    $("#page-prev").mouseover(function () { $("#page-prev").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-prev").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-up-4").mouseover(function () { $("#page-up-4").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-up-4").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-up-3").mouseover(function () { $("#page-up-3").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-up-3").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-up-2").mouseover(function () { $("#page-up-2").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-up-2").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-up-1").mouseover(function () { $("#page-up-1").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-up-1").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-down-1").mouseover(function () { $("#page-down-1").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-down-1").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-down-2").mouseover(function () { $("#page-down-2").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-down-2").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-down-3").mouseover(function () { $("#page-down-3").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-down-3").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-down-4").mouseover(function () { $("#page-down-4").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-down-4").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
    $("#page-next").mouseover(function () { $("#page-next").removeClass("onMouseDownStyle").addClass("onMouseOverStyle"); }).mouseout(function () { $("#page-next").removeClass("onMouseOverStyle").addClass("onMouseDownStyle"); });
}



//验证时间大小
function checkTime(startTime, endTime)
{

    if (startTime > endTime)
    {
        return false;
    }
    else
    {
        return true;
    }
//    var startBegin = startTime.indexOf('-');
//    var startEnd = endTime.lastIndexOf('-');
//    var endBegin = endTime.indexOf('-');
//    var end = endTime.lastIndexOf('-');
//    var startMonth = "";
//    var endMonth = "";
//    var startDay = "";
//    var endDay = "";
//    if (startTime.substring(startBegin + 1, startEnd - 1) == 0)
//    {
//        startMonth = startTime.substring(startBegin + 2, startEnd)
//    }
//    else
//    {
//        startMonth = startTime.substring(startBegin + 1, startEnd);
//    }
//    if (endTime.substring(endBegin + 1, end - 1) == 0)
//    {
//        endMonth = endTime.substring(endBegin + 2, end);
//    }
//    else
//    {
//        endMonth = endTime.substring(endBegin + 1, end);
//    }

//    if (startTime.substring(startEnd + 1, startTime.length - 1) == 0)
//    {
//        startDay = startTime.substring(startEnd + 2, startTime.length);
//    }
//    else
//    {
//        startDay = startTime.substring(startEnd + 1, startTime.length);
//    }

//    if (endTime.substring(end + 1, endTime.length - 1) == 0)
//    {
//        endDay = endTime.substring(end + 2, endTime.length);
//    }
//    else
//    {
//        endDay = endTime.substring(end + 1, endTime.length);
//    }

//    if (parseInt(startTime.substring(0, startBegin)) > parseInt(endTime.substring(0, endBegin)))
//    {
//        return false;
//    }
//    else
//    {
//        return true;
//    }
//    if (parseInt(startMonth) > parseInt(endMonth))
//    {
//        return false;
//    }
//    else
//    {
//        return true;
//    }
//    if (parseInt(startDay) > parseInt(endDay))
//    {
//        return false;
//    }
//    else
//    {
//        return true;
//    }
}

//判断特殊字符
function checkChar(InString, id)
{
    var RefString = new Array("<", "%", "\"", ">", "~", "&", "?", "'", "'", "[", "]", "{", "}", "*", ")", "(", "-", "=", "#", "$", "^", "+", "@");
    for (Count = 0; Count < InString.length; Count++)
    {
        TempChar = InString.substring(Count, Count + 1);
        for (var i = 0; i < RefString.length; i++)
        {
            if (TempChar == RefString[i].toString())
            {
                alert("您的输入的" + id + "中含有非法字符,请重新输入（只能输入数字，字母，中文，逗号，点等）!");
                return false;
            }
        }
    }
    return true;
}
