using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;
using System.Data;

namespace TrafficExam.Interface
{
    public interface ICountPaper
    {
        /// <summary>
        /// 根据考试期数获取人员考试统计信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        IList<PersonPaperEx> GetCountPaperByPerson(string examId, string departOrderType, string scoreOrderType, string departClickState, string scoreClickState);
        /// <summary>
        /// 获取人员考试信息明细
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        IList<PersonDetailEx> GetPersonPersonDetail(string loginName, string examId);


        /// <summary>
        /// 根据考试期数获取科目统计信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        IList<CountPaper> GetCountPaperBySubjectType(string examId);

        /// <summary>
        /// 获取查询日期范围内的考试期数列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        IList<CountPaper> GetExamList(DateTime startDate, DateTime endDate);
        /// <summary>
        /// 返回结果DataTable，用于导出到Excel
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        DataTable ExportToExcel(string examId);

        /// <summary>
        /// 得到考生试卷信息
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        IList<CountPaper> GetPersonPaperInfo(string examId, string loginName);
       
    }
}
