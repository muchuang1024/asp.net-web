using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class html_bbs_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
        conn.ConnectionString = str.ConnectionString;
        string loginName = filter.FilterSQL(txtUser.Text.ToString());//防止sql注入
        string password = jiami.getMd5Hash(txtPwd.Text.ToString());//MD5加密
        SqlDataAdapter cmd = new SqlDataAdapter("select * from user_info where user_account='" +loginName + "' AND user_password= '" + password + "'", conn);
        conn.Open();
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('用户名不存在或密码错误。');</script>");
        }
        else
        {
           
            int i = 0;
         
               i =Convert.ToInt32(DropDownList2.SelectedValue);
                if (i != 0)
                {
                    Response.Cookies["user_info"].Expires = DateTime.Now.AddDays(i);
                }
            Response.Cookies["user_info"].Value = txtUser.Text;
            Response.Redirect("bbs_index.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}