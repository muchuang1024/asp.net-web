<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_findpwd.aspx.cs" Inherits="html_bbs_findpwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>找回密码</h2>
<div>
    输入你的账号<br /><br /><asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click"  CssClass="button" />&nbsp;
    <asp:Button ID="Button2" runat="server" Text="返回首页"  CssClass="button" 
        PostBackUrl="~/bbs_index.aspx" /><br /><br />
</div>
</asp:Content>

