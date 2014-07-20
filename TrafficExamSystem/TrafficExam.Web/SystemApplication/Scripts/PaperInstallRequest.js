$(document).ready(function () 
{
    GetSubjectTypeList(); //获取已经设置好的考点
    $("#Sub_GetSubject").click(function () 
    {
        SetSubject(); //设置科目类型及考试时间
    });
});
/*加载设置的考点*/
function GetSubjectTypeList() 
{
    //ajax验证数据
     
    $.ajax({ global: true, url: "PaperInstallRequest.aspx", data: { ActionName: "GetSubjectType" },
        success: function (data) {
            if (data != null) {
                ShowSubjectTypeList(data);
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
function ShowSubjectTypeList(oLists) {
   
    var chbs = $("#topic").find("input[name='More']");
    for (var i = 0; i < oLists.length; i++) {
        
       var SubjectType = oLists[i];
       for (var j = 0; j < chbs.length; j++) 
       {
            if (SubjectType.SubjectTypeId == chbs[j].value) 
            {
                $(chbs[j]).attr("checked", true);

            }

        }
      }
}
function SetSubject()
{

    var str = "";
    var startTime;
    var endTime;
    var n = 0;
    var s = document.getElementsByName('More');
    for (var i = 0; i < s.length; i++)
    {
        if (s[i].checked == true) 
        {
         
           str += s[i].value + ',';
           n++; //选中复选框个数
        }
   }
    str = str.substring(0, 2 * n-1);
    alert(str == '' ? '你还没有选择任何内容！' : str);
    if (n == 0) 
    {
        alert("请选择科目！");
        return false;
    }
    else 
    {

        if ($("#starttime").val() != "" && $("#endtime").val() != "")
        {
            startTime = $("#starttime").val();
            endTime = $("#endtime").val();
            $.ajax({ global: true, url: "PaperInstallRequest.aspx", data: { ActionName: "SetSubjectList", SubjectIdlist: str, StartTime: startTime, EndTime: endTime },
                success: function (data) {
                    if (data == true) {
                        alert('完成考试科目设置!');
                    }
                    else 
                    {
                        alert('考试时间设置不合理');

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
        else
        {
            alert('开始答题时间和结束答题时间不能为空');
            return false;
        }
    }
}
 