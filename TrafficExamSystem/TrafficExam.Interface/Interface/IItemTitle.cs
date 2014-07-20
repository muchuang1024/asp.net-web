using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IItemTitle
    {

        /// <summary>
        /// 添加题库
        /// </summary>
        /// <param name="info">题库对象</param>
        /// <returns></returns>
        bool InsertItemTitle(ItemTitle item);
        /// <summary>
        /// 修改题库信息
        /// </summary>
        /// <param name="info">题库对象</param>
        /// <returns></returns>
        bool UpdateItemTitle(ItemTitle item);
        /// <summary>
        /// 删除题库信息
        /// </summary>
        /// <param name="messageId">题库Id</param>
        /// <returns></returns>
        bool DeleteItemTitle(int itemTitleId);
        /// <summary>
        /// 获取题库列表(含分页)
        /// </summary>
        /// <returns></returns>
        IList<ItemTitle> GetItemTitleList(string tableName, string fields, string orderFieldType, int pageIndex, int pageSize, string where, ref int pageCount, ref int rowCount);
        /// <summary>
        /// 根据题库Id获取题库信息
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        IList<ItemTitle> GetItemTitleInfo(int itemTitleId);
        /// <summary>
        /// 根据题干信息、考点、题目类型进行搜索
        /// </summary>
        /// <param name="title"></param>
        /// <param name="SubjectType"></param>
        /// <param name="SubjectItem"></param>
        /// <returns></returns>
        IList<ItemTitle> SearchTitleInfo(string title, string SubjectType, string SubjectItem);
       
    }
}
