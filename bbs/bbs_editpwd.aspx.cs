using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class html_bbs_editpwd : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conn.ConnectionString = str.ConnectionString;
            SqlCommand cmd = new SqlCommand("select image_name from user_info where user_account ='" + Request.Cookies["user_info"].Value + "'", conn);
            conn.Open();
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                ImageButton1.ImageUrl = "~/images/" + da[0].ToString();
            }
            conn.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pwd = jiami.getMd5Hash(TextBox2.Text);

        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter cmd = new SqlDataAdapter("select * from user_info where user_account='" + Request.Cookies["user_info"].Value + "' AND user_password= '" + pwd + "'", conn);
        conn.Open();
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('旧密码输入错误。');</script>");
        }
        else
        {
            pwd = jiami.getMd5Hash(TextBox3.Text);
            SqlCommand cmd1 = new SqlCommand("Update user_info set user_password ='" + pwd + "' where user_account='" + Request.Cookies["user_info"].Value + "'", conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
        
    }
}