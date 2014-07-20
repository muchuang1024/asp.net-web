using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class html_bbs_headimage : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        imageBind();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string savepath = Server.MapPath("~/images/");
        int i=0;
        string file_path = FileUpload1.PostedFile.FileName.ToLower();
          string type =file_path.Substring(file_path.LastIndexOf(".") + 1).ToLower();//判断上传文件类型
  
        if (type == "jpg")
        {
            i = 1;
        }
        else if (type == "jpeg")
        {
            i = 1;
        }
        else if (type == "bmp")
        {
            i = 1;
        }
        else if (type == "gif")
        {
            i = 1;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('文件格式错误。');</script>"); 
        }    

        if (FileUpload1.HasFile&&i==1)
        {
            string filename = FileUpload1.FileName;
            savepath += DateTime.Now.ToString("MMddHHmm")+"_" + filename;
            FileUpload1.SaveAs(savepath);
            string name = Path.GetFileName(savepath);
           conn.ConnectionString = str.ConnectionString;
           SqlCommand cmd = new SqlCommand("Update user_info set image_name ='" + name + "' where user_account = '" + Request.Cookies["user_info"].Value + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            imageBind();
        }
    }
   
}