<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountPaperByPerson.aspx.cs"
    Inherits="TrafficExam.Web.SystemApplication.CountPaperByPerson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>按人员信息统计</title>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/skin.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/CountPaperByPerson.js" type="text/javascript"></script>
    <script src="../DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td valign="top" colspan="5">
                    <table width="100%" border="0" cellspacing="0" class="bxxqtable">
                        <tr>
                            <td class="Adminrighttitle" colspan="5" style="text-align: center">
                                人员考试信息统计
                            </td>
                        </tr>
                        <tr>
                            <td class="Adminrighttitle" style="width: 15%; text-align: right; padding-right: 10px">
                                开始日期
                            </td>
                            <td class="Adminrighttitle" style="width: 30%;">
                                <input type="text" class="Adminrighttableiput" onclick="WdatePicker()" id="txtStartDate" />
                            </td>
                            <td class="Adminrighttitle" style="width: 15%; text-align: right; padding-right: 10px">
                                结束日期
                            </td>
                            <td class="Adminrighttitle" style="width: 30%;">
                                <input type="text" class="Adminrighttableiput" onclick="WdatePicker()" id="txtEndDate" />
                            </td>
                            <td class="Adminrighttitle">
                                <input id="btnSelect" type="submit" class="Adminrighttablebtn" value="查询" />
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet" colspan="5">
                                <div class="bxxqnext" id="divEaxms" style="display: none">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="5">
                    <table width="100%" border="0" cellspacing="0" class="AdminrightTable01" id="tableCountList"
                        style="display: none">
                    </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
