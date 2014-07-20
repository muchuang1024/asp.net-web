using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
public partial class html_bbs_userinfo : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql;
        string sql1;
        if (Request.QueryString["user_name"] != null)
        {
            sql = "select * from user_info where user_account='" + Request.QueryString["user_name"].ToString() + "'";
            sql1 = "select * from post where user_name='" + Request.QueryString["user_name"].ToString() + "'";
            Repeater2DataBind(sql);
            Repeater1DataBind(sql1);
        }
        else if (Request.QueryString["user_id"] != null)
        {
            sql = "select * from user_info where user_id=" + Convert.ToInt32(Request.QueryString["user_id"].ToString() )+ "";
            sql1 = "select * from (user_info inner join post on user_info.user_account = post.user_name) where user_id=" + Convert.ToInt32(Request.QueryString["user_id"].ToString()) + "";
            Repeater2DataBind(sql);
            Repeater1DataBind(sql1);
        }
       
    }
    public string GetIsNull(string str)
    {
        if (str == "")
        {
            return "Ta没有填写";
        }
        else {
            return str;
        }
    }
    public string Getintroduce(string str)
    {
        if (str == "")
        {
            return "TA还没有填写个人简介哦 ";
        }
        else 
        {
            return str;
        }
    }
    private void  Repeater2DataBind(string sql)
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        Repeater2.DataSource = ds;
        Repeater2.DataBind();
    }
    private void Repeater1DataBind(string sql)
    {
        Label1.Visible = false;
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count<=0)
        {
            Label1.Visible = true;
            Label1.Text = "该用户还没有发表过帖子哦";
        }
        else
        {
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }
    public string getClass(int score)
    {
        getClass1 score1 = new getClass1(score);
        return score1.getScore();

    }
    public string judgeisnull(string str)
    {
        StringBuilder str1 = new StringBuilder();
        if (str == "")
        {
            return "暂时没有人评论.";
        }
        else
        {
            str1.Append("<a href=\"bbs_userinfo.aspx?user_name=" + str + "\">"+str+"</a>");
            return str1.ToString();
        }
    }
    public string judeisnulldate(string str)
    {
        if (str == "")
        {
            return "";
        }
        else
        {
            return (Convert.ToDateTime(str)).ToString("MM/dd HH:mm");
        }
    }
}