$(document).ready(function ()
{
    $("#btnAdd").click(function ()
    {
        InsertUser();
    });
});
function InsertUser()
{
    if (CheckUserInfo())
    {
        var sex = $("input[name='group_Sex']:checked").val();
        var position = $("#selectPosition option:selected").get(0).value; //获取select控件选中
        var department = $("#selectDepartment option:selected").get(0).value; //获取select控件选中
        $("#Condition").val("RealName=" + $.trim($("#txtRealName").val()) + "&Sex=" + sex + "&LoginPassword=" + $.trim($("#txtPassword").val()) + "&PoliceCode=" + $.trim($("#txtPoliceCode").val()) + "&Position=" + position + "&Department=" + department + "");
        $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "InsertUser", Condition: $("#Condition").val() },
            success: function (data)
            {
                if (data == true)
                {
                    alert('新增人员成功!');
                    window.location.href = 'AddUser.aspx';
                }
                else
                {
                    alert('新增人员错误!');
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