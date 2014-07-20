using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MDS.XJSON.Core;
using TrafficExam.Command;
using TrafficExam.Model;
using TrafficExam.Bll;

namespace TrafficExam.Web
{
    public partial class IndexRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                switch (Request["ActionName"].ToString())
                {
                    case "GetLoginName":
                        //获取所有考题科目类型
                        Response.Write(IJsonHelper.ListToJson(GetLoginName(), "SystemUser"));
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogInfo log = ExceptionLogInfo.LogInstance();
                log.WriterLog(ex.ToString());
            }
        }
        private IList<SystemUser> GetLoginName()
        {
            BllUser bllUser = new BllUser();
            return bllUser.GetLoginName();

        }
    }
}