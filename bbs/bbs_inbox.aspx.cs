using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class html_bbs_inbox : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            imageBind();
            repeaterBind();
        }
    }

    private void imageBind()
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
    private void repeaterBind()
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from message where recipient ='" + Request.Cookies["user_info"].Value + "'", conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count == 0)
        {
            Label1.Visible = true;
            Label1.Text = "现在还没有人给你发信息。";
        }
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
    public string getState(int i)
    {
        if (i == 0)
        {
            return "未读";
        }
        else if (i == 1)
        {
            return "已读";
        }
        else
        {
            return "";
        }
    }
}