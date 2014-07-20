using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    public class CountPaper
    {

        private int countPaperId;
        /// <summary>
        /// 统计主键
        /// </summary>
        public int CountPaperId
        {
            get { return countPaperId; }
            set { countPaperId = value; }
        }

        private int paperId;
        /// <summary>
        /// 试题主键
        /// </summary>
        public int PaperId
        {
            get { return paperId; }
            set { paperId = value; }
        }
        private int itemTitleId;
        /// <summary>
        /// 题库主键[TitleId]
        /// </summary>
        public int ItemTitleId
        {
            get { return itemTitleId; }
            set { itemTitleId = value; }
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
        private int titleId;
        /// <summary>
        /// 题号
        /// </summary>
        public int TitleId
        {
            get { return titleId; }
            set { titleId = value; }
        }
        private string title;
        /// <summary>
        /// 题干 
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string firstOption;
        /// <summary>
        /// 第一个选项
        /// </summary>
        public string FirstOption
        {
            get { return firstOption; }
            set { firstOption = value; }
        }
        private string secondOption;
        /// <summary>
        /// 第二个选项
        /// </summary>
        public string SecondOption
        {
            get { return secondOption; }
            set { secondOption = value; }
        }
        private string thirdOption;
        /// <summary>
        /// 第三个选项
        /// </summary>
        public string ThirdOption
        {
            get { return thirdOption; }
            set { thirdOption = value; }
        }
        private string fourthOption;
        /// <summary>
        /// 第四个选项
        /// </summary>
        public string FourthOption
        {
            get { return fourthOption; }
            set { fourthOption = value; }
        }
        private string fifthOption;
        /// <summary>
        /// 第五个选项
        /// </summary>
        public string FifthOption
        {
            get { return fifthOption; }
            set { fifthOption = value; }
        }
        private string sixthOption;
        /// <summary>
        /// 第六个选项
        /// </summary>
        public string SixthOption
        {
            get { return sixthOption; }
            set { sixthOption = value; }
        }
        private string answer;
        /// <summary>
        /// 题目答案
        /// </summary>
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        private string subjectType;
        /// <summary>
        /// 科目类型
        /// </summary>
        public string SubjectType
        {
            get { return subjectType; }
            set { subjectType = value; }
        }
        private int itemCount;
        /// <summary>
        /// 选项个数
        /// </summary>
        public int ItemCount
        {
            get { return itemCount; }
            set { itemCount = value; }
        }
        private int subjectItem;
        /// <summary>
        /// 科目项[1:单选、2：多选、3：判断]
        /// </summary>
        public int SubjectItem
        {
            get { return subjectItem; }
            set { subjectItem = value; }
        }
        private string userAnswer;
        /// <summary>
        /// 用户答案
        /// </summary>
        public string UserAnswer
        {
            get { return userAnswer; }
            set { userAnswer = value; }
        }

        private bool isProper;
        /// <summary>
        ///是否正确
        /// </summary>
        public bool IsProper
        {
            get { return isProper; }
            set { isProper = value; }
        }
        private string examId;
        /// <summary>
        /// 考试序号
        /// </summary>
        public string ExamId
        {
            get { return examId; }
            set { examId = value; }
        }
        private DateTime startTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime endTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

    }
}
