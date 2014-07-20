
var userId = getQueryStringByName("UserId");
$(document).ready(function ()
{
    LoadUserInfo();

    $("#btnUpdate").click(function ()
    {
        UpdateUserInfo();
    });
})


function LoadUserInfo()
{
    //加载页面数据
    $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "GetUserInfo", UserId: userId },
        success: function (data)
        {
            if (data == null)
            {
                /*当没有查询数据的时候,默认绘制空表*/
                DrawTable();
                //alert('没有查询数据!');
            }
            else
            {
                //将数据呈现到页面
                ShowUserInfo(data);
            }
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}
function ShowUserInfo(otr)
{
    var userInfo = otr.UserInfo[0];
    $("#txtRealName").val(userInfo.RealName);
    $("input[name='group_Sex'][value='" + (userInfo.Sex).replace(/( )/g, "") + "']").attr("checked", true); //这个设置Radio的选中
    //if (userInfo.Sex == "男")
    //{
    // document.getElementById("boy").checked = "checked";
    //}
    //if (userInfo.Sex == "女")
    //{
    //document.getElementById("girl").checked = "checked";
    // }
    $("#txtPoliceCode").val(userInfo.PoliceCode);
    $("#txtPassword").val(userInfo.LoginPassword);
    $("#txtRepeatPassword").val(userInfo.LoginPassword);
    //为select赋值
    $("#selectPosition option[value='" + userInfo.Position + "']").attr("selected", true); //设置内部option选中
    $("#selectDepartment option[value='" + userInfo.Department + "']").attr("selected", true); //设置内部option选中
}
function UpdateUserInfo()
{
    if (CheckUserInfo())
    {
        var sex = $("input[name='group_Sex']:checked").val();
        var position = $("#selectPosition option:selected").get(0).value; //获取select控件选中
        var department = $("#selectDepartment option:selected").get(0).value; //获取select控件选中
        $("#Condition").val("RealName=" + $.trim($("#txtRealName").val()) + "&Sex=" + sex + "&LoginPassword=" + $.trim($("#txtPassword").val()) + "&PoliceCode=" + $.trim($("#txtPoliceCode").val()) + "&Position=" + position + "&Department=" + department + "");
        $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "UpdateUserInfo", Condition: $("#Condition").val(), UserId: userId },
            success: function (data)
            {
                if (data == true)
                {
                    alert('修改人员信息成功!');
                    window.location.href = 'UserList.aspx';
                }
                else
                {
                    alert('修改人员信息失败!');
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
function CheckUserInfo()
{
    if ($("#txtRealName").val() == "")
    {
        alert("请输入人员姓名！");
        return false;
    }
    if ($("#txtPoliceCode").val() == "")
    {
        alert("请输入人员警号！");
        return false;
    }
    if ($("#txtPassword").val() == "")
    {
        alert("请输入密码！");
        return false;
    }
    if ($("#txtRepeatPassword").val() == "")
    {
        alert("请输入确认密码！");
        return false;
    }
    if ($.trim($("#txtPassword").val()) != $.trim($("#txtRepeatPassword").val()))
    {
        alert("两次输入的密码不一致！！");
        $("#txtPassword").val("");
        $("#txtRepeatPassword").val("");
        return false;
    }
    var position = $("#selectPosition option:selected").get(0).value; //获取select控件选中
    if (position == "请选择")
    {
        alert("请为该人员设定职务！");
        return false;
    }
    var department = $("#selectDepartment option:selected").get(0).value; //获取select控件选中
    if (department == "请选择")
    {
        alert("请为该人员设定部门！");
        return false;
    }
    return true;
}

//根据QueryString参数名称获取值 
function getQueryStringByName(name)
{
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1)
    {
        return "";
    }
    return result[1];
}