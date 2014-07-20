<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperIndex.aspx.cs" Inherits="TrafficExam.Web.UserApplication.PaperIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>考题页面</title>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/PaperIndex.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div>
        <div class="AdminMain">
            <table border="0" cellspacing="7" class="AdminTable">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" class="bxxqtable">
                            <tr>
                                <td class="bxxqtabletitle">
                                    <span>【<label id="lblTitleId"></label>】</span>
                                    <label id="lblTitle">
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="bxxqnext">
                                        <table width="100%" border="0" cellspacing="1" class="bxxqnexttable" id="paperInfo">
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; padding-left: 55px; width: 100%;" colspan="2">
                                    <div id="divResult" style="display: none">
                                        <table>
                                            <tr>
                                                <td>
                                                    本题结果：<label id="lblResult"></label>
                                                </td>
                                                <td>
                                                    <div id="divProperAnswer">
                                                        正确答案：<label id="lblProperAnswer"></label></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <input id="btnNext" type="submit" class="Adminrighttablebtn" value="下一题" />
                        <input id="btnPrev" type="submit" class="Adminrighttablebtn" value="上一题" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
