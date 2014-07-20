var departOrderType = "ASC";
var scoreOrderType = "ASC";
var departClickState = "";
var scoreClickState = "";
$(document).ready(function ()
{
    $("#btnSelect").click(function ()
    {
        GetExamList();
    });
})
function GetExamList()
{
    var startDate = $("#txtStartDate").val()
    var endDate = $("#txtEndDate").val()
    //加载页面数据
    $.ajax({ global: true, url: "CountPaperRequest.aspx", data: { ActionName: "GetExamList", StartDate: startDate, EndDate: endDate },
        beforeSend: function ()
        {
            $.blockUI({
                css: { border: '1px solid #000', width: '10%', left: '45%' },
                overlayCSS: { backgroundColor: '#fff', opacity: 0 },
                message: '<img src="/Images/wait.gif" /><br />数据加载中，请稍候...'
            });
        },
        success: function (data)
        {
            $.unblockUI(); //IE7已上解决锁定方法
            if (data.ExamList.length == 0)
            {
                alert("该时间范围内未查询到考试信息！");
            }
            else
            {
                //将数据呈现到页面
                ShowExamList(data);
            }
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}
/*显示考试期数*/
function ShowExamList(oLists)
{
    var examList = "";

    $("#divEaxms").html("");
    //$("#tableCountList").css("display", "none");
    $("#divEaxms").css("display", "");
    var corpsStr = '<div><font style="font-size: 14px;font-weight:900; color:#2e2e2e; "><label>期数:</label></font></div>';
    corpsStr += '<div class="Adminrightline"></div>';
    var examId = "";
    for (var j = 0; j < oLists.ExamList.length; j++)
    {
        examList = oLists.ExamList[j];
        examId = ExamIdToFormat(examList.ExamId);
        corpsStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="corps_Exam" title="' + examList.ExamId + '" id="checkbox_' + examList.ExamId + '" value="' + examList.ExamId + '" /><label title="' + examId + '" for="' + examId + '" style="padding-right: 30px">' + examId + '</label></span>';
    }
    corpsStr += '<div class="Adminrightline"></div>';
    corpsStr += '<div align="center"><input id="btnAnalyze" type="submit" class="Adminrighttablebtn" value="统计" onclick="GetCountPaperByPerson()" /></div>';
    $("#divEaxms").append(corpsStr);
}

function ExamIdToFormat(examId)
{
    var newExamId = examId.substr(0, 4) + '-';
    newExamId += examId.substr(4, 2) + '-';
    newExamId += examId.substr(6, 2) + '-';
    newExamId += examId.substr(8, 4);
    return newExamId;
}
function GetCountPaperByPerson()
{

    var examIds = new Array();
    var chbs = $("#divEaxms").find("input[name='corps_Exam']:checked");
    if (chbs.length == 0)
    {
        alert("请至少选择一个期数！");
        return false;
    }
    else
    {
        for (var i = 0; i < chbs.length; i++)
        {
            //将所有的被选中项的value值写入数组里面
            examIds[i] = $(chbs[i]).attr("value");
        }
    }

    //加载页面数据
    $.ajax({ global: true, url: "CountPaperRequest.aspx", data: { ActionName: "GetCountPaperByPerson", "ExamIds[]": examIds, "DepartOrderType": departOrderType, "ScoreOrderType": scoreOrderType, "DepartClickState": departClickState, "ScoreClickState": scoreClickState },
        beforeSend: function ()
        {
            $.blockUI({
                css: { border: '1px solid #000', width: '10%', left: '45%' },
                overlayCSS: { backgroundColor: '#fff', opacity: 0 },
                message: '<img src="/Images/wait.gif" /><br />数据加载中，请稍候...'
            });
        },
        success: function (data)
        {
            $.unblockUI(); //IE7已上解决锁定方法
            if (data == null)
            {
                /*当没有查询数据的时候,默认绘制空表*/
                DrawTable();
                //alert('没有查询数据!');
            }
            else
            {
                //将数据呈现到页面
                DataToTable(data);
            }

        },
        dataType: "json",
        type: "POST",
        async: true
    });
}

function DataToTable(oLists)
{
    $("#tableCountList").html("");
    var str = '<tr class="AdminrightTable01title">';
    str += '<td style="padding-left: 20px; text-align: center; width: 10%">期数</td>';
    str += '<td style="padding-left: 20px; text-align: center; width: 7%">姓名</td>';
    str += '<td style="padding-left: 20px; text-align: center; width: 6%">性别</td>';
    str += '<td style="padding-left: 20px; text-align: center; width: 8%">警号 </td>';
    str += '<td style="padding-left: 20px; text-align: center; width: 10%">职务</td>';
    str += '<td  id="department"   style="padding-left: 20px;  text-align: center; cursor:hand;  width: 9%">部门</td>';
    str += '<td style="padding-left: 20px; text-align: center; width: 7%">单选(对)</td>';
    str += '<td style="padding-left: 20px; text-align: center; width: 7%">多选(对)</td>';
    str += '<td style="padding-left: 20px; text-align: center; width: 7%">判断(对)</td>';
    str += '<td  id="score"  style="padding-left: 20px; text-align: center;cursor:hand;  width: 9%">分数</td>';
    str += '<td style="text-align: center; width: 10%">查看试卷</td>';
    str += '<td style="text-align: center; width: 10%">查看明细</td>';
    str += '</tr>';
    $("#tableCountList").css("display", "");
    $("#divEaxms").css("display", "none");
    if (oLists.CountPaper.length > 0)
    {
        for (var i = 0; i < oLists.CountPaper.length; i++)
        {
            str += "<tr>";
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].ExamId + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].RealName + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].Sex + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].PoliceCode + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].Position + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].Department + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].OnceItem + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].MoreItem + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].DeterItem + '</td>';
            str += '<td style="padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;">' + oLists.CountPaper[i].Score + '</td>';
            str += '<td style="padding-left: 10px; line-height: 25px; text-align: center;background-color: #FFFFFF;"><a target="_blank" href="PersonPaperDetail.aspx?LoginName=' + oLists.CountPaper[i].LoginName + '&ExamId=' + oLists.CountPaper[i].ExamId + '"  title="点击查看">查看</a></td>';
            str += '<td style="padding-left: 10px; line-height: 25px; text-align: center;background-color: #FFFFFF;"><a target="_blank" href="PersonScoreDetail.aspx?LoginName=' + oLists.CountPaper[i].LoginName + '&ExamId=' + oLists.CountPaper[i].ExamId + '"  title="点击查看">查看</a></td>';
            str += "</tr>";
            str += " <tr><td colspan='11'><div class='Adminrightline'></div></td></tr>";
        }
        str += "<tr><td style='padding-left: 20px; line-height: 25px; text-align: center;background-color: #FFFFFF;' colspan='11'><input type='submit' id='btnExport'  class='Adminrighttablebtn' value='导出数据' onclick='ExportToExcel()'></td></tr>";
    }

    $("#tableCountList").append(str);
    $("td[id='department']").click(function ()
    {
        departClickState = "onClick";
        scoreClickState = "";
        if (departOrderType == "DESC")
        {
            departOrderType = "ASC";
        }
        else
        {
            departOrderType = "DESC";
        }
        GetCountPaperByPerson();
    });
    $("td[id='score']").click(function ()
    {
        departClickState = "";
        scoreClickState = "onClick";
        if (scoreOrderType == "DESC")
        {
            scoreOrderType = "ASC";
        }
        else
        {
            scoreOrderType = "DESC";
        }
        GetCountPaperByPerson();
    });
    $("a[class='personDetail']").click(function ()
    {
        /*显示人员考试信息明细*/
        ShowPersonDetail($(this));
    });
}
function DrawTable()
{
    /*当查询回来的数据结果为null的时候,默认给他加载12空行*/
    var str = "";
    for (var j = 0; j <= 12; j++)
    {
        str += "<tr class='AdminrightTable01data02'>";
        str += "<td colspan='11'></td>";
        str += "</tr>";
    }
    $("#tableCountList").append(str);
}
function ExportToExcel()
{
    var examIds = new Array();
    var chbs = $("#divEaxms").find("input[name='corps_Exam']:checked");
    if (chbs.length == 0)
    {
        alert("请至少选择一个期数！");
        return false;
    }
    else
    {
        for (var i = 0; i < chbs.length; i++)
        {
            //将所有的被选中项的value值写入数组里面
            examIds[i] = $(chbs[i]).attr("value");
        }
    }
    window.location = "../SystemApplication/ExportRequest.aspx?ExportToExcel=" + examIds + "";
}

