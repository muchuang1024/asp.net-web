//每页显示数据数量
var pageNumber = 100;
$(document).ready(function () {
    
    //默认加载出用户所有的信息列表
     LoadPage(true, 1);
    //跳转页事件
    $("#btnSearch").click(function ()
    {
        //加载出搜索后符合条件的用户所有的信息列表
         LoadPage(true, 1);
        // SearchTitleInfo();
     })
     $("#btnConfirm").click(function ()
     {
        var strReg = /^[0-9]*$/; //匹配数字
        r = $("#txtPageNum").val().search(strReg);
        if (r == -1)
        {
            alert("请填写数字!");
            return false;
        }
        else 
        {
            pageIndex = Number($("#txtPageNum").val());
            LoadPage(false, pageIndex);
        }
     })
 });
 function LoadPage(isFristLoad, pIndex)
 {
     //逻辑判断页码是否超出范围
     if (pIndex > pageCount)
     {
         pIndex = pageCount;
     }
     if (pIndex <= 0)
     {
         pIndex = 1;
     }

     if (!isNaN(pIndex))
     {
         pageIndex = Number(pIndex);

     }
     //加载页面数据
     var title = $("#title").val();
     var subjecttype = $("#InsurerName").val();
     var subjectitem = $("#InsuranceType").val();
     $.ajax({ global: true, url: "ItemTitleRequest.aspx", data: { ActionName: "GetItemTitleList", PageIndex: pageIndex, PageSize: pageNumber, Title: title, SubjectType: subjecttype, SubjectItem: subjectitem },
         success: function (data) {
             if (pageIndex == 1) {
                 pageCount = parseInt(data.ItemTitle[0].pageCount);
                 spanRowCount = parseInt(data.ItemTitle[1].spanRowCount);
             }
             //当前总页数
             $("#lblPageCount").text(pageCount);
             $("#lblTotalCount").text(spanRowCount);
             $("#lblTotalCount").css({
                 'color': 'red'
             });
             //判断当前页设置分页的显示
             if (pIndex == 1 && pageCount <= 1) { DisabledPageBtn("All"); }
             else if (pageIndex == 1) { DisabledPageBtn("First"); }
             else if (pageIndex == 2) { DisabledPageBtn("Second"); }
             else if (pageIndex == pageCount - 1) { DisabledPageBtn("Skip"); }
             else if (pageIndex == pageCount) { DisabledPageBtn("Last"); }
             else {
                 DisabledPageBtn("");
             }
             DataToTable(data)
         },
         error: function (e) {
             alert(e);
         },
         dataType: "json",
         type: "POST",
         async: true
     });
 }
function myClick()
{
    if (confirm("你確定要刪除嗎？"))
    {
        return true;
    }
    else
    {
        return false;

    }
}
function DataToTable(oLists)
{
    $("#tableItemTitleList").html(null);
    var type;
    var str = "<tr class='AdminrightTable01title'>";
    str += "<td style='padding-left: 20px; text-align: left; width:50%'>题干</td>";
    str += "<td style='padding-left: 20px; text-align: left; width:15%'>所属分类</td>";
    str += "<td style='text-align: left; width:10%'>答案个数</td>";
    str += "<td style='text-align: left; width:10%'> 题目类型</td>";
    str += "<td style='text-align: left; width:8%'>修改</td>";
    str += "<td style='text-align: left; width:7%'>删除</td>";
    str += "</tr>";
    if (oLists.ItemTitle.length > 0) 
    {
        for (var i = 2; i < oLists.ItemTitle.length; i++) 
        {
            if (oLists.ItemTitle[i].SubjectItem == 1) 
            {
                type = "单选";
            }
            if (oLists.ItemTitle[i].SubjectItem == 2) 
            {
                type = "多选";
            }
            if (oLists.ItemTitle[i].SubjectItem == 3)
            {
                type = "判断";
            }
            str += "<tr>";
            str += '<td >' + oLists.ItemTitle[i].Title + '</td>';
            str += '<td >' + oLists.ItemTitle[i].SubjectType + '</td>';
            str += '<td >' + oLists.ItemTitle[i].ItemCount + '</td>';
            str += '<td >' + type + '</td>';
            str += '<td><a href="UpdateItemTitle.aspx?ItemTitleId=' + oLists.ItemTitle[i].TitleId + '" title="点击修改">修改</a></td>';
            str += '<td><a href="DeleteItemTitle.aspx?ItemTitleId=' + oLists.ItemTitle[i].TitleId + '" onclick="return myClick()" title="点击删除">删除</a></td>';
            str += "</tr>";
            str += " <tr><td colspan='6'><div class='Adminrightline'></div></td></tr>";
        }
        $("#tableItemTitleList").append(str);
    }
    else 
    {
        alert('信息不存在');
    }
     
}
function SearchTitleInfo() 
{
    var title = $("#title").val();
    var subjecttype = $("#InsurerName").val();
    var subjectitem = $("#InsuranceType").val();
    $.ajax({ global: true, url: "ItemTitleRequest.aspx", data: { ActionName: "SearchTitleInfo", Title: title, SubjectType: subjecttype, SubjectItem: subjectitem },
        success: function (data) 
        {
            TitleDataToTable(data);
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
function TitleDataToTable(oLists)
{

    $("#tableItemTitleList").html(null);
    $("#page").html(null);
    var str = "<tr class='AdminrightTable01title'>";
    str += "<td style='padding-left: 20px; text-align: left; width:50%'>题干</td>";
    str += "<td style='padding-left: 20px; text-align: left; width:15%'>所属分类</td>";
    str += "<td style='text-align: left; width:10%'>答案个数</td>";
    str += "<td style='text-align: left; width:10%'> 题目类型</td>";
    str += "<td style='text-align: left; width:8%'>修改</td>";
    str += "<td style='text-align: left; width:7%'>删除</td>";
    str += "</tr>";
    var type;
    for (var i = 0; i < oLists.length; i++)
    {
        var item = oLists[i];
        if (item.SubjectItem == 1)
        {
            type = "单选";
        }
        if (item.SubjectItem == 2)
        {
            type = "多选";
        }
        if (item.SubjectItem == 3)
        {
            type = "判断";
        }
        str += "<tr>";
        str += '<td >' + item.Title + '</td>';
        str += '<td >' + item.SubjectType + '</td>';
        str += '<td >' + item.ItemCount + '</td>';
        str += '<td >' + type + '</td>';
        str += '<td><a href="UpdateItemTitle.aspx?ItemTitleId=' + item.TitleId + '" title="点击修改">修改</a></td>';
        str += '<td><a href="DeleteItemTitle.aspx?ItemTitleId=' + item.TitleId + '" onclick="return myClick()" title="点击删除">删除</a></td>';
        str += "</tr>";
        str += " <tr><td colspan='6'><div class='Adminrightline'></div></td></tr>";
    }
    $("#tableItemTitleList").append(str);
}