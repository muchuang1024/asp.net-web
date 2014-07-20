using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllPraticeSubjectType
    {
        IPraticeSubjectType iPraticeSubjectType;
        /// <summary>
        /// 构造函数
        /// </summary>
        public BllPraticeSubjectType()
        {
            iPraticeSubjectType = BussinessFactory.NewDBPraticeSubjectType();
        }
        public bool SetSubjectList(string SubjectIdlist, int once, int more, int deter, string loginName)
        {
            return iPraticeSubjectType.SetSubjectList(SubjectIdlist, once, more, deter,loginName);
        }

    }
}
