using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data.SqlClient;
using System.Data;
using TrafficExam.Command;

namespace TrafficExam.Data
{
    public class DBPaper : IPaper
    {
        #region 根据题号与用户名获取试题信息
        /// <summary>
        /// 根据题号与用户名获取试题信息
        /// </summary>
        /// <param name="titleId">题号</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public IList<Paper> GetPaperInfo(string TableName,int titleId, string loginName)
        {
            string strSql = "select PaperId,TitleId,Title,FirstOption,SecondOption,ThirdOption,FourthOption,FifthOption,SixthOption,Answer,ItemCount,SubjectItem,UserAnswer,IsProper  From " + TableName;
            strSql += " where  TitleId=" + titleId + " and LoginName='" + loginName + "'";
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<Paper> list = IListHelper.DataSetToIList<Paper>(ds, 0);
            return list;
        }
        #endregion

        #region 根据用户名获取考题
        /// <summary>
        /// 设置考卷
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public bool SetPaperList(string loginName, string TableName)
        {
            if (!IsExisted(loginName))
            {
                SqlParameter[] sp = new SqlParameter[2];
                sp[0] = new SqlParameter("@loginName", DbType.String);
                sp[0].Value = loginName;//用户名
                sp[1] = new SqlParameter("@TableName", DbType.String);
                sp[1].Value = TableName;//表名
                return SqlHelper.ExecuteSqlText(CommandType.StoredProcedure, "Proc_GetPaper", sp);
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 修改用户答案
        /// <summary>
        /// 修改用户答案
        /// </summary>
        /// <param name="titleId">题号</param>
        /// <param name="loginName">用户名</param>
        /// <param name="userAnswer">答案</param>
        /// <returns></returns>
        public bool UpdateUserAnswer(int titleId, string loginName, string userAnswer, bool isProper)
        {
            string strSql = "Update Paper Set UserAnswer='" + userAnswer + "',IsProper='" + isProper + "'";
            strSql += " where  TitleId=" + titleId + " and LoginName='" + loginName + "'";
            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, null);
        }
        #endregion

        #region 判断该用户是否已经存在考卷
        /// <summary>
        /// 判断是否已经存在考卷
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        private bool IsExisted(string loginName)
        {
            string strSql = "select Count(PaperId)  from  Paper where LoginName=@loginName";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@loginName", DbType.String);
            sp[0].Value = loginName;//用户名
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql, sp));
            if (count > 0)
                return true;
            return false;
        }
        #endregion

        #region 根据用户名获取试卷题目对错列表
        /// <summary>
        /// 根据用户名获取试卷题目对错列表
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IList<Paper> GetIsProperList(string loginName)
        {
            string strSql = "select PaperId,TitleId,UserAnswer,SubjectItem,IsProper  From Paper";
            strSql += " where  LoginName='" + loginName + "'";
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<Paper> list = IListHelper.DataSetToIList<Paper>(ds, 0);
            return list;
        }
        #endregion
    }
}
