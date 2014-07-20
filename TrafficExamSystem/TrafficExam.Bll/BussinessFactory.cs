using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Data;

namespace TrafficExam.Bll
{
    /// <summary>
    /// 返回数据层实例的工厂类
    /// </summary>
    public class BussinessFactory
    {
        /// <summary>
        /// 返回用户数据操作实例
        /// </summary>
        /// <returns></returns>
        public static IUser NewDBUser()
        {
            return new DBUser();
        }
        /// <summary>
        /// 返回用户权限页面数据菜单操作实例
        /// </summary>
        /// <returns></returns>
        public static IFunction NewDBFunction()
        {
            return new DBFunction();
        }
        /// <summary>
        /// 返回用户权限数据操作实例
        /// </summary>
        /// <returns></returns>
        public static IGroup NewDBGroup()
        {
            return new DBGroup();
        }
        /// <summary>
        /// 返回关系数据操作实例
        /// </summary>
        /// <returns></returns>
        public static IRelation NewDBRelation()
        {
            return new DBRelation();
        }
        /// <summary>
        /// 返回试题操作实例
        /// </summary>
        /// <returns></returns>
        public static IPaper NewDBPaper()
        {
            return new DBPaper();
        }
        /// <summary>
        /// 返回试题操作实例
        /// </summary>
        /// <returns></returns>
        public static IPraticePaper NewDBPraticePaper()
        {
            return new DBPraticePaper();
        }
        /// <summary>
        /// 考试练习表
        /// </summary>
        /// <returns></returns>
        public static ISubjectType NewDBSubjectType()
        {
            return new DBSubjectType();
        }
        /// <summary>
        /// 练习科目表
        /// </summary>
        /// <returns></returns>
        public static IPraticeSubjectType NewDBPraticeSubjectType()
        {
            return new DBPraticeSubjectType();
        }
        
        /// <summary>
        /// 返回题库操作实例
        /// </summary>
        /// <returns></returns>
        public static IItemTitle NewDBItemTitle()
        {
            return new DBItemTitle();
        }
        /// <summary>
        ///返回考试时间操作实例
        /// </summary>
        /// <returns></returns>
        public static IExamTime NewDBExamTime()
        {
            return new DBExamTime();
        }
        /// <summary>
        /// 返回考试统计操作实例
        /// </summary>
        /// <returns></returns>
        public static ICountPaper NewDBCountPaper()
        {
            return new DBCountPaper();
        }
    }
}
