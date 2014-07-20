using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class html_posting : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conn.ConnectionString = str.ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from section order by section_id asc", conn);
            SqlDataAdapter da1 = new SqlDataAdapter("select * from f where section_id=(select min(section_id) from section )", conn);
            conn.Open();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            da.Fill(ds);
            DropDownList2.DataSource = ds.Tables[0].DefaultView;
            DropDownList2.DataValueField = ds.Tables[0].Columns[0].ColumnName;
            DropDownList2.DataTextField = ds.Tables[0].Columns[1].ColumnName;
            DropDownList2.DataBind();
            da1.Fill(ds1);
            DropDownList3.DataSource = ds1.Tables[0].DefaultView;
            DropDownList3.DataValueField = ds1.Tables[0].Columns[0].ColumnName;
            DropDownList3.DataTextField = ds1.Tables[0].Columns[1].ColumnName;
            DropDownList3.DataBind();
            conn.Close();
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from f where section_id='"+DropDownList2.SelectedValue.ToString()+"'", conn);
        conn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList3.DataSource = ds.Tables[0].DefaultView;
        DropDownList3.DataValueField = ds.Tables[0].Columns[0].ColumnName;
        DropDownList3.DataTextField = ds.Tables[0].Columns[1].ColumnName;
        DropDownList3.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["user_info"] == null)
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('你还没有登陆。请登录！！！');location.href='bbs_login.aspx';</script>");
        }
        else
        {
            int id = 0;
            conn.ConnectionString = str.ConnectionString;
            if (RadioButton1.Checked)
            {
                string upsqlpost = "insert into post (post_title,post_body,f_id,user_name,post_date) values ('" + TextBox2.Text + "','" + TextArea1.Value + "','" + DropDownList3.SelectedValue.ToString() + "','" + Request.Cookies["user_info"].Value.ToString() + "','" + DateTime.Now.ToString() + "') Select @@IDENTITY ";
                SqlCommand cmd1 = new SqlCommand(upsqlpost, conn);
                conn.Open();
                SqlDataReader da = cmd1.ExecuteReader();

                while (da.Read())
                {
                    id = Convert.ToInt32(da[0]);
                }
                conn.Close();
                string sql1 = "Update user_info set score = score+20 where user_account ='" + Request.Cookies["user_info"].Value + "'";
                string sql = "Update f  set  post_id =" + id + ",post = post + 1,f_lastpost_name ='"+Request.Cookies["user_info"].Value+"',last_post_title ='" + TextBox2.Text + "',f_lastpost_time='" + DateTime.Now.ToString() + "',user_id=(select user_id from user_info where user_account ='" + Request.Cookies["user_info"].Value.ToString() + "')  where  f_id ='" + DropDownList3.SelectedValue.ToString() + "'";//在用户表返回user_id,在更新f表中的f_id为DropDownList3.SelectValue数据
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                SqlCommand cmd3 = new SqlCommand(sql1, conn);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('恭喜你，发帖成功。');</script>");

            }
            else if (RadioButton2.Checked)
            {
                int gold = 0;
                SqlCommand da = new SqlCommand("select gold from user_info where user_account ='" + Request.Cookies["user_info"].Value + "'", conn);
                conn.Open();
                SqlDataReader ds = da.ExecuteReader();
                while (ds.Read())
                {
                    gold = Convert.ToInt32(ds["gold"].ToString());
                }

                conn.Close();
                if (gold >= 50)
                {

                    string upsqlpost = "insert into post (post_title,post_body,f_id,user_name,post_date,class) values ('" + TextBox2.Text + "','" + TextArea1.Value + "','" + DropDownList3.SelectedValue.ToString() + "','" + Request.Cookies["user_info"].Value.ToString() + "','" + DateTime.Now.ToString() + "',1) Select @@IDENTITY ";
                    SqlCommand cmd1 = new SqlCommand(upsqlpost, conn);
                    conn.Open();
                    SqlDataReader da1 = cmd1.ExecuteReader();

                    while (da1.Read())
                    {
                        id = Convert.ToInt32(da1[0]);
                    }
                    conn.Close();
                    string sql1 = "Update user_info set score = score+20,gold =gold-50 where user_account ='" + Request.Cookies["user_info"].Value + "'";
                    string sql = "Update f  set   post_id =" + id + ",f_lastpost_name ='" + Request.Cookies["user_info"].Value + "',last_post_title ='" + TextBox2.Text + "',f_lastpost_time='" + DateTime.Now.ToString() + "',user_id=(select user_id from user_info where user_account ='" + Request.Cookies["user_info"].Value.ToString() + "')   where  f_id ='" + DropDownList3.SelectedValue.ToString() + "'";//在用户表返回user_id,在更新f表中的f_id为DropDownList3.SelectValue数据
                    SqlCommand cmd2 = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    SqlCommand cmd3 = new SqlCommand(sql1, conn);
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                    Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('恭喜你，发积分帖成功。');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('对不起，你当前只有" + gold + "E币，不足50点。你可以通过回复帖子赚取E币。');</script>");
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}