<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_f.aspx.cs" Inherits="admin_bbs_edit_f" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="Stylesheet" type="text/css" href="../../Styles/txt.css" />
    <style type="text/css">
        .style1
        {
            width: 150px;
             text-align:right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
    <div style="border:1px solid #a9cbee; width:100%; min-height:200px;">
       <div id="Div1">
&nbsp;<span style="font-size:larger; font-weight:bold; line-height:20px">
 <img src="../images/lun.GIF" alt="论坛"  style="width: 39px; margin-top: 0px; height: 30px;" /> 论坛管理---------添加板块</span>
           <br />
       </div>
       <br />
       <div>
                
           选择板块：<asp:DropDownList 
               ID="DropDownList1" runat="server" Width="100px" AutoPostBack="True" 
               onselectedindexchanged="DropDownList1_SelectedIndexChanged">
           </asp:DropDownList>
                
           <br />
       <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" 
               AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
               GridLines="None" Width="100%" 
               onpageindexchanged="DataGrid1_PageIndexChanged" 
               ondeletecommand="DataGrid1_DeleteCommand">
           <AlternatingItemStyle BackColor="White" />
           <Columns>
               <asp:BoundColumn DataField="f_title" HeaderText="标题"></asp:BoundColumn>
               <asp:BoundColumn DataField="f_describe" HeaderText="板块描述"></asp:BoundColumn>
               <asp:BoundColumn DataField="f_moderator" HeaderText="版主" ReadOnly="True">
               </asp:BoundColumn>
               <asp:BoundColumn DataField="image_name" HeaderText="图片"></asp:BoundColumn>
               <asp:ButtonColumn CommandName="Select" HeaderText="修改板块内容" Text="编辑">
               </asp:ButtonColumn>
               <asp:ButtonColumn   CommandName="Delete" HeaderText="删除该板块" Text="删除">
               </asp:ButtonColumn>
           </Columns>
           <EditItemStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <ItemStyle BackColor="#EFF3FB" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" 
               NextPageText="下一页" PrevPageText="上一页" />
           <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

       </asp:DataGrid>         
       </div><br/>
       <div style="border:1px solid #a9cbee">

           <table border="0" cellpadding="0" cellspacing="0" 
               style="width: 100%; height: 66px;">
               <tr>
                   <td class="style1">
                       板块名称：</td>
                   <td>
                       <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="style1">
                       板块描述：</td>
                   <td>
                       <textarea id="TextArea1" runat ="server" cols="40" name="S1" rows="8"></textarea></td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="style1">
                       板块图片：</td>
                   <td>
                       <asp:FileUpload ID="FileUpload1" runat="server" />
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
                <tr>
                   <td class="style1">
                       </td>
                   <td>
                       
                       <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" 
                           CssClass="button" Height="30px" Width="82px"/>
                       
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
           </table>

       </div>
    </div>
    </form>
</body>
</html>
