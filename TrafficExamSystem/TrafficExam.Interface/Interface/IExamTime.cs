using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IExamTime
    {
        /// <summary>
        /// 获取考试开始时间、结束时间、当前时间
        /// </summary>
        /// <returns>IList<ExamTime></returns>
        IList<ExamTime> GetExamTimeList();

        int GetSecondValue();


    }
}
