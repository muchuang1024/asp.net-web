using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IPaper
    {
        /// <summary>
        /// 根据用户名和考题Id获取考题信息
        /// </summary>
        /// <param name="titleId">考题Id</param>
        /// <returns></returns>
        IList<Paper> GetPaperInfo(string TableName,int titleId, string loginName);
        /// <summary>
        /// 根据用户名生成用户考试列表
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        bool SetPaperList(string loginName, string TableName);

        /// <summary>
        /// 修改用户答案
        /// </summary>
        /// <param name="titleId">题号</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        bool UpdateUserAnswer(int titleId, string loginName, string userAnswer, bool isProper);

        /// <summary>
        /// 根据用户名获取试卷对错信息列表
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        IList<Paper> GetIsProperList(string loginName);
    }
}
