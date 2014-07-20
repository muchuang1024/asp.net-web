<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TrafficExam.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登陆</title>
    <link href="CSS/main.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <div class="IndexMain">
        <table width="793" border="0" cellspacing="7" class="IndexTable">
            <tr>
                <td valign="top">
                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=5,0,0,0"
                        width="657" height="340">
                        <param name="wmode" value="transparent" />
                        <param name="movie" value="Flash/flash.swf" />
                        <param name="quality" value="high" />
                        <embed wmode="transparent" src="Flash/flash.swf" quality="high" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
                            type="application/x-shockwave-flash" width="657" height="340"> </embed>
                    </object>
                    <table width="100%" border="0" cellpadding="0" cellspacing="3" style="margin-top: 5px;">
                        <tr>
                            <td height="100" align="left">
                            </td>
                            <td align="center">
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="298" valign="top" class="IndexLogin">
                    <form id="form1" name="form1" method="post" action="" runat="server">
                    <div class="IndexLoginTitle">
                        用户登录</div>
                    <table width="100%" border="0">
                        <tr>
                            <td>
                                <input name="textfield" type="text" class="IndexLoginInput" id="txtUserName" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="textfield2">
                                </label>
                                <input name="textfield2" type="password" class="IndexLoginInput" id="txtPassword"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="49" valign="bottom">
                                <input name="button" type="submit" class="IndexLoginBtn" id="btn_Login" value="登 陆"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="43">
                            </td>
                        </tr>
                        <tr>
                        </tr>
                    </table>
                    </form>
                </td>
            </tr>
            <tr style="height: 400px">
                <td colspan="2" valign="top">
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
