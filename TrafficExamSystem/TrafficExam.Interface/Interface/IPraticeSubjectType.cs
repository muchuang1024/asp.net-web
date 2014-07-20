using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IPraticeSubjectType
    {
        /// <summary>
        /// 设置练习科目表
        /// </summary>
        /// <param name="SubjectIdlist"></param>
        /// <param name="once"></param>
        /// <param name="more"></param>
        /// <param name="deter"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        bool SetSubjectList(string SubjectIdlist, int once, int more, int deter, string loginName);

    }
}
