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

public partial class html_bbs_showsection : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1DataBind();
        }
    }
    public string getimage(string i)
    {
        if (i == "2")
        { 
           return "~//images//精品.png";
        }
        else if (i == "1")
        {
            return "~//images//积分.png";
        }
        else
        {
            return "~//images//普通.png";
        }
    }
    private void DataList1DataBind()
    {
        string f_id = Request.QueryString["f_id"].ToString();
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from post where f_id ='" + f_id + "' order by class desc,post_date desc", conn);
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
            this.prePage.NavigateUrl = "bbs_showsection.aspx?pageindex=" + Convert.ToInt32(curPage - 1) + "&f_id=" + Convert.ToInt32(Request.QueryString["f_id"].ToString());
        }
        if (!objPage.IsLastPage)
        {
            nextPage.Enabled = true;
            this.nextPage.NavigateUrl = "bbs_showsection.aspx?pageindex=" + Convert.ToInt32(curPage + 1) + "&f_id=" + Convert.ToInt32(Request.QueryString["f_id"].ToString());
        }
        if (objPage.IsLastPage)
        {
            nextPage.Enabled = false;
        }
        Repeater1.DataSource = objPage;
        Repeater1.DataBind();

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
           str1.Append("<a href=\"bbs_userinfo.aspx?user_name='"+str+"'\">"+str+"</a>");
           return str1.ToString() ;
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["user_info"] != null)
        {
            Response.Redirect("posting.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('你还没有登陆。请登录！！！');location.href='bbs_login.aspx';</script>");
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["user_info"] != null)
        {
            Response.Redirect("posting.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('你还没有登陆。请登录！！！');location.href='bbs_login.aspx';</script>");

        }
    }
}