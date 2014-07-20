using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class admin_bbs_section : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    SqlConnection conn1 = new SqlConnection();
    SqlConnection conn2 = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DatabindDataGrid();
        }
    }
    private void DatabindDataGrid()
    {
        conn.ConnectionString = str.ConnectionString;
       
        SqlDataAdapter da = new SqlDataAdapter("select * from section", conn);
        conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        this.DataGrid1.DataKeyField = "section_id";
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
        DatabindDataGrid();
    }
    protected void DataGrid1_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string section_id = this.DataGrid1.DataKeys[e.Item.ItemIndex].ToString();
      
        conn.ConnectionString = str.ConnectionString;
        conn1.ConnectionString = str.ConnectionString;
        conn2.ConnectionString = str.ConnectionString;
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete from section where section_id ='" + section_id + "'", conn);
        cmd.ExecuteNonQuery();
        string sql = "select f_id from f where section_id = '" + section_id + "'";
        SqlCommand cmd1 = new SqlCommand(sql, conn);
        SqlDataReader sdr = cmd1.ExecuteReader();
        while (sdr.Read())
        {
            int id = Convert.ToInt32(sdr["f_id"]);
           
            string sql2 = "select post_id from post where f_id = '" + id + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn1);
            conn1.Open();
            SqlDataReader sdr1 =cmd2.ExecuteReader();
            while (sdr1.Read())
            {
                int post_id = Convert.ToInt32(sdr1["post_id"]);
                conn2.Open();
                SqlCommand cmd3 = new SqlCommand("delete from  reply where post_id ='" + post_id + "'",conn2);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("delete from  post where post_id ='" + post_id + "'",conn2);
                cmd4.ExecuteNonQuery();
                conn2.Close();
            }
            conn1.Close();
            conn2.Open();
            SqlCommand cmd5 = new SqlCommand("delete from f where f_id='" + id + "'", conn2);
            cmd5.ExecuteNonQuery();
            conn2.Close();
        }
        conn.Close();
        this.DatabindDataGrid();
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.ConnectionString = str.ConnectionString;
        SqlCommand  cmd =new SqlCommand("insert into section (section_name) values ('"+TextBox1.Text+"')",conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        DatabindDataGrid();
        TextBox1.Text = "";
    }
    protected void DataGrid1_EditCommand(object source, DataGridCommandEventArgs e)
    {

    }
}