using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficExam.Bll;
using System.Data;
using TrafficExam.Command;
using MDS.XJSON.Core;

namespace TrafficExam.Web.SystemApplication
{
    public partial class ExportRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();

            if (!string.IsNullOrEmpty(Request["ExportToExcel"].ToString()))
            {
                string examIds = Request["ExportToExcel"].ToString().Trim();
                Response.Write(json.Serialize(ExportByWeb(examIds)));
            }
        }

        /// <summary>
        /// 导出数据到Excel
        /// </summary>
        /// <param name="dt"></param>
        private string ExportByWeb(string examId)
        {
            try
            {
                BllCountPaper bllCountPaper = new BllCountPaper();
                DataTable dt = bllCountPaper.ExportToExcel(examId);
                string[] oldColumnNames = new string[] { "ExamId", "RealName", "Sex", "PoliceCode", "Position", "Department", "OnceItem", "MoreItem", "DeterItem", "Score" };
                string[] newColumnNames = new string[] { "考试批次", "姓名", "性别", "警号", "职务", "部门", "单选", "多选", "判断", "成绩" };
                ExcelHelper.ExportByWeb(dt, "考试成绩", "考试成绩.xls", "考试成绩", oldColumnNames, newColumnNames);
                return "true";
            }
            catch
            {
                return "false";
            }
        }
    }
}
