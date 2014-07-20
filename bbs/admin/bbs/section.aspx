<%@ Page Language="C#" AutoEventWireup="true" CodeFile="section.aspx.cs" Inherits="admin_bbs_section" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/txt.css" />
</head>
<body>
    <form id="form1" runat="server">
   <div style="border:1px solid #a9cbee; width: 100%; min-height:200px;">
       <div id="Div1" style="100%">
&nbsp;<span style="font-size:larger; font-weight:bold; line-height:20px"> <img src="../images/lun.GIF" alt="论坛"  style="width: 39px; margin-top: 0px; height: 30px;" />
论坛管理---------添加板块</span>
           <br /><br />
       </div>
        <div id="content">
        <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" ondeletecommand="DataGrid1_DeleteCommand" 
                onpageindexchanged="DataGrid1_PageIndexChanged" Width="100%" 
                CellPadding="4" ForeColor="#333333" GridLines="None" 
                oneditcommand="DataGrid1_EditCommand">
            <AlternatingItemStyle BackColor="White" />
            <Columns>
                <asp:BoundColumn DataField="section_name" HeaderText="板块名称"></asp:BoundColumn>
                <asp:ButtonColumn CommandName="Delete" HeaderText="删除板块" Text="删除">
                </asp:ButtonColumn>
                <asp:EditCommandColumn CancelText="取消" EditText="编辑" HeaderText="编辑板块" 
                    UpdateText="更新"></asp:EditCommandColumn>
            </Columns>
            <EditItemStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <PagerStyle NextPageText="下一页" 
                PrevPageText="上一页" BackColor="#2461BF" ForeColor="White" 
                HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:DataGrid>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加板块" CssClass="button" />
        </div>
   </div>
    </form>
</body>
</html>
