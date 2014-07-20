<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_top.aspx.cs" Inherits="admin_admin_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../Styles/txt.css" />
    <link rel="Stylesheet" type="text/css" href="css/admin.css" />
   
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image:url(./images/bg_top.jpg); height:150px">
      <table width="100%" height="150"  cellpadding="0" cellspacing="0"  style="border:1px solid #76BEF0; background-image:url(images/top.png) ; background-repeat:no-repeat">
        <tr>
          <td width="33%" rowspan="2"></td>
          <td width="6%" rowspan="2">&nbsp;</td>
          <td width="61%" height="38" align="right"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td align="center">登陆用户：
                <asp:Label ID="username" runat="server"></asp:Label>
                &nbsp;|&nbsp;</td>
              <td align="right">身份：管理员
                <asp:Button runat="server" ID="btnQuit" Text="退出登录" CssClass="button" 
                        OnClick="btnQuit_Click"/></td>
            </tr>
          </table>
          <table width="120" border="0" cellspacing="0" cellpadding="0">
              <tr> </tr>
          </table></td>
        </tr>
        <tr>
          <td align="right">&nbsp;</td>
        </tr>
      </table>
    </div>
</form>
</body>
</html>
