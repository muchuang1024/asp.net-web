using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficExam.Model;
using TrafficExam.Command;
using MDS.XJSON.Core;
using TrafficExam.Bll;

namespace TrafficExam.Web.SystemApplication
{
    public partial class PaperInstallRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                switch (Request["ActionName"].ToString())
                {
                    case "SetSubjectList":
                        //设置考题及考试时间
                        string subjectIdlist = Request["SubjectIdlist"].ToString().Trim();
                        DateTime startTime = Convert.ToDateTime(Request["StartTime"].ToString().Trim());
                        int minute = Int32.Parse(Request["Minute"].ToString());
                        int OnceItem = Int32.Parse(Request["OnceItem"].ToString());
                        int MoreItem = Int32.Parse(Request["MoreItem"].ToString());
                        int DeterItem = Int32.Parse(Request["DeterItem"].ToString());
                        Response.Write(json.Serialize(SetSubjectList(subjectIdlist, startTime, minute, OnceItem, MoreItem, DeterItem)));
                        break;
                    case "GetSubjectType":
                        Response.Write(json.Serialize(GetSubjectTypeList()));
                        break;
                    case "ShowExamTime":
                        Response.Write(IJsonHelper.ListToJson(GetExamTimeList(), "ExamTime"));
                        break;
                    case "CompleteExam":
                        Response.Write(json.Serialize(CompleteExam()));
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
        private bool SetSubjectList(string SubjectIdlist, DateTime StartTime, int minute,int OnceItem, int MoreItem, int DeterItem)
        {
            BllSubjectType bllSubjectType = new BllSubjectType();
            return bllSubjectType.SetSubjectList(SubjectIdlist, StartTime, minute, OnceItem, MoreItem, DeterItem);
        }
        private IList<SubjectType> GetSubjectTypeList()
        {
            BllSubjectType bllSubjectType = new BllSubjectType();
            return bllSubjectType.GetSubjectTypeList();
        }
        private IList<ExamTime> GetExamTimeList()
        {
            BllExamTime bllExamTime = new BllExamTime();
            return bllExamTime.GetExamTimeList();
        }
        private bool CompleteExam()
        {
            BllSubjectType bllSubjectType = new BllSubjectType();
            return bllSubjectType.CompleteExam();
        }
    }
}