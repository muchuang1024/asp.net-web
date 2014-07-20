$(document).ready(function ()
{
    LoadCheckedUser();
    //大队领导
    $("#chkLeadership").click(function ()
    {
        CheckLeadership();
    })
    //部门领导
    $("#chkDepartment").click(function ()
    {
        CheckDepartment();
    })
    //民警
    $("#chkPolice").click(function ()
    {
        CheckPolice();
    })
    //协警
    $("#chkHelpPolice").click(function ()
    {
        CheckHelpPolice();
    })

    $("#SubmitUser").click(function ()
    {
        SetUserState();
    });
});
function CheckLeadership()
{
    if ($("#chkLeadership").attr("checked"))
    {
        $("#div_Leadership").css("display", "");
        $("input[name='leadership_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Leadership").css("display", "none");
        $("input[name='leadership_Role']").attr("checked", false);
    }
}
function CheckDepartment()
{
    if ($("#chkDepartment").attr("checked"))
    {
        $("#div_Department").css("display", "");
        $("input[name='department_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Department").css("display", "none");
        $("input[name='department_Role']").attr("checked", false);
    }
}
function CheckPolice()
{
    if ($("#chkPolice").attr("checked"))
    {
        $("#div_Police").css("display", "");
        $("input[name='police_Role']").attr("checked", true);
    }
    else
    {
        $("#div_Police").css("display", "none");
        $("input[name='police_Role']").attr("checked", false);
    }
}
function CheckHelpPolice()
{
    if ($("#chkHelpPolice").attr("checked"))
    {
        $("#div_HelpPolice").css("display", "");
        $("input[name='helpPolice_Role']").attr("checked", true);
    }
    else
    {
        $("#div_HelpPolice").css("display", "none");
        $("input[name='helpPolice_Role']").attr("checked", false);
    }
}

function LoadCheckedUser()
{
    $.ajax({ global: true, url: "SetUserRequest.aspx", data: { ActionName: "GetUserList" },
        success: function (data)
        {
            PositionDataToTable(data);
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

//加载人员
function PositionDataToTable(oLists)
{
    var leadershipStr = ""; //大队领导
    var departmentStr = ""; //部门领导
    var policeStr = ""; //警察
    var helpPoliceStr = ""; //协警
    var user = "";
    for (var j = 0; j < oLists.user.length; j++)
    {
        user = oLists.user[j];
        if (user.Position == "大队领导")
        {
            if (user.IsOpen == true)
            {
                leadershipStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="leadership_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsLeadershipSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                leadershipStr += '<span class="tableSpan"><input type="checkBox"  name="leadership_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsLeadershipSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Leadership").html(leadershipStr);
        }
        else if (user.Position == "部门领导")
        {
            if (user.IsOpen == true)
            {
                departmentStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="department_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsDepartmentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                departmentStr += '<span class="tableSpan"><input type="checkBox"  name="department_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsDepartmentSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Department").html(departmentStr);
        }
        else if (user.Position == "民警")
        {
            if (user.IsOpen == true)
            {
                policeStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="police_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                policeStr += '<span class="tableSpan"><input type="checkBox"  name="police_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_Police").html(policeStr);
        }
        else if (user.Position == "协警")
        {
            if (user.IsOpen == true)
            {
                helpPoliceStr += '<span class="tableSpan" ><input type="checkBox" checked="checked"   name="helpPolice_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '"  onclick="return IsHelpPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            else
            {
                helpPoliceStr += '<span class="tableSpan"><input type="checkBox"  name="helpPolice_Role" title="' + user.RealName + '" id="checkbox_' + user.UserId + '" value="' + user.LoginName + '" onclick="return IsHelpPoliceSelected()"/><label title="' + user.RealName + '" for="' + user.UserId + '" style="padding-right: 30px">' + user.RealName + '</label></span>';
            }
            $("#div_HelpPolice").html(helpPoliceStr);
        }
    }
    IsLeadershipSelected();
    IsDepartmentSelected();
    IsPoliceSelected();
    IsHelpPoliceSelected();
}

/*大队领导*/
function IsLeadershipSelected()
{
    var chbs = $("#div_Leadership").find("input[name='leadership_Role']:checked");
    if (chbs.length > 0)
    {
        $("#chkLeadership").attr("checked", true);
        $("#div_Leadership").css("display", "");
    }
    else
    {
        $("#chkLeadership").attr("checked", false);
        $("#div_Leadership").css("display", "none");
    }
}

/*部门领导*/
function IsDepartmentSelected()
{
    var chbs = $("#div_Department").find("input[name='department_Role']:checked");
    if (chbs.length > 0)
    {
        $("#chkDepartment").attr("checked", true);
        $("#div_Department").css("display", "");
    }
    else
    {
        $("#chkDepartment").attr("checked", false);
        $("#div_Department").css("display", "none");
    }
}
/*民警*/
function IsPoliceSelected()
{
    var chbs = $("#div_Police").find("input[name='police_Role']:checked");
    if (chbs.length > 0)
    {
        $("#chkPolice").attr("checked", true);
        $("#div_Police").css("display", "");
    }
    else
    {
        $("#chkPolice").attr("checked", false);
        $("#div_Police").css("display", "none");
    }
}
/*协警*/
function IsHelpPoliceSelected()
{
    var chbs = $("#div_HelpPolice").find("input[name='helpPolice_Role']:checked");
    if (chbs.length > 0)
    {
        $("#chkHelpPolice").attr("checked", true);
        $("#div_HelpPolice").css("display", "");
    }
    else
    {
        $("#chkHelpPolice").attr("checked", false);
        $("#div_HelpPolice").css("display", "none");
    }
}
//设置参加考试的人员
function SetUserState()
{
    var loginNames = "";
    var tableName = "Paper";
    var chbs_leadership = $("#div_Leadership").find("input[name='leadership_Role']:checked");
    var chbs_department = $("#div_Department").find("input[name='department_Role']:checked"); //部门领导
    var chbs_police = $("#div_Police").find("input[name='police_Role']:checked"); //民警
    var chbs_helpPolice = $("#div_HelpPolice").find("input[name='helpPolice_Role']:checked"); //协警
    if (chbs_leadership.length == 0 && chbs_department.length == 0 && chbs_police.length == 0 && chbs_helpPolice.length == 0)
    {
        alert("请对考试人员进行设置！");
        return false;
    }
    else
    {
        if (chbs_leadership.length > 0)
        {
            for (var i = 0; i < chbs_leadership.length; i++)
            {
                loginNames += chbs_leadership[i].value + ',';
            }
        }
        if (chbs_department.length > 0)
        {
            for (var j = 0; j < chbs_department.length; j++)
            {
                loginNames += chbs_department[j].value + ',';
            }
        }
        if (chbs_police.length > 0)
        {
            for (var k = 0; k < chbs_police.length; k++)
            {
                loginNames += chbs_police[k].value + ',';
            }
        }
        if (chbs_helpPolice.length > 0)
        {
            for (var k = 0; k < chbs_helpPolice.length; k++)
            {
                loginNames += chbs_helpPolice[k].value + ',';
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