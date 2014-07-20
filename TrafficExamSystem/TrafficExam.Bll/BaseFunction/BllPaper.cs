using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllPaper
    {
        IPaper iPaper = null;
        public BllPaper()
        {
            iPaper = BussinessFactory.NewDBPaper();
        }
        /// <summary>
        /// 根据题号+用户名获取题库信息
        /// </summary>
        /// <param name="titleId">题号</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public IList<Paper> GetPaperInfo(string TableName,int titleId, string loginName)
        {
            return iPaper.GetPaperInfo(TableName,titleId, loginName);
        }
        /// <summary>
        /// 根据用户名设置题库
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public bool SetPaperList(string loginName, string TableName)
        {
            return iPaper.SetPaperList(loginName, TableName);
        }
        /// <summary>
        /// 修改用户答案
        /// </summary>
        /// <param name="titleId">题号</param>
        /// <param name="loginName">用户名</param>
        /// <param name="userAnswer">答案</param>
        /// <returns></returns>
        public bool UpdateUserAnswer(int titleId, string loginName, string userAnswer, bool isProper)
        {
            return iPaper.UpdateUserAnswer(titleId, loginName, userAnswer, isProper);
        }
        /// <summary>
        /// 根据用户名返回题目对错列表
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public IList<Paper> GetIsProperList(string loginName)
        {
            return iPaper.GetIsProperList(loginName);
        }
    }
}
