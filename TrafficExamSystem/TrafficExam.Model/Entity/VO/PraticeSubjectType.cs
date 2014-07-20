using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    public class PraticeSubjectType
    {
        private int subjectTypeId;
        /// <summary>
        /// 科目类别编号
        /// </summary>
        public int SubjectTypeId
        {
            get { return subjectTypeId; }
            set { subjectTypeId = value; }
        }
        private string subjectType;
        /// <summary>
        ///  科目类别名称
        /// </summary>
        public string SubjectTypeName
        {
            get { return subjectType; }
            set { subjectType = value; }
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
        private string loginName;
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
    }
}
