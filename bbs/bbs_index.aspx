<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="bbs_index.aspx.cs" Inherits="html_bbs_index" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Styles/Bbs.css" rel="stylesheet" type="text/css"/>
<style type="text/css">
    a:link, a:active, a:visited {
	color:blue;
	text-decoration: none;
}
a:hover {
	color: #4455aa;
	text-decoration: underline;
}
.pcStyle
{
  margin-left:0px;    
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="bbs_main1" class="bbs_main1_css">
<div id="section" class="section_css">
<div>
</div>
<asp:repeater id="parent" runat="server">
 <itemtemplate>
    <table width="900px" border="1" cellpadding="0" cellspacing="0"  style=" text-indent:20px; border-color:#6595D6">
					<tr class="title_link">
						
        <td class="title" style="background-image: url('./images/title_bg.gif')">&nbsp;<a href="#"><%# Eval("section_name")%></a></td>
					</tr>
			
			<asp:repeater id="child" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("f2") %>' runat="server">
						<itemtemplate>
          <tr> 
            <td class="board">
<table width="100%" border="0" cellspacing="0" cellpadding="3">
                <tr> 
                  <td style="width:9%" rowspan="2" align="center" class="boardstate">
                  <div align="center">
                  <asp:ImageButton ID="ImageButton1"  Width="100px" Height="100px"  CssClass="pcStyle" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"[\"image_name\"]","~/images/{0}") %>' runat="server" />
                  </div>
                  </td>
                  <td style="width:77%"><table width="100%" style="height:100%" border="0" cellpadding="2" cellspacing="0">
                      <tr> 
                        <td style="width:67"><font color="#000000"><a href="bbs_showsection.aspx?f_id=<%#DataBinder.Eval(Container.DataItem, "[\"f_id\"]")%>">
                         <%#DataBinder.Eval(Container.DataItem, "[\"f_title\"]")%>
                          </a></font></td>
                        <td width="10%" rowspan="3">
                        </td>
                        <td style="width:23%">主题：<%# judgeisnull(DataBinder.Eval(Container.DataItem, "[\"f_id\"]").ToString(), DataBinder.Eval(Container.DataItem, "[\"last_post_title\"]").ToString(), DataBinder.Eval(Container.DataItem, "[\"post_id\"]").ToString())%></td>
                      </tr>
                      <tr> 
                        <td style="width:67%" rowspan="2" valign="top">
                          <%# DataBinder.Eval(Container.DataItem, "[\"f_describe\"]")%>
                          <font style="color:#000000">&nbsp; </font></td>
                        <td>作者： <%# Get_user(DataBinder.Eval(Container.DataItem, "[\"f_lastpost_name\"]").ToString(), DataBinder.Eval(Container.DataItem, "[\"user_id\"]").ToString())%>
                         
                         </td>
                      </tr>
                      <tr> 
                        <td style="width:23%">日期： 
                        <%#judeisnulldate(DataBinder.Eval(Container.DataItem, "[\"f_lastpost_time\"]").ToString())%>
                        
                        </td>
                      </tr>
                    </table></td>
                </tr>
                <tr> 
                  <td style="background-color:#E2EBF5">
<table style="width:100%" border="0" cellspacing="0" cellpadding="1">
                      <tr> 
                        <td style="width:50%">版主： 
                        <%# Get_moderator(DataBinder.Eval(Container.DataItem, "[\"f_moderator\"]").ToString(), DataBinder.Eval(Container.DataItem, "[\"f_id\"]").ToString())%>
                        </td>
                        <td style="width:50%"><table style="width:60%" border="0" align="right" cellpadding="0" cellspacing="0">
                            <tr>
                              <td style="width:30"><img alt="" src="./images/Forum_today.gif" width="25" height="10"/></td>
                              <td style="width:200"><div align="center">
                                 <%#getToday(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "[\"f_id\"]")))%>
                                  </div></td>
                              <td style="width:30"><img alt="" src="./images/post.gif" width="25" height="10"/></td>
                              <td style="width:200"><div align="center">
                                  <%#DataBinder.Eval(Container.DataItem, "[\"post\"]")%>
                                 </div></td>
                              <td style="width:30"><img alt="" src="./images/topic.gif" width="25" height="10"/></td>
                              <td style="width:200"><div align="center">
                                 <%#DataBinder.Eval(Container.DataItem, "[\"topic\"]")%>
                                  </div></td>
                            </tr>
                          </table></td>
                      </tr>
                    </table></td>
                </tr>
              </table>
								</td>
							</tr>
     	</itemtemplate>
					</asp:repeater>
                  <table border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td style="height:18px"></td>
					</tr>
				</table>
                    </itemtemplate>
                </asp:repeater>
</div>
</div>
</asp:Content>

