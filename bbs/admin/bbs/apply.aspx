<%@ Page Language="C#" AutoEventWireup="true" CodeFile="apply.aspx.cs" Inherits="admin_bbs_apply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/txt.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="lianjie"  style="border:1px solid #76BEF0; margin-left:10px">
    
        选择你要查看申请所在的子板块&nbsp;<asp:DropDownList 
            ID="DropDownList2" runat="server" AutoPostBack="True"  Width="100px"
            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
        <br /><br />
    <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" Width="100%" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
        <AlternatingItemStyle BackColor="White" />
        <Columns>
            <asp:BoundColumn DataField="apply_name" HeaderText="申请者姓名"></asp:BoundColumn>
            <asp:BoundColumn DataField="apply_reason" HeaderText="申请理由"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="之前是否当版主">
                <ItemTemplate>
                    <%# getyes(Eval("state").ToString())%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="apply_date" HeaderText="申请时间"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="是否同意申请">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1"  CommandArgument='<% #Eval("apply_id") %>' 
                        runat="server" onclick="LinkButton1_Click">任命</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <EditItemStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <PagerStyle NextPageText="下一页" PrevPageText="上一页" BackColor="#2461BF" 
            ForeColor="White" HorizontalAlign="Center" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>
    </div>
    </form>
</body>
</html>
