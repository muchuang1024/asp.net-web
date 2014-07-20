using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class html_bbs_showpost : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
        datalist1Bind();
        if (!IsPostBack)
        {
            DataList2DataBind();
            Addren();
      
                judge();
              
            
        }
       
    }
    public string getJuge(int i)
    {
        if (i == 0)
        {
            return "沙发";
        }
        else if (i == 1)
        {
            return "板凳";
        }
        else if (i == 2)
        {
            return "打地铺";
        }
        else
        {
            i = i + 1;
            return "第" + i + "楼";
        }
    }

    public void lb_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender ;
        TextArea1.Value = lb.CommandArgument.ToString()+"</br>";
       

    }
    private void judge()
    {

        if (Request.Cookies["user_info"] != null)
        {
            int post_id = Convert.ToInt32(Request.QueryString["post_id"].ToString());
            int f_id = Convert.ToInt32(Request.QueryString["f_id"].ToString());
            conn.ConnectionString = str.ConnectionString;
            SqlDataAdapter cmd = new SqlDataAdapter("select * from f where f_moderator ='" + Request.Cookies["user_info"].Value + "' AND f_id =" + f_id + "", conn);
            conn.Open();
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count < 1)
            {

            }
            else
            {
                SqlDataAdapter cmd1 = new SqlDataAdapter("select class from post where post_id =" + post_id + "", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                cmd1.Fill(ds1);
                conn.Close();
                LinkButton lb1 = (LinkButton)DataList1.Items[0].FindControl("lb1");
                LinkButton lb2 = (LinkButton)DataList1.Items[0].FindControl("lb2");
                LinkButton lb4 = (LinkButton)DataList1.Items[0].FindControl("lb3");
                lb1.Visible = false;
                lb2.Visible = false;
                lb4.Visible = false;
                if (Convert.ToInt32(ds1.Tables[0].Rows[0]["class"].ToString()) == 2)
                {
                    lb4.Visible = true;
                }
                else if (Convert.ToInt32(ds1.Tables[0].Rows[0]["class"].ToString()) <= 1)
                {
                    lb1.Visible = true;
                }
                lb2.Visible = true;
                for (int i = 0; i < DataList2.Items.Count; i++)
                {
                    LinkButton lb3 = (LinkButton)DataList2.Items[i].FindControl("lb3");
                    lb3.Visible = true;
                }
            }
        }
        
    }
    private void datalist1Bind()
    {
        string post_id = Request.QueryString["post_id"].ToString();
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from (post inner join user_info on post.user_name=user_info.user_account"
            + ") where post_id ='" + post_id + "' ", conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        DataList1.DataSource = ds;
        DataList1.DataBind();
        judge();
    }
    private void Addren()
    {
        conn.ConnectionString = str.ConnectionString;
        SqlCommand cmd = new SqlCommand("update post set post_count = post_count+1 where post_id ='" + Request.QueryString["post_id"].ToString() + "'",conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    private void DataList2DataBind()
    {
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from (reply inner join user_info on reply.user_id = user_info.user_id)"
            + "where reply.post_id = '" + Request.QueryString["post_id"].ToString() + "'", conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        PagedDataSource objPage = new PagedDataSource();
        objPage.DataSource = ds.Tables[0].DefaultView;
        objPage.AllowPaging = true;
        objPage.PageSize = 20;
        int curPage;
        if (Request.QueryString["pageindex"] != null)
        {
            curPage = Convert.ToInt32(Request.QueryString["pageindex"].ToString());

        }

        else
            curPage = 1;
        objPage.CurrentPageIndex = curPage - 1;//设置当前分页的索引
        this.Label1.Text = "当前页：第" + curPage.ToString() + "页";
        this.Label2.Text = "共有" + objPage.PageCount.ToString() + "页 ";
        if (objPage.IsFirstPage)
        {
            prePage.Enabled = false;
        }
        if (!objPage.IsFirstPage)//判断当前页是否为第一页
        {
            prePage.Enabled = true;
            this.prePage.NavigateUrl = "bbs_showpost.aspx?pageindex=" + Convert.ToInt32(curPage - 1) + "&f_id=" + Convert.ToInt32(Request.QueryString["f_id"].ToString()) + "&post_id=" + Convert.ToInt32(Request.QueryString["post_id"].ToString());
        }
        if (!objPage.IsLastPage)
        {
            nextPage.Enabled = true;
            this.nextPage.NavigateUrl = "bbs_showpost.aspx?pageindex=" + Convert.ToInt32(curPage + 1) + "&f_id=" + Convert.ToInt32(Request.QueryString["f_id"].ToString()) + "&post_id=" + Convert.ToInt32(Request.QueryString["post_id"].ToString());
        }
        if (objPage.IsLastPage)
        {
            nextPage.Enabled = false;
        }
        DataList2.DataSource = objPage;

        DataList2.DataBind();

    }
     protected void lb1_Click(object sender, EventArgs e)
     {
         conn.ConnectionString = str.ConnectionString;
         LinkButton btn = (LinkButton)sender;
         int reply = Convert.ToInt32(btn.CommandArgument);
         SqlCommand cmd = new SqlCommand("Update post set class =2 where post_id ='" + reply + "'", conn);
         conn.Open();
         cmd.ExecuteNonQuery();
         conn.Close();
         Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('加精已成功。该帖子已为精华帖.');</script>");
         DataList2DataBind();
            
         judge();
    
     }
     protected void lb2_Click(object sender, EventArgs e)
     {
         conn.ConnectionString = str.ConnectionString;
         LinkButton btn = (LinkButton)sender;
         int post_id = Convert.ToInt32(btn.CommandArgument);
         SqlCommand cmd = new SqlCommand("delete from post where post_id ='" + post_id + "'", conn);
         SqlCommand cmd2 = new SqlCommand("delete from reply where post_id ='" + post_id + "'", conn);
         conn.Open();
         cmd.ExecuteNonQuery();
         cmd2.ExecuteNonQuery();
         conn.Close();
          Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('该帖子的全部内容已被全部删除。点击回到首页。');location.href='bbs_index.aspx';</script>");
         
     }
     protected void lb4_Click(object sender, EventArgs e)
     {
         conn.ConnectionString = str.ConnectionString;
         LinkButton btn = (LinkButton)sender;
         int reply = Convert.ToInt32(btn.CommandArgument);
         SqlCommand cmd = new SqlCommand("Update post set class =0 where post_id ='" + reply + "'", conn);
         conn.Open();
         cmd.ExecuteNonQuery();
         conn.Close();
         Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('取消加精已成功。该帖子已为普通帖.');</script>");
         DataList2DataBind();
         judge();
     }
    protected void lb3_Click(object sender, EventArgs e)
    {
        conn.ConnectionString = str.ConnectionString;
        LinkButton btn = (LinkButton)sender;
        int reply = Convert.ToInt32(btn.CommandArgument);
        SqlCommand cmd = new SqlCommand("delete from reply where reply_id ='" + reply + "'",conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        DataList2DataBind();
        Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('该回复也被删除。');</script>");
        judge();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
    
        if (Request.Cookies["user_info"] != null)
        {
            string user_name = Request.Cookies["user_info"].Value.ToString();
            string post_id = Request.QueryString["post_id"].ToString();
            conn.ConnectionString = str.ConnectionString;
            SqlCommand cmd = new SqlCommand("Insert into reply (reply_body,user_id,reply_date,post_id) values ('" + TextArea1.Value + "',(select user_id from user_info where user_account='" + user_name + "'),'" + DateTime.Now.ToString() + "','" + post_id + "' ) Select @@IDENTITY", conn);
           
            int id = 0;
            conn.Open();
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                id = Convert.ToInt32(da[0]);
            }
            conn.Close();
            SqlCommand cmd1 = new SqlCommand("Update post set post_replynum = post_replynum +1,post_lastname ='" + user_name + "', reply_lastid ="
                + "(select user_id from user_info where user_account='" + user_name + "'),last_replydate='" + DateTime.Now.ToString() + "' where post_id='" + post_id + "' ", conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            SqlCommand cmd2 = new SqlCommand("Update user_info set score = score +5 ,gold = gold +5 where user_account ='"+Request.Cookies["user_info"].Value+"' ",conn);
            SqlCommand cmd3 = new SqlCommand("Update f set topic = topic+1 where f_id  = (select f_id from post where post_id ='" + post_id + "')", conn);
            conn.Open();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            conn.Close();
            DataList2DataBind();
            datalist1Bind();
            
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('你还没有登陆。请登录！！！');location.href='bbs_login.aspx';</script>");
            
        }
    }
    public string getClass(int score)
    {
        getClass1 score1 =new  getClass1(score);
        return score1.getScore();
        
    }
}