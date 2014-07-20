$(document).ready(function () {
    $("#Sub_GetSubject").click(function () {
        SetSubject();
       
    });

});
function SetSubject()
{
    var str = ""; //存放考试科目序号
    var once = document.getElementById("onceitem").value;
    var more = document.getElementById("moreitem").value;
    var deter = document.getElementById("deteritem").value;
    var one = document.getElementsByName('item');
    var intonce = 0; //单选个数
    var intmore = 0; //多选个数
    var intdeter = 0; //判断题个数
    var flag = 0;
    for (var j = 0; j < one.length; j++) {
        if (one[j].checked == true) {
            flag = flag + 1;
        }
    }
    if (flag == 0) {
        alert('请选择题目难易程度');
        return false;
    }
    //题目难度为简单
    if (document.getElementById('onceitem').checked == true) {
        intonce = 40;
        intmore = 10;
        intdeter = 40;
    }
    //题目难度为中等
    if (document.getElementById('moreitem').checked == true) {
        intonce = 35;
        intmore = 15;
        intdeter = 35;
    }
    //题目难度为困难
    if (document.getElementById('deteritem').checked == true) {
        intonce = 30;
        intmore = 20;
        intdeter = 30;
    }
    var subject = document.getElementsByName("More");
    var n = 0;
    for (var i = 0; i < subject.length; i++)
    {
        if (subject[i].checked == true)
        {
            n = n + 1;
            str = str + subject[i].value + ',';
        }

    }
    str = str.substring(0, 2 * n - 1);

    $.ajax({ global: true, url: "PraticePaperIndexRequest.aspx", data: { ActionName: "SetSubjectList", SubjectIdlist: str, OnceItem: intonce, MoreItem: intmore, DeterItem: intdeter },
        success: function (data) {
            if (data == false) {
                alert('插入科目表失败');
            }
            else {
                window.opener = null; //关闭提示
                window.top.close();
                name = window.open('./Pratice.aspx', '', 'fullscreen,resizable=yes');
                show(name);
                //  window.location.href = './Pratice.aspx';

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
function show(name) {
    try {
        name.document.focus();
        setTimeout("show(name)", 1);
    }
    catch (e) { }
}