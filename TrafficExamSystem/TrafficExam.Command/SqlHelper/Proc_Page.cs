using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TrafficExam.Command
{
    public class Proc_Page
    {/// <summary>
        ///  分页存储过程,支持多表.
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
        public static DataTable GetDataTablePage(string tableName, string fields, string orderFieldType, int pageIndex, int pageSize, string where, ref int pageCount, ref int rowCount)
        {
            SqlParameter[] sp = new SqlParameter[8];
            sp[0] = new SqlParameter("@tableName", DbType.String);
            sp[0].Value = tableName;//@TableName varchar(5000),--传递进去表名,可以为多表

            sp[1] = new SqlParameter("@fields", DbType.Int32);
            sp[1].Value = fields;//@Fields varchar(5000), --表中的字段，查询的字段必须只能出现1次,同时为了提高效率,最好不要用*

            sp[2] = new SqlParameter("@orderField", DbType.String);// @OrderField varchar(5000), --要排序的字段
            sp[2].Value = orderFieldType;

            sp[3] = new SqlParameter("@sqlWhere", DbType.String);//@sqlWhere varchar(5000), --WHERE子句,查询条件
            sp[3].Value = where;

            sp[4] = new SqlParameter("@pageIndex", DbType.Int32);//@pageIndex int, --要显示的页的索引
            sp[4].Value = pageIndex;

            sp[5] = new SqlParameter("@pageSize", DbType.Int32);//@pageSize int, --分页的大小，每页显示的记录条数
            sp[5].Value = pageSize;

            sp[6] = new SqlParameter("@pageCount", DbType.Int32);//@TotalPage int output --页的总数,输出参数
            sp[6].Value = pageCount;
            sp[6].Direction = ParameterDirection.Output;


            sp[7] = new SqlParameter("@rowCount ", DbType.Int32);//@RowCount int output  --记录总数,输出参数
            sp[7].Value = rowCount;
            sp[7].Direction = ParameterDirection.Output;

            DataTable dt = SqlHelper.GetDataTable(CommandType.StoredProcedure, "usp_PagingLarge", sp);
            pageCount = (Int32)sp[6].Value;
            rowCount = (Int32)sp[7].Value;
            return dt;

        }

    }
}
