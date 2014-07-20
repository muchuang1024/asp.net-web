using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    public class PersonDetailEx
    {
        private string loginName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string realName;
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }
        private int paperTrue;
        /// <summary>
        /// 正确答案个数
        /// </summary>
        public int PaperTrue
        {
            get { return paperTrue; }
            set { paperTrue = value; }
        }
        private int paperFalse;
        /// <summary>
        /// 错误答案个数
        /// </summary>
        public int PaperFalse
        {
            get { return paperFalse; }
            set { paperFalse = value; }
        }

        private string subjectType;
        /// <summary>
        /// 科目类别
        /// </summary>
        public string SubjectType
        {
            get { return subjectType; }
            set { subjectType = value; }
        }
        private string subjectItem;
        /// <summary>
        /// 题目类型[1、单选2、多选、3、判断]
        /// </summary>
        public string SubjectItem
        {
            get { return subjectItem; }
            set { subjectItem = value; }
        }
    }
}
