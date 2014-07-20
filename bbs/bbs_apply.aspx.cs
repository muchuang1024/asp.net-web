using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class html_bbs_apply : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["user_info"] != null)
        {
            LabelBind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('你还没有登陆。请登录！！！');location.href='bbs_login.aspx';</script>");
        }
    }
    public void LabelBind()
    {
        conn.ConnectionString = str.ConnectionString;
        SqlCommand cmd = new SqlCommand("select * from (f inner join section on f.section_id= section.section_id )where f_id='" + Request.QueryString["id"].ToString() + "'", conn);
        conn.Open();
        SqlDataReader da = cmd.ExecuteReader();
        while (da.Read())
        {
            Label1.Text = da["section_name"].ToString();
            Label2.Text = da["f_title"].ToString();
        }
          conn.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Inertapply();
       
    }
    private void Inertapply()
    {
        int f_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        conn.ConnectionString = str.ConnectionString;
        int state = 0;
        if (RadioButton1.Checked)
        {
            state = 1;
        }
        else
        {
            state = 0;
        }
        SqlCommand cmd = new SqlCommand("Insert into apply (apply_name,apply_reason,f_id,state,apply_date) values('"+Request.Cookies["user_info"].Value+"',"+
            "'"+TextArea1.Value+"','"+f_id+"','"+state+"','"+DateTime.Now.ToString()+"')",conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('你申请已提交，待管理员回复。');location.href='bbs_index.aspx';</script>");
    }
}