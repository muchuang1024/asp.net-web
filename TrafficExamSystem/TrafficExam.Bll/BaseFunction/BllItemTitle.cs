using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllItemTitle
    {
        IItemTitle iItemTitle = null;
        public BllItemTitle()
        {
            iItemTitle = BussinessFactory.NewDBItemTitle();
        }

       /// <summary>
       /// 根据题号，获取题目信息
       /// </summary>
       /// <param name="itemTitleId"></param>
       /// <returns></returns>
        public IList<ItemTitle> GetItemTitleInfo(int itemTitleId)
        {
            return iItemTitle.GetItemTitleInfo(itemTitleId);
        }
        /// <summary>
        /// 调用分页存储过程返回详细题库列表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">需要返回的字段名</param>
        /// <param name="orderFieldType">排序字段</param>
        /// <param name="pageIndex">显示第几页</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="where">查询条件</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="rowCount">总记录数</param>
        /// <returns></returns>
        public IList<ItemTitle> GetItemTitleList(string tableName, string fields, string orderFieldType, int pageIndex, int pageSize, string where, ref int pageCount, ref int rowCount)
        {
            return iItemTitle.GetItemTitleList(tableName, fields, orderFieldType, pageIndex, pageSize, where, ref  pageCount, ref  rowCount);
        }
        /// <summary>
        /// 插入题目信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="firstoption"></param>
        /// <param name="secondoption"></param>
        /// <param name="thirdoption"></param>
        /// <param name="fourthoption"></param>
        /// <param name="fifthoption"></param>
        /// <param name="sixthoption"></param>
        /// <param name="answer"></param>
        /// <param name="subjecttype"></param>
        /// <param name="itemcount"></param>
        /// <param name="subjectitem"></param>
        /// <returns></returns>
        public bool InsertItemTitle(ItemTitle item)
        {
            return iItemTitle.InsertItemTitle(item);
        }
        /// <summary>
        /// 根据题号，删除题目信息
        /// </summary>
        /// <param name="itemTitleId"></param>
        /// <returns></returns>
        public bool DeleteItemTitle(int itemTitleId)
        {
            return iItemTitle.DeleteItemTitle(itemTitleId);
        }
        /// <summary>
        /// 更新题目信息
        /// </summary>
        /// <param name="titleid"></param>
        /// <param name="title"></param>
        /// <param name="firstoption"></param>
        /// <param name="secondoption"></param>
        /// <param name="thirdoption"></param>
        /// <param name="fourthoption"></param>
        /// <param name="fifthoption"></param>
        /// <param name="sixthoption"></param>
        /// <param name="answer"></param>
        /// <param name="subjecttype"></param>
        /// <param name="itemcount"></param>
        /// <param name="subjectitem"></param>
        /// <returns></returns>
        public bool UpdateItemTitle(ItemTitle item)
        {
            return iItemTitle.UpdateItemTitle(item);
        }
        /// <summary>
        /// 根据题干信息、考点、题目类型进行搜索
        /// </summary>
        /// <param name="title"></param>
        /// <param name="SubjectType"></param>
        /// <param name="SubjectItem"></param>
        /// <returns></returns>
        public IList<ItemTitle> SearchTitleInfo(string title, string SubjectType, string SubjectItem)
        {
            return iItemTitle.SearchTitleInfo(title, SubjectType, SubjectItem);
        }

    }
}
