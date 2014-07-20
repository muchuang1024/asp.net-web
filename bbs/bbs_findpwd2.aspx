<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_findpwd2.aspx.cs" Inherits="html_findpwd2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>密码找回</h2>
    <br />
你的密保问题是：<asp:Label ID="Label1" runat="server"  Text="Label"></asp:Label>
    <br />
输入你的答案：<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox><br/>
    <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" CssClass="button" />    <asp:Button ID="Button2" CssClass="button" runat="server" Text="返回首页" />
    
    <asp:Label ID="Label2" runat="server" ></asp:Label>
</asp:Content>

