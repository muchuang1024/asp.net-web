using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

namespace TrafficExam.Command
{
    /// <summary>
    /// List Transfer DataTable Class
    /// </summary>
    public class IListHelper
    {
        /// <summary>
        /// 将IList<T> 转换为DataSet
        /// </summary>
        /// <param name="i_objlist"></param>
        /// <returns></returns>
        public static DataSet ConvertToDataSet<T>(IList<T> i_objlist)
        {
            if (i_objlist == null || i_objlist.Count <= 0)
            {
                return null;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (T t in i_objlist)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            return ds;
        }

        /// <summary>
        /// 将IList<T>转换为DataTable
        /// </summary>
        /// <param name="i_objlist"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> i_objlist)
        {
            if (i_objlist == null || i_objlist.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (T t in i_objlist)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }
            return dt;
        }
        /// <summary>
        /// DataSet转换为泛型集合
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns></returns>
        public static IList<T> DataSetToIList<T>(DataSet p_DataSet, int p_TableIndex)
        {

            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return null;
            if (p_TableIndex < 0)
                p_TableIndex = 0;
            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            //返回值初始化
            IList<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        //属性与字段名称一致的进行赋值
                        if (pi.Name.Equals(p_Data.Columns[i].ColumnName))
                        {
                            //数据库Null值单独处理
                            if (p_Data.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, p_Data.Rows[j][i], null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }
        /// <summary>
        /// DataTable转换为泛型集合
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="p_DataTable">DataTable</param>
        /// <returns></returns>
        public static IList<T> DataTableToIList<T>(DataTable p_DataTable)
        {
            //返回值初始化
            IList<T> result = new List<T>();
            for (int j = 0; j < p_DataTable.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_DataTable.Columns.Count; i++)
                    {
                        //属性与字段名称一致的进行赋值
                        if (pi.Name.Equals(p_DataTable.Columns[i].ColumnName))
                        {
                            //数据库Null值单独处理
                            if (p_DataTable.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, p_DataTable.Rows[j][i], null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        /// <summary>
        /// DataSet转换为泛型集合
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableName">待转换数据表名称</param>
        /// <returns></returns>
        public static IList<T> DataSetToIList<T>(DataSet p_DataSet, string p_TableName)
        {
            int _TableIndex = 0;
            //DataSet没有数据返回null
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            //没有待装换的数据表名称返回null
            if (string.IsNullOrEmpty(p_TableName))
                return null;
            for (int i = 0; i < p_DataSet.Tables.Count; i++)
            {
                if (p_DataSet.Tables[i].TableName.Equals(p_TableName))
                {
                    _TableIndex = i;
                    break;
                }
            }
            return DataSetToIList<T>(p_DataSet, _TableIndex);
        }

        /// <summary>
        /// 将IList转换为DataTable
        /// </summary>
        /// <param name="i_objlist"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(IList i_objlist)
        {
            if (i_objlist == null || i_objlist.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = i_objlist[0].GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo pi in myPropertyInfo)
            {
                if (pi == null)
                {
                    continue;
                }
                dt.Columns.Add(pi.Name, System.Type.GetType(pi.PropertyType.ToString()));
            }
            for (int j = 0; j < i_objlist.Count; j++)
            {
                row = dt.NewRow();
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];
                    row[pi.Name] = pi.GetValue(i_objlist[j], null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 将IList转换为DataSet
        /// </summary>
        /// <param name="i_objlist"></param>
        /// <returns></returns>
        public static DataSet ConvertToDataSet(IList i_objlist)
        {
            if (i_objlist == null || i_objlist.Count <= 0)
            {
                return null;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = i_objlist[0].GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo pi in myPropertyInfo)
            {
                if (pi == null)
                {
                    continue;
                }
                dt.Columns.Add(pi.Name, System.Type.GetType(pi.PropertyType.ToString()));
            }
            for (int j = 0; j < i_objlist.Count; j++)
            {
                row = dt.NewRow();
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];
                    row[pi.Name] = pi.GetValue(i_objlist[j], null);
                }
                dt.Rows.Add(row);
            }
            ds.Tables.Add(dt);
            return ds;
        }
    }
}
