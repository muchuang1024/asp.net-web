using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TrafficExam.Command
{
    public class SqlHelper
    {
        private SqlHelper() { }

        /// <summary>
        /// 连接数据库方法
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            return GetConn.GetConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TrafficExamConnectionString"].ConnectionString);
        }
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">SqlCommand参数格式</param>
        /// <param name="cmdText">存储过程的名称或T - SQL命令</param>
        /// <param name="cmdParms">一个SqlParamters数组，用于传递参数</param>
        /// <returns>一个SqlDataReader包含的结果</returns>
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = SqlHelper.GetConnection();
            try
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                //在执行CommandBehavior命令时，如果关闭关联的DataReader对象，则关联的Connection对象也关闭
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (Exception ex)
            {
                connection.Close();
                return GetExceptionLogInfo(ex) as SqlDataReader;
            }
        }

        private static object GetExceptionLogInfo(Exception ex)
        {
            ExceptionLogInfo logInfo = ExceptionLogInfo.LogInstance();
            logInfo.WriterLog(ex.ToString());
            return null;
        }
        /// <summary>
        /// 返回数据集DataTable
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            SqlConnection conn = SqlHelper.GetConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();
                cmd.CommandText = cmdText;
                cmd.Connection = conn;
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                cmd.Dispose();
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                return GetExceptionLogInfo(ex) as DataTable;
            }
        }
        /// <summary>
        /// 返回数据集DataSet
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            SqlConnection conn = SqlHelper.GetConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();
                cmd.CommandText = cmdText;
                cmd.Connection = conn;
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                cmd.Dispose();
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                return GetExceptionLogInfo(ex) as DataSet;
            }
        }

        /// <summary>
        /// 返回一行
        /// </summary>
        /// <param name="strsql">要执行的SQL语句</param>
        /// <returns></returns>
        public static DataRow GetDataRow(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            try
            {
                DataSet ds = null;
                ds = GetDataSet(cmdType, cmdText, cmdParms);
                if (ds != null & ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return GetExceptionLogInfo(ex) as DataRow;
            }
        }

        /// <summary>
        /// 执行返回第一行第一列值的语句
        /// </summary>
        /// <param name="sqlStr">返回第一行第一列值</param>
        /// <returns></returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = SqlHelper.GetConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                // ExecuteScalar的作用是执行查询，并返回查询所返回的查询结果集中的第1行第1列，忽略其它行或列；
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                cmd.Dispose();
                connection.Close();
                return val;
            }
            catch (Exception ex)
            {
                connection.Close();
                return GetExceptionLogInfo(ex);
            }
        }

        /// <summary>
        /// 准备一个用于执行SQL命令的方法
        /// </summary>
        /// <param name="cmd">SqlCommand object/SqlCommand对象[SqlCommand：数据库语句]</param>
        /// <param name="conn">SqlConnection object/SqlConnection对象[SqlConnection：数据库连接]</param>
        /// <param name="trans">SqlTransaction object/SqlTransaction对象[SqlTransaction：SQL事务]</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text/键入cmd存储过程或sql语句</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products/命令文本，例如：选择产品</param>
        /// <param name="cmdParms">SqlParameters to use in the command/一个SqlParamters数组，用于执行命令</param>
        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        /// <summary>
        /// 执行sql语句方法
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool ExecuteSqlText(CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = SqlHelper.GetConnection();
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();
            try
            {
                //这个是执行回滚的方法,如果要回滚那么必须先 connection.Open()
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                // ExecuteScalar的作用是执行查询，并返回查询所返回的查询结果集中的第1行第1列，忽略其它行或列；
                int val = cmd.ExecuteNonQuery();
                trans.Commit();
                cmd.Parameters.Clear();
                cmd.Dispose();
                connection.Close();
                if (val > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                GetExceptionLogInfo(ex);
                return false;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
            }
        }
    }
}
