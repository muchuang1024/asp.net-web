<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_login.aspx.cs" Inherits="html_bbs_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    h3
    {
    	 text-align :center;
     }
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
</style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<div style="font-size:16px; font-weight:bold; text-align:center">用户登陆</div>
    用户名：<asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
    密码：<asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <br />
    登陆保存：<asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Value="0">不保存</asp:ListItem>
        <asp:ListItem Value="1">保存一天</asp:ListItem>
        <asp:ListItem Value="30">保存一月</asp:ListItem>
        <asp:ListItem Value="356">保存一年</asp:ListItem>
    </asp:DropDownList>&nbsp;&nbsp
    忘记密码&nbsp;&nbsp;<a href="bbs_findpwd.aspx">点击找回</a><br/><br />
    <asp:Button ID="Button1" runat="server" Text="登陆" onclick="Button1_Click"  
            CssClass="button" Width="100px" />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="返回首页"  CssClass="button"
        PostBackUrl="~/bbs_index.aspx" Width="100px" />
 <br />
 <br />

</div>
</asp:Content>

