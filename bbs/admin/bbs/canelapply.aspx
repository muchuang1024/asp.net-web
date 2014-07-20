<%@ Page Language="C#" AutoEventWireup="true" CodeFile="canelapply.aspx.cs" Inherits="admin_bbs_canelapply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style="border:1px solid #76BEF0; margin-left:10px">
    
       &nbsp;选择你要取消版主所在的子板块 <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" 
            AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br /><br />
    
    <asp:DataGrid ID="DataGrid1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="100%">
        <AlternatingItemStyle BackColor="White" />
        <Columns>
            <asp:BoundColumn DataField="f_title" HeaderText="所在的子版块"></asp:BoundColumn>
            <asp:BoundColumn DataField="f_moderator" HeaderText="版主账号"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="取消版主职位">
              
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument ='<%# Eval("f_id") %>' onclick="LinkButton1_Click">取消</asp:LinkButton>
                </ItemTemplate>
              
            </asp:TemplateColumn>
        </Columns>
        <EditItemStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataGrid>
    </div>
    </form>
</body>
</html>
