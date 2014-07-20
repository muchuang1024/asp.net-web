<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="posting.aspx.cs" Inherits="html_posting" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript" language="javascript" src="../Scripts/tinymce/tinymce.min.js"></script>
<script type="text/javascript">
    tinymce.init({ selector: 'textarea' });
</script>
<title>
</title>

    <style type="text/css">
        .style1
        {
            width: 146px;
        }
        .style32
        {
            width: 146px;
            height: 22px;
        }
        .style33
        {
            height: 22px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="posting_main">
    <table style=" text-align:center; color:#FFF;border-collapse:collapse; background-image:url('../images/section_title.jpg'); height:30px" 
            width="900px">
        <tr>
        <td style="width:100%">发起一个新的帖子</td>
        
        </tr>
        </table>
     

</div>
&nbsp;<table border="1" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td class="style1">
                文章的标题</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="189px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td class="style1">
                文章内容：</td>
            <td>
                <textarea id="TextArea1" runat="server" cols="20" name="S1" rows="3"></textarea></td>
         
        </tr>
        <tr>
            <td class="style32">
                版块选择：</td>
            <td class="style33">
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
          
        </tr>
         <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
                    GroupName="tie" Text="普通帖" />
                <asp:RadioButton ID="RadioButton2"
                    runat="server" GroupName="tie" Text="积分帖" />
             &nbsp;&nbsp; *积分帖需花费 50E币 积分贴显示将比普通帖靠前。</td>
           
        </tr>
         <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" CssClass="button" Text="发表" />
                <asp:Button ID="Button2" runat="server" Text="返回首页" 
                    PostBackUrl="~/html/bbs_index.aspx" CssClass="button" />
             </td>
           
        </tr>
    </table>
    <br />
</asp:Content>

