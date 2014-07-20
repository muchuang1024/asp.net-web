using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data;
using TrafficExam.Command;
using System.Data.SqlClient;

namespace TrafficExam.Data
{
    public class DBCountPaper : ICountPaper
    {
        public IList<PersonPaperEx> GetCountPaperByPerson(string examId, string departOrderType, string scoreOrderType, string departClickState, string scoreClickState)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@examId", DbType.String);
            sp[0].Value = examId;//期数
            sp[1] = new SqlParameter("@departOrderType", DbType.String);
            sp[1].Value = departOrderType;//部门排序
            sp[2] = new SqlParameter("@scoreOrderType", DbType.String);
            sp[2].Value = scoreOrderType;//分数排序
            sp[3] = new SqlParameter("@departClickState", DbType.String);
            sp[3].Value = departClickState;//部门排序
            sp[4] = new SqlParameter("@scoreClickState", DbType.String);
            sp[4].Value = scoreClickState;//分数排序
            ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, "GetCountPaperByPerson", sp);
            IList<PersonPaperEx> list = IListHelper.DataSetToIList<PersonPaperEx>(ds, 0);
            return list;
        }
        /// <summary>
        /// 获取人员考试明细
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="examId">期数</param>
        /// <returns></returns>
        public IList<PersonDetailEx> GetPersonPersonDetail(string loginName, string examId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@examId", DbType.String);
            sp[0].Value = examId;//期数
            sp[1] = new SqlParameter("@LoginName", DbType.String);
            sp[1].Value = loginName;//用户名
            ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, "GetPersonPersonDetail", sp);
            IList<PersonDetailEx> list = IListHelper.DataSetToIList<PersonDetailEx>(ds, 0);
            return list;
        }

        public IList<CountPaper> GetCountPaperBySubjectType(string examId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据开始时间、结束时间获取考试设置列表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public IList<CountPaper> GetExamList(DateTime startDate, DateTime endDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@startDate", DbType.DateTime);
            sp[0].Value = startDate;//开始日期
            sp[1] = new SqlParameter("@endDate", DbType.DateTime);
            sp[1].Value = endDate;//结束日期
            ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, "GetExamList", sp);
            IList<CountPaper> list = IListHelper.DataSetToIList<CountPaper>(ds, 0);
            return list;
        }

        /// <summary>
        /// 根据考试期数导出统计信息到Excel
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public DataTable ExportToExcel(string examId)
        {
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@examId", DbType.String);
            sp[0].Value = examId;//期数
            sp[1] = new SqlParameter("@departOrderType", DbType.String);
            sp[1].Value = "ASC";//部门排序
            sp[2] = new SqlParameter("@scoreOrderType", DbType.String);
            sp[2].Value = "ASC";//分数排序
            sp[3] = new SqlParameter("@departClickState", DbType.String);
            sp[3].Value = "onClick";//部门排序
            sp[4] = new SqlParameter("@scoreClickState", DbType.String);
            sp[4].Value = "";//分数排序
            DataTable dt = SqlHelper.GetDataTable(CommandType.StoredProcedure, "GetCountPaperByPerson", sp);
            return dt;
        }
        /// <summary>
        /// 得到考生试卷信息
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IList<CountPaper> GetPersonPaperInfo(string examId,string loginName)
        {
            string strSql = "select CountPaperId,Title,FirstOption,SecondOption,ThirdOption,FourthOption,FifthOption,SixthOption,UserAnswer,Answer,ItemCount From CountPaper";
            strSql += " where  ExamId=" + examId + " and LoginName='" + loginName + "'";
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<CountPaper> list = IListHelper.DataSetToIList<CountPaper>(ds, 0);
            return list;
        }

    }
}
