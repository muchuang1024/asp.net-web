$(document).ready(function () {

    GetSubjectTypeList(); //获取已经设置好的考点
    ShowExamTime(); //获取已经设置好的考试时间
    LoadCheckedUser(); //获取已经设置的考试人员
    //大队领导
    $("#chkLeadership").click(function () {
        CheckLeadership();
    })
    //部门领导
    $("#chkDepartment").click(function () {
        CheckDepartment();
    })
    //民警
    $("#chkPolice").click(function () {
        CheckPolice();
    })
    //协警
    $("#chkHelpPolice").click(function () {
        CheckHelpPolice();
    })
    //大队部
    $("#chkCorps").click(function () {
        CheckCorps();
    })
    //事故中队
    $("#chkAccident").click(function () {
        CheckAccident();
    })
    //监控中心
    $("#chkMonitoringCenter").click(function () {
        CheckMonitoringCenter();
    })
    //办公室
    $("#chkOffice").click(function () {
        CheckOffice();
    })
    //车管所
    $("#chkVehicle").click(function () {
        CheckVehicle();
    })
    //邓关中队
    $("#chkDengguan").click(function () {
        CheckDengguan();
    })
    //二中队
    $("#chkSecond").click(function () {
        CheckSecond();
    })
    //仙市中队
    $("#chkXianshi").click(function () {
        CheckXianshi();
    })
    //沿滩中队
    $("#chkYantan").click(function () {
        CheckYantan();
    })
    //新进人员
    $("#chkNewUser").click(function () {
        CheckNewUser();
    })
    //其他
    $("#chkOther").click(function () {
        CheckOther();
    })
    //设置科目类型及考试时间
    $("#Sub_GetSubject").click(function () {
        SetSubject();
      
    })
    $("#btn_CompleteExam").click(function () {
        CompleteExam(); //完成考试
        Panelenable(); //控件可用
    })
    $('#selectPos').click(function () {
        $("#dpt :checkbox:checked").attr("checked", false); ;
        $("#pos").css("display", "block");
        $("#dpt").css("display", "none");
    })
    $('#selectDpt').click(function () {
        $("#pos :checkbox:checked").attr("checked", false); ;
        $("#pos").css("display", "none");
        $("#dpt").css("display", "block");
    })
});
function CompleteExam()
{
    //ajax验证数据
    $.ajax({ global: true, url: "PaperInstallRequest.aspx", data: { ActionName: "CompleteExam" },
        success: function (data) {
            if (data == true) {
                alert("上一批次考试结束,您可以进行新的考试科目设置！");
                $("#Sub_GetSubject").attr("disabled", false);
                //按钮可用
             
            }
        },
        error: function (e) {
            alert(e);
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}

/*加载设置的考点*/
function GetSubjectTypeList()
{
    //ajax验证数据
    $.ajax({ global: true, url: "PaperInstallRequest.aspx", data: { ActionName: "GetSubjectType" },
        success: function (data)
        {
            if (data != null)
            {
                ShowSubjectTypeList(data);
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
/*勾选已经设置好的考点前面的复选框*/
function ShowSubjectTypeList(oLists)
{
    var chbs = $("#topic").find("input[name='More']");
    for (var i = 0; i < oLists.length; i++)
    {
        var SubjectType = oLists[i];
        for (var j = 0; j < chbs.length; j++)
        {
            if (SubjectType.SubjectTypeId == chbs[j].value)
            {
                $(chbs[j]).attr("checked", true);
            }
        }
    }
    if (oLists[0].CountPaperId > 0)
    {
        //$("#Sub_GetSubject").attr("disabled", "disabled");
        $("#Sub_GetSubject").attr("disabled", "disabled");
        Paneldisable(); //控件不可用
        //按钮不可用;
    }

}
//设定考试后，所有控件不可用，不可更改
function Paneldisable() 
{
    var d = document.getElementById("mainContent");
    for (var i = 0; i < d.childNodes.length; i++) 
    {
        if (d.childNodes[i].disabled != null) 
        {
            d.childNodes[i].disabled = "disabled";
        }
    }
}
//完成考试后，所有控件可用
function Panelenable() {
    var d = document.getElementById("mainContent");
    for (var i = 0; i < d.childNodes.length; i++) {
        if (d.childNodes[i].disabled != null) 
        {
            d.childNodes[i].disabled = false;
        }
      }
}
function ShowExamTime()
{
    $.ajax({ global: true, url: "PaperInstallRequest.aspx", data: { ActionName: "ShowExamTime" },
        success: function (data)
        {
            if (data.ExamTime.length != 0)
            {
                GetExamTimeList(data);
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
function GetExamTimeList(oLists)
{
    var start = "";
    var end= "";
    var regS = new RegExp("\\/", "g");
    if (oLists.ExamTime[0].EndTime.indexOf('/') >= 0)
    {
        end = oLists.ExamTime[0].EndTime.replace(regS, "-");
        end = end.substring(0, end.length - 3);
        //处理考试结束时间
        var m1 = end.indexOf('-'); //从前往后获取第一个"-"符号的位置
        var m2 = end.lastIndexOf('-'); //从后往后获取第二个"-"符号的位置
        var m3 = end.indexOf(' '); //截取空格字符的位置 （2013-9-1 12:23）
        var m4 = end.indexOf(':'); //截取分号字符的位置
        var year2 = end.substring(0, m1);
        var month2 = end.substring(m1 + 1, m2); //月份
        var day2 = end.substring(m2 + 1, m3); //天数
        var hour2 = end.substring(m3 + 1, m4);//小时
        var minute2 = end.substring(m4 + 1);//分钟
        if (month2.length == 1)
        {
            month2 = "0" + month2;
        }
        if (day2.length == 1)
        {
            day2 = "0" + day2;
        }
        if (hour2.length == 1)
        {

            hour2 = "0" + hour2;
        }
        if (minute2.length == 1)
        {
            minute2 = "0" + minute2;
        }
        end = year2 + "-" + month2 + "-" + day2 +" "+ hour2 + ":" + minute2 ;

    }
    else
    {
        end = oLists.ExamTime[0].EndTime;
        end = end.substring(0, end.length - 3);
    }
    if (oLists.ExamTime[0].StartTime.indexOf('/') >= 0)
    {
        start = oLists.ExamTime[0].StartTime.replace(regS, "-");
        start = start.substring(0, start.length - 3);
        //处理考试开始时间
        var n1 = start.indexOf('-'); //从前往后获取第一个"-"符号的位置
        var n2 = start.lastIndexOf('-'); //从后往后获取第二个"-"符号的位置
        var n3 = start.indexOf(' '); //截取空格字符的位置 （2013-9-1 12:23）
        var n4 = start.indexOf(':'); //截取分号字符的位置
        var year1 = start.substring(0, n1);
        var month1 = start.substring(n1 + 1, n2); //月份
        var day1 = start.substring(n2 + 1, n3); //天数
        var hour1 = start.substring(n3 + 1, n4); //小时
        var minute1 = start.substring(n4 + 1);  //分钟
        if (month1.length == 1)
        {
            month1 = "0" + month1;
        }
        if (day1.length == 1)
        {
            day1 = "0" + day1;
        }
        if (hour1.length == 1)
        {
            hour1 = "0" + hour1;
        }
        if (minute1.length == 1)
        {
            minute1 = "0" + minute1;
        }
        start = year1 + "-" + month1 + "-" + day1 + " "+ hour1 + ":" + minute1;
    }
    else
    {
        start = oLists.ExamTime[0].StartTime;
        start = start.substring(0, start.length - 3);
    }
    document.getElementById("starttime").value = start;
    //document.getElementById("endtime").value = end;
}
function SetSubject()
{
    
    var str = "";
    var startTime="";
    var endTime = "";
    var n = 0;
    var flag = 0;
    var intonce = intmore = intdeter = 0;
    var one = document.getElementsByName('item');
    var chbs_leadership = $("#div_Leadership").find("input[name='leadership_Role']:checked");
    var chbs_department = $("#div_Department").find("input[name='department_Role']:checked"); //部门领导
    var chbs_police = $("#div_Police").find("input[name='police_Role']:checked"); //民警
    var chbs_helpPolice = $("#div_HelpPolice").find("input[name='helpPolice_Role']:checked"); //协警
     var chbs_Corps = $("#div_Corps").find("input[name='corps_Role']:checked"); //大队部选中项目
    var chbs_Accident = $("#div_Accident").find("input[name='accident_Role']:checked"); //事故中队选中项目
    var chbs_MonitoringCenter = $("#div_MonitoringCenter").find("input[name='monitoringCenter_Role']:checked"); //监控中心选中项目
    var chbs_Office = $("#div_Office").find("input[name='office_Role']:checked"); //办公室选中项目
    var chbs_Vehicle = $("#div_Vehicle").find("input[name='vehicle_Role']:checked"); //车管所选中项目
    var chbs_Dengguan = $("#div_Dengguan").find("input[name='dengguan_Role']:checked"); //邓关中队选中项目
    var chbs_Second = $("#div_Second").find("input[name='second_Role']:checked"); //二中队选中项目
    var chbs_Xianshi = $("#div_Xianshi").find("input[name='xianshi_Role']:checked"); //仙市中队选中项目
    var chbs_Yantan = $("#div_Yantan").find("input[name='yantan_Role']:checked"); //沿滩中队选中项目
    var chbs_newUser = $("#div_NewUser").find("input[name='newUser_Role']:checked"); //新进人员选中项目
    var chbs_Other = $("#div_Other").find("input[name='other_Role']:checked"); //其他人员选中项目
    for (var j = 0; j < one.length; j++) 
    {
        if (one[j].checked == true) 
        {
            flag = flag + 1;
        }
    }
    if (flag == 0) 
    {
        alert('请选择题目难易程度');
        return false;
    }
    //题目难度为简单
    if (document.getElementById('onceitem').checked == true)
    {
        intonce = 40;
        intmore = 10;
        intdeter = 40;
    }
    //题目难度为中等
    if (document.getElementById('moreitem').checked == true)
    {
        intonce = 35;
        intmore = 15;
        intdeter = 35;
    }
    //题目难度为困难
    if (document.getElementById('deteritem').checked == true)
    {
        intonce = 30;
        intmore = 20;
        intdeter =30;
    }
    //设置考试人员
    if ($("#selectPos").attr("checked")) //按照职务设置
    {
    if (chbs_leadership.length == 0 && chbs_department.length == 0 && chbs_police.length == 0 && chbs_helpPolice.length == 0)
     {
        alert("请对考试人员进行设置！");
        return false;
    }
    }
    else if($("#selectDpt").attr("checked")) //按照部门设置
    {
     if(chbs_Corps.length == 0 && chbs_Accident.length == 0 && chbs_MonitoringCenter.length == 0 && chbs_Office.length == 0 && chbs_Vehicle.length == 0 && chbs_Dengguan.length == 0 && chbs_Second.length == 0 && chbs_Xianshi.length == 0 && chbs_newUser.length == 0 && chbs_Other.length == 0)
    {
        alert("请对考试人员进行设置！");
        return false;
    }
    }
    //设置考点
    var s = document.getElementsByName('More');
    for (var i = 0; i < s.length; i++)
    {
        if (s[i].checked == true)
        {
            str += s[i].value + ',';
            n++; //选中复选框个数
        }
    }
    str = str.substring(0, 2 * n - 1);
    if (n == 0)
    {
        alert("请设置考点！");
        return false;
    }
    else {
        if ($("#starttime").val() != "" && $("#endtime").val() != "" && !isNaN($("#endtime").val()))
        {
            startTime = $("#starttime").val();
            minute = $("#endtime").val();
            $.ajax({ global: true, url: "PaperInstallRequest.aspx", data: { ActionName: "SetSubjectList", SubjectIdlist: str, StartTime: startTime, Minute: minute, OnceItem: intonce, MoreItem: intmore, DeterItem: intdeter },
                success: function (data)
                {
                    if (data == true)
                    {
                        SetUserState();
                        $("#Sub_GetSubject").attr("disabled", "disabled");
                        Paneldisable(); //控件不可用
                    }
                    else
                    {
                        alert('考试时间设置不合理');
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
        else
        {
            alert('开始答题时间和考试用时不能为空');
            return false;
        }
    }
}
function CheckLeadership() {
    if ($("#chkLeadership").attr("checked")) {
        $("#div_Leadership").css("display", "");
        $("input[name='leadership_Role']").attr("checked", true);
    }
    else {
        $("#div_Leadership").css("display", "none");
        $("input[name='leadership_Role']").attr("checked", false);
    }
}
function CheckDepartment() {
    if ($("#chkDepartment").attr("checked")) {
        $("#div_Department").css("display", "");
        $("input[name='department_Role']").attr("checked", true);
    }
    else {
        $("#div_Department").css("display", "none");
        $("input[name='department_Role']").attr("checked", false);
    }
}
function CheckPolice() {
    if ($("#chkPolice").attr("checked")) {
        $("#div_Police").css("display", "");
        $("input[name='police_Role']").attr("checked", true);
    }
    else {
        $("#div_Police").css("display", "none");
        $("input[name='police_Role']").attr("checked", false);
    }
}
function CheckHelpPolice() {
    if ($("#chkHelpPolice").attr("checked")) {
        $("#div_HelpPolice").css("display", "");
        $("input[name='helpPolice_Role']").attr("checked", true);
    }
    else {
        $("#div_HelpPolice").css("display", "none");
        $("input[name='helpPolice_Role']").attr("checked", false);
    }
}

function LoadCheckedUser() {
    $.ajax({ global: true, url: "SetUserRequest.aspx", data: { ActionName: "GetUserList" },
        success: function (data) {
            PositionDataToTable(data);
        },
        error: function (e) {
            alert(e);
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}

//加载人员
function PositionDataToTable(oLists) {
    var leadershipStr = ""; //大队领导
    var departmentStr = ""; //部门领导
    var policeStr = ""; //警察
    var helpPoliceStr = ""; //协警
    var user = "";
    for (var j = 0; j < oLists.user.length; j++) {
        user = oLists.user[j];
        if (user.Position == "大队领导") {
            if (user.IsOpen == true) {
                leadershipStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="leadership_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsLeadershipSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                leadershipStr += '<span class="tableSpan"><input type="checkBox"  name="leadership_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsLeadershipSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Leadership").html(leadershipStr);
        }
        else if (user.Position == "部门领导") {
            if (user.IsOpen == true) {
                departmentStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="department_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsDepartmentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                departmentStr += '<span class="tableSpan"><input type="checkBox"  name="department_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsDepartmentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Department").html(departmentStr);
        }
        else if (user.Position == "民警") {
            if (user.IsOpen == true) {
                policeStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="police_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                policeStr += '<span class="tableSpan"><input type="checkBox"  name="police_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Police").html(policeStr);
        }
        else if (user.Position == "协警") {
            if (user.IsOpen == true) {
                helpPoliceStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="helpPolice_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsHelpPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                helpPoliceStr += '<span class="tableSpan"><input type="checkBox"  name="helpPolice_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsHelpPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_HelpPolice").html(helpPoliceStr);
        }
    }
    IsLeadershipSelected();
    IsDepartmentSelected();
    IsPoliceSelected();
    IsHelpPoliceSelected();
    var corpsStr = ""; //大队部
    var accidentStr = ""; //事故中队
    var monitoringCenterStr = ""; //监控中心
    var officeStr = ""; //办公室
    var vehicleStr = ""; //车管所
    var dengguanStr = ""; //邓关中队
    var secondStr = ""; //二中队
    var xianshiStr = ""; //仙市中队
    var yantanStr = ""; //沿滩中队
    var newUserStr = ""; //新进人员
    var otherStr = ""; //其他
    var user = "";
    for (var j = 0; j < oLists.user.length; j++) {
        user = oLists.user[j];
        if (user.Department == "大队部") {
            if (user.IsOpen == true) {
                corpsStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="corps_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsCorpsSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                corpsStr += '<span class="tableSpan"><input type="checkBox"  name="corps_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsCorpsSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Corps").html(corpsStr);
        }
        else if (user.Department == "事故中队") {
            if (user.IsOpen == true) {
                accidentStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="accident_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsAccidentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                accidentStr += '<span class="tableSpan"><input type="checkBox"  name="accident_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsAccidentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Accident").html(accidentStr);
        }
        else if (user.Department == "监控中心") {
            if (user.IsOpen == true) {
                monitoringCenterStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="monitoringCenter_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsMonitoringCenterSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                monitoringCenterStr += '<span class="tableSpan"><input type="checkBox"  name="monitoringCenter_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsMonitoringCenterSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_MonitoringCenter").html(monitoringCenterStr);
        }
        else if (user.Department == "办公室") {
            if (user.IsOpen == true) {
                officeStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="office_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsOfficeSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                officeStr += '<span class="tableSpan"><input type="checkBox"  name="office_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsOfficeSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Office").html(officeStr);
        }
        else if (user.Department == "车管所") {
            if (user.IsOpen == true) {
                vehicleStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="vehicle_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsVehicleSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                vehicleStr += '<span class="tableSpan"><input type="checkBox"  name="vehicle_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsVehicleSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Vehicle").html(vehicleStr);
        }
        else if (user.Department == "邓关中队") {
            if (user.IsOpen == true) {
                dengguanStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="dengguan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsDengguanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                dengguanStr += '<span class="tableSpan"><input type="checkBox"  name="dengguan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsDengguanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Dengguan").html(dengguanStr);
        }
        else if (user.Department == "二中队") {
            if (user.IsOpen == true) {
                secondStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="second_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsSecondSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                secondStr += '<span class="tableSpan"><input type="checkBox"  name="second_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsSecondSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Second").html(secondStr);
        }
        else if (user.Department == "仙市中队") {
            if (user.IsOpen == true) {
                xianshiStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="xianshi_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsXianshiSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                xianshiStr += '<span class="tableSpan"><input type="checkBox"  name="xianshi_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsXianshiSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Xianshi").html(xianshiStr);
        }
        else if (user.Department == "沿滩中队") {
            if (user.IsOpen == true) {
                yantanStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="yantan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsYantanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                yantanStr += '<span class="tableSpan"><input type="checkBox"  name="yantan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsYantanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Yantan").html(yantanStr);
        }
        else if (user.Department == "新进人员") {
            if (user.IsOpen == true) {
                newUserStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="newUser_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsNewUserSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                newUserStr += '<span class="tableSpan"><input type="checkBox"  name="newUser_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsNewUserSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_NewUser").html(newUserStr);
        }
        else if (user.Department == "其他") {
            if (user.IsOpen == true) {
                otherStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="other_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsOtherSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else {
                otherStr += '<span class="tableSpan"><input type="checkBox"  name="other_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsOtherSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Other").html(otherStr);
        }
    }
    IsCorpsSelected();
    IsAccidentSelected();
    IsMonitoringCenterSelected();
    IsOfficeSelected();
    IsVehicleSelected();
    IsDengguanSelected();
    IsSecondSelected();
    IsXianshiSelected();
    IsYantanSelected();
    IsNewUserSelected();
    IsOtherSelected();
}

/*大队领导*/
function IsLeadershipSelected() {
    var chbs = $("#div_Leadership").find("input[name='leadership_Role']:checked");
    if (chbs.length > 0) {
        $("#chkLeadership").attr("checked", true);
        $("#div_Leadership").css("display", "");
    }
    else {
        $("#chkLeadership").attr("checked", false);
        $("#div_Leadership").css("display", "none");
    }
}

/*部门领导*/
function IsDepartmentSelected() {
    var chbs = $("#div_Department").find("input[name='department_Role']:checked");
    if (chbs.length > 0) {
        $("#chkDepartment").attr("checked", true);
        $("#div_Department").css("display", "");
    }
    else {
        $("#chkDepartment").attr("checked", false);
        $("#div_Department").css("display", "none");
    }
}
/*民警*/
function IsPoliceSelected() {
    var chbs = $("#div_Police").find("input[name='police_Role']:checked");
    if (chbs.length > 0) {
        $("#chkPolice").attr("checked", true);
        $("#div_Police").css("display", "");
    }
    else {
        $("#chkPolice").attr("checked", false);
        $("#div_Police").css("display", "none");
    }
}
/*协警*/
function IsHelpPoliceSelected() {
    var chbs = $("#div_HelpPolice").find("input[name='helpPolice_Role']:checked");
    if (chbs.length > 0) {
        $("#chkHelpPolice").attr("checked", true);
        $("#div_HelpPolice").css("display", "");
    }
    else {
        $("#chkHelpPolice").attr("checked", false);
        $("#div_HelpPolice").css("display", "none");
    }
}
/*大队部*/
function CheckCorps() {
    if ($("#chkCorps").attr("checked")) {
        $("#div_Corps").css("display", "");
        $("input[name='corps_Role']").attr("checked", true);
    }
    else {
        $("#div_Corps").css("display", "none");
        $("input[name='corps_Role']").attr("checked", false);
    }
}
/*事故中队*/
function CheckAccident() {
    if ($("#chkAccident").attr("checked")) {
        $("#div_Accident").css("display", "");
        $("input[name='accident_Role']").attr("checked", true);
    }
    else {
        $("#div_Accident").css("display", "none");
        $("input[name='accident_Role']").attr("checked", false);
    }
}
//监控中心
function CheckMonitoringCenter() {
    if ($("#chkMonitoringCenter").attr("checked")) {
        $("#div_MonitoringCenter").css("display", "");
        $("input[name='monitoringCenter_Role']").attr("checked", true);
    }
    else {
        $("#div_MonitoringCenter").css("display", "none");
        $("input[name='monitoringCenter_Role']").attr("checked", false);
    }
}
//办公室
function CheckOffice() {
    if ($("#chkOffice").attr("checked")) {
        $("#div_Office").css("display", "");
        $("input[name='office_Role']").attr("checked", true);
    }
    else {
        $("#div_Office").css("display", "none");
        $("input[name='office_Role']").attr("checked", false);
    }
}
//车管所
function CheckVehicle() {
    if ($("#chkVehicle").attr("checked")) {
        $("#div_Vehicle").css("display", "");
        $("input[name='vehicle_Role']").attr("checked", true);
    }
    else {
        $("#div_Vehicle").css("display", "none");
        $("input[name='vehicle_Role']").attr("checked", false);
    }
}
//邓关中队
function CheckDengguan() {
    if ($("#chkDengguan").attr("checked")) {
        $("#div_Dengguan").css("display", "");
        $("input[name='dengguan_Role']").attr("checked", true);
    }
    else {
        $("#div_Dengguan").css("display", "none");
        $("input[name='dengguan_Role']").attr("checked", false);
    }
}
//二中队
function CheckSecond() {
    if ($("#chkSecond").attr("checked")) {
        $("#div_Second").css("display", "");
        $("input[name='second_Role']").attr("checked", true);
    }
    else {
        $("#div_Second").css("display", "none");
        $("input[name='second_Role']").attr("checked", false);
    }
}
//仙市中队
function CheckXianshi() {
    if ($("#chkXianshi").attr("checked")) {
        $("#div_Xianshi").css("display", "");
        $("input[name='xianshi_Role']").attr("checked", true);
    }
    else {
        $("#div_Xianshi").css("display", "none");
        $("input[name='xianshi_Role']").attr("checked", false);
    }
}
//沿滩中队
function CheckYantan() {
    if ($("#chkYantan").attr("checked")) {
        $("#div_Yantan").css("display", "");
        $("input[name='yantan_Role']").attr("checked", true);
    }
    else {
        $("#div_Yantan").css("display", "none");
        $("input[name='yantan_Role']").attr("checked", false);
    }
}
//新进人员
function CheckNewUser() {
    if ($("#chkNewUser").attr("checked")) {
        $("#div_NewUser").css("display", "");
        $("input[name='newUser_Role']").attr("checked", true);
    }
    else {
        $("#div_NewUser").css("display", "none");
        $("input[name='newUser_Role']").attr("checked", false);
    }
}
//其他
function CheckOther() {
    if ($("#chkOther").attr("checked")) {
        $("#div_Other").css("display", "");
        $("input[name='other_Role']").attr("checked", true);
    }
    else {
        $("#div_Other").css("display", "none");
        $("input[name='other_Role']").attr("checked", false);
    }
}
//设置参加考试的人员
function SetUserState() 
{
         var loginNames = "";
         var tableName = "Paper";
         if ($('#selectPos').attr("checked")) 
         {
             var chbs_leadership = $("#div_Leadership").find("input[name='leadership_Role']:checked");
             var chbs_department = $("#div_Department").find("input[name='department_Role']:checked"); //部门领导
             var chbs_police = $("#div_Police").find("input[name='police_Role']:checked"); //民警
             var chbs_helpPolice = $("#div_HelpPolice").find("input[name='helpPolice_Role']:checked"); //协警
             if (chbs_leadership.length > 0) {
                 for (var i = 0; i < chbs_leadership.length; i++) {
                     loginNames += chbs_leadership[i].value + ',';
                 }
             }
             if (chbs_department.length > 0) {
                 for (var j = 0; j < chbs_department.length; j++) {
                     loginNames += chbs_department[j].value + ',';
                 }
             }
             if (chbs_police.length > 0) {
                 for (var k = 0; k < chbs_police.length; k++) {
                     loginNames += chbs_police[k].value + ',';
                 }
             }
             if (chbs_helpPolice.length > 0) {
                 for (var k = 0; k < chbs_helpPolice.length; k++) {
                     loginNames += chbs_helpPolice[k].value + ',';
                 }
             }
         }
         else if ($('#selectDpt').attr("checked")) 
         {
             var chbs_Corps = $("#div_Corps").find("input[name='corps_Role']:checked"); //大队部选中项目
             var chbs_Accident = $("#div_Accident").find("input[name='accident_Role']:checked"); //事故中队选中项目
             var chbs_MonitoringCenter = $("#div_MonitoringCenter").find("input[name='monitoringCenter_Role']:checked"); //监控中心选中项目
             var chbs_Office = $("#div_Office").find("input[name='office_Role']:checked"); //办公室选中项目
             var chbs_Vehicle = $("#div_Vehicle").find("input[name='vehicle_Role']:checked"); //车管所选中项目
             var chbs_Dengguan = $("#div_Dengguan").find("input[name='dengguan_Role']:checked"); //邓关中队选中项目
             var chbs_Second = $("#div_Second").find("input[name='second_Role']:checked"); //二中队选中项目
             var chbs_Xianshi = $("#div_Xianshi").find("input[name='xianshi_Role']:checked"); //仙市中队选中项目
             var chbs_Yantan = $("#div_Yantan").find("input[name='yantan_Role']:checked"); //沿滩中队选中项目
             var chbs_newUser = $("#div_NewUser").find("input[name='newUser_Role']:checked"); //新进人员选中项目
             var chbs_Other = $("#div_Other").find("input[name='other_Role']:checked"); //其他人员选中项目
             if (chbs_Corps.length > 0) {
                 for (var i = 0; i < chbs_Corps.length; i++) {
                     loginNames += chbs_Corps[i].value + ',';
                 }
             }
             if (chbs_Accident.length > 0) {
                 for (var j = 0; j < chbs_Accident.length; j++) {
                     loginNames += chbs_Accident[j].value + ',';
                 }
             }
             if (chbs_MonitoringCenter.length > 0) {
                 for (var k = 0; k < chbs_MonitoringCenter.length; k++) {
                     loginNames += chbs_MonitoringCenter[k].value + ',';
                 }
             }
             if (chbs_Office.length > 0) {
                 for (var m = 0; m < chbs_Office.length; m++) {
                     loginNames += chbs_Office[m].value + ',';
                 }
             }
             if (chbs_Vehicle.length > 0) {
                 for (var n = 0; n < chbs_Vehicle.length; n++) {
                     loginNames += chbs_Vehicle[n].value + ',';
                 }
             }
             if (chbs_Dengguan.length > 0) {
                 for (var o = 0; o < chbs_Dengguan.length; o++) {
                     loginNames += chbs_Dengguan[o].value + ',';
                 }
             }
             if (chbs_Second.length > 0) {
                 for (var p = 0; p < chbs_Second.length; p++) {
                     loginNames += chbs_Second[p].value + ',';
                 }
             }
             if (chbs_Xianshi.length > 0) {
                 for (var q = 0; q < chbs_Xianshi.length; q++) {
                     loginNames += chbs_Xianshi[q].value + ',';
                 }
             }
             if (chbs_Yantan.length > 0) {
                 for (var t = 0; t < chbs_Yantan.length; t++) {
                     loginNames += chbs_Yantan[t].value + ',';
                 }
             }
             if (chbs_newUser.length > 0) {
                 for (var w = 0; w < chbs_newUser.length; w++) {
                     loginNames += chbs_newUser[w].value + ',';
                 }
             }
             if (chbs_Other.length > 0) {
                 for (var g = 0; g < chbs_Other.length; g++) {
                     loginNames += chbs_Other[g].value + ',';
                 }
             }
         }
    /*去掉最后一个逗号*/
    loginNames = loginNames.substring(0, loginNames.length - 1);
    $.ajax({ global: true, url: "SetUserRequest.aspx", data: { ActionName: "SetUserState", LoginNames: loginNames, TableName: tableName },
        beforeSend: function () {
            $.blockUI({
                css: { border: '1px solid #000', width: '25%', left: '45%' },
                overlayCSS: { backgroundColor: '#fff', opacity: 0 },
                message: '<img src="/Images/wait.gif" /><br />正在为设置的考试人员分配考题，请稍候...'
            });
        },
        success: function (data) {
            $.unblockUI(); //IE7已上解决锁定方法
            if (data == "false") {
                alert('考试设置失败!');
            }
            else {
                alert('考试设置成功!');
            }
        },
        error: function (e) {
            alert(e);
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}
//计算考试结束时间(已作废)
function CountEndTime(start) {
    var time = $("#endtime").val();
    var n1 = start.indexOf('-'); //从前往后获取第一个"-"符号的位置
    var n2 = start.lastIndexOf('-'); //从后往后获取第二个"-"符号的位置
    var n3 = start.indexOf(' '); //截取空格字符的位置 （2013-9-1 12:23）
    var n4 = start.indexOf(':'); //截取分号字符的位置
    var year1 = start.substring(0, n1);//年份
    var month1 = start.substring(n1 + 1, n2); //月份
    var day1 = start.substring(n2 + 1, n3); //天数
    var hour1 = start.substring(n3 + 1, n4); //小时
    var minute1 = start.substring(n4 + 1);  //分钟
    var minute2 = parseInt(minute1) + parseInt(time);
    var hour2 = 0;
    if(minute2 > 60) 
    {
        minute2 = minute2 % 60;
        hour2 = parseInt(hour1) + 1;
    }
    var end = year1 + "-" + month1 + "-" + day1 + " " + hour2.toString() + ":" + minute2.toString();
    return end;

}
/*大队部选中*/
function IsCorpsSelected() {
    var chbs = $("#div_Corps").find("input[name='corps_Role']:checked"); //大队部选中项目
    if (chbs.length > 0) {
        $("#chkCorps").attr("checked", true);
        $("#div_Corps").css("display", "");
    }
    else {
        $("#chkCorps").attr("checked", false);
        $("#div_Corps").css("display", "none");
    }
}
/*事故中队选中*/
function IsAccidentSelected() {
    var chbs = $("#div_Accident").find("input[name='accident_Role']:checked"); //事故中队选中项目
    if (chbs.length > 0) {
        $("#chkAccident").attr("checked", true);
        $("#div_Accident").css("display", "");
    }
    else {
        $("#chkAccident").attr("checked", false);
        $("#div_Accident").css("display", "none");
    }
}
//监控中心选中
function IsMonitoringCenterSelected() {
    var chbs = $("#div_MonitoringCenter").find("input[name='monitoringCenter_Role']:checked"); //监控中心选中项目
    if (chbs.length > 0) {
        $("#chkMonitoringCenter").attr("checked", true);
        $("#div_MonitoringCenter").css("display", "");
    }
    else {
        $("#chkMonitoringCenter").attr("checked", false);
        $("#div_MonitoringCenter").css("display", "none");
    }
}
//办公室选中
function IsOfficeSelected() {
    var chbs = $("#div_Office").find("input[name='office_Role']:checked"); //办公室选中项目
    if (chbs.length > 0) {
        $("#chkOffice").attr("checked", true);
        $("#div_Office").css("display", "");
    }
    else {
        $("#chkOffice").attr("checked", false);
        $("#div_Office").css("display", "none");
    }
}
//车管所选中
function IsVehicleSelected() {
    var chbs = $("#div_Vehicle").find("input[name='vehicle_Role']:checked"); //车管所选中项目
    if (chbs.length > 0) {
        $("#chkVehicle").attr("checked", true);
        $("#div_Vehicle").css("display", "");
    }
    else {
        $("#chkVehicle").attr("checked", false);
        $("#div_Vehicle").css("display", "none");
    }
}
//邓关中队
function IsDengguanSelected() {
    var chbs = $("#div_Dengguan").find("input[name='dengguan_Role']:checked"); //邓关中队选中项目
    if (chbs.length > 0) {
        $("#chkDengguan").attr("checked", true);
        $("#div_Dengguan").css("display", "");
    }
    else {
        $("#chkDengguan").attr("checked", false);
        $("#div_Dengguan").css("display", "none");
    }
}
//二中队选中
function IsSecondSelected() {
    var chbs = $("#div_Second").find("input[name='second_Role']:checked"); //二中队选中项目
    if (chbs.length > 0) {
        $("#chkSecond").attr("checked", true);
        $("#div_Second").css("display", "");
    }
    else {
        $("#chkSecond").attr("checked", false);
        $("#div_Second").css("display", "none");
    }
}
//仙市中队
function IsXianshiSelected() {
    var chbs = $("#div_Xianshi").find("input[name='xianshi_Role']:checked"); //仙市中队选中项目
    if (chbs.length > 0) {
        $("#chkXianshi").attr("checked", true);
        $("#div_Xianshi").css("display", "");
    }
    else {
        $("#chkXianshi").attr("checked", false);
        $("#div_Xianshi").css("display", "none");
    }
}
//沿滩中队
function IsYantanSelected() {
    var chbs = $("#div_Yantan").find("input[name='yantan_Role']:checked"); //沿滩中队选中项目
    if (chbs.length > 0) {
        $("#chkYantan").attr("checked", true);
        $("#div_Yantan").css("display", "");
    }
    else {
        $("#chkYantan").attr("checked", false);
        $("#div_Yantan").css("display", "none");
    }
}
//新进人员
function IsNewUserSelected() {
    var chbs = $("#div_NewUser").find("input[name='newUser_Role']:checked"); //沿滩中队选中项目
    if (chbs.length > 0) {
        $("#chkNewUser").attr("checked", true);
        $("#div_NewUser").css("display", "");
    }
    else {
        $("#chkNewUser").attr("checked", false);
        $("#div_NewUser").css("display", "none");
    }
}
//其他
function IsOtherSelected() {
    var chbs = $("#div_Other").find("input[name='other_Role']:checked"); //沿滩中队选中项目
    if (chbs.length > 0) {
        $("#chkOther").attr("checked", true);
        $("#div_Other").css("display", "");
    }
    else {
        $("#chkOther").attr("checked", false);
        $("#div_Other").css("display", "none");
    }
}