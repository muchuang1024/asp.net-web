using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class html_bbs_cookiesclear : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Request.Cookies["user_info"].Values.Clear();
        HttpCookie cook = Request.Cookies["user_info"];
        cook.Expires = DateTime.Now.AddDays(-365); 
        cook.Values.Clear(); 
        System.Web.HttpContext.Current.Response.Cookies.Set(cook); 


        Response.Redirect("bbs_index.aspx");
    }
}