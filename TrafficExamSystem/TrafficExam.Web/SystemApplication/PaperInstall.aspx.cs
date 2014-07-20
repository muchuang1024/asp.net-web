using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrafficExam.Web.SystemApplication
{
    public partial class PaperInstall : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo myCI = new System.Globalization.CultureInfo("zh-CN", true);
            myCI.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            System.Threading.Thread.CurrentThread.CurrentCulture = myCI;
        }
    }
}