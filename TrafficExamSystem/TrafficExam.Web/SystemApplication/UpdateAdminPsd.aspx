<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateAdminPsd.aspx.cs" Inherits="TrafficExam.Web.SystemApplication.UpdateAdminPsd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
     <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/UpdateAdminPassword.js" type="text/javascript"></script>
</head>
<body style ="background-color:white">
<div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td align="center" valign="top">
                    <table width="690" border="0" cellspacing="0" class="bxgsbox">
                        <tr>
                            <td align="center" class="bxgsboxtitle">
                               修改管理员密码
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0">
                                    <tr>
                                        <td class="Adminrighttabletdtitle">
                                            旧密码
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="txtOldPassword" class="Adminrighttableiput" type="text" maxlength="16" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="Adminrighttabletdtitle">
                                            新密码
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="txtPassword" class="Adminrighttableiput" type="password" maxlength="16" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="Adminrighttabletdtitle">
                                            重复密码
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="txtRepeatPassword" class="Adminrighttableiput" type="password" maxlength="16" />
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="Adminrightline">
                                </div>
                                <table width="100%" border="0">
                                    <tr>
                                        <td height="53" align="center">
                                           <input id="btnUpdate" type="button" class="Adminrighttablebtn"  value="修改" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
