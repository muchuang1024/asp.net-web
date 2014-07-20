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
    public class DBSubjectType : ISubjectType
    {
        #region 获取已勾选的科目考点
        /// <summary>
        /// 获取已勾选的科目考点
        /// </summary>
        /// <returns></returns>
        public IList<SubjectType> GetSubjectType()
        {
            DataSet ds = new DataSet();
            string strSql = @"select SubjectTypeId  from SubjectType";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SubjectType> list = IListHelper.DataSetToIList<SubjectType>(ds, 0);
            return list;
        }
        #endregion

        #region 获取所有考题科目类型
        /// <summary>
        /// 获取所有考题科目类型
        /// </summary>
        /// <returns></returns>
        public IList<SubjectType> GetSubjectTypeList()
        {
            DataSet ds = new DataSet();
            string strSql = @"select SubjectType.SubjectTypeId,COUNT(PaperId) as CountPaperId from SubjectType";
            strSql += "  left join Paper on SubjectType.SubjectType=Paper.SubjectType group by SubjectTypeId";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SubjectType> list = IListHelper.DataSetToIList<SubjectType>(ds, 0);
            return list;
        }
        #endregion

        #region  设置考题类型以及考试开始和结束时间
        /// <summary>
        /// 设置考题类型以及考试开始和结束时间
        /// </summary>
        /// <param name="SubjectIdlist"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool SetSubjectList(string SubjectIdlist, DateTime startTime, int minute, int once ,int more, int deter)
        {
            //判断考试时间设定是否合理
            DateTime EndTime=startTime.AddMinutes(minute);
            DateTime CurrentTime = DateTime.Now; 
            if (DateTime.Compare(startTime, CurrentTime) < 0)
            {
                return false;
            }
            SqlParameter[] sp = new SqlParameter[6];
            sp[0] = new SqlParameter("@SubjectTypeName", DbType.String);
            sp[0].Value = SubjectIdlist;
            sp[1] = new SqlParameter("@StartTime", DbType.String);
            sp[1].Value = startTime;
            sp[2] = new SqlParameter("@EndTime", DbType.String);
            sp[2].Value = EndTime;
            sp[3] = new SqlParameter("@Once", DbType.String);
            sp[3].Value = once;
            sp[4] = new SqlParameter("@More", DbType.String);
            sp[4].Value = more;
            sp[5] = new SqlParameter("@Deter", DbType.String);
            sp[5].Value = deter;
            return SqlHelper.ExecuteSqlText(CommandType.StoredProcedure, "Proc_GetSubject", sp);
        }
        #endregion

        #region 完成考试
        /// <summary>
        /// 完成考试
        /// </summary>
        /// <returns></returns>
        public bool CompleteExam()
        {
            return SqlHelper.ExecuteSqlText(CommandType.StoredProcedure, "Proc_CompleteExam", null);
        }
        #endregion
    }
}
