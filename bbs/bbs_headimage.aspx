<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_headimage.aspx.cs" Inherits="html_bbs_headimage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

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
        <script type="text/javascript">
         

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:auto;width:900px">
        <div id ="logo" style=" border-bottom:4px solid #0066FF">
            <font style="font-size:15px; font-weight:bold">用户头像修改中心</font>
        </div>
        <div style="border:1px solid #a9cbee; margin-top: 13px; width: 183px;float:left">
            <div style="border:1px solid #a9cbee; margin-top: 13px; width: 120px; height:120px;margin-right:auto;margin-left:auto">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="120px" Width="120px" 
       />
            </div>
            <div style="width:170px;border:1px solid #a9cbee;margin-right:auto; text-align:center;margin-left:auto; margin-top: 11px;">
    欢迎您：<%#Request.Cookies["user_name"].Value %></div>
            <div style="width:126px ;margin-left:auto;margin-right:auto">
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Contacts" NodeIndent="10" 
        Width="126px">
                    <HoverNodeStyle Font-Underline="False" />
                    <Nodes>
                        <asp:TreeNode  Text="个人资料修改" Value="新建节点" 
                            NavigateUrl="~/bbs_edituserinfo.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="头像设置" Value="新建节点" NavigateUrl="~/bbs_headimage.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode Text="密码设置" Value="新建节点" NavigateUrl="~/bbs_editpwd.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode Text="收件箱" Value="新建节点" NavigateUrl="~/bbs_inbox.aspx">
                        </asp:TreeNode>
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
        <div style="border:1px solid #a9cbee; margin-top: 13px; width: 700px; float:right; height: 281px;">

      <table id="mytable" cellspacing="0" width="700px" summary="The technical specifications of the Apple PowerMac G5 series"> 
  <tr> 
   <th scope="col" abbr="Dual 2" class="style1">&nbsp;</th> 
 
  <td class="style3">
      
   
      图片格式为（jpg，jpeg，bmp，gif）</td> 
 
  <td class="style3">
      &nbsp;</td> 
   
  
   
  </tr> 
  <tr> 
    
    <th scope="col" abbr="Dual 2" class="style1">上传头像：</th> 

    <td class="style5">
    
<asp:FileUpload ID="FileUpload1" runat="server" /></td> 

    <td class="style5">
        推荐头像大小为120*120</td> 
  </tr> 
  <tr> 
    <th scope="col" abbr="Dual 2" class="style1">&nbsp;</th> 
   
    <td class="style3">
        &nbsp;
        </td> 

    <td class="style3">
        &nbsp;</td> 

  </tr> 
  <tr> 
  <th scope="col" abbr="Dual 1.8" class="style1">上传后点击：</th> 
  
    <td class="style5">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="上传" onclick="Button1_Click" CssClass="button" />&nbsp;
        </td> 

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
   
</table> 


        </div>
        <div style=" clear:both">
        </div>
    </div>
</asp:Content>

