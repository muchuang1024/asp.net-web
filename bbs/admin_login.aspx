<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">        td img {display: block;}
body
{
	margin:0px;
}
.button{ border-style: none;
    border-color: inherit;
    border-width: medium;
    background: url('index/登录界面_r9_c7.jpg');
    font-size:14px; color:#fff; font-weight:bold;
    height:93px;
    width:36px;
    }
.txt
{
    padding-left:10px;
    padding-top:6px;    
}
</style>

</head>
<body bgcolor="#ffffff">
    <form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="1344">
<!-- fwtable fwsrc="登录界面.png" fwbase="登录界面.jpg" fwstyle="Dreamweaver" fwdocid = "1085144278" fwnested="0" -->
  <tr>
   <td><img src="index/spacer.gif" width="158" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="382" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="36" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="55" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="104" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="21" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="94" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="50" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="27" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="417" height="1" border="0" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="1" border="0" alt="" /></td>
  </tr>

  <tr>
   <td rowspan="10"><img name="n_r1_c1" src="index/登录界面_r1_c1.jpg" width="158" height="684" border="0" id="n_r1_c1" alt="" /></td>
   <td colspan="9"><img name="n_r1_c2" src="index/登录界面_r1_c2.jpg" width="1186" height="92" border="0" id="n_r1_c2" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="92" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="7"><img name="n_r2_c2" src="index/登录界面_r2_c2.jpg" width="742" height="34" border="0" id="n_r2_c2" alt="" /></td>
   <td><a href="bbs_index.aspx"><img name="n_r2_c9" src="index/登录界面_r2_c9.jpg" width="27" height="34" border="0" id="n_r2_c9" alt="" /></a></td>
   <td><img name="n_r2_c10" src="index/登录界面_r2_c10.jpg" width="417" height="34" border="0" id="n_r2_c10" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="34" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="9"><img name="n_r3_c2" src="index/登录界面_r3_c2.jpg" width="1186" height="143" border="0" id="n_r3_c2" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="143" border="0" alt="" /></td>
  </tr>
  <tr>
   <td rowspan="4" colspan="2"><img name="n_r4_c2" src="index/登录界面_r4_c2.jpg" width="418" height="97" border="0" id="n_r4_c2" alt="" /></td>
   <td colspan="2">
       <asp:TextBox ID="TextBox2" Height="21px" Width="141px" runat="server" 
           ontextchanged="TextBox2_TextChanged"></asp:TextBox>
      </td>
   <td rowspan="4" colspan="2"><img name="n_r4_c6" src="index/登录界面_r4_c6.jpg" width="115" height="97" border="0" id="n_r4_c6" alt="" /></td>
   <td rowspan="7" colspan="3"><img name="n_r4_c8" src="index/登录界面_r4_c8.jpg" width="494" height="415" border="0" id="n_r4_c8" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="37" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="2"><img name="n_r5_c4" src="index/登录界面_r5_c4.jpg" width="159" height="18" border="0" id="n_r5_c4" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="18" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="2">
       <asp:TextBox ID="TextBox1" Width="141px" Height="20px" runat="server" 
           TextMode="Password"  ></asp:TextBox>
      </td>
   <td><img src="index/spacer.gif" width="1" height="36" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="2"><img name="n_r7_c4" src="index/登录界面_r7_c4.jpg" width="159" height="6" border="0" id="n_r7_c4" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="6" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="6"><img name="n_r8_c2" src="index/登录界面_r8_c2.jpg" width="692" height="8" border="0" id="n_r8_c2" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="8" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img name="n_r9_c2" src="index/登录界面_r9_c2.jpg" width="382" height="37" border="0" id="n_r9_c2" alt="" /></td>
   <td colspan="2">
       <asp:ImageButton ID="ImageButton1" Width="91px" Height="33px"   ImageUrl="~/CreatImage.aspx" runat="server" />
      </td>
   <td colspan="2" style="background-image: url('index/登录界面_r9_c5.jpg')">
       <asp:TextBox ID="TextBox3" runat="server" Height="21px" 
           style="margin-left: 6px" Width="102px" 
           ontextchanged="TextBox3_TextChanged"></asp:TextBox>
      </td>
   <td>
       <asp:Button ID="Button1" runat="server" Height="37"  CssClass="button"  Width="94" onclick="Button1_Click" />
      </td>
   <td><img src="index/spacer.gif" width="1" height="37" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="5"><img name="n_r10_c2" src="index/登录界面_r10_c2.jpg" width="598" height="273" border="0" id="n_r10_c2" alt="" /></td>
   <td><img name="n_r10_c7" src="index/登录界面_r10_c7.jpg" width="94" height="273" border="0" id="n_r10_c7" alt="" /></td>
   <td><img src="index/spacer.gif" width="1" height="273" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="10" background="index/floorbg.jpg"><div style="padding:auto; text-align:center"> Copyright©2013-2014 SiChuang University of Science All Rights Reserved.&nbsp;<a href="bbs_index.aspx" style="text-decoration:none; font-weight:700; font-size:larger; color:#45A8DF">系统首页</a></div>&nbsp;</td>
   <td><img src="index/spacer.gif" width="1" height="73" border="0" alt="" /></td>
  </tr>
</table>
    </form>
</body>
</html>