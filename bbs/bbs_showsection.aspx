<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_showsection.aspx.cs" Inherits="html_bbs_showsection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
      .d1{ 
margin:10px auto; 
width:900px;  
height:20px; 
overflow:hidden; 
white-space:nowrap; 
}  
.div2{ 
width:900px; 
height:20px; 
font-size:12px; 
} 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
      var s, s2, s3, s4, timer, i = 0;
      function init() {
          s = getid("div1");
          s2 = getid("div2");
          s3 = getid("div3");
          s4 = getid("div4");
          s4.innerHTML = s3.innerHTML;
          s2.style.width = s.offsetWidth + "px";
          s2.style.height = s.offsetHeight + "px";
          timer = setInterval(mar, 30)
      }
      function mar() {
          //s2.innerHTML=s.scrollLeft; 
          if (s3.offsetWidth <= s.scrollLeft) {
              s.scrollLeft -= s3.offsetWidth;
          } else { s.scrollLeft++; }
      }
      function getid(id) {
          return document.getElementById(id);
      }
      window.onload = init; 
</script> 
<div class="d1" id="div1"> 
<span class="div2" id="div3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 欢迎大家来到理工E平台
&nbsp;来到这里的用户请遵守本论坛的规定。&nbsp;不能谈论一些敏感词汇。&nbsp;本论坛可以为用户提供一个交流学习，思想的好地方。
</span> 
<span id="div4" class="div2"></span> 
</div> 
<div class="d2" id="div2"></div> 
    <div>

    <div id="">
    <div style=" font:14px/24px Helvetica, Tahoma, Arial, sans-serif; color:#666">
        理工E立方&gt;子模块</div>
       <div>
           <asp:Button ID="Button1" runat="server" Text="发帖" 
               PostBackUrl="~/html/posting.aspx" onclick="Button1_Click" CssClass="button"/>
&nbsp;</div>
        <table style=" text-align:center; color:#FFF;border-collapse:collapse; background-image:url('./images/section_title.jpg'); height:30px" 
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
               <td style="width:40px">
                   <asp:Image ID="Image1"  Width="40px" Height="19px" ImageUrl='<%#getimage(Eval("class").ToString()) %>' runat="server" /></td>
                <td style="width:510px;text-indent:5px"><a href='bbs_showpost.aspx?f_id=<%# Eval("f_id") %>&post_id=<%#Eval("post_id")%>&pageindex=1 '><%#Eval("post_title") %></a></td>
                <td style="font-size:12px;width:100px;text-align:center"><a href="bbs_userinfo.aspx?user_name=<%# Eval("user_name") %>"><%#Eval("user_name")%></a><br/><%#((DateTime)Eval("post_date")).ToString("MM/dd HH:mm")%></td>
                <td style="width:50px; text-align:center"><%# Eval("post_replynum") %></td>
                <td style="width:50px; text-align:center"><%# Eval("post_count") %></td>
                <td style="font-size:12px;width:100px;text-align:center"><%# judgeisnull(Eval("post_lastname").ToString()) %><br/><%# judeisnulldate(Eval("last_replydate").ToString())%></td>
               </tr>
             </table>
         </AlternatingItemTemplate> 
         <ItemTemplate>
            <table width="900px" style="border-collapse:collapse;border-left:1px solid #a9cbee;border-right:1px solid #a9cbee; table-layout:fixed" >
               <tr style="background-color:#FFF">
                 <td style="width:40px"><asp:Image ID="Image1" Width="40px" Height="19px" ImageUrl='<%#getimage(Eval("class").ToString()) %>' runat="server" /></td>
                <td style="width:510px;text-indent:5px"><a href='bbs_showpost.aspx?f_id=<%#Eval("f_id") %>&post_id=<%#Eval("post_id")%>&pageindex=1 '><%# Eval("post_title") %></a></td>
                <td style="font-size:12px;width:100px;text-align:center"><a href="bbs_userinfo.aspx?user_name=<%# Eval("user_name") %>"><%#Eval("user_name")%></a><br/><%#((DateTime)Eval("post_date")).ToString("MM/dd HH:mm")%></td>
                <td style="width:50px;text-align:center"><%# Eval("post_replynum") %></td>
                <td style="width:50px;text-align:center"><%# Eval("post_count") %></td>
                <td style="font-size:12px;width:100px;text-align:center"><%# judgeisnull(Eval("post_lastname").ToString()) %><br/><%# judeisnulldate(Eval("last_replydate").ToString())%></td>
               </tr>
             </table> 
            </ItemTemplate>
        </asp:Repeater>
         <table style=" text-align:center; color:#FFF;border-collapse:collapse; background-image:url('./images/section_title.jpg'); height:30px" 
            width="900px">
        <tr>
        <td style="width:550px">标题</td>
          <td style="width:100px">发帖人</td>
            <td style="width:50px">回复</td>
             <td style="width:50px">人气</td>
              <td style="width:100px">最后更新</td>
        </tr>
        </table>
    </div>
    <div id="repeater_page" style="width:900px;border:1px solid #a9cbee; height:30px;margin-top:10px;margin-bottom:10px">
    <div id="page_button" style="width:500px;height:28px; float:left; margin-left:30px">
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </div>
        <div id="Div5" 
        style="width:201px; float:right; height:28px; margin-top: 0px;">
            <asp:HyperLink ID="prePage" runat="server">上一页</asp:HyperLink>
            <asp:HyperLink ID="nextPage" runat="server">下一页</asp:HyperLink>
    </div>
    <div id="clear" style=" clear:both">
    </div>
</div>

    <div>
        <asp:Button ID="Button3" runat="server" Text="发帖" onclick="Button3_Click"  CssClass="button"/>
           <asp:Button ID="Button4" runat="server" Text="回到首页" 
               PostBackUrl="~/bbs_index.aspx" CssClass="button"/>
    </div>
    <br />
    
</div>
</asp:Content>

