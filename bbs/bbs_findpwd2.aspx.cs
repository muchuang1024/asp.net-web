using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class html_findpwd2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NewMethod();
        }
    }

    private void NewMethod()
    {
        conn.ConnectionString = str.ConnectionString;
       
        SqlDataAdapter da = new SqlDataAdapter("select * from user_info where user_account ='"+Request.QueryString["user_name"].ToString()+"'",conn);
        conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        Label1.Text = ds.Tables[0].Rows[0]["user_question"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from user_info where user_answer ='" + TextBox1.Text + "' AND user_account ='" + Request.QueryString["user_name"] .ToString()+ "'", conn);
        conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('密保问题输入错误');</script>");
        }
        else
        {
            conn.Open();
            string pwd="123";
            string password = jiami.getMd5Hash(pwd);
            string sql = "update user_info set user_password = '" + password + "' where user_account = '" + Request.QueryString["user_name"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Label2.Text = "你的密码已重置为123，请到个人中心及时修改";
        }
    }
}