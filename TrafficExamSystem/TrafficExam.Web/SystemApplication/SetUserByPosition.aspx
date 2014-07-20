<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetUserByPosition.aspx.cs"
    Inherits="TrafficExam.Web.SystemApplication.SetUserByPosition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置考试人员</title>
    <link href="../../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/SetUserByPosition.js" type="text/javascript"></script>
</head>
<body style="background-color: White; height: 298px;">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td valign="top" style="height: 200px">
                    <table width="100%" border="0" cellspacing="0" class="bxxqtable" id="positionlist">
                        <tr>
                            <td class="bxxqtabletitle">
                                根据职务设置考试人员
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList1">
                                    <span>
                                        <input type="checkbox" value="大队领导" name="position" id="chkLeadership" />
                                        大队领导</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Leadership" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList2">
                                    <span>
                                        <input type="checkbox" value="部门领导" name="position" id="chkDepartment" />
                                        部门领导</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Department" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList3">
                                    <span>
                                        <input type="checkbox" value="民警" name="position" id="chkPolice" />
                                        民警</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Police" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList4">
                                    <span>
                                        <input type="checkbox" value="协警" name="position" id="chkHelpPolice" />
                                        协警</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_HelpPolice" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 20px">
                            <td class='AdminrightTable01data02'>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input class="Adminrighttablebtn" type="button" id="SubmitUser" value="设定" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
