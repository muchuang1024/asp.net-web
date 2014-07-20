using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class html_bbs_message : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
       
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["user_info"] != null)
        {
            if (Request.QueryString["user_name"] == null)
            {

            }
            else
            {
                TextBox2.Text = Request.QueryString["user_name"].ToString();
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('你还没有登陆。请登录！！！');</script>");
            Response.Redirect("bbs_login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        conn.ConnectionString = str.ConnectionString;
        SqlCommand cmd = new SqlCommand("Insert into message (recipient,sender,message_date,message_title,message_main) values('" + TextBox2.Text + "','" + Request.Cookies["user_info"].Value + "','" + DateTime.Now.ToString() + "',"+
            "'" + TextBox3.Text + "','" + TextArea1.Value + "')", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}