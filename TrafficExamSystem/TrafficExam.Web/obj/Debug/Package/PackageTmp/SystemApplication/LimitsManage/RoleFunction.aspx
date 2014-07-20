<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleFunction.aspx.cs" Inherits="TrafficExam.Web.SystemApplication.LimitsManage.RoleFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色权限分配管理</title>
    <link href="../../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../Scripts/RoleFunction.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" class="bxxqtable">
                        <tr>
                            <td class="bxxqtabletitle">
                                角色权限分配管理
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="roleList">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="Adminrightline">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="functionList">
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 500px">
                            <td class='AdminrightTable01data02'>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input class="Adminrighttablebtn" type="submit" id="SubmitRoleGroup" value="提交" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
