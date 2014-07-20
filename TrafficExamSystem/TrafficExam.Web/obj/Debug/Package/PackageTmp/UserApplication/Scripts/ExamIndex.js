var pageIndex = 0;
//总页数
var pageCount = 1;

var answer = "";
/*完成题目的考题的最大Id*/
var maxCompletePaperId = 0;
$(document).ready(function ()
{
    /*抽题*/
    SetPaperList();
    /*加载题目对错信息*/
    GetIsProperList();
    /*加载考试时间*/
    GetExamTimeList();
    var clickPaperId = 0;
    $(".clicktd").click(function ()
    {
        var tdPaperId = $(this).attr('id')

        pageIndex = tdPaperId.substring(7, tdPaperId.length);
        if (pageIndex <= maxCompletePaperId)
        {
            if (pageIndex > 1 && pageIndex <= 90)
            {
                if (pageIndex == 90)
                {
                    clickPaperId = pageIndex;
                    $("#btnNext").attr("disabled", true);
                }
                else
                {
                    $("#btnNext").attr("disabled", false);
                }
                $("#btnPrev").attr("disabled", false);
            }
            else
            //设置上一页按钮不可用
                $("#btnPrev").attr("disabled", true);
            /*90题特殊处理,当点击其他地方的时候需要执行提交*/
            if (pageIndex != 90 && clickPaperId == 90)
            {
                if ($("#lblResult").text() == "")
                {
                    if (!SubmitAnswer())
                        return false;
                    clickPaperId = 0;
                }
            }
            LoadPaperInfo(pageIndex);
        }
        else
        {
            /*当前题目的题号*/
            //$("#lblTitle").text().split('、')[0]; //题号
            pageIndex = parseInt($("#lblTitle").text().split('、')[0]);
            alert("请顺序做题!");
        }
    });
    /*下一题按钮*/
    $("#btnNext").click(function ()
    {
        if (SubmitAnswer())
        {
            pageIndex = parseInt(pageIndex) + 1;
            if (pageIndex > 1 && pageIndex <= 90)
            {
                if (pageIndex == 90)
                {
                    $("#btnNext").attr("disabled", true);
                }
                $("#btnPrev").attr("disabled", false);
            }
            else
            //设置上一页按钮不可用
                $("#btnPrev").attr("disabled", true);
            LoadPaperInfo(pageIndex);
        }
    });
    /*上一题按钮*/
    $("#btnPrev").click(function ()
    {
        pageIndex = pageIndex - 1;
        if (pageIndex != 1)
        {
            $("#btnNext").attr("disabled", false);
            $("#btnPrev").attr("disabled", false);
        }
        else
            $("#btnPrev").attr("disabled", true);
        LoadPaperInfo(pageIndex);
    });
    /*提交试卷*/
    $("#btnSubmit").click(function ()
    {
        SubmitExam();
    });
});

//提交答案
function SubmitAnswer()
{
    /*如果没有显示题目结果,证明该题没有做*/
    if ($("#lblResult").text() == "")
    {
        var titleId = $("#lblTitle").text().split('、')[0]; //题号
        var userChooseAnswer = "";
        var isProper = false;
        if (titleId <= 45)  //单选
        {
            userChooseAnswer = $("input[name='OnceItem_Role']:checked").attr("value"); //这个方法是可以取Radio的选中
            if (userChooseAnswer == undefined)
            {
                alert("请选择答案!")
                return false;
            }
            else if (userChooseAnswer != answer)
            {
                alert("错误，本题答案：" + answer);
                $("#tdPaper" + titleId).addClass("homebox");
            }
            else
            {
                isProper = true;
                $("#tdPaper" + titleId).addClass("tctable");
            }
        }
        else if (45 < titleId && titleId <= 64) //多选
        {
            var chbs = $("#paperInfo").find("input[name='MoreItem_Role']:checked");
            if (chbs.length == 0)
            {
                alert("请选择答案！");
                return false;
            }
            else
            {
                for (var i = 0; i < chbs.length; i++)
                {
                    //将所有的被选中项的value值写入数组里面
                    userChooseAnswer += $(chbs[i]).attr("value");
                }
                if (answer != userChooseAnswer)
                {
                    alert("错误,本题答案：" + answer);
                    $("#tdPaper" + titleId).addClass("homebox");
                }
                else
                {
                    isProper = true;
                    $("#tdPaper" + titleId).addClass("tctable");
                }
            }
        }
        else if (65 <= titleId && titleId <= 90) //判断
        {
            userChooseAnswer = $("input[name='DeterItem_Role']:checked").attr("value"); //这个方法是可以取Radio的选中
            if (userChooseAnswer == undefined)
            {
                alert("请选择答案!")
                return false;
            }
            else if (userChooseAnswer != answer)
            {
                alert("错误，本题答案：" + answer);
                $("#tdPaper" + titleId).addClass("homebox");
            }
            else
            {
                $("#tdPaper" + titleId).addClass("tctable");
                isProper = true;
            }
        }
        $.ajax({ global: true, url: "PaperIndexRequest.aspx", data: { ActionName: "UpdateUserAnswer", TitleId: titleId, UserAnswer: userChooseAnswer, IsProper: isProper },
            success: function (data)
            {
                if (data == false)
                {
                    alert('保存用户答案到数据库失败,请检查网络连接!');
                }
                else
                {
                    /*存储数据成功,把最大记录号加1*/
                    maxCompletePaperId = parseInt(maxCompletePaperId) + 1;
                }
            },
            error: function (e)
            {
                alert(e);
            },
            dataType: "json",
            type: "POST",
            async: true
        });
    }
    return true;
}
//设置考题
function SetPaperList()
{
    $.ajax({ global: true, url: "PaperIndexRequest.aspx", data: { ActionName: "SetPaperList" },
        success: function (data)
        {
            if (data == true)
            {
                pageIndex = 1;
                $("#btnPrev").attr("disabled", true); //上一题不可用
                /*加载第一道考题*/
                LoadPaperInfo(pageIndex);
            }
            else
            {
                alert('生成考题失败!');
            }
        },
        error: function (e)
        {
            alert(e);
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}
/*加载考题*/
function LoadPaperInfo(pageIndex)
{
    //ajax验证数据
    $.ajax({ global: true, url: "PaperIndexRequest.aspx", data: { ActionName: "GetPaperInfo", TitleId: pageIndex },
        success: function (data)
        {
            if (data != null)
            {
                ShowPaperInfo(data);
            }
        },
        error: function (e)
        {
            alert(e);
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}
/*加载做的题目的对错*/
function GetIsProperList()
{
    //ajax验证数据
    $.ajax({ global: true, url: "PaperIndexRequest.aspx", data: { ActionName: "GetIsProperList" },
        success: function (data)
        {
            if (data != null)
            {
                ShowExamCard(data);
            }
        },
        error: function (e)
        {
            alert(e);
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}
/*加载做的题目的信息*/
function ShowExamCard(oLists)
{
    var properTrue = 0; /*做对了多少题*/
    var properFalse = 0; /*做错了多少题*/
    var prperSpace = 0; /*未做题目*/
    for (var t = 0; t < oLists.length; t++)
    {
        var examCard = oLists[t];
        if (examCard.UserAnswer != "")
        {
            if (examCard.IsProper == true)
            {
                $("#tdPaper" + examCard.TitleId).addClass("tctable");
                properTrue = properTrue + 1;
            }
            else
            {
                $("#tdPaper" + examCard.TitleId).addClass("homebox");
                properFalse = properFalse + 1
            }
        }
        else
        {
            $("#tdPaper" + examCard.TitleId).addClass("tcbox");
            prperSpace = prperSpace + 1;
            if (prperSpace == 1)
            {
                maxCompletePaperId = t + 1;
            }
        }
    }
    $("#lblProperTrue").text(properTrue);
    $("#lblProperFalse").text(properFalse);
    $("#lblPrperSpace").text(prperSpace);

}
/*考试时间设定*/
function GetExamTimeList()
{
    //ajax验证数据
    $.ajax({ global: true, url: "PaperIndexRequest.aspx", data: { ActionName: "GetExamTimeList" },
        success: function (data)
        {
            if (data.error == true)
            {
                alert(data.message);
            }
            if (data == null)
            {
                alert('没有查询数据!');
            }
            else
            {
                ShowTime(data);
            }
        },
        error: function (e)
        {
            alert(e);
        },
        dataType: "json",
        type: "POST",
        async: false
    });
}
/*加载考试时间*/

var timer = null;

var maxTime;
function ShowTime(oLists)
{
    var min1 = parseInt(oLists.ExamTime[0].EndTime.substr(11, 2)) * 60 + parseInt(oLists.ExamTime[0].EndTime.substr(14, 2));
    var min2 = parseInt(oLists.ExamTime[0].CurrentTime.substr(11, 2)) * 60 + parseInt(oLists.ExamTime[0].CurrentTime.substr(14, 2));
    maxTime = (min1 - min2) * 60;
    /*开始倒计时*/
    timer = setInterval("CountDown()", 1000)
}
function CountDown()
{
    if (maxTime >= 0)
    {
        var minutes = Math.floor(maxTime / 60);
        var seconds = Math.floor(maxTime % 60);
        $("#lblCountdown").text("距离结束还有：" + minutes + "分" + seconds + "秒");
        --maxTime;
    }
    else
    {
        clearInterval(timer);
        alert("考试结束！");
    }
}


//加载题目
function ShowPaperInfo(oLists)
{
    $("#paperInfo").html('');
    var item = oLists[0];
    if (item.SubjectItem == 1)
    {
        $("#lblTitleId").text("单选");
        $("#lblTitle").text(item.TitleId + "、" + item.Title);
        ShowOnceItem(item);
        /*先把内容加载出来*/
        if (item.UserAnswer != "")
        {
            $("#divResult").css("display", "");
            if (item.IsProper == true)
            {
                $("#lblResult").text("正确");
                $("#divProperAnswer").css("display", "none");
            }
            else
            {
                $("#lblResult").text("错误");
                $("#divProperAnswer").css("display", "");
                $("#lblProperAnswer").text(item.Answer);
            }
            $("input[name='OnceItem_Role'][value='" + item.UserAnswer + "']").attr("checked", true);
        }
        else
        {
            $("#divResult").css("display", "none");
            $("#lblResult").text("");
            answer = item.Answer;
        }
    }
    else if (item.SubjectItem == 2)
    {
        $("#lblTitleId").text("多选");
        $("#lblTitle").text(item.TitleId + "、" + item.Title);
        ShowMoreItem(item);
        /*先把内容加载出来*/
        if (item.UserAnswer != "")
        {
            $("#divResult").css("display", "");
            if (item.IsProper == true)
            {
                $("#lblResult").text("正确");
                $("#divProperAnswer").css("display", "none");
            }
            else
            {
                $("#lblResult").text("错误");
                $("#divProperAnswer").css("display", "");
                $("#lblProperAnswer").text(item.Answer);
            }
            var chbs = $("#paperInfo").find("input[name='MoreItem_Role']"); //把所有的【多选】选择项加载出来
            for (var i = 0; i < item.UserAnswer.length; i++)
            {
                for (var n = 0; n < chbs.length; n++)
                {
                    if (item.UserAnswer[i] == chbs[n].value)
                    {
                        $(chbs[n]).attr("checked", true);
                    }
                }
            }
        }
        else
        {
            $("#divResult").css("display", "none");
            $("#lblResult").text("");
            answer = item.Answer;
        }
    }
    else if (item.SubjectItem == 3)
    {
        $("#lblTitleId").text("判断");
        $("#lblTitle").text(item.TitleId + "、" + item.Title);
        ShowDeterItem(item);
        if (item.UserAnswer != "")
        {
            $("#divResult").css("display", "");
            if (item.IsProper == true)
            {
                $("#lblResult").text("正确");
                $("#divProperAnswer").css("display", "none");
            }
            else
            {
                $("#lblResult").text("错误");
                $("#divProperAnswer").css("display", "");
                $("#lblProperAnswer").text(item.Answer);
            }
            $("input[name='DeterItem_Role'][value='" + item.UserAnswer + "']").attr("checked", true);
        }
        else
        {
            $("#divResult").css("display", "none");
            $("#lblResult").text("");
            answer = item.Answer;
        }
    }
}
/*提交考试*/
function SubmitExam()
{
    if (confirm("您是否确认提交试卷！") == true)//这里要特别注意"!"感叹号的全区/半区区分
    {
        if (pageIndex == 90)
        {
            if ($("#lblResult").text() == "")
            {
                if (!SubmitAnswer())
                {
                    return false;
                }
            }
        }
        //ajax验证数据
        $.ajax({ global: true, url: "PaperIndexRequest.aspx", data: { ActionName: "SubmitExam" },
            success: function (data)
            {
                if (data == true)
                {
                    window.location.href = "../Login.aspx";
                }
                else
                {
                    alert("系统出错,提交考试失败！");
                }
            },
            error: function (e)
            {
                alert(e);
            },
            dataType: "json",
            type: "POST",
            async: true
        });
    }
}
/**************单选****************/
function ShowOnceItem(item)
{
    var str = '';
    var itemCount = item.ItemCount;
    if (itemCount == 6)
    {
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FirstOption + '" id="Radio_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.SecondOption + '" id="Radio_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.ThirdOption + '" id="Radio_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FourthOption + '" id="Radio_' + item.FourthOption + '" value="D"/>D、' + item.FourthOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FifthOption + '" id="Radio_' + item.FifthOption + '" value="E"/>E、' + item.FifthOption + '</span></td></tr>';
        str += '<span ><tr><td  class="bxxqtableselcet"><input type="radio"  name="OnceItem_Role" title="' + item.SixthOption + '" id="Radio_' + item.SixthOption + '" value="F"/>F、' + item.SixthOption + '</span></span>';
    }
    else if (itemCount == 5)
    {
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FirstOption + '" id="Radio_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.SecondOption + '" id="Radio_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.ThirdOption + '" id="Radio_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FourthOption + '" id="Radio_' + item.FourthOption + '" value="D"/>D、' + item.FourthOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FifthOption + '" id="Radio_' + item.FifthOption + '" value="E"/>E、' + item.FifthOption + '</span></td></tr>';
    }
    else if (itemCount == 4)
    {
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FirstOption + '" id="Radio_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.SecondOption + '" id="Radio_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.ThirdOption + '" id="Radio_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FourthOption + '" id="Radio_' + item.FourthOption + '" value="D"/>D、' + item.FourthOption + '</span></td></tr>';
    }
    else if (itemCount == 3)
    {
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FirstOption + '" id="Radio_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.SecondOption + '" id="Radio_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.ThirdOption + '" id="Radio_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
    }
    else if (itemCount == 2)
    {
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.FirstOption + '" id="Radio_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="OnceItem_Role" title="' + item.SecondOption + '" id="Radio_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
    }
    $("#paperInfo").append(str);
}
/************多选*****************/
function ShowMoreItem(item)
{
    var str = "";
    var itemCount = item.ItemCount;
    if (itemCount == 6)
    {
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FirstOption + '" id="checkBox_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="checkBox"   name="MoreItem_Role" title="' + item.SecondOption + '" id="checkBox_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.ThirdOption + '" id="checkBox_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FourthOption + '" id="checkBox_' + item.FourthOption + '" value="D"/>D、' + item.FourthOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FifthOption + '" id="checkBox_' + item.FifthOption + '" value="E"/>E、' + item.FifthOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.SixthOption + '" id="checkBox_' + item.SixthOption + '" value="F"/>F、' + item.SixthOption + '</span></td></tr>';
    }
    else if (itemCount == 5)
    {
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FirstOption + '" id="checkBox_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="checkBox"   name="MoreItem_Role" title="' + item.SecondOption + '" id="checkBox_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.ThirdOption + '" id="checkBox_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FourthOption + '" id="checkBox_' + item.FourthOption + '" value="D"/>D、' + item.FourthOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FifthOption + '" id="checkBox_' + item.FifthOption + '" value="E"/>E、' + item.FifthOption + '</span></td></tr>';
    }
    else if (itemCount == 4)
    {
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FirstOption + '" id="checkBox_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="checkBox"   name="MoreItem_Role" title="' + item.SecondOption + '" id="checkBox_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.ThirdOption + '" id="checkBox_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FourthOption + '" id="checkBox_' + item.FourthOption + '" value="D"/>D、' + item.FourthOption + '</span></td></tr>';
    }
    else if (itemCount == 3)
    {
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FirstOption + '" id="checkBox_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="checkBox"   name="MoreItem_Role" title="' + item.SecondOption + '" id="checkBox_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.ThirdOption + '" id="checkBox_' + item.ThirdOption + '" value="C"/>C、' + item.ThirdOption + '</span></td></tr>';
    }
    else if (itemCount == 2)
    {
        str += '<tr><td  class="bxxqtableselcet"><span><input type="checkBox"   name="MoreItem_Role" title="' + item.FirstOption + '" id="checkBox_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
        str += '<tr><td  class="bxxqtableselcet"><span ><input type="checkBox"   name="MoreItem_Role" title="' + item.SecondOption + '" id="checkBox_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
    }
    $("#paperInfo").append(str);
}
/************判断**************/
function ShowDeterItem(item)
{
    var str = "";
    str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="DeterItem_Role" title="' + item.FirstOption + '" id="Radio_' + item.FirstOption + '" value="A"/>A、' + item.FirstOption + '</span></td></tr>';
    str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="DeterItem_Role" title="' + item.SecondOption + '" id="Radio_' + item.SecondOption + '" value="B"/>B、' + item.SecondOption + '</span></td></tr>';
    $("#paperInfo").append(str);
}