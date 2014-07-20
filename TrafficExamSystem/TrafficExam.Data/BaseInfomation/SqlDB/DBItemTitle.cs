using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;
using TrafficExam.Interface;
using System.Data;
using TrafficExam.Command;
using System.Data.SqlClient;
namespace TrafficExam.Data
{
    public class DBItemTitle : IItemTitle
    {
        #region 添加题库
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
            string strSql = "insert into ItemTitle(Title,FirstOption,SecondOption,ThirdOption,FourthOption,FifthOption,SixthOption,Answer,SubjectType,ItemCount,SubjectItem) values";
            strSql += "(@title,@firstoption,@secondoption,@thirdoption,@fourthoption,@fifthoption,@sixthoption,@answer,@subjecttype,@itemcount,@subjectitem)";
            SqlParameter[] sp = new SqlParameter[11];
            sp[0] = new SqlParameter("@title", DbType.String);
            sp[0].Value = item.Title;//题干

            sp[1] = new SqlParameter("@firstoption", DbType.String);
            sp[1].Value = item.FirstOption;//选项1

            sp[2] = new SqlParameter("@secondoption", DbType.String);
            sp[2].Value = item.SecondOption;//选项2

            sp[3] = new SqlParameter("@thirdoption", DbType.String);
            sp[3].Value = item.ThirdOption;//选项3

            sp[4] = new SqlParameter("@fourthoption", DbType.String);
            sp[4].Value = item.FourthOption;//选项4

            sp[5] = new SqlParameter("@fifthoption", DbType.String);
            sp[5].Value = item.FifthOption;//选项5

            sp[6] = new SqlParameter("@sixthoption",DbType.String);
            sp[6].Value = item.SixthOption;//选项6

            sp[7] = new SqlParameter("@answer", DbType.String);
            sp[7].Value = item.Answer;//答案

            sp[8] = new SqlParameter("@subjecttype",DbType.String);
            sp[8].Value = item.SubjectType;//考点

            sp[9] = new SqlParameter("@itemcount", DbType.Int32);
            sp[9].Value = item.ItemCount;//答案个数

            sp[10] = new SqlParameter("@subjectitem", DbType.String);
            sp[10].Value = item.SubjectItem;//题目类型
            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, sp);
           
        }
        #endregion 

        #region 更新题库
        /// <更新题目信息>
        /// 
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
            string strSql = "Update ItemTitle Set Title= @title ,FirstOption=@firstoption,SecondOption=@secondoption,ThirdOption=@thirdoption,FourthOption=@fourthoption,FifthOption=@fifthoption,SixthOption= @sixthoption,Answer=@answer ,SubjectType=@subjecttype,ItemCount=@itemcount,SubjectItem=@subjectitem";
            strSql += " where  TitleId=@titleid";
            SqlParameter[] sp = new SqlParameter[12];
            sp[0] = new SqlParameter("@title", DbType.String);
            sp[0].Value = item.Title;//题干

            sp[1] = new SqlParameter("@firstoption", DbType.String);
            sp[1].Value = item.FirstOption;//选项1

            sp[2] = new SqlParameter("@secondoption", DbType.String);
            sp[2].Value = item.SecondOption;//选项2

            sp[3] = new SqlParameter("@thirdoption", DbType.String);
            sp[3].Value = item.ThirdOption;//选项3

            sp[4] = new SqlParameter("@fourthoption", DbType.String);
            sp[4].Value = item.FourthOption;//选项4

            sp[5] = new SqlParameter("@fifthoption", DbType.String);
            sp[5].Value = item.FifthOption;//选项5

            sp[6] = new SqlParameter("@sixthoption", DbType.String);
            sp[6].Value = item.SixthOption;//选项6

            sp[7] = new SqlParameter("@answer", DbType.String);
            sp[7].Value = item.Answer;//答案

            sp[8] = new SqlParameter("@subjecttype", DbType.String);
            sp[8].Value = item.SubjectType;//考点

            sp[9] = new SqlParameter("@itemcount", DbType.Int32);
            sp[9].Value = item.ItemCount;//答案个数

            sp[10] = new SqlParameter("@subjectitem", DbType.String);
            sp[10].Value = item.SubjectItem;//题目类型

            sp[11] = new SqlParameter("@titleid", DbType.String);
            sp[11].Value = item.TitleId;//题号
            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, sp);
           
        }
        #endregion

        #region 删除题库
        /// <summary>
        /// 根据题号删除题目信息
        /// </summary>
        /// <param name="itemTitleId"></param>
        /// <returns></returns>
        public bool DeleteItemTitle(int itemTitleId)
        {
            string strSql = "delete from ItemTitle where TitleId='" + itemTitleId + "'";
            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, null);
        }
        #endregion

        #region 根据条件(分页)获取题库信息列表
        /// <summary>
        /// 根据条件获取题库信息列表
        /// </summary>
        /// <param name="tableName">表名,多表[A,B这样的方式传递]</param>
        /// <param name="fields">查询字段</param>
        /// <param name="orderFieldType">排序字段,以及排序方式,字段与方式中间使用空格分开</param>
        /// <param name="PageIndex">显示第几页</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="where">查询条件</param>
        /// <param name="TotalPage">总页数</param>
        /// <param name="RowCount">总记录数</param>
        /// <returns></returns>
        public IList<ItemTitle> GetItemTitleList(string tableName, string fields, string orderFieldType, int pageIndex, int pageSize, string where, ref int pageCount, ref int rowCount)
        {
            DataTable dt = Proc_Page.GetDataTablePage(tableName, fields, orderFieldType, pageIndex, pageSize, where, ref  pageCount, ref  rowCount);
            return IListHelper.DataTableToIList<ItemTitle>(dt);
            
            
        }
        #endregion 

        #region 根据题号获取考题信息
        /// <summary>
        /// 根据题号获取信息
        /// </summary>
        /// <param name="itemTitleId"></param>
        /// <returns></returns>
        public IList<ItemTitle> GetItemTitleInfo(int itemTitleId)
        {
            DataSet ds = new DataSet();
            string strsql = @"select * from ItemTitle where TitleId='" + itemTitleId + "'";
            ds = SqlHelper.GetDataSet(CommandType.Text, strsql, null);
            IList<ItemTitle> list = IListHelper.DataSetToIList<ItemTitle>(ds, 0);
            return list;
        }
        #endregion

        #region 根据条件搜索题库信息列表
        /// <summary>
        /// 根据条件搜索题库信息列表
        /// </summary>
        /// <param name="title"></param>
        /// <param name="SubjectType"></param>
        /// <param name="SubjectItem"></param>
        /// <returns></returns>
        public IList<ItemTitle> SearchTitleInfo(string title, string SubjectType, string SubjectItem)
        {
            string sqlstr = @"select Title,SubjectType,ItemCount,SubjectItem,TitleId from ItemTitle where 1 = 1";
             if(title != "")
             {
                sqlstr +="and Title like '%"+title+"%'";
             }
             if(SubjectType !="")
             {
                 sqlstr += " and SubjectType = '"+SubjectType+"'";
             }
             if(SubjectItem != "")
             {
                sqlstr +=" and SubjectItem = '"+SubjectItem+"'";
             }
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDataSet(CommandType.Text, sqlstr, null);
            IList<ItemTitle> list = IListHelper.DataSetToIList<ItemTitle>(ds, 0);
            return list;
        }
        #endregion

    }
}
