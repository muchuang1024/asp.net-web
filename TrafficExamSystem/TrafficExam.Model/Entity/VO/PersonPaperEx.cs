using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    public class PersonPaperEx
    {
        private string examId;
        /// <summary>
        /// 期数
        /// </summary>
        public string ExamId
        {
            get { return examId; }
            set { examId = value; }
        }
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
        private string sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string policeCode;
        /// <summary>
        /// 警号
        /// </summary>
        public string PoliceCode
        {
            get { return policeCode; }
            set { policeCode = value; }
        }
        private string position;
        /// <summary>
        /// 职务
        /// </summary>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        private string department;
        /// <summary>
        /// 部门
        /// </summary>
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        private int onceItem;
        /// <summary>
        /// 单选
        /// </summary>
        public int OnceItem
        {
            get { return onceItem; }
            set { onceItem = value; }
        }
        private int moreItem;
        /// <summary>
        /// 多选
        /// </summary>
        public int MoreItem
        {
            get { return moreItem; }
            set { moreItem = value; }
        }

        private int deterItem;
        /// <summary>
        /// 判断
        /// </summary>
        public int DeterItem
        {
            get { return deterItem; }
            set { deterItem = value; }
        }

        private int score;
        /// <summary>
        /// 成绩
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
