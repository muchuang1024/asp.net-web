<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_message.aspx.cs" Inherits="html_bbs_message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 124px;
            text-align:right;
        }
      
        .style32
        {
            width: 124px;
            text-align: right;
            height: 25px;
        }
        .style33
        {
            height: 25px;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-indent:20px;font-size:16px; font-weight:bold; width:900px;height:25px; border-bottom:4px solid #0066FF">
   发送消息
</div>
<div id="" style="width:800px">
    <table style="width: 900px;" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td class="style32">
                &nbsp;
                收件人：</td>
            <td class="style33">
                &nbsp;
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            <font style="color:Red">确认用户名是否填写正确，否则发出的消息对方无法接受。</font></td>
            <td class="style33">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                标题：
                </td>
            <td>
                &nbsp;
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                内容：</td>
            <td>
                &nbsp;
                <textarea rows="8"  cols ="58" runat="server" id="TextArea1" name="S1"></textarea></td>
            <td>
                &nbsp;
            </td>
        </tr>
          <tr>
            <td class="style1">
                &nbsp;
                标题：
                </td>
            <td>
               
             
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="发送" CssClass="button"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="返回" CssClass="button" PostBackUrl="~/bbs_index.aspx"/>
               
             
            </td>
            <td>
               
            </td>
        </tr>
    </table>
</div>
</asp:Content>