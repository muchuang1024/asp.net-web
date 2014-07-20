<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="bbs_register.aspx.cs" Inherits="html_bbs_register" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="./Styles/HTMLPage.css" rel="stylesheet" type="text/css"/>
        <link href="./Styles/Bbs.css" rel="stylesheet" type="text/css"/>
        <link href="./Styles/txt.css" rel="Stylesheet" type="text/css" />
        <script type="text/javascript" src="./Scripts/jquery.js"></script>
        <script type="text/javascript">
             function CheckUserInfo()
             {
              
                if($("#txtUser").val() == "")
                 {
                    alert("请输入人员姓名！");
                    return false;
                }
                if (/.*[\u4e00-\u9fa5]+.*$/.test( $("#txtUser").val())) 
                {
                    alert("用户名不能含有汉字！");
                    return false;
                }
                if ($("#txtPwd").val() == "") {
                    alert("请输入密码！");
                    return false;
                }
                if ($("#txtRepeatPwd").val() == "") {
                    alert("请输入确认密码！");
                    return false;
                }
                if ($.trim($("#txtPwd").val()) != $.trim($("#txtRepeatPwd").val())) {
                    alert("两次输入的密码不一致！！");
                    $("#txtPwd").val("");
                    $("#txtRepeatPwd").val("");
                    return false;
                }
                var email = document.getElementById("txtEmail"); //对电子邮件的验证
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                if (!myreg.test(email.value)) 
                {
                    alert('提示\n\n请输入有效的E_mail！');
                    email.focus();
                    return false;
                }
                if ($("#txtSecure").val() == "")
                 {
                    alert("请输入密保问题！");
                    return false;
                }
                if ($("#txtAnswer").val() == "")
                 {
                    alert("请设置密保答案！");
                    return false;
                }
                return true;
            }
        
        </script>
   <style type="text/css">
    #mytable { 
    width: 800px; 
    padding: 0; 
    margin-left:auto;
    margin-right:auto;
        height: 398px;
    } 

caption { 
    padding: 0 0 5px 0; 
    width: 700px;      
    font: italic 11px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif; 
    text-align: right; 
} 

th { 
    font: bold 11px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif; 
    color: #4f6b72; 
    border-right: 1px solid #C1DAD7; 
    border-bottom: 1px solid #C1DAD7; 
    border-top: 1px solid #C1DAD7; 
    letter-spacing: 2px; 
    text-transform: uppercase; 
    text-align: left; 
    padding: 6px 6px 6px 12px; 
    background: #CAE8EA url(images/bg_header.jpg) no-repeat; 
} 

th.nobg { 
    border-top: 0; 
    border-left: 0; 
    border-right: 1px solid #C1DAD7; 
    background: none; 
} 


td.alt { 
    background: #F5FAFA; 
    color: #797268; 
} 

th.spec { 
    border-left: 1px solid #C1DAD7; 
    border-top: 0; 
    background: #fff url(images/bullet1.gif) no-repeat; 
    font: bold 10px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif; 
} 

th.specalt { 
    border-left: 1px solid #C1DAD7; 
    border-top: 0; 
    background: #f5fafa url(images/bullet2.gif) no-repeat; 
    font: bold 10px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif; 
    color: #797268; 
} 
/*---------for IE 5.x bug*/ 
        a:link, a:active, a:visited
         {
	         color: blue;
	         text-decoration: none;
        }
        a:hover 
        {
	        color: #4455aa;
	        text-decoration: underline;
        }


    .style1
    {
        width: 150px;
        text-align:right;
        
    }


    </style>
    
    <style type="text/css">
        #form1
        {
            margin-top: 0px;
        }
        .mianmainstyle1
        {
            height: 219px;
        }
        .mianstyle2
        {
            width: 75px;
        }
        .mianstyle3
        {
            height: 219px;
            width: 75px;
        }
        .mainstyle1
        {
            width: 609px;
        }
        .style21
        {
            height: 219px;
            width: 461px;
        }
        .style31
        {
            width: 461px;
        }	 
    </style>
   
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="contnet"  class="contnet" style="" >
    <div id="bbs_logo"  style="background-image: url('./images/title(4).jpg'); height:326px">
             
        <table style="width:100%; height: 302px;" border="0" cellpadding="0" 
            cellspacing="0">
            <tr>
                <td class="mianstyle2">
                    &nbsp;
                </td>
                <td class="style31">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="mianstyle3">
                    &nbsp;
                </td>
                <td class="style21">
                    &nbsp;
                </td>
                <td class="mianmainstyle1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="mainstyle2">
                    &nbsp;
                </td>
                <td class="style31">
                   <a href="bbs_index.aspx" style="text-decoration:none; font-weight:700; font-size:larger;margin-top:10px">返回首页</a></td>
                <td>
                    &nbsp;
                   <div id="login" style="width:326px">
        <div id="login_state">
        <%if (Request.Cookies["user_info"] == null)
  { %>
    <div >
    欢饮来到理工E平台方&nbsp; 你还没有登陆点击<a href="./bbs_login.aspx">登陆</a>&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="./bbs_register.aspx">注册</asp:HyperLink>
        <br/>

    </div>
<%}
  else
  { %>
  <div id="Div1" >
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      亲！欢迎你:<%Response.Write( Request.Cookies["user_info"].Value.ToString());%>
      <a href="./bbs_edituserinfo.aspx">个人中心</a></div>
<%} %>
        </div>
        
    
   
    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="bbs_main" class="bbs_main_css">
    <div id="bss_top" class="bbs_top_css">
    
    <div>
     <div>
        <h2>用户注册</h2>
      <div style="width:900px; height: auto;">
      <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series"> 
  <tr> 
   <th scope="col" abbr="Dual 2" class="style1">用户名：</th> 
 
  <td class="alt" style="width: 241px">
      <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
      </td> 
       <td class="alt"><font style="color:Red">*输入你的用户名(只能为字母或数字)</font></td> 
   
  
   
  </tr> 
  <tr> 
    
    <th scope="col" abbr="Dual 2" class="style1">密码：</th> 

    <td class="alt">
       <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
      </td> 
    <td class="alt"><font style="color:Red">*输入你的密码</font></td> 
  </tr> 
  <tr> 
    <th scope="col" abbr="Dual 2" class="style1">确认密码：</th> 
   
    <td class="alt" style="width: 241px">
       <asp:TextBox ID="txtRepeatPwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
      </td> 

    <td class="alt"><font style="color:Red">*输入你的密码</font></td> 
  </tr> 
  <tr> 
  <th scope="col" abbr="Dual 1.8" class="style1">你的性别：</th> 
  
    <td class="alt">
        <asp:RadioButton ID="rbtnBoy" runat="server" Text="男" Checked="True" 
            GroupName="sex" />
        <asp:RadioButton ID="rbtnGirl" runat="server" Text="女" GroupName="sex" />
      </td> 
    <td class="alt">&nbsp;</td> 

  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">你的邮箱：</th> 
    <td class="alt" style="width: 241px">
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
      </td> 
    <td class="alt"><font style="color:Red">*邮箱格式</font></td> 
  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">你的密保问题：</th> 
    <td class="alt" style="width: 241px">
       
        <asp:TextBox ID="txtSecure" runat="server" CssClass="form-control"></asp:TextBox>
      </td> 
    <td class="alt"><font style="color:Red">*必需</font></td> 
  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">答案为：</th> 
    <td class="alt" style="width: 241px">
        <asp:TextBox ID="txtAnswer" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
      </td> 
    <td class="alt"><font style="color:Red">*必需</font></td> 
  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">你在读的学校：</th> 
    <td class="alt" style="width: 241px">
        <asp:TextBox runat="server" ID="txtSchool" CssClass="form-control"></asp:TextBox>
      </td> 
    <td class="alt">&nbsp;</td> 
  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">个人标签：</th> 
    <td class="alt" style="width: 241px">
        <asp:TextBox ID="txtTag" runat="server" CssClass="form-control"></asp:TextBox>
      </td> 
    <td class="alt"></td> 
  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">你的个人介绍：</th> 
    <td class="alt" style="width: 241px">
           <asp:TextBox ID="txtIntro" CssClass="form-control" runat="server"></asp:TextBox>
      </td> 
    <td class="alt">&nbsp;</td> 
    </tr> 
    <tr>
       <th scope="col" abbr="Dual 2" class="style1"></th> 
    <td class="alt" style="width: 241px">
    <asp:Button ID="btnRegister" CssClass="button" runat="server" 
            OnClientClick="return CheckUserInfo()" Text="注册" onclick="btnRegister_Click" />
         <asp:Button ID="btnReset"  CssClass="button"   runat="server"  Text="重置"/>
         <br />
    </td> 
    <td class="alt">&nbsp;</td> 
  </tr>
</table> 
  </div></div>
    </div>
    </div>
    </div>
    </div>
    </form>
   
</body>
</html>
