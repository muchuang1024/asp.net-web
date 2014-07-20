using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class admin_login : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["CheckCode"].ToString() == TextBox3.Text.ToLower())
        {
            if (Session["user"] == null)
            {
                Session["user"] = TextBox2.Text.Trim();
            }
            conn.ConnectionString = str.ConnectionString;
            SqlDataAdapter cmd = new SqlDataAdapter("select * from admin_user where user_name ='" + TextBox2.Text.Trim() + "' AND user_password ='" + TextBox1.Text.Trim() + "'", conn);
            DataSet ds = new DataSet();
            conn.Open();
            cmd.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count <= 0)
            {
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('账号或用户名错误');</script>");
            }
            else
            {
                Response.Redirect("admin/index.aspx");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('验证码输入错误！！！');</script>"); 
        }

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
}