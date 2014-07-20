using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllSubjectType
    {
        ISubjectType iSubjectType;
        /// <summary>
        /// 构造函数
        /// </summary>
        public BllSubjectType()
        {
            iSubjectType = BussinessFactory.NewDBSubjectType();
        }
        /// <summary>
        /// 获取已勾选的科目考点
        /// </summary>
        /// <returns></returns>
        public IList<SubjectType> GetSubjectType()
        {
            return iSubjectType.GetSubjectType();
        }
             
        /// <summary>
        /// 获取所有考题科目类型（考点）
        /// </summary>
        /// <returns></returns>
        public IList<SubjectType> GetSubjectTypeList()
        {
            return iSubjectType.GetSubjectTypeList();
        }
        /// <summary>
        /// 设置考题类型及考试开始和结束时间
        /// </summary>
        /// <param name="SubjectIdlist"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool SetSubjectList(string SubjectIdlist, DateTime startTime,int minute ,int once, int more, int deter)
        {
            return iSubjectType.SetSubjectList(SubjectIdlist, startTime, minute, once ,more, deter);
        }

        /// <summary>
        /// 完成考试
        /// </summary>
        /// <returns></returns>
        public bool CompleteExam()
        {
            return iSubjectType.CompleteExam();
        }
    }
}
