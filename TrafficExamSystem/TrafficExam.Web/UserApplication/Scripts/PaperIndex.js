var pageIndex = 0;
//总页数
var pageCount = 1;

var answer = "";

$(document).ready(function ()
{
    /*抽提*/
    SetPaperList();
    $("#btnNext").click(function ()
    {
        if (SubmitAnswer())
        {
            pageIndex = pageIndex + 1;
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
            }
            else
            {
                isProper = true;
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
                }
                else
                {
                    isProper = true;
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
            }
            else
            {
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
    str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="DeterItem_Role" title="' + item.FirstOption + '" id="Radio_' + item.FirstOption + '" value="A"/>' + item.FirstOption + '</span></td></tr>';
    str += '<tr><td  class="bxxqtableselcet"><span ><input type="radio"  name="DeterItem_Role" title="' + item.SecondOption + '" id="Radio_' + item.SecondOption + '" value="B"/>' + item.SecondOption + '</span></td></tr>';
    $("#paperInfo").append(str);
}