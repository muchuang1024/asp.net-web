using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_bbs_canelapply : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dropBind();
          
        }

    }
    private void dropBind()
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from f where f_moderator is not null", conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        DropDownList1.DataSource = ds.Tables[0].DefaultView;
        DropDownList1.DataValueField = ds.Tables[0].Columns[0].ColumnName;
        DropDownList1.DataTextField = ds.Tables[0].Columns[1].ColumnName;
        DropDownList1.DataBind();
        conn.Close();
        if (DropDownList1.SelectedIndex > -1)
        {
            int i = Convert.ToInt32(DropDownList1.SelectedValue);
            DataGridBind(i);
        }
        else
            DataGridBind(-1);
    }
    private void DataGridBind(int i)
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter cmd = new SqlDataAdapter("select * from f  where  f.f_id ='"+i+"'", conn);
        conn.Open();
      DataSet ds= new DataSet();
      cmd.Fill(ds);
        conn.Close();
        DataGrid1.DataSource = ds;
        this.DataGrid1.DataKeyField = "f_id";
        DataGrid1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(DropDownList1.SelectedValue);
        DataGridBind(i);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(DropDownList1.SelectedValue);
        conn.ConnectionString = str.ConnectionString;
        LinkButton lb = (LinkButton)sender;
        int f_id = Convert.ToInt32(lb.CommandArgument);
        SqlCommand cmd = new SqlCommand("Update f set f_moderator =null where  f_id ='"+f_id+"'", conn);
        SqlCommand cmd1 = new SqlCommand("Update apply set apply_allow =0 where  f_id ='" + f_id + "'", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Open();
        cmd1.ExecuteNonQuery();
        conn.Close();
        dropBind();
    }
}