<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_apply.aspx.cs" Inherits="html_bbs_apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 20px;
            width: 176px;
        }
        .style3
        {
        	text-align:right;
            width: 176px;
        }
           a:link, a:active, a:visited {
	color: blue;
	text-decoration: none;
}
a:hover {
	color: #4455aa;
	text-decoration: underline;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="border:1px solid #a9cbee; margin-top: 13px; width: 900px; height: auto;">
                
            <div id="message_title" 
                style="width:880px;border:1px solid #a9cbee; text-indent:20px;margin-left:auto;margin-right:auto;height:25px; margin-top: 20px;">
            <%#  Eval("message_date")%>&nbsp;&nbsp;&nbsp;你现在正在申请 <asp:Label ID="Label1" 
                    runat="server" Text="Label"></asp:Label>
                版块<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                区的版主</div>
             <div id="message_main" 
                
          style="width:880px;border:1px solid #a9cbee;margin-left:auto; text-indent:20px; margin-right:auto;height:auto; padding-top:20px; margin-top: 11px;">
             
             <%# Eval("message_main") %>申请须知：<br />
                 <font style="color:Red">版主有对该板块的帖子进行顶置和删除功能。<br />
                 你必须遵守本论坛的宗旨。维护论坛的正常功能。</font></div>
                          <div id="Div1" 
                style="width:880px;border:1px solid #a9cbee;margin-left:auto; text-indent:20px; margin-right:auto;height:auto; padding-top:10px; margin-top: 21px;">
             
             <%# Eval("message_main") %>
                              <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                  <tr>
                                      <td class="style2">
                                          &nbsp;</td>
                                      <td class="style1">
                                      </td>
                                      <td class="style1">
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style3">
                                          申请理由：</td>
                                      <td>
                                          <textarea id="TextArea1" runat="server" cols="40" name="S1" rows="8"></textarea></td>
                                      <td>
                                          &nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="style3">
                                          是否有担任版主经历：</td>
                                      <td>
                                          <asp:RadioButton ID="RadioButton1" runat="server" Text="是" Checked="True" 
                                              GroupName="rb" />
                                          <asp:RadioButton ID="RadioButton2" runat="server" Text="否" GroupName="rb" />
                                      </td>
                                      <td>
                                          &nbsp;</td>
                                  </tr>
                              </table>
            </div>
              
              <div id="message_btn" 
                style="width:880px; text-align:center;border:1px solid #a9cbee;margin-left:auto;margin-right:auto;height:25px; margin-top: 20px; margin-bottom: 20px;">
            
                  <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" CssClass="button" />
                   &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返回首页"  CssClass="button"
                      PostBackUrl="~/bbs_index.aspx" />
            
             </div>
             
        </div>
</asp:Content>

