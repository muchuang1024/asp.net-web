<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TrafficExam.Web.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>沿滩区交警大队警务知识考试系统</title>
    <link href="CSS/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/Index.js"></script>
    <script type="text/javascript">
        function Setvalue() {
            document.getElementById('txtUserName').value = document.getElementById('username').options[document.getElementById('username').selectedIndex].value;
            document.getElementById('txtPassword').value = "111111";//根据用户名置密码
        }
    </script>
</head>
<body>
    <form id="form2" runat="server">
    <div class="loginbox">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src="images/PicLogintop.png" width="1009" height="129" />
                </td>
            </tr>
            <tr>
                <td height="173" align="center">
                    <div class="table">
                        <form id="form1" name="form1" method="post" action="">
                        <table width="375" border="0" align="center" style="margin: 30px 0px;">
                            <tr class="trinput01">
                                <td height="60" align="right" valign="middle">
                                    <label for="textfield">
                                    </label>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tt"><tr><td align="left"> 
<!--select标签和input外面的span标签的格式是为了使两个位置在同一位置，控制位置--> 
<span style="position:absolute;border:1pt solid 
#c1c1c1;overflow:hidden;width:188px;height:19px;clip:rect(-1px 190px 190px 170px);"> 
<select name="username" id="username" style="width:190px;height:20px;margin:-2px;" 
onChange="Setvalue();"> 
<!--下面的option的样式是为了使字体为灰色，只是视觉问题，看起来像是注释一样--> 
<option value="" style="color:#c2c2c2;">---请选择---</option> 
</select> 
</span> 
<span style="position:absolute;border-top:1pt solid #c1c1c1;border-left:1pt solid #c1c1c1;border-
bottom:1pt solid #c1c1c1;width:170px;height:19px;"> 
<input type="text" name="textfield" id="txtUserName" value="" style="width:170px;height:15px;border:0pt;" runat="server"> 
</span> 

</td></tr></table> 
                                  
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" class="trinput02">
                                    <input name="textfield2" type="password" class="input" id="txtPassword" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#">
                                        <asp:ImageButton ImageUrl="~/Images/login.png" Width="375" Height="63" ID="btn_Login"
                                            runat="server" OnClick="btn_Login_Click" />
                                        <%--<img src="images/login.png" width="375" height="63" id="btn_Login" runat="server" />--%></a>
                                </td>
                            </tr>
                        </table>
                        </form>
                    </div>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
