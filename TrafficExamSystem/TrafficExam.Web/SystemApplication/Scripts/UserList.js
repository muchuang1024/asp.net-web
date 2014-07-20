$(document).ready(function ()
{
    
    LoadUserList();
    $("#btnSearch").click(function ()
    {
        SearchUserInfo(); //人员查询
    })
})

function LoadUserList()
{
    //加载页面数据
    
    $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "GetUserList" },
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
   
    var str = "";
    var userInfo = "";
    if (oLists.UserInfo.length > 0)
    {
        for (var i = 0; i < oLists.UserInfo.length; i++)
        {
            userInfo = oLists.UserInfo[i];
            str += "<tr>";
            str += '<td style="padding-left: 20px;text-align: center; line-height: 25px;background-color: #FFFFFF;">' + userInfo.RealName + '</td>';
            str += '<td style="text-align: center;">' + userInfo.Sex + '</td>';
            str += '<td style="text-align: center;">' + userInfo.PoliceCode + '</td>';
            str += '<td style="text-align: center;">' + userInfo.Position + '</td>';
            str += '<td style="text-align: center;">' + userInfo.Department + '</td>';
            str += '<td style="text-align: center;"><a  href="UpdateUserInfo.aspx?UserId=' + userInfo.UserId + '" title="点击修改">修改</a></td>';
            str += '<td style="text-align: center;"><a class="DelUserList" style="cursor:pointer" id= ' + userInfo.UserId + ' title="点击删除" >删除</a></td>';
            str += "</tr>";
            str += " <tr><td colspan='8'><div class='Adminrightline'></div></td></tr>";
        }
    }
    $("#tableUserList").append(str);
    $("a[class='DelUserList']").click(function ()
    {
        if (confirm("是否确认删除该人员信息！") == true)//这里要特别注意"!"感叹号的全区/半区区分
        {
            /*删除用户信息*/
            DeleteUserInfo($(this));
        }
    });
}
function DrawTable()
{
    /*当查询回来的数据结果为null的时候,默认给他加载12空行*/
    var str = "";
    for (var j = 0; j <= 12; j++)
    {
        str += "<tr class='AdminrightTable01data02'>";
        str += "<td colspan='8'></td>";
        str += "</tr>";
    }
    $("#tableUserList").append(str);
}

function DeleteUserInfo(otr)
{
    /*用户Id*/
    var userId = otr[0].id;
    //加载页面数据
    $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "DeleteUserInfo", UserId: userId },
        success: function (data)
        {
            if (data == true)
            {
                /*数据删除功能后,刷新页面*/
                alert("删除用户信息成功！");
                window.location.href = "../SystemApplication/UserList.aspx";
            }
        },
        dataType: "json",
        type: "POST",
        async: true
    });
}
function SearchUserInfo()
{

    var name = $("#name").val();
    var policeid = $("#policeid").val();
    var position = $("#position").val();
    var depart = $("#department").val();
    $.ajax({ global: true, url: "UserRequest.aspx", data: { ActionName: "SearchUserInfo", Name: name, PoliceId: policeid, Position: position, Depart: depart },
        success: function (data)
        {
            
            UserDataToTable(data);
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
function UserDataToTable(oLists)
{ 
    var userInfo = "";
    $("#tableUserList").html(null);
    var str = "<tr class='AdminrightTable01title'>";
    str += "<td style='text-align: center;'>姓名</td>";
    str += "<td style='text-align: center;'>性别</td>";
    str += "<td style='text-align: center'>警号</td>";
    str += "<td style='text-align: center'>职务</td>";
    str += "<td style='text-align: center'>部门</td>";
    str += "<td style='text-align: center'>修改</td>";
    str += "<td style='text-align: center;'>删除</td>";
    str += "</tr>";
    for (var i = 0; i < oLists.UserInfo.length; i++)
    {
         
        userInfo = oLists.UserInfo[i];
        str += "<tr>";
        str += '<td style="text-align: center;">' + userInfo.RealName + '</td>';
        str += '<td style="text-align: center;">' + userInfo.Sex + '</td>';
        str += '<td style="text-align: center;">' + userInfo.PoliceCode + '</td>';
        str += '<td style="text-align: center;">' + userInfo.Position + '</td>';
        str += '<td style="text-align: center;">' + userInfo.Department + '</td>';
        str += '<td style="text-align: center;"><a  href="UpdateUserInfo.aspx?UserId=' + userInfo.UserId + '" title="点击修改">修改</a></td>';
        str += '<td style="text-align: center;"><a class="DelUserList" style="cursor:pointer" id= ' + userInfo.UserId + ' title="点击删除" >删除</a></td>';
        str += "</tr>";
        str += " <tr><td colspan='8'><div class='Adminrightline'></div></td></tr>";
    }
    $("#tableUserList").append(str);
    $("a[class='DelUserList']").click(function ()
    {
        if (confirm("是否确认删除该人员信息！") == true)//这里要特别注意"!"感叹号的全区/半区区分
        {
            /*删除用户信息*/
            DeleteUserInfo($(this));
        }
    });
}