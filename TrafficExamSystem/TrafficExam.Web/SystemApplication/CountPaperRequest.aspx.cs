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
using System.Data;

namespace TrafficExam.Web.SystemApplication
{
    public partial class CountPaperRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                string examIds = "";
                string loginName = "";

                switch (Request["ActionName"].ToString())
                {
                    case "GetCountPaperByPerson":
                        examIds = Request["ExamIds[]"].ToString().Trim();
                        string departOrderType = Request["DepartOrderType"].ToString().Trim();
                        string scoreOrderType = Request["ScoreOrderType"].ToString().Trim();
                        string departClickState = Request["DepartClickState"].ToString().Trim();
                        string scoreClickState = Request["ScoreClickState"].ToString().Trim();
                        Response.Write(IJsonHelper.ListToJson<PersonPaperEx>(GetCountPaperByPerson(examIds, departOrderType, scoreOrderType, departClickState, scoreClickState), "CountPaper"));
                        break;
                    case "GetPersonPersonDetail":
                        loginName = Request["LoginName"].ToString().Trim();
                        examIds = Request["ExamId"].ToString().Trim();
                        Response.Write(IJsonHelper.ListToJson<PersonDetailEx>(GetPersonPersonDetail(loginName, examIds), "PersonDetail"));
                        break;
                    case "GetCountPaperBySubjectType":
                        examIds = Request["ExamIds"].ToString().Trim();
                        Response.Write(IJsonHelper.ListToJson<CountPaper>(GetCountPaperBySubjectType(examIds), "CountPaper"));
                        break;
                    case "GetExamList":
                        DateTime startTime = Convert.ToDateTime(Request["StartDate"].ToString().Trim());
                        DateTime endTime = Convert.ToDateTime(Request["EndDate"].ToString().Trim());
                        Response.Write(IJsonHelper.ListToJson<CountPaper>(GetExamList(startTime, endTime), "ExamList"));
                        break;
                    case "GetPersonPaperInfo":
                         loginName = Request["LoginName"].ToString().Trim();
                         examIds = Request["ExamId"].ToString().Trim();
                         Response.Write(IJsonHelper.ListToJson<CountPaper>(GetPersonPaperInfo(examIds, loginName)));
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
        /// 根据考试期数统计人员考试信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        private IList<PersonPaperEx> GetCountPaperByPerson(string examId, string departOrderType, string scoreOrderType, string departClickState, string scoreClickState)
        {
            BllCountPaper bllCountPaper = new BllCountPaper();
            return bllCountPaper.GetCountPaperByPerson(examId, departOrderType, scoreOrderType, departClickState, scoreClickState);
        }
        /// <summary>
        /// 获取人员考试明细信息
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        private IList<PersonDetailEx> GetPersonPersonDetail(string loginName, string examId)
        {
            BllCountPaper bllCountPaper = new BllCountPaper();
            return bllCountPaper.GetPersonPersonDetail(loginName, examId);
        }
        /// <summary>
        /// 根据考试期数统计科目统计信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        private IList<CountPaper> GetCountPaperBySubjectType(string examId)
        {
            BllCountPaper bllCountPaper = new BllCountPaper();
            return bllCountPaper.GetCountPaperBySubjectType(examId);
        }
        /// <summary>
        /// 根据考试期数统计科目统计信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        private IList<CountPaper> GetExamList(DateTime startDate, DateTime endDate)
        {
            BllCountPaper bllCountPaper = new BllCountPaper();
            return bllCountPaper.GetExamList(startDate, endDate);
        }
        /// <summary>
        /// 根据考试期数和用户名获取考生试卷
        /// </summary>
        /// <param name="examid"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        private IList<CountPaper> GetPersonPaperInfo(string examid, string loginName)
        {
            BllCountPaper bllCountPaper = new BllCountPaper();
            return bllCountPaper.GetPersonPaperInfo(examid, loginName);
        }
    }
}
