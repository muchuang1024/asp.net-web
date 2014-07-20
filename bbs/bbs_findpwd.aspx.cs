using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class html_bbs_findpwd : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da =new SqlDataAdapter("select * from user_info where user_account ='"+TextBox1.Text+"'",conn);
        conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count >= 1)
        {
            Response.Redirect("bbs_findpwd2.aspx?user_name=" + TextBox1.Text + "");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('请输入正确的用户名.');</script>");
        }
    }
}