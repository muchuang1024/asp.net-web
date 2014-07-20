$(document).ready(function ()
{
    ShowGroupList();
    $("#SubmitRoleGroup").click(function ()
    {
        SaveRoleGroup();
    });
});
//加载权限分组列表
function ShowGroupList()
{
    $.ajax({ global: true, url: "RoleFunctionRequest.aspx", data: { ActionName: "GetGroupList" },
        success: function (data)
        {
            if (data == null)
            {
                alert('没有查询数据!');
            }
            else
            {
                GroupDataToTable(data);
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
//点击分组实现勾选
function GroupDataToTable(oLists)
{
    var str = '';
    for (var i = 0; i < oLists.length; i++)
    {
        var item = oLists[i];
        str += '<span ><input type="radio" onclick="CheckRadion()"  name="Group_Role" title="' + item.GroupName + '" id="Radio_' + item.GroupId + '" value="' + item.GroupId + '"/><label title="' + item.GroupName + '" for="' + item.GroupId + '">' + item.GroupName + '</label></span>';
    }
    $("#roleList").html(str);
}
//Radio点击事件
function CheckRadion()
{
    var groupId = $("input[name='Group_Role']:checked").attr("value"); //这个方法是可以取Radio的选中

    $.ajax({ global: true, url: "RoleFunctionRequest.aspx", data: { ActionName: "GetFunctionList", Group_Id: groupId },
        success: function (data)
        {
            if (data == null)
            {
                alert('没有查询数据!');
            }
            else
            {
                FunctionDataToTable(data);
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
//绑定角色所对应的功能名称
function FunctionDataToTable(oLists)
{
    var str = '';
    var isExits = false;

    for (var i = 0; i < oLists.FunctionList.length; i++)
    {
        var item = oLists.FunctionList[i];
        var isExits = false;
        for (var j = oLists.FunctionListByGroupId.length - 1; j >= 0; j--)
        {
            var roleItem = oLists.FunctionListByGroupId[j];
            //查询出所有的功能,如果SystemFunction中功能的FunctionId与SystemRelation中的FunctionId相等
            //则证明该功能已经被该角色拥有,所以checkBox中checked状态为选中
            if (item.FunctionId == roleItem.FunctionId)
            {
                //这里的Lable很经典,当for里面的值唯一可以实现点击的选中
                str += '<span class="tableSpan"><input type="checkBox" checked="checked"   name="Function_Role" title="' + item.FunctionName + '" id="Radio_' + item.FunctionId + '" value="' + item.FunctionId + '"/><label title="' + item.FunctionName + '" for="' + item.FunctionId + '">' + item.FunctionName + '</label></span>';
                isExits = true;
                break;
            }
        }
        if (!isExits)
        {
            str += '<span class="tableSpan"><input type="checkBox"  name="Function_Role" title="' + item.FunctionName + '" id="Radio_' + item.FunctionId + '" value="' + item.FunctionId + '"/><label title="' + item.FunctionName + '" for="' + item.FunctionId + '">' + item.FunctionName + '</label></span>';
        }
    }
    $("#functionList").html(str);
}
//保存点击事件
function SaveRoleGroup()
{

    var roleSelected = $("input[name='Group_Role']:checked").attr("value"); //这个方法是可以取Radio的选中
    var functionIdselected = new Array();
    var chbs = $("#functionList").find("input[name='Function_Role']:checked");
    if (chbs.length == 0)
    {
        alert("请至少为角色分配一个功能！");
        return false;
    }
    else
    {
        for (var i = 0; i < chbs.length; i++)
        {
            //将所有的被选中项的value值写入数组里面
            functionIdselected[i] = $(chbs[i]).attr("value");
        }
    }
    //这里只是传递了数组,其他参数需要自己写
    $.ajax({ global: true, url: "RoleFunctionRequest.aspx", data: { ActionName: "SaveRoleGroup", "SelectedRoleGroup[]": functionIdselected, "RoleSelected": roleSelected },
        success: function (data)
        {
            if (data == "false")
            {
                alert('为角色分配权限失败!');
            }
            else
            {
                alert('为角色分配权限成功!');
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