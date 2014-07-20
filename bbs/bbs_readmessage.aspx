<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_readmessage.aspx.cs" Inherits="html_bbs_readmessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


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


        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:auto;width:900px">
        <div id ="logo" style=" border-bottom:4px solid #0066FF">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/13.jpg" 
        Width="187px" />
            <font style="font-size:15px; font-weight:bold">收件箱</font>
        </div>
        <div style="border:1px solid #a9cbee; margin-top: 13px; width: 183px;float:left">
            <div style="border:1px solid #a9cbee; margin-top: 13px; width: 120px; height:120px;margin-right:auto;margin-left:auto">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="120px" Width="120px" 
         />
            </div>
            <div style="width:170px;border:1px solid #a9cbee;margin-right:auto; text-align:center;margin-left:auto; margin-top: 11px;">
    欢饮您：<%#Request.Cookies["user_name"].Value %></div>
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
                        <asp:TreeNode Text="注销登录" Value="新建节点"></asp:TreeNode>
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
                 <asp:repeater ID="repeater1" runat="server">
                <ItemTemplate>
            <div id="message_title" 
                style="width:680px;border:1px solid #a9cbee; text-indent:20px;margin-left:auto;margin-right:auto;height:25px; margin-top: 20px;">
            <%#  Eval("message_date")%>&nbsp;&nbsp;&nbsp;&nbsp;发件人：<%# Eval("sender") %>&nbsp;&nbsp;&nbsp;&nbsp;发送时间:
            <%#Eval("message_date") %></div>
             <div id="message_main" 
                style="width:680px;border:1px solid #a9cbee;margin-left:auto; min-height:300px; text-indent:20px; margin-right:auto;height:auto; padding-top:30px; margin-top: 21px;">
             
             <%# Eval("message_main") %></div>
              <div id="message_btn" style="width:680px;border:1px solid #a9cbee;margin-left:auto;margin-right:auto;height:25px; margin-top: 20px; margin-bottom: 20px;">
             <a href="bbs_message.aspx?user_name=<%#Eval("sender") %>">回复</a>&nbsp;&nbsp;&nbsp;<a href="bbs_inbox.aspx">返回收件箱</a>
             </div>
               </ItemTemplate>
               </asp:repeater>
        </div>
        
        <div style=" clear:both">
        </div>
    </div>
</asp:Content>

