using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data;
using TrafficExam.Command;

namespace TrafficExam.Data
{
    public class DBExamTime : IExamTime
    {
        #region 获取考试开始时间、结束时间、当前时间
        /// <summary>
        /// 获取考试开始时间、结束时间、当前时间
        /// </summary>
        /// <returns>IList<ExamTime></returns>
        public IList<ExamTime> GetExamTimeList()
        {
            DataSet ds = new DataSet();
            string strSql = @"Select StartTime,EndTime,GetDate() as CurrentTime From ExamTime";
            //string strSql = "  Select cast(StartTime as nvarchar(50)) as StartTime,cast(EndTime as nvarchar(50)) as EndTime,CAST (GetDate() as nvarchar(50)) as CurrentTime From ExamTime";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<ExamTime> list = IListHelper.DataSetToIList<ExamTime>(ds, 0);
            return list;
        }
        #endregion


        /// <summary>
        /// 返回时间差
        /// </summary>
        /// <returns></returns>
        public int GetSecondValue()
        {
            string strSql = @"select DATEDIFF(ss,GetDate(),EndTime) as secondValue from ExamTime";
            int o = (int)SqlHelper.ExecuteScalar(CommandType.Text, strSql, null);
            return o;
        }
    }
}
