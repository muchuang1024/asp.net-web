using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MDS.XJSON.Core;
using TrafficExam.Command;
using TrafficExam.Bll;

namespace TrafficExam.Web.SystemApplication
{
    public partial class DeleteItemTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                int id = Convert.ToInt32(Request.QueryString["ItemTitleId"].ToString());//获取题号
                Response.Write(json.Serialize(DelItemTitle(id)));//删除考题
                Response.Write("<script>alert('删除成功！');</script>");
                Response.Redirect("ItemTitleList.aspx");

            }
            catch (Exception ex)
            {
                ExceptionLogInfo log = ExceptionLogInfo.LogInstance();
                log.WriterLog(ex.ToString());
            }

        }
        /// <summary>
        /// 删除题号为itemTitleId的题目
        /// </summary>
        /// <param name="itemTitleId"></param>
        /// <returns></returns>
        private bool DelItemTitle(int itemTitleId)
        {
            BllItemTitle bllItemTitle = new BllItemTitle();
            return bllItemTitle.DeleteItemTitle(itemTitleId);
        }
    }
}