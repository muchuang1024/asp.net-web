<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemTitleList.aspx.cs" Inherits="TrafficExam.Web.SystemApplication.ItemTitleList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>题库信息列表</title>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/page.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/page.js" type="text/javascript"></script>
    <script src="Scripts/ItemTitleList.js" type="text/javascript"></script>
    <style type="text/css">
        #title
        {
            width: 326px;
        }
    </style>
</head>
<body style="background-color: White">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td valign="top">
                    <table>
                      <tr>
                        <td style="width:40%">题干搜索：<input id="title" type="text"/></td>
                        <td style="width:25%">考点搜索：<select id="InsurerName" > 
                                                    <option value=""></option>
                                                    <option value="法律法规知识">法律法规知识</option>
                                                    <option value="执勤执法">执勤执法</option>
                                                    <option value="事故处理">事故处理</option>
                                                    <option value="车辆及驾驶人管理">车辆及驾驶人管理</option>
                                                    <option value="警纪警规">警纪警规</option>
                                                    <option value="警务技能">警务技能</option>
                                                    <option value="警察礼仪">警察礼仪</option>
                                                    <option value="办公文秘">办公文秘</option>
                                                    <option value="宣传教育">宣传教育</option>
                                                    </select>
                         </td>
                        <td style="width:15%">题目类型搜索： 
                         <select id="InsuranceType" >
                           <option value=""></option>
                          <option value="1">单选</option>
                          <option value="2">多选</option>
                          <option value="3">判断</option>
                         </select>
                         </td>
                        <td style="width:5%"><input id="btnSearch" type="button" value="搜索" /></td></tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" class="AdminrightTable01" id="tableItemTitleList">
                        <tr class="AdminrightTable01title">
                            <td style="padding-left: 20px; text-align: left; width:50%">
                                题干
                            </td>
                            <td style="padding-left: 20px; text-align: left;width:15%">
                                所属分类
                            </td>
                            <td style="text-align: left; width:10%">
                                答案个数
                            </td>
                            <td style="text-align: left; width:10%">
                                标题（题干）
                            </td>
                            <td style="text-align: left;width:8%">
                                修改
                            </td>
                            <td style="text-align: left; width:7%">
                                删除
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="page" id="page">
            <div class="clear">
            </div>
            <div class="pageUp" id="page-prev">
                &nbsp;上一页</div>
            <div id="page-up-4">
            </div>
            <div id="page-up-3">
            </div>
            <div id="page-up-2">
            </div>
            <div id="page-up-1">
            </div>
            <div id="page-cur">
            </div>
            <div id="page-down-1">
            </div>
            <div id="page-down-2">
            </div>
            <div id="page-down-3">
            </div>
            <div id="page-down-4">
            </div>
            <div class="pageSentence">
                ......</div>
            <div class="pageDown" id="page-next">
                下一页&nbsp;</div>
            <div class="totalPageNum">
                共<label id="lblPageCount"></label>页</div>
            <div class="totalPageNum">
                共<label id="lblTotalCount"></label>条</div>
            <div class="pageLeftWriting">
                第</div>
            <div class="pageSentence">
                <input type="text" id="txtPageNum" value="1" />
            </div>
            <div class="pageRightWriting">
                页</div>
            <div class="pageSentence">
                <input type="button" id="btnConfirm" value="确定" />
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</body>
</html>
