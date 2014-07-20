using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewBind();
    }
         private void  GridViewBind()
    {
        SqlConnection conn = new SqlConnection();
        ConnectionStringSettings str = System.Configuration.ConfigurationManager.ConnectionStrings["123"];
        conn.ConnectionString = str.ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select * from admin_user", conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        GridView1.DataSource = ds;
   
        GridView1.DataBind();
    }
    }
