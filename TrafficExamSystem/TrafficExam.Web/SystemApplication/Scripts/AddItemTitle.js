$(document).ready(function ()
{
    $("#btnReg").click(function ()
    {
       InsertItemTitle();
    });
});
function InsertItemTitle() 
{
   if($("#Adminrighttabletdtitle").val() == "")
   {
       alert('题目不能为空');
   }
   else 
   {
       var title;//题目
       var Firstoption;//第一个答案
       var Secondoption; //第二个答案
       var Thirdoption;//第三个答案
       var Fourthoption;//第四个答案
       var Fifthoption;//第五个答案
       var Sixthoption;//第六个答案
       var Subjecttype;//科目类型
       var Itemcount;//答案个数
       var Subjectitem; //题目类型（单选、多选、判断）
       var str = "";
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
               str += s[k].value+',';
               n++; //选中复选框个数
           }
       }
       str = str.substring(0, 2 * n - 1);
       if (Subjecttype == "") 
       {
           alert("请选择考点！");
           return false;
       }
       if (Subjectitem == 1 || Subjectitem == 3) 
       {
           if (n > 1)
           {
               alert('只能选择一个答案');
               return false;
           }
       }
       $.ajax({ global: true, url: "ItemTitleRequest.aspx",
           data: { ActionName: "InsertItemTitle", Title: title, FirstOption: Firstoption, SecondOption: Secondoption, ThirdOption: Thirdoption, FourthOption: Fourthoption, FifthOption: Fifthoption, SixthOption: Sixthoption, Answer: str, SubjectType: Subjecttype, ItemCount: Itemcount, SubjectItem: Subjectitem },
           success: function (data)
           {
               if (data == true)
               {
                   alert('新增题目成功!');
                   window.location.href = 'ItemTitleList.aspx';
               }
               else
               {
                   alert('新增题目错误!');
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