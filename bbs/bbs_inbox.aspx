<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_inbox.aspx.cs" Inherits="html_bbs_inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    欢迎您：<%#Request.Cookies["user_name"].Value %></div>
            <div style="width:126px ;margin-left:auto;margin-right:auto">
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Contacts" NodeIndent="10" 
        Width="126px">
                    <HoverNodeStyle Font-Underline="False" />
                    <Nodes>
                        <asp:TreeNode  Text="个人资料修改" Value="新建节点" 
                            NavigateUrl="~/html/bbs_edituserinfo.aspx"></asp:TreeNode>
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
       <table style=" text-align:center; color:#FFF;border-collapse:collapse; background-image:url('./images/section_title.jpg'); height:30px" 
            width="700px">
        <tr>
        <td style="width:300px">邮件标题</td>
          <td style="width:100px">发件人</td>
            <td style="width:100px">发件时间</td>
             <td style="width:100px">阅读状态</td>
              <td style="width:50px">阅读</td>
        </tr>
        </table>
        <asp:Repeater ID="Repeater1" runat="server">
         <AlternatingItemTemplate> 
         <table width="700px" style="border-collapse:collapse;border-left:1px solid #a9cbee;border-right:1px solid #a9cbee; table-layout:fixed" >
               <tr style="background-color:#CAE8EA">
                <td style="width:300px;text-indent:5px"><%#Eval("message_title") %></td>
                <td style="font-size:12px;width:100px;text-align:center"><a href="bbs_userinfo.aspx?user_name=<%# Eval("sender") %>"><%#Eval("sender")%></a></td>
                <td style="width:100px; text-align:center"><%#((DateTime)Eval("message_date")).ToString("MM/dd HH:mm")%></td>
                 <td style="width:100px;text-align:center"><%#getState(Convert.ToInt32(Eval("state")))%></td>
                <td style="font-size:12px;width:50px;text-align:center"><a href="bbs_readmessage.aspx?id=<%# Eval("message_id") %>">阅读</a></td>
               </tr>
             </table>
         </AlternatingItemTemplate> 
         <ItemTemplate>
            <table width="700px" style="border-collapse:collapse;border-left:1px solid #a9cbee;border-right:1px solid #a9cbee; table-layout:fixed" >
               <tr style="background-color:#FFF">
                <td style="width:300px;text-indent:5px"><%# Eval("message_title") %></td>
                <td style="font-size:12px;width:100px;text-align:center"><a href="bbs_userinfo.aspx?user_name=<%# Eval("sender") %>"><%#Eval("sender")%></a></td>
                <td style="width:100px;text-align:center"><%#((DateTime)Eval("message_date")).ToString("MM/dd HH:mm")%></td>
                  <td style="width:100px;text-align:center"><%#getState(Convert.ToInt32(Eval("state")))%></td>
                <td style="font-size:12px;width:50px;text-align:center"><a href="bbs_readmessage.aspx?id=<%# Eval("message_id") %>">阅读</a></td>
               </tr>
             </table> 
            </ItemTemplate>
        </asp:Repeater>
            <asp:Label ID="Label1" runat="server"  Visible ="false"></asp:Label>
        </div>
        <div style=" clear:both">
        </div>
    </div>
</asp:Content>

