<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true"  ValidateRequest="false" CodeFile="bbs_showpost.aspx.cs" Inherits="html_bbs_showpost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 180px;
        }
        .style2
        {
        	text-indent:20px;
        	border-left :1px solid #a9cbee;
            height: 23px;
        }
        .style3
        {
        	border-left :1px solid #a9cbee;
        	border-top :1px solid #a9cbee;
            text-indent:20px;
             min-height:209px;
        }
        .style4
        {
            width: 182px;
        }
        .style5
        {
            width: 182px;
            height: 20px;
        }
        .style6
        {
         
            height: 20px;
        }
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
        #TextArea1
        {
            width: 309px;
        }
    </style>
    <script type="text/javascript" language="javascript" src="./Scripts/tinymce/tinymce.min.js"></script>
<script type="text/javascript">
    tinymce.init({ selector: 'textarea' });


</script>
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

<div style="width:900px">
    <asp:Button ID="Button2" runat="server" Text="回复"  Width="62px"  PostBackUrl="#re" CssClass="button" />
    <asp:Button ID="Button3" runat="server" Width="62px" Text="发帖子" PostBackUrl="~/html/posting.aspx" CssClass="button" />
    <asp:Button ID="Button5" runat="server" PostBackUrl="~/bbs_index.aspx"  Text="回到首页" CssClass="button"/>
    </div>
<div id="main" style="">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
         <table style="  color:#FFF;border-collapse:collapse; background-image:url('../images/section_title.jpg'); height:30px" 
            width="900px">
        <tr>
        <td style=" text-indent:20px; width:550px"><%#Eval("post_title") %></td>
         
        </tr>
        </table>
        <br/>
         <table style="border: 1px solid #a9cbee;margin: 0px 0px 8px; width:900px; height: auto;" 
        cellpadding="0" cellspacing="0">
        <tr>
            <td class="style1" rowspan="3">
               <div style="height:260px;width:180px">
                   <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                       <tr>
                           <td>
                             
                           </td>
                           <td style="height:12px;">
                             
                           </td>
                           <td>
                             
                           </td>
                       </tr>
                       <tr>
                           <td>
                             
                           </td>
                           <td style="width:120px;height:120px">
                             
                               <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image_name","~/images/{0}") %>' Height="120px" Width="120px" />
                           </td>
                           <td>
                             
                           </td>
                       </tr>
                       <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               <a href="bbs_message.aspx?user_name=<%# Eval("user_account") %>">发起消息</td>
                           <td>
                             
                           </td>
                       </tr>
                         <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               昵称：<a href="bbs_userinfo.aspx?user_name=<%# Eval("user_account") %>"><%#Eval("user_name") %></a></td>
                           <td>
                             
                           </td>
                       </tr>
                         <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               等级：<%#getClass(Convert.ToInt32(Eval("score"))) %></td>
                           <td>
                           
                           </td>
                       </tr>
                          <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               财富值：<%#Eval("gold") %>E币</td>
                           <td>
                           
                           </td>
                       </tr>
                   </table>
               </div>
            </td>
            <td class="style2">
              发表于：<%#Eval("post_date") %><div style="height:23px;float:right;margin-right:10px"><span style=" color:Red">楼主</sapn></div></td>
        </tr>
        <tr>
            <td class="style3">
              <%#Eval("post_body")%>
              
            </td>
        </tr>
        <tr>
            <td style="height:28px;border-top :1px solid #a9cbee;border-left :1px solid #a9cbee">
             回复次数&nbsp;<%#Eval("post_replynum") %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                 ID="lb1" Visible="false" runat="server" OnClick="lb1_Click" CommandArgument='<%#Eval("post_id") %>'>加精</asp:LinkButton>&nbsp;<asp:LinkButton
                 ID="lb2" Visible="false" OnClick="lb2_Click"  CommandArgument='<%#Eval("post_id") %>' runat="server">删帖</asp:LinkButton>&nbsp;<asp:LinkButton
                     ID="lb3" Visible="false" OnClick="lb4_Click"  CommandArgument='<%#Eval("post_id") %>' runat="server">取消加精</asp:LinkButton></td>
        </tr>
    </table>   
        </ItemTemplate>
    </asp:DataList>
    <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
            <table style="border: 1px solid #a9cbee;margin:auto; width:900px; height: auto;" 
        cellpadding="0" cellspacing="0">
        <tr>
            <td class="style1" rowspan="3">
               <div style="height:260px;width:180px;margin-right:auto;margin-left:auto;">
                   <table style="width: 100%; margin-left:auto; margin-right:auto" border="0" cellpadding="0" cellspacing="0">
                       <tr>
                           <td>
                             
                           </td>
                           <td style="height:12px;">
                             
                           </td>
                           <td>
                             
                           </td>
                       </tr>
                       <tr>
                           <td>
                             
                           </td>
                           <td style="width:120px;height:120px">
                             
                               <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image_name","~/images/{0}") %>' Height="120px" Width="120px" />
                           </td>
                           <td>
                             
                           </td>
                       </tr>
                       <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               <a href="bbs_message.aspx?user_name=<%# Eval("user_account") %>">发起消息</td>
                           <td>
                             
                           </td>
                       </tr>
                         <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               昵称：<a href="bbs_userinfo.aspx?user_name=<%# Eval("user_account") %>"><%#Eval("user_account") %></a></td>
                           <td>
                             
                           </td>
                       </tr>
                         <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               等级：<%#getClass(Convert.ToInt32(Eval("score"))) %></td>
                           <td>
                             
                           </td>
                       </tr>
                          <tr>
                           <td>
                             
                           </td>
                           <td>
                             
                               财富值：<%#Eval("gold") %>E币</td>
                           <td>
                           
                           </td>
                       </tr>
                   </table>
               </div>
            </td>
            <td class="style2">
               发表于：<%#Eval("reply_date") %><div style="height:23px;float:right;margin-right:10px">
                    <%# getJuge(Convert.ToInt32(Container.ItemIndex)+(Convert.ToInt32(Request.QueryString["pageindex"])-1)*2)%></div></td>
              
         
        </tr>
        <tr>
            <td class="style3">
            <span style=" display:block; margin-top:20px">
              <%#Eval("reply_body") %></span>
              
            </td>
        </tr>
        <tr>
            <td style="height:28px;border-top :1px solid #a9cbee;border-left :1px solid #a9cbee">
              
                <asp:LinkButton ID="lb3" CommandArgument='<%# Eval("reply_id") %>' OnClick="lb3_Click" Visible ="false" runat="server">删除该条回复</asp:LinkButton>
                <asp:LinkButton ID="lb4" runat="server"  CommandArgument='<%# Eval("reply_body") %>' OnClick="lb_Click" PostBackUrl="#re">引用</asp:LinkButton>
            </td>
        </tr>
    </table>
        </ItemTemplate>
    </asp:DataList>
</div>
<div id="repeater_page" style="width:900px;border:1px solid #a9cbee; height:28px;margin-top:10px;margin-bottom:10px">
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

<div id="reply" style="width:100%">
      <table style="  color:#FFF;border-collapse:collapse; background-image:url('../images/section_title.jpg'); height:30px" 
            width="900px">
        <tr>
        <td style=" text-indent:20px; width:550px">回复帖子</td>
         
        </tr>
        </table>
    <table style="border: 1px solid #a9cbee;width:900px" cellpadding="0" cellspacing="0" >
        <tr>
            <td class="style5">
                </td>
            <td class="style6">
                </td>
           
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
            <a id="re"></a>
                <textarea id="TextArea1" runat="server" name="S1" rows="3"></textarea></td>
         
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    style="height: 21px" Text="发布回复"  CssClass="button"/>
            </td>
         </tr> 
         <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
               回复评论不得有国家规定内容，否则收到删帖封号处理。
            </td>
           
        </tr>
    </table>
    
</div>
</asp:Content>

