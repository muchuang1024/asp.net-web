using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MDS.XJSON.Core;
using TrafficExam.Command;
using TrafficExam.Bll;
using TrafficExam.Model;

namespace TrafficExam.Web.UserApplication
{
    public partial class PraticePaperIndexRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            JsonSerializer json = new JsonSerializer();
            try
            {
                switch (Request["ActionName"].ToString())
                {
                  
                    case "SetPaperList":
                        //把数据库权限分组返回到界面进行显示
                        string TableName = Request["TableName"].ToString().Trim();
                        Response.Write(json.Serialize(SetPaperList(Session["LoginName"].ToString(), TableName)));
                        break;
                    case "GetPaperInfo":
                        /// 返回考题信息
                        string tableName = Request["TableName"].ToString().Trim();
                        int titleId = Convert.ToInt32(Request["TitleId"].ToString().Trim());
                        Response.Write(json.Serialize(GetPaperInfo(tableName, Session["LoginName"].ToString(), titleId)));
                        break;
                    case "UpdateUserAnswer":
                        /// 修改用户答案
                        int titleId2 = Convert.ToInt32(Request["TitleId"].ToString().Trim());
                        string userAnswer = Request["UserAnswer"].ToString().Trim();
                        bool isProper = Convert.ToBoolean(Request["IsProper"].ToString().Trim());
                        Response.Write(json.Serialize(UpdateUserAnswer(titleId2, Session["LoginName"].ToString(), userAnswer, isProper)));
                        break;
                    case "GetIsProperList":
                        ///根据用户名获取考题对错列表
                        Response.Write(json.Serialize(GetIsProperList(Session["LoginName"].ToString())));
                        break;
                    case "SubmitExam":
                        string tablename = Request["TableName"].ToString().Trim();
                        int score = 0;
                        //提交考卷[提交考试只是将SystemUser表中IpOpen修改为false,并立即显示成绩]
                        bool result = SubmitExam(tablename, Session["LoginName"].ToString(), ref score);
                        if (result)
                        {
                            Response.Write(json.Serialize(score));
                        }
                        break;
                    case "SetSubjectList":
                        //设置考题及考试时间
                        string subjectIdlist = Request["SubjectIdlist"].ToString();
                        int OnceItem = Int32.Parse(Request["OnceItem"].ToString());
                        int MoreItem = Int32.Parse(Request["MoreItem"].ToString());
                        int DeterItem = Int32.Parse(Request["DeterItem"].ToString());
                        string loginName = Session["LoginName"].ToString();
                        Response.Write(json.Serialize(SetSubjectList(subjectIdlist, OnceItem, MoreItem, DeterItem, loginName)));
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
        private bool SetSubjectList(string SubjectIdlist, int OnceItem, int MoreItem, int DeterItem, string loginName)
        {
           
           BllPraticeSubjectType bllPratieSubjectType = new BllPraticeSubjectType();
           return bllPratieSubjectType.SetSubjectList(SubjectIdlist, OnceItem, MoreItem, DeterItem, loginName);
        }
       /// <summary>
       /// 设置考题
       /// </summary>
       /// <param name="loginName"></param>用户名
       /// <param name="TableName"></param>表名
       /// <returns></returns>
        private bool SetPaperList(string loginName, string TableName)
        {
            BllPraticePaper bllPraticePaper = new BllPraticePaper();
            return bllPraticePaper.SetPaperList(loginName, TableName);
        }
        /// <summary>
        /// 返回考题信息
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="titleId">考题Id</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private IList<PraticePaper> GetPaperInfo(string tableName, string loginName, int titleId)
        {
            BllPraticePaper bllPraticePaper = new BllPraticePaper();
            return bllPraticePaper.GetPaperInfo(tableName, titleId, loginName);
        }
        /// <summary>
        /// 修改用户答案
        /// </summary>
        /// <param name="titleId">题号</param>
        /// <param name="loginName">用户名</param>
        /// <param name="userAnswer">答案</param>
        /// <returns></returns>
        private bool UpdateUserAnswer(int titleId, string loginName, string userAnswer, bool isProper)
        {
            BllPraticePaper bllPraticePaper = new BllPraticePaper();
            return bllPraticePaper.UpdateUserAnswer(titleId, loginName, userAnswer, isProper);
        }

        /// <summary>
        /// 根据用户名获取考题对错列表
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        private IList<PraticePaper> GetIsProperList(string loginName)
        {
            BllPraticePaper bllPraticePaper = new BllPraticePaper();
            return bllPraticePaper.GetIsProperList(loginName);
        }

        /// <summary>
        /// 提交考卷[提交考试只是将SystemUser表中IpOpen修改为false,并理解显示分数]
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        private bool SubmitExam(string tableName, string loginName, ref int score)
        {
            BllUser user = new BllUser();
            return user.SubmitExam(tableName, loginName, ref score);
        }
    }
}