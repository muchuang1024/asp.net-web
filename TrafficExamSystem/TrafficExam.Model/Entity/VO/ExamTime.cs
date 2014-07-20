using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    public class ExamTime
    {

        private DateTime examId;
        /// <summary>
        /// 考试序号有时间表示
        /// </summary>
        public DateTime ExamId
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

        private DateTime currentTime;
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; }
        }
        public ExamTime()
        {
            startTime = DateTime.Now;
            endTime = DateTime.Now;
            currentTime = DateTime.Now;
            examId = DateTime.Now;
        }
    }
}
