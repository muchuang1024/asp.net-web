var loginName = getQueryStringByName("LoginName");
var examId = getQueryStringByName("ExamId");

$(document).ready(function () {
   
    LoadPaperDetail();
})

function LoadPaperDetail()
{
    
      $.ajax({ global: true, url: "CountPaperRequest.aspx", data: { ActionName: "GetPersonPaperInfo", ExamId: examId, LoginName: loginName },
        success: function(data)
        {
            if (data != null)
            {
                ShowPaperInfo(data);
               
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
function ShowPaperInfo(oLists)
{
    var str = "";
    $("#showPaperDetail").html('');
    for (var i = 0; i < oLists.CountPaper.length; i++) 
    {
        var item = oLists.CountPaper[i];
        str += '<div class="div_question"><div class="div_title_question_all">';
        str += '<div id="divTitle10" class="div_title_question">' + item.Title + '</div>';
        str += '<div style="clear:both;"></div>';
        str += '</div>';
        str += '<div class="div_table_radio_question">';
	    str += '<div class="div_table_clear_top"></div>';
        if (item.ItemCount == 2) 
        {
            str += '<ul><li style="width:99%;">A.' + item.FirstOption + '</li>';
            str += '<li  style="width:99%;">B.' + item.SecondOption + '</li></ul>';
        }
        else if (item.ItemCount == 3) 
        {
            str += '<ul><li style="width:99%;">' + item.FirstOption + '</li>';
            str += '<li style="width:99%;">B.' + item.SecondOption + '</li>';
            str += '<li style="width:99%;">C.' + item.ThirdOption + '</li></ul>';
        
        }
        else if (item.ItemCount == 4) 
        {
            str += '<ul><li style="width:99%;">A.' + item.FirstOption + '</li>';
            str += '<li style="width:99%;">B.' + item.SecondOption + '</li>';
            str += '<li style="width:99%;">C.' + item.ThirdOption + '</li>';
            str += '<li style="width:99%;">D.' + item.FourthOption + '</li></ul>';
        }
        else if (item.ItemCount == 5) 
        {
            str += '<ul><li style="width:99%;">A.' + item.FirstOption + '</li>';
            str += '<li style="width:99%;">B.' + item.SecondOption + '</li>';
            str += '<li style="width:99%;">C.' + item.ThirdOption + '</li>';
            str += '<li style="width:99%;">D.' + item.FourthOption + '</li>';
            str += '<li style="width:99%;">E.' + item.FifthOption + '</li></ul>';
        }
        else if (item.ItemCount == 6) 
        {
            str += '<ul><li style="width:99%;">A.' + item.FirstOption + '</li>';
            str += '<li style="width:99%;">B.' + item.SecondOption + '</li>';
            str += '<li style="width:99%;">C.' + item.ThirdOption + '</li>';
            str += '<li style="width:99%;">D.' + item.FourthOption + '</li>';
            str += '<li style="width:99%;">E.' + item.FifthOption + '</li>';
            str += '<li style="width:99%;">F.' + item.SixthOption + '</li></ul>';
        }
        else 
        {
            str += '<div>对不起没有该选项</div>';
        }
        str += '<div style="clear:both;"></div>';
        str += '<div style="color:red; font-weight:bold">考生答案:' + item.UserAnswer + '</div>';
        str += '<div style="color:red; font-weight:bold">正确答案:' + item.Answer + '</div>';
        str += '<div class="div_table_clear_bottom"></div>';
        str += "</div></div>";
    
     }
     $("#showPaperDetail").append(str);
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

