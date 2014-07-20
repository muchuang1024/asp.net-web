using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllExamTime
    {
        IExamTime iExamTime = null;

        public BllExamTime()
        {
            iExamTime = BussinessFactory.NewDBExamTime();
        }
        /// <summary>
        /// 返回考试时间设定
        /// </summary>
        /// <returns></returns>
        public IList<ExamTime> GetExamTimeList()
        {
            return iExamTime.GetExamTimeList();
        }
        /// <summary>
        /// 返回考试时间差
        /// </summary>
        /// <returns></returns>
        public int GetSecondValue()
        {
            return iExamTime.GetSecondValue();
        }
    }

}
