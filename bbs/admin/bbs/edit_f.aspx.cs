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
public partial class admin_bbs_edit_f : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    SqlConnection conn1 = new SqlConnection();
    SqlConnection conn2 = new SqlConnection();
    ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dropBind();
        }
    }
    private void dropBind()
    {
           conn.ConnectionString = str.ConnectionString;
           
            SqlDataAdapter da = new SqlDataAdapter("select * from section ", conn);
            conn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownList1.DataSource = ds.Tables[0].DefaultView;
            DropDownList1.DataValueField = ds.Tables[0].Columns[0].ColumnName;
            DropDownList1.DataTextField = ds.Tables[0].Columns[1].ColumnName;
            DropDownList1.DataBind();
            NewMethod(Convert.ToInt32(DropDownList1.SelectedValue));
            conn.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataGrid1.CurrentPageIndex = 0;
        int section_id = Convert.ToInt32(DropDownList1.SelectedValue);
        NewMethod(section_id);
    }

    private void NewMethod(int section_id)
    {
        conn1.ConnectionString = str.ConnectionString;
        SqlDataAdapter cmd = new SqlDataAdapter("select * from f where section_id ='" + section_id + "'", conn1);
        conn1.Open();
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        conn1.Close();
        DataGrid1.DataSource = ds;
        this.DataGrid1.DataKeyField = "f_id";
        DataGrid1.DataBind();
    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
        int section_id = Convert.ToInt32(DropDownList1.SelectedValue);
        NewMethod(section_id);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.ConnectionString = str.ConnectionString; 
        int section_id = Convert.ToInt32(DropDownList1.SelectedValue);
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
        else if (type == "png")
        {
            i = 1;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('文件格式错误。');</script>"); 
        }

        if (FileUpload1.HasFile && i == 1)
        {
            string filename = FileUpload1.FileName;
            savepath += DateTime.Now.ToString("MMddHHmm") + "_" + filename;
            FileUpload1.SaveAs(savepath);
            string name = Path.GetFileName(savepath);
            SqlCommand cmd = new SqlCommand("Insert into f (f_title,f_describe,section_id,image_name) values('" + TextBox1.Text + "','" + TextArea1.Value + "','" + section_id + "','"+name+"')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            NewMethod(section_id);
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('添加板块成功。');</script>"); 
        }
    }
    protected void DataGrid1_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
         int section_id = Convert.ToInt32(DropDownList1.SelectedValue);
         string f_id = this.DataGrid1.DataKeys[e.Item.ItemIndex].ToString();
         string sql2 = "select post_id from post where f_id = '" + f_id + "'";
         conn1.ConnectionString = str.ConnectionString;
         conn2.ConnectionString = str.ConnectionString;
         SqlCommand cmd2 = new SqlCommand(sql2, conn1);
         conn1.Open();
            SqlDataReader sdr1 =cmd2.ExecuteReader();
            while (sdr1.Read())
            {
                int post_id = Convert.ToInt32(sdr1["post_id"]);
                conn2.Open();
                SqlCommand cmd3 = new SqlCommand("delete from  reply where post_id ='" + post_id + "'",conn2);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("delete from  post where post_id ='" + post_id + "'",conn2);
                cmd4.ExecuteNonQuery();
                conn2.Close();
            }
            conn1.Close();
            conn2.Open();
            SqlCommand cmd5 = new SqlCommand("delete from f where f_id='" + f_id + "'", conn2);
            cmd5.ExecuteNonQuery();
            conn2.Close();

            NewMethod(section_id);
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('删除板块成功。');</script>"); 
       
    }
}