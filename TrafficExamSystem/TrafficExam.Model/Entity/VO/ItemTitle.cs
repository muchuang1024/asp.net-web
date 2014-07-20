﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    public class ItemTitle
    {
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
        /// 答案
        /// </summary>
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        private string subjectType;
        /// <summary>
        /// 所属科目类型
        /// </summary>
        public string SubjectType
        {
            get { return subjectType; }
            set { subjectType = value; }
        }
        private int itemCount;
        /// <summary>
        /// 答案个数
        /// </summary>
        public int ItemCount
        {
            get { return itemCount; }
            set { itemCount = value; }
        }
        private string subjectItem;
        /// <summary>
        /// 题目类型【1、单选；2、多选；3、判断】
        /// </summary>
        public string SubjectItem
        {
            get { return subjectItem; }
            set { subjectItem = value; }
        }
    }
}