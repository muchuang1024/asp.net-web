$(document).ready(function ()
{
    LoadCheckedUser();
    //大队部
    $("#chkCorps").click(function ()
    {
        CheckCorps();
    })
    //事故中队
    $("#chkAccident").click(function ()
    {
        CheckAccident();
    })
    //监控中心
    $("#chkMonitoringCenter").click(function ()
    {
        CheckMonitoringCenter();
    })
    //办公室
    $("#chkOffice").click(function ()
    {
        CheckOffice();
    })
    //车管所
    $("#chkVehicle").click(function ()
    {
        CheckVehicle();
    })
    //邓关中队
    $("#chkDengguan").click(function ()
    {
        CheckDengguan();
    })
    //二中队
    $("#chkSecond").click(function ()
    {
        CheckSecond();
    })
    //仙市中队
    $("#chkXianshi").click(function ()
    {
        CheckXianshi();
    })
    //沿滩中队
    $("#chkYantan").click(function ()
    {
        CheckYantan();
    })
    //新进人员
    $("#chkNewUser").click(function ()
    {
        CheckNewUser();
    })
    //其他
    $("#chkOther").click(function ()
    {
        CheckOther();
    })
    $("#SubmitUser").click(function ()
    {
        SetUserState();
    });
});
/*大队部*/
function CheckCorps()
{
    if ($("#chkCorps").attr("checked"))
    {
        $("#div_Corps").css("display", "");
        $("input[name='corps_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Corps").css("display", "none");
        $("input[name='corps_Role']").attr("checked", false);
    }
}
/*事故中队*/
function CheckAccident()
{
    if ($("#chkAccident").attr("checked"))
    {
        $("#div_Accident").css("display", "");
        $("input[name='accident_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Accident").css("display", "none");
        $("input[name='accident_Role']").attr("checked", false);
    }
}
//监控中心
function CheckMonitoringCenter()
{
    if ($("#chkMonitoringCenter").attr("checked"))
    {
        $("#div_MonitoringCenter").css("display", "");
        $("input[name='monitoringCenter_Role']").attr("checked", true);
    }
    else
    {
        $("#div_MonitoringCenter").css("display", "none");
        $("input[name='monitoringCenter_Role']").attr("checked", false);
    }
}
//办公室
function CheckOffice()
{
    if ($("#chkOffice").attr("checked"))
    {
        $("#div_Office").css("display", "");
        $("input[name='office_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Office").css("display", "none");
        $("input[name='office_Role']").attr("checked", false);
    }
}
//车管所
function CheckVehicle()
{
    if ($("#chkVehicle").attr("checked"))
    {
        $("#div_Vehicle").css("display", "");
        $("input[name='vehicle_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Vehicle").css("display", "none");
        $("input[name='vehicle_Role']").attr("checked", false);
    }
}
//邓关中队
function CheckDengguan()
{
    if ($("#chkDengguan").attr("checked"))
    {
        $("#div_Dengguan").css("display", "");
        $("input[name='dengguan_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Dengguan").css("display", "none");
        $("input[name='dengguan_Role']").attr("checked", false);
    }
}
//二中队
function CheckSecond()
{
    if ($("#chkSecond").attr("checked"))
    {
        $("#div_Second").css("display", "");
        $("input[name='second_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Second").css("display", "none");
        $("input[name='second_Role']").attr("checked", false);
    }
}
//仙市中队
function CheckXianshi()
{
    if ($("#chkXianshi").attr("checked"))
    {
        $("#div_Xianshi").css("display", "");
        $("input[name='xianshi_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Xianshi").css("display", "none");
        $("input[name='xianshi_Role']").attr("checked", false);
    }
}
//沿滩中队
function CheckYantan()
{
    if ($("#chkYantan").attr("checked"))
    {
        $("#div_Yantan").css("display", "");
        $("input[name='yantan_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Yantan").css("display", "none");
        $("input[name='yantan_Role']").attr("checked", false);
    }
}
//新进人员
function CheckNewUser()
{
    if ($("#chkNewUser").attr("checked"))
    {
        $("#div_NewUser").css("display", "");
        $("input[name='newUser_Role']").attr("checked", true);
    }
    else
    {
        $("#div_NewUser").css("display", "none");
        $("input[name='newUser_Role']").attr("checked", false);
    }
}
//其他
function CheckOther()
{
    if ($("#chkOther").attr("checked"))
    {
        $("#div_Other").css("display", "");
        $("input[name='other_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Other").css("display", "none");
        $("input[name='other_Role']").attr("checked", false);
    }
}
function LoadCheckedUser()
{
    $.ajax({ global: true, url: "SetUserRequest.aspx", data: { ActionName: "GetUserList" },
        success: function (data)
        {
            DepartmentDataToTable(data);
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
function DepartmentDataToTable(oLists)
{
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
    for (var j = 0; j < oLists.user.length; j++)
    {
        user = oLists.user[j];
        if (user.Department == "大队部")
        {
            if (user.IsOpen == true)
            {
                corpsStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="corps_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsCorpsSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                corpsStr += '<span class="tableSpan"><input type="checkBox"  name="corps_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsCorpsSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Corps").html(corpsStr);
        }
        else if (user.Department == "事故中队")
        {
            if (user.IsOpen == true)
            {
                accidentStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="accident_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsAccidentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                accidentStr += '<span class="tableSpan"><input type="checkBox"  name="accident_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsAccidentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Accident").html(accidentStr);
        }
        else if (user.Department == "监控中心")
        {
            if (user.IsOpen == true)
            {
                monitoringCenterStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="monitoringCenter_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsMonitoringCenterSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                monitoringCenterStr += '<span class="tableSpan"><input type="checkBox"  name="monitoringCenter_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsMonitoringCenterSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_MonitoringCenter").html(monitoringCenterStr);
        }
        else if (user.Department == "办公室")
        {
            if (user.IsOpen == true)
            {
                officeStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="office_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsOfficeSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                officeStr += '<span class="tableSpan"><input type="checkBox"  name="office_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsOfficeSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Office").html(officeStr);
        }
        else if (user.Department == "车管所")
        {
            if (user.IsOpen == true)
            {
                vehicleStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="vehicle_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsVehicleSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                vehicleStr += '<span class="tableSpan"><input type="checkBox"  name="vehicle_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsVehicleSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Vehicle").html(vehicleStr);
        }
        else if (user.Department == "邓关中队")
        {
            if (user.IsOpen == true)
            {
                dengguanStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="dengguan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsDengguanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                dengguanStr += '<span class="tableSpan"><input type="checkBox"  name="dengguan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsDengguanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Dengguan").html(dengguanStr);
        }
        else if (user.Department == "二中队")
        {
            if (user.IsOpen == true)
            {
                secondStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="second_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsSecondSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                secondStr += '<span class="tableSpan"><input type="checkBox"  name="second_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsSecondSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Second").html(secondStr);
        }
        else if (user.Department == "仙市中队")
        {
            if (user.IsOpen == true)
            {
                xianshiStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="xianshi_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsXianshiSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                xianshiStr += '<span class="tableSpan"><input type="checkBox"  name="xianshi_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsXianshiSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Xianshi").html(xianshiStr);
        }
        else if (user.Department == "沿滩中队")
        {
            if (user.IsOpen == true)
            {
                yantanStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="yantan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsYantanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                yantanStr += '<span class="tableSpan"><input type="checkBox"  name="yantan_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsYantanSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Yantan").html(yantanStr);
        }
        else if (user.Department == "新进人员")
        {
            if (user.IsOpen == true)
            {
                newUserStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="newUser_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsNewUserSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                newUserStr += '<span class="tableSpan"><input type="checkBox"  name="newUser_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsNewUserSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_NewUser").html(newUserStr);
        }
        else if (user.Department == "其他")
        {
            if (user.IsOpen == true)
            {
                otherStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="other_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsOtherSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
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
/*大队部选中*/
function IsCorpsSelected()
{
    var chbs = $("#div_Corps").find("input[name='corps_Role']:checked"); //大队部选中项目
    if (chbs.length > 0)
    {
        $("#chkCorps").attr("checked", true);
        $("#div_Corps").css("display", "");
    }
    else
    {
        $("#chkCorps").attr("checked", false);
        $("#div_Corps").css("display", "none");
    }
}
/*事故中队选中*/
function IsAccidentSelected()
{
    var chbs = $("#div_Accident").find("input[name='accident_Role']:checked"); //事故中队选中项目
    if (chbs.length > 0)
    {
        $("#chkAccident").attr("checked", true);
        $("#div_Accident").css("display", "");
    }
    else
    {
        $("#chkAccident").attr("checked", false);
        $("#div_Accident").css("display", "none");
    }
}
//监控中心选中
function IsMonitoringCenterSelected()
{
    var chbs = $("#div_MonitoringCenter").find("input[name='monitoringCenter_Role']:checked"); //监控中心选中项目
    if (chbs.length > 0)
    {
        $("#chkMonitoringCenter").attr("checked", true);
        $("#div_MonitoringCenter").css("display", "");
    }
    else
    {
        $("#chkMonitoringCenter").attr("checked", false);
        $("#div_MonitoringCenter").css("display", "none");
    }
}
//办公室选中
function IsOfficeSelected()
{
    var chbs = $("#div_Office").find("input[name='office_Role']:checked"); //办公室选中项目
    if (chbs.length > 0)
    {
        $("#chkOffice").attr("checked", true);
        $("#div_Office").css("display", "");
    }
    else
    {
        $("#chkOffice").attr("checked", false);
        $("#div_Office").css("display", "none");
    }
}
//车管所选中
function IsVehicleSelected()
{
    var chbs = $("#div_Vehicle").find("input[name='vehicle_Role']:checked"); //车管所选中项目
    if (chbs.length > 0)
    {
        $("#chkVehicle").attr("checked", true);
        $("#div_Vehicle").css("display", "");
    }
    else
    {
        $("#chkVehicle").attr("checked", false);
        $("#div_Vehicle").css("display", "none");
    }
}
//邓关中队
function IsDengguanSelected()
{
    var chbs = $("#div_Dengguan").find("input[name='dengguan_Role']:checked"); //邓关中队选中项目
    if (chbs.length > 0)
    {
        $("#chkDengguan").attr("checked", true);
        $("#div_Dengguan").css("display", "");
    }
    else
    {
        $("#chkDengguan").attr("checked", false);
        $("#div_Dengguan").css("display", "none");
    }
}
//二中队选中
function IsSecondSelected()
{
    var chbs = $("#div_Second").find("input[name='second_Role']:checked"); //二中队选中项目
    if (chbs.length > 0)
    {
        $("#chkSecond").attr("checked", true);
        $("#div_Second").css("display", "");
    }
    else
    {
        $("#chkSecond").attr("checked", false);
        $("#div_Second").css("display", "none");
    }
}
//仙市中队
function IsXianshiSelected()
{
    var chbs = $("#div_Xianshi").find("input[name='xianshi_Role']:checked"); //仙市中队选中项目
    if (chbs.length > 0)
    {
        $("#chkXianshi").attr("checked", true);
        $("#div_Xianshi").css("display", "");
    }
    else
    {
        $("#chkXianshi").attr("checked", false);
        $("#div_Xianshi").css("display", "none");
    }
}
//沿滩中队
function IsYantanSelected()
{
    var chbs = $("#div_Yantan").find("input[name='yantan_Role']:checked"); //沿滩中队选中项目
    if (chbs.length > 0)
    {
        $("#chkYantan").attr("checked", true);
        $("#div_Yantan").css("display", "");
    }
    else
    {
        $("#chkYantan").attr("checked", false);
        $("#div_Yantan").css("display", "none");
    }
}
//新进人员
function IsNewUserSelected()
{
    var chbs = $("#div_NewUser").find("input[name='newUser_Role']:checked"); //沿滩中队选中项目
    if (chbs.length > 0)
    {
        $("#chkNewUser").attr("checked", true);
        $("#div_NewUser").css("display", "");
    }
    else
    {
        $("#chkNewUser").attr("checked", false);
        $("#div_NewUser").css("display", "none");
    }
}
//其他
function IsOtherSelected()
{
    var chbs = $("#div_Other").find("input[name='other_Role']:checked"); //沿滩中队选中项目
    if (chbs.length > 0)
    {
        $("#chkOther").attr("checked", true);
        $("#div_Other").css("display", "");
    }
    else
    {
        $("#chkOther").attr("checked", false);
        $("#div_Other").css("display", "none");
    }
}
//设置参加考试的人员
function SetUserState()
{
    var loginNames = "";
    var tableName = "Paper";
    var n = 0;
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
    if (chbs_Corps.length == 0 && chbs_Accident.length == 0 && chbs_MonitoringCenter.length == 0 && chbs_Office.length == 0 && chbs_Vehicle.length == 0 && chbs_Dengguan.length == 0 && chbs_Second.length == 0 && chbs_Xianshi.length == 0 && chbs_newUser.length == 0 && chbs_Other.length == 0)
    {
        alert("请对考试人员进行设置！");
        return false;
    }
    else
    {
        if (chbs_Corps.length > 0)
        {
            for (var i = 0; i < chbs_Corps.length; i++)
            {
                loginNames += chbs_Corps[i].value + ',';
            }
        }
        if (chbs_Accident.length > 0)
        {
            for (var j = 0; j < chbs_Accident.length; j++)
            {
                loginNames += chbs_Accident[j].value + ',';
            }
        }
        if (chbs_MonitoringCenter.length > 0)
        {
            for (var k = 0; k < chbs_MonitoringCenter.length; k++)
            {
                loginNames += chbs_MonitoringCenter[k].value + ',';
            }
        }
        if (chbs_Office.length > 0)
        {
            for (var m = 0; m < chbs_Office.length; m++)
            {
                loginNames += chbs_Office[m].value + ',';
            }
        }
        if (chbs_Vehicle.length > 0)
        {
            for (var n = 0; n < chbs_Vehicle.length; n++)
            {
                loginNames += chbs_Vehicle[n].value + ',';
            }
        }
        if (chbs_Dengguan.length > 0)
        {
            for (var o = 0; o < chbs_Dengguan.length; o++)
            {
                loginNames += chbs_Dengguan[o].value + ',';
            }
        }
        if (chbs_Second.length > 0)
        {
            for (var p = 0; p < chbs_Second.length; p++)
            {
                loginNames += chbs_Second[p].value + ',';
            }
        }
        if (chbs_Xianshi.length > 0)
        {
            for (var q = 0; q < chbs_Xianshi.length; q++)
            {
                loginNames += chbs_Xianshi[q].value + ',';
            }
        }
        if (chbs_Yantan.length > 0)
        {
            for (var t = 0; t < chbs_Yantan.length; t++)
            {
                loginNames += chbs_Yantan[t].value + ',';
            }
        }
        if (chbs_newUser.length > 0)
        {
            for (var w = 0; w < chbs_newUser.length; w++)
            {
                loginNames += chbs_newUser[w].value + ',';
            }
        }
        if (chbs_Other.length > 0)
        {
            for (var g = 0; g < chbs_Other.length; g++)
            {
                loginNames += chbs_Other[g].value + ',';
            }
        }
    }
    /*去掉最后一个逗号*/
    loginNames = loginNames.substring(0, loginNames.length - 1);
    $.ajax({ global: true, url: "SetUserRequest.aspx", data: { ActionName: "SetUserState", LoginNames: loginNames, TableName: tableName },
        beforeSend: function ()
        {
            $.blockUI({
                css: { border: '1px solid #000', width: '25%', left: '45%' },
                overlayCSS: { backgroundColor: '#fff', opacity: 0 },
                message: '<img src="/Images/wait.gif" /><br />正在为设置的考试人员分配考题，请稍候...'
            });
        },
        success: function (data)
        {
            $.unblockUI(); //IE7已上解决锁定方法
            if (data == "false")
            {
                alert('设置考试人员失败!');
            }
            else
            {
                alert('设置考试人员成功!');
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