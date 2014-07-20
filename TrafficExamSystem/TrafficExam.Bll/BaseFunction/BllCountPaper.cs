using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data;

namespace TrafficExam.Bll
{
    public class BllCountPaper
    {

        ICountPaper iCountPaper = null;
        public BllCountPaper()
        {
            iCountPaper = BussinessFactory.NewDBCountPaper();
        }
        /// <summary>
        /// 根据考试编号获取人员考试统计信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public IList<PersonPaperEx> GetCountPaperByPerson(string examId, string departOrderType, string scoreOrderType, string departClickState, string scoreClickState)
        {
            return iCountPaper.GetCountPaperByPerson(examId, departOrderType, scoreOrderType, departClickState, scoreClickState);
        }
        /// <summary>
        /// 获取人员考试明细信息
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="examId">期数</param>
        /// <returns></returns>
        public IList<PersonDetailEx> GetPersonPersonDetail(string loginName, string examId)
        {
            return iCountPaper.GetPersonPersonDetail(loginName, examId);
        }
        /// <summary>
        /// 根据考试期数获取科目统计信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public IList<CountPaper> GetCountPaperBySubjectType(string examId)
        {
            return iCountPaper.GetCountPaperBySubjectType(examId);
        }
        /// <summary>
        /// 根据考试期数获取科目统计信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public IList<CountPaper> GetExamList(DateTime startDate, DateTime endDate)
        {
            return iCountPaper.GetExamList(startDate, endDate);
        }
        /// <summary>
        /// 导出对应期数的数据到Excel
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public DataTable ExportToExcel(string examId)
        {
            return iCountPaper.ExportToExcel(examId);
        }
        /// <summary>
        /// 得到考生试卷信息
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IList<CountPaper> GetPersonPaperInfo(string examId, string loginName)
        {
            return iCountPaper.GetPersonPaperInfo(examId, loginName);
        }
    }
}
