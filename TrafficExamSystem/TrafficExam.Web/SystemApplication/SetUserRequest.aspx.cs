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

namespace TrafficExam.Web.SystemApplication
{
    public partial class SetUserRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                switch (Request["ActionName"].ToString())
                {
                    case "GetUserList":
                        Response.Write(IJsonHelper.ListToJson<SystemUser>(GetUserList(1), "user"));
                        break;
                    case "SetUserState":
                        string loginNames = Request["LoginNames"].ToString();
                        string TableName = Request["TableName"].ToString();
                        Response.Write(json.Serialize(SetUserState(loginNames,TableName)));
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

        /// <summary>
        /// 获取人员信息列表
        /// </summary>
        /// <param name="groupId">分组Id</param>
        /// <returns></returns>
        private IList<SystemUser> GetUserList(int groupId)
        {
            BllUser blluser = new BllUser();
            return blluser.GetUserList(groupId);
        }

        private string SetUserState(string loginNames,string TableName)
        {
            BllUser blluser = new BllUser();
            if (blluser.SetUserState(loginNames,TableName))
            {
                return "true";  //更新成功
            }
            return "false"; //更新失败
        }
    }
}