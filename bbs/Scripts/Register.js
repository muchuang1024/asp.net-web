$(document).ready(function () {

    $("#btnRegister").click(function ()
    {
        Register();
    });
    $("#btnReset").click(function ()
    {
        
    });
});
function  Register() 
{
    if (CheckUserInfo()) 
    {
        var usersex = $("input[name='sex']:checked").val();
        var username = $.trim(("#txtUser").val());
        var userpassword = $.trim(("#txtPwd").val());
        var useremail = $.trim(("#txtEmail").val());
        var userquestion = $("#txtSecure").val();
        var useranswer = $("#txtAnswer").val();
        var userintro = $("#txtIntro").val();
        var userschool = $("#txtSchool").val();
        var usertag = $("#txtTag").val();
        $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "InsertUserInfo", Sex: usersex, Name: username, Password: userpassword, Email: useremail, Question: userquestion, Answer: useranswer,Intro: userintro, School: userschool, Tag: usertag},
            success: function (data) {
                if (data == true)
                {
                    alert('注册成功!');
                    window.location.href = 'bbs_register.aspx';
                }
                else 
                {
                    alert('注册失败!');
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
}
function CheckUserInfo()
 {
     if ($("#txtUser").val() == "")
     {
        alert("请输入人员姓名！");
        return false;
    }
    if ($("#txtPwd").val() == "") 
    {
        alert("请输入密码！");
        return false;
    }
    if ($("#txtRepeatPwd").val() == "")
    {
        alert("请输入确认密码！");
        return false;
    }
    if ($.trim($("#txtPwd").val()) != $.trim($("#txtRepeatPwd").val()))
    {
        alert("两次输入的密码不一致！！");
        $("#txtPwd").val("");
        $("#txtRepeatPwd").val("");
        return false;
    }
     var email = document.getElementById("txtEmail"); //对电子邮件的验证
     var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
     if(!myreg.test(email.value))
     {
         alert('提示\n\n请输入有效的E_mail！');
         email.focus();
         return false;
     }
     return true;
}
function Reset()
{
    $("#txtUser").val() = ""
}