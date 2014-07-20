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

public partial class html_bbs_index : System.Web.UI.Page
{
     SqlConnection conn = new SqlConnection();
        ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
       
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            repeaterBind();
        }
    }
    public string judgeisnull(string f_id,string str,string post_id)
    {
        int f_id1 = Convert.ToInt32(f_id);
        
        StringBuilder str1 = new StringBuilder();
        if (str == "")
        {
            return "暂时没人发帖.";
        }
        else
        {
            str = GetString(str);
            str1.Append("<a href=\"bbs_showpost.aspx?=" + str + "&post_id="+post_id+"&user_id=1&f_id="+f_id1+"\">" + str  + "</a>");
            return str1.ToString();
        }
    }
    public string GetString(string str1)
    {
        if (str1 != "")
        {
            if (str1.Length > 9)
            {
                return str1.Substring(0, 9) + "..";
            }
            else
            {
                return str1;
            }
        }
        else
        {
            return "没有人发帖";
        }

    }
    private void repeaterBind()
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from section", conn );
        conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds,"section");
        parent.DataSource = ds.Tables["section"];
        SqlDataAdapter da2 = new SqlDataAdapter("select * from f", conn);
        da2.Fill(ds, "f");
        DataRelation rel = new DataRelation("f2",ds.Tables["section"].Columns["section_id"], ds.Tables["f"].Columns["section_id"],false);
        ds.Relations.Add(rel);
        Page.DataBind();
        conn.Close();
    }
    public string judeisnulldate(string str)
    {
        if (str == "")
        {
            return "暂无";
        }
        else
        {
            return (Convert.ToDateTime(str)).ToString("MM/dd HH:mm");
        }
    }
    public string Get_moderator(string moderator,string f_id)
    {
        if (moderator == "")
        {
            return "版主暂无。" + "<a href=\"bbs_apply.aspx?id="+f_id+"\">申请版主</a>";
        }
        else
        {
            return "<a href=\"bbs_userinfo.aspx?user_name="+moderator+"\">"+moderator+"</a>";
        }
    }
    public string Get_user(string moderator, string f_id)
    {
        if (moderator == "")
        {
            return "暂时没有人";
        }
        else
        {
            return "<a href=\"bbs_userinfo.aspx?user_name=" + moderator + "\">" + moderator + "</a>";
        }
    }
    public string getToday(int i)
    {
        SqlConnection conn2 = new SqlConnection();
        string str1 = "0";
        conn2.ConnectionString = str.ConnectionString;
        SqlCommand cmd = new SqlCommand("select count(*) from post where datediff(day,post_date,'" + DateTime.Now.ToString() + "') = 0 AND f_id ='" + i + "'", conn2);
        conn2.Open();
        SqlDataReader ds = cmd.ExecuteReader();
        while (ds.Read())
        {
            str1 = ds[0].ToString();
        }
        conn2.Close();
        return str1;
    }
 }
