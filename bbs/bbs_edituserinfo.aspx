<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_edituserinfo.aspx.cs" Inherits="html_edit_userinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../Scripts/jquery.js"></script>
   <script type="text/javascript">
       function CheckUserInfo() 
       {
           var email = document.getElementById("TextBox5"); //对电子邮件的验证
           var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
           if (!myreg.test(email.value)) {
               alert('提示\n\n请输入有效的E_mail！');
               email.focus();
               return false;
           }
           return true;
       }
   </script>
    <style type="text/css">
        #logo
        {
            margin-top: 25px;
        }
    .style1
    {
            width: 100px;
            text-align:right;
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
    background: #CAE8EA ;
} 


        .style3
        {
            width: 250px;
            font-size: 11px;
            color: #797268;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            padding-left: 12px;
            padding-right: 6px;
            padding-top: 6px;
            padding-bottom: 6px;
            background: #F5FAFA;
        }
     
        .style5
        {
        	width:250px;
            font-size: 11px;
            color: #4f6b72;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            padding-left: 12px;
            padding-right: 6px;
            padding-top: 6px;
            padding-bottom: 6px;
            background: #fff;
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
    <div style="height:auto;width:900px">
<div id ="logo" style=" border-bottom:4px solid #0066FF">
    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/13.jpg" 
        Width="187px" />
    <font style="font-size:15px; font-weight:bold">个人资料修改中心</font>    
</div>
<div style="border:1px solid #a9cbee; margin-top: 13px; width: 183px;float:left">
<div style="border:1px solid #a9cbee; margin-top: 13px; width: 120px; height:120px;margin-right:auto;margin-left:auto">
    
    <asp:ImageButton ID="ImageButton1" runat="server" Height="120px" Width="120px" 
         />
</div>
<div style="width:170px;border:1px solid #a9cbee;margin-right:auto; text-align:center;margin-left:auto; margin-top: 11px;">
    欢迎您：<% Response.Write(Request.Cookies["user_info"].Value.ToString());%></div>
    <div style="width:126px ;margin-left:auto;margin-right:auto">
    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Contacts" NodeIndent="10" 
        Width="126px">
        <HoverNodeStyle Font-Underline="False" />
        <Nodes>
           <asp:TreeNode  Text="个人资料修改" Value="新建节点" 
                NavigateUrl="~/bbs_edituserinfo.aspx"></asp:TreeNode>
            <asp:TreeNode Text="头像设置" Value="新建节点" NavigateUrl="~/bbs_headimage.aspx"></asp:TreeNode>
            <asp:TreeNode Text="密码设置" Value="新建节点" NavigateUrl="~/bbs_editpwd.aspx"></asp:TreeNode>
            <asp:TreeNode Text="收件箱" Value="新建节点" NavigateUrl="~/bbs_inbox.aspx"></asp:TreeNode>
            <asp:TreeNode Text="注销登录" Value="新建节点" 
                NavigateUrl="~/bbs_cookiesclear.aspx"></asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/bbs_index.aspx" Text="返回首页" Value="返回首页">
            </asp:TreeNode>
        </Nodes>
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
            VerticalPadding="0px" />
    </asp:TreeView>
    </div>
</div>
<div style="border:1px solid #a9cbee; margin-top: 13px; width: 700px; float:right; height: auto;">

      <table id="mytable" cellspacing="0" width="700px" summary="The technical specifications of the Apple PowerMac G5 series"> 
  <tr> 
   <th scope="col" abbr="Dual 2" class="style1">昵称：</th> 
 
  <td class="style3">
      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
      </td> 
 
  <td class="style3">
      &nbsp;</td> 
   
  
   
  </tr> 
  <tr> 
    
    <th scope="col" abbr="Dual 2" class="style1">你的标签：</th> 

    <td class="style5">
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
      </td> 

    <td class="style5">
        &nbsp;</td> 
  </tr> 
  <tr> 
    <th scope="col" abbr="Dual 2" class="style1">你的学校：</th> 
   
    <td class="style3">
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
      </td> 

    <td class="style3">
        &nbsp;</td> 

  </tr> 
  <tr> 
  <th scope="col" abbr="Dual 1.8" class="style1">你的性别：</th> 
  
    <td class="style5">
        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
            GroupName="sex" Text="男" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="sex" Text="女" />
      </td> 

    <td class="style5">
        &nbsp;</td> 

  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">你的邮箱：</th> 
    <td class="style3">
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
      </td> 
    <td class="style3">
        &nbsp;</td> 
  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">你的个人介绍：</th> 
  
    <td class="style5">
        <textarea id="TextArea1" cols="40" runat="server" name="S1" rows="8"></textarea></td> 

    <td class="style5">
        &nbsp;</td> 

  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">&nbsp;</th> 
    <td class="style3">
        &nbsp;</td> 
    <td class="style3">
        &nbsp;</td> 
  </tr> 
  <tr> 
     
     <th scope="col" abbr="Dual 2" class="style1">&nbsp;</th> 
  
    <td class="style5">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="提交" CssClass="button" OnClientClick="return  CheckUserInfo()"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="重置" CssClass="button" 
            onclick="Button2_Click"  />
      </td> 

    <td class="style5">
        &nbsp;</td> 

    </tr> 
    <tr>
       <th scope="col" abbr="Dual 2" class="style1"></th> 
    <td class="style3">
      
       
      </td> 
    <td class="style3">
        &nbsp;</td> 
  </tr>
</table> 


</div>
<div style=" clear:both">
</div>
</div>
</asp:Content>

