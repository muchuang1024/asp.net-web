using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface ISubjectType
    {
        /// <summary>
        /// 获取已勾选的科目考点
        /// </summary>
        /// <returns></returns>
        IList<SubjectType> GetSubjectType();
        /// <summary>
        /// 获取所有考题科目类型
        /// </summary>
        /// <returns></returns>
        IList<SubjectType> GetSubjectTypeList();
        /// <summary>
        /// 设置考题类别及考试开始和结束时间
        /// </summary>
        /// <param name="SubjectIdlist"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        bool SetSubjectList(string SubjectIdlist, DateTime startTime, int minute, int once, int more, int deter);
        /// <summary>
        /// 完成考试
        /// </summary>
        /// <returns></returns>
        bool CompleteExam();
    }
}
