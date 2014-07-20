using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class html_bbs_readmessage : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        imageBind();
        message();
    }
    private void message()
    {
        int message_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        conn.ConnectionString = str.ConnectionString;
        SqlCommand cmd1 = new SqlCommand("Update message set state =1 where message_id='"+message_id+"'",conn);
        SqlDataAdapter cmd= new SqlDataAdapter("select * from message where message_id ="+message_id+"", conn);
        DataSet ds = new DataSet();
        conn.Open();
        cmd.Fill(ds);
        conn.Close();
        conn.Open();
        cmd1.ExecuteNonQuery();
        conn.Close();
        repeater1.DataSource = ds;
        repeater1.DataBind();
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
}