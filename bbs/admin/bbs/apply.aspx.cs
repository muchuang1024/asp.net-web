using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_bbs_apply : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NewMethod();
            DataGridBind();
        }

    }
   
    public string getyes(string i)
    {
        if (i == "1")
        {
            return "担任过";
        }
        else if (i == "0")
        {
            return "否";
        }
        else
        {
            return "";
        }
    }

    private void NewMethod()
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from f ", conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        DropDownList2.DataSource = ds.Tables[0].DefaultView;
        DropDownList2.DataValueField = ds.Tables[0].Columns[0].ColumnName;
        DropDownList2.DataTextField = ds.Tables[0].Columns[1].ColumnName;
        DropDownList2.DataBind();
        conn.Close();
    }
    public void DataGridBind()
    {
        int f_id = Convert.ToInt32(DropDownList2.SelectedValue);
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from apply where apply_allow =0 AND f_id=" + f_id + "", conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        DataGrid1.DataSource = ds;
        DataGrid1.DataKeyField = "apply_id";
        DataGrid1.DataBind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataGridBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int f_id = Convert.ToInt32(DropDownList2.SelectedValue);
        conn.ConnectionString = str.ConnectionString;
        LinkButton lb = (LinkButton)sender;
        int apply_id = Convert.ToInt32(lb.CommandArgument);
        SqlCommand cmd2 = new SqlCommand("Update apply set apply_allow =0 where f_id='" + f_id + "'", conn);
        SqlCommand cmd = new SqlCommand("Update apply set apply_allow =1 where apply_id='" + apply_id + "'", conn);
        SqlCommand cmd1 = new SqlCommand("Update f set f_moderator =(select apply_name from apply where apply_id='"+apply_id+"') where f_id=(select f_id from apply where apply_id='" + apply_id + "')", conn);
        conn.Open();
        cmd2.ExecuteNonQuery();
        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        conn.Close();
        DataGridBind();
    }
}