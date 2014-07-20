var ItemTitleId = getParamValue("ItemTitleId");
$(document).ready(function ()
{
    GetItemTitleInfo(ItemTitleId);
    $("#Update_ItemTitle").click(function ()
    {
        UpdateItemTitleInfo();//更新题目信息
    });
    $("#Back_ItemTitle").click(function () 
    {
        window.location.href = 'ItemTitleList.aspx' ; //返回题目列表
    });
});
/*获取参数*/
function getUrlParams()
{
    var search = window.location.search ; 
    // 写入数据字典
    var tmparray = search.substr(1,search.length).split("&");
    var paramsArray = new Array; 
    if( tmparray != null)
    {
        for(var i = 0;i<tmparray.length;i++)
        {
            var reg = /[=|^==]/;    // 用=进行拆分，但不包括==
            var set1 = tmparray[i].replace(reg,'&');
            var tmpStr2 = set1.split('&');
            var array = new Array ; 
            array[tmpStr2[0]] = tmpStr2[1] ; 
            paramsArray.push(array);
        }
    }
    // 将参数数组进行返回
    return paramsArray ;     
}

// 根据参数名称获取参数值
function getParamValue(name)
{
    var paramsArray = getUrlParams();
    if(paramsArray != null)
    {
        for(var i = 0 ; i < paramsArray.length ; i ++ )
        {
            for(var  j in paramsArray[i] )
            {
                if( j == name )
                {
                    return paramsArray[i][j] ; 
                }
            }
        }
    }
    return null ; 
}
/*加载题库*/
function GetItemTitleInfo(itemTitleId) 
{
    //ajax验证数据
    $.ajax({ global: true, url: "ItemTitleRequest.aspx", data: { ActionName: "GetItemTitleInfo", ItemTitleId: itemTitleId },
        success: function (data) {
            if (data != null) {
                ShowItemTitleInfo(data);
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
//加载题目
function  ShowItemTitleInfo(oLists) 
{
    var item = oLists[0];
    
    document.getElementById("Adminrighttabletdtitle").value= item.Title;
    document.getElementById("selectInsurerName").value = item.SubjectType;
    if (item.SubjectItem == 1) 
    {
        document.getElementById("radioInsuranceTypeA").checked = true;
    }
    if (item.SubjectItem == 2)
     {
         document.getElementById("radioInsuranceTypeB").checked = true;
    }
    if (item.SubjectItem == 3) 
    {
        document.getElementById("radioInsuranceTypeC").checked = true;
    }
    document.getElementById("select1").value = item.ItemCount;
    document.getElementById("Password1").value = item.FirstOption;
    document.getElementById("Password2").value=item.SecondOption;
    document.getElementById("Password3").value=item.ThirdOption;
    document.getElementById("Password4").value=item.FourthOption;
    document.getElementById("Password5").value=item.FifthOption;
    document.getElementById("Password6").value = item.SixthOption;
    var chbs = $("#item").find("input[name='answer']");
//   for (var i = 0; i < item.Answer.length; i++) 
//  {
        for (var j = 0; j < chbs.length; j++) 
        {
            if (item.Answer.indexOf(chbs[j].value)>=0) 
            {
                $(chbs[j]).attr("checked", true);

            }

        }

//  }
   
    var count = item.ItemCount;
    if (count == 2) 
    {
           document.getElementById("sixthanswer").style.display = 'none';
           document.getElementById("fifthanswer").style.display = 'none';
           document.getElementById("fourthanswer").style.display = 'none';
           document.getElementById("thirdanswer").style.display = 'none';
           document.getElementById("firstanswer").style.display = "";
           document.getElementById("secondanwser").style.display = "";
     }
     if (count == 3) 
     {
            document.getElementById("sixthanswer").style.display = 'none';
            document.getElementById("fifthanswer").style.display = 'none';
            document.getElementById("fourthanswer").style.display = 'none';
            document.getElementById("thirdanswer").style.display = "";
            document.getElementById("secondanwser").style.display = "";
            document.getElementById("firstanswer").style.display = "";
     }
     if (count == 4) 
     {
                document.getElementById("sixthanswer").style.display = 'none';
                document.getElementById("fifthanswer").style.display = 'none';
                document.getElementById("fourthanswer").style.display = "";
                document.getElementById("thirdanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";
                document.getElementById("firstanswer").style.display = "";
      }
      if (count == 5) 
      {
                document.getElementById("sixthanswer").style.display = 'none';
                document.getElementById("fifthanswer").style.display = "";
                document.getElementById("fourthanswer").style.display = "";
                document.getElementById("thirdanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";
                document.getElementById("firstanswer").style.display = "";
       }
       if (count == 6) 
       {
                document.getElementById("sixthanswer").style.display = "";
                document.getElementById("fifthanswer").style.display = "";
                document.getElementById("fourthanswer").style.display = "";
                document.getElementById("thirdanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";
                document.getElementById("firstanswer").style.display = "";
       }
       
}
function UpdateItemTitleInfo() 
{
   if($("#Adminrighttabletdtitle").val() == "")
   {
       alert('题目不能为空');
   }
   else 
   {
       var title;
       var Firstoption;
       var Secondoption;
       var Thirdoption;
       var Fourthoption;
       var Fifthoption;
       var Sixthoption;
       var answer="";
       var Subjecttype;
       var Itemcount;
       var Subjectitem;
       var n = 0;
       title = $("#Adminrighttabletdtitle").val();
       Firstoption = $("#Password1").val();
       Secondoption = $("#Password2").val();
       Thirdoption = $("#Password3").val();
       Fourthoption = $("#Password4").val();
       Fifthoption = $("#Password5").val();
       Sixthoption = $("#Password6").val();
       Subjecttype = $("#selectInsurerName").val();
       Itemcount = $("#select1").val();
       Subjectitem = $("input[name='group_InsuranceType']:checked").val();
       var s = document.getElementsByName('answer');
       for (var k = 0; k < Itemcount; k++) 
       {
           if (s[k].checked == true)
           {
               answer += s[k].value+',';
               n++; //选中复选框个数
           }
       }
       answer = answer.substring(0, 2 * n - 1);
       if (Subjectitem == 1 || Subjectitem == 3) 
       {
           if (n > 1) 
           {
               alert('只能选择一个答案');
               return false;
           }

       }
       $.ajax({ global: true, url: "ItemTitleRequest.aspx",
           data: { ActionName: "UpdateItemTitleInfo", TitleId: ItemTitleId, Title: title, FirstOption: Firstoption, SecondOption: Secondoption, ThirdOption: Thirdoption, FourthOption: Fourthoption, FifthOption: Fifthoption, SixthOption: Sixthoption, Answer: answer, SubjectType: Subjecttype, ItemCount: Itemcount, SubjectItem: Subjectitem },
           success: function (data) {
               if (data == true) {
                   alert('更新题目成功!');
                   document.location.reload();
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