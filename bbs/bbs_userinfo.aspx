<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_userinfo.aspx.cs" Inherits="html_bbs_userinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  type="text/css" href="../Styles/Bbs.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main" class="bbs_main1_css">
    <div style=" font:12px/24px Helvetica, Tahoma, Arial, sans-serif; color:#666">
理工E立方>ta的资料
</div>
<asp:Repeater ID="Repeater2" runat="server">
<ItemTemplate>
    <div id="user_info" style="border-top:4px solid #0066FF;  margin-top: 12px;">  
    <div id="image" 
            style="width:150px;text-align:center;height:260px; float:left; background-color:#CCDDFF; margin-top: 18px;"> 
        <div id="image_" style="width:120px;height:120px; margin:5px auto auto auto">
            <asp:Image ID="ImageButton1" ImageUrl='<%#Eval("image_name","~/images/{0}") %>' runat="server" Height="120px" Width="120px" />
        </div> 
        <div style="height: 22px;  width: 149px; margin-top: 12px;">
           <a href="bbs_message.aspx?user_name=<%# Eval("user_account") %>">发起消息</a></div>  
    </div>
    <div style="width:650px; float:right">
        <div id="user_name1" 
            style="width:650px; text-indent:20px;height:32px; border-bottom:1px solid #DDDDDD; margin-top: 19px;">
           昵称:<%#Eval("user_name") %></div>
           <div style="height: 80px">
           &nbsp;
           个人介绍：<%# Getintroduce(Eval("user_introduce").ToString()) %></div>
           <div style="height: 93px">
               <table style="width:100%;" cellpadding="0" cellspacing="0">
                   <tr style="height:30px">
                       <td>
                           他的等级：<%#getClass(Convert.ToInt32(Eval("score"))) %></td>
                       <td>
                           他的积分：<%# Eval("score") %></td>
                       <td>
                           他的金币值：<%# Eval("gold") %>E币</td>
                   </tr>
                   <tr style="height:30px">
                       <td>
                          他的性别：<%#Eval("user_sex") %></td>
                       <td>
                           在读学校:<%# GetIsNull(Eval("school").ToString()) %></td>
                       <td>
                          个人标签：<%# GetIsNull(Eval("label").ToString()) %></td>
                   </tr>
                   <tr style="height:30px">
                       <td>
                          注册时间：<%#Eval("user_date") %></td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
               </table>
           </div>
    </div>
    <div class="clear">
    </div>
</div>
</ItemTemplate>
</asp:Repeater>
<div style="width:900px">
    <div style=" font-size:large; width:900px;height:30px;border-bottom:4px solid #0066FF; font-weight: bold;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 他发过的帖子</div>
</div>
<div>
<table style=" text-align:center; color:#FFF;border-collapse:collapse; background-image:url('../images/section_title.jpg'); height:30px; margin-top: 13px;" 
            width="900px">
        <tr>
        <td style="width:550px">标题</td>
          <td style="width:100px">发帖人</td>
            <td style="width:50px">回复</td>
             <td style="width:50px">人气</td>
              <td style="width:100px">最后更新</td>
        </tr>
        </table>
<asp:Repeater ID="Repeater1" runat="server">
         <AlternatingItemTemplate> 
         <table width="900px" style="border-collapse:collapse;border-left:1px solid #a9cbee;border-right:1px solid #a9cbee; table-layout:fixed" >
               <tr style="background-color:#CAE8EA">
                <td style="width:550px;text-indent:5px"><a href='bbs_showpost.aspx?f_id=<%#Eval("f_id") %>&post_id=<%#Eval("post_id")%>&pageindex=1 '><%#Eval("post_title") %></a></td>
                <td style="font-size:12px;width:100px;text-align:center"><%#Eval("user_name")%><br/><%#((DateTime)Eval("post_date")).ToString("MM/dd HH:mm")%></td>
                <td style="width:50px; text-align:center"><%# Eval("post_replynum") %></td>
                <td style="width:50px; text-align:center"><%# Eval("post_count") %></td>
                <td style="font-size:12px;width:100px;text-align:center"><%# judgeisnull(Eval("post_lastname").ToString()) %><br/><%# judeisnulldate(Eval("last_replydate").ToString())%></td>
               </tr>
             </table>
         </AlternatingItemTemplate> 
         <ItemTemplate>
            <table width="900px" style="border-collapse:collapse;border-left:1px solid #a9cbee;border-right:1px solid #a9cbee; table-layout:fixed" >
               <tr style="background-color:#FFF">
                <td style="width:550px;text-indent:5px"><a href='bbs_showpost.aspx?f_id=<%#Eval("f_id") %>&post_id=<%#Eval("post_id")%>&pageindex=1 '><%# Eval("post_title") %></a></td>
                <td style="font-size:12px;width:100px;text-align:center"><%#Eval("user_name")%><br/><%#((DateTime)Eval("post_date")).ToString("MM/dd HH:mm")%></td>
                <td style="width:50px;text-align:center"><%# Eval("post_replynum") %></td>
                <td style="width:50px;text-align:center"><%# Eval("post_count") %></td>
                <td style="font-size:12px;width:100px;text-align:center"><%# judgeisnull(Eval("post_lastname").ToString()) %><br/><%# judeisnulldate(Eval("last_replydate").ToString())%></td>
               </tr>
             </table> 
            </ItemTemplate>
        </asp:Repeater>
    <asp:Label ID="Label1" runat="server"  Visible="false"></asp:Label>
    <br />
    <br />
</div>
</div>
</asp:Content>

