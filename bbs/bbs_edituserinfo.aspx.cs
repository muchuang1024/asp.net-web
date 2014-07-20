using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class html_edit_userinfo : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conn.ConnectionString = str.ConnectionString;
            SqlCommand cmd = new SqlCommand("select * from user_info where user_account ='" + Request.Cookies["user_info"].Value + "'", conn);
            conn.Open();
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                ImageButton1.ImageUrl = "~/images/" + da["image_name"].ToString();
                TextBox2.Text = da["user_name"].ToString();
                TextBox3.Text = da["label"].ToString();
                TextBox4.Text = da["school"].ToString();
                TextBox5.Text = da["user_email"].ToString();
                TextArea1.Value = da["user_introduce"].ToString();
            }
            conn.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sex;
        if (RadioButton1.Checked)
        {
            sex = "男";
        }
        else
        {
            sex = "女";
        }
        conn.ConnectionString = str.ConnectionString;
        SqlCommand cmd = new SqlCommand("Update  user_info set user_name='" + TextBox2.Text + "',label='" + TextBox3.Text + "',school='" + TextBox4.Text + "',user_email='" + TextBox5.Text + "',user_introduce='"+TextArea1.Value+"',user_sex='"+sex+"' " +
            " where user_account='"+Request.Cookies["user_info"].Value+"'", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextArea1.Value = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";

    }
}