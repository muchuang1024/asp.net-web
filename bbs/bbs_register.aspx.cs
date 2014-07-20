using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class html_bbs_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
        conn.ConnectionString = str.ConnectionString;
        string loginName = filter.FilterSQL(txtUser.Text.ToString());//防止sql注入
        string userPassword = jiami.getMd5Hash(txtPwd.Text.ToString());//md5加密
        string sql="select user_account from user_info where user_account = '"+loginName+"'";
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds,"user_info");
        if (ds.Tables["user_info"].Rows.Count > 0)
        {
            Response.Write("<script language='javascript'>alert('对不起，该用户名已注册');</script>");
             
        }
        string str1="";
        if (rbtnBoy.Checked)
        {
            str1 = "男";
        }
        else
        {
            str1 = "女";
        }
        try
        {
           
            SqlCommand cmd = new SqlCommand("Insert into user_info (user_sex,user_account,user_password,user_email,user_question,user_answer,user_introduce,user_date,school,label) values ('"+str1+"', '"+loginName+"','" + userPassword + "', '" + txtEmail.Text + "','" + txtSecure.Text + "','" + txtAnswer.Text + "','" + txtIntro.Text + "','" + DateTime.Now.ToString() + "','"+txtSchool.Text+"','"+txtTag.Text+"')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("bbs_login.aspx");
         
        }
        catch (Exception b)
        {
            
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('对不起，现在暂时不能注册请稍后再试！');</script>");
            
        }
        finally
        {
            conn.Close();  
        }
    }
   
}