using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_admin_top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        username.Text = Session["user"].ToString();
    }
    protected void btnQuit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script language=javascript>javascript:window.open('../admin_login.aspx',target='_parent');</script>");
      
    }
}