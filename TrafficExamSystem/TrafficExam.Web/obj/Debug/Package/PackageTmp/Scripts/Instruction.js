var Request = new Object();
Request = GetRequest();
var type;
var name;
type = Request["type"];//操作类型
//alert(type);
$(document).ready(function () {
    LoadSubjectType(); //获取已经设置好的考点
    if (type == "Pratice") {
        document.getElementById("btnBegExam").disabled = true;
    }
    else if (type == "Exam") {
        document.getElementById("btnPratice").disabled = true;
    }

    $("#btnBegExam").click(function () {
        window.opener = null;//关闭提示
        window.top.close();
        name = window.open('../UserApplication/Exam.aspx', '', 'fullscreen,resizable=yes');
        //name = window.open('../UserApplication/Exam.aspx', 'myhomepage', 'top=0px,left=0px,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no,fullscreen=1');
        show(name);
        // window.location.href = "../UserApplication/Exam.aspx";
    })
    $("#btnPratice").click(function () {
        window.location.href = "../UserApplication/SetPratice.aspx";

    })
});
function show(name) 
{
    try {
         name.document.focus();
         setTimeout("show(name)", 1);
    }
    catch (e) { }
}
function GetRequest() 
{
   var url = location.search; //获取url中"?"符后的字串
   var theRequest = new Object();
   if (url.indexOf("?") != -1) {
      var str = url.substr(1);
      strs = str.split("&");
      for(var i = 0; i < strs.length; i ++) {
         theRequest[strs[i].split("=")[0]]=(strs[i].split("=")[1]);
      }
   }
   return theRequest;
}
function LoadSubjectType()
{
    //加载页面考点数据

    $.ajax({ global: true, url: "IntroRequest.aspx", data: { ActionName: "GetSubjectType" },
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
function ShowSubjectTypeList(oLists)
{
    var str = "";
    var SubjectTypeName = "";
    $("#info").html(null);
    for (var i = 0; i < oLists.length; i++)
    {
        var Subject = oLists[i];
        if (Subject.SubjectTypeId == 1)
        {
            SubjectTypeName = "法律法规知识";
        }
        if (Subject.SubjectTypeId == 2)
        {
            SubjectTypeName = "执勤执法";
        }
        if (Subject.SubjectTypeId == 3)
        {
            SubjectTypeName = "事故处理";
        }
        if (Subject.SubjectTypeId == 4)
        {
            SubjectTypeName = "车辆及驾驶人管理 ";
        }
        if (Subject.SubjectTypeId == 5)
        {
            SubjectTypeName = "警纪警规 ";
        }
        if (Subject.SubjectTypeId == 6)
        {
            SubjectTypeName = "警务技能";
        }
        if (Subject.SubjectTypeId == 7)
        {
            SubjectTypeName = "警察礼仪";
        }
        if (Subject.SubjectTypeId == 8)
        {
            SubjectTypeName = "办公文秘";
        }
        if (Subject.SubjectTypeId == 9)
        {
            SubjectTypeName = "宣传教育";
        }
        str += '<label style="padding-left:15px">' + SubjectTypeName + '</label>';
    }
    $("#info").append(str);
}