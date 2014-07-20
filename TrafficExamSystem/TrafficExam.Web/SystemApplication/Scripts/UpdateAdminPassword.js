
$(document).ready(function ()
{
    LoadAdminPwd();
    $("#btnUpdate").click(function ()
    {
        if (CheckPwdInfo())
        {
            UpdateAdminPassword();
        }
    });
})

function LoadAdminPwd()
{
    //加载管理员密码
    $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "GetAdminPwd" },
        success: function (data)
        {
            if (data == null)
            {
                alret("错误");
            }
            else
            {
                //将密码呈现到页面
                ShowAdminPwd(data);
            }
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}

function ShowAdminPwd(olists)
{
    var userInfo = olists.UserInfo[0];
    $("#txtOldPassword").val(userInfo.LoginPassword);

}

function CheckPwdInfo()
{
    if ($.trim($("#txtPassword").val()) != $.trim($("#txtRepeatPassword").val()))
    {
        alert("两次输入的密码不一致！！");
        $("#txtPassword").val("");
        $("#txtRepeatPassword").val("");
        return false;
    }
    else
        return true;
}
function UpdateAdminPassword()
{
    var pwd = "";
    pwd = $.trim($("#txtPassword").val());
      $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "UpdateAdminPassword", Password: pwd },
            success: function (data)
            {
                if (data == true)
                {
                    alert('修改管理员密码成功!');
                    window.location.href = 'UpdateAdminPsd.aspx';
                
                }
                else
                {
                      alert('修改密码失败!');
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
  