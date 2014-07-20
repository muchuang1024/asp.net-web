using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data;
using TrafficExam.Command;

namespace TrafficExam.Data
{
    public class DBGroup : IGroup
    {
        #region 获取所有的权限分组名称
        /// <summary>
        /// 获取所有的权限分组名称
        /// </summary>
        /// <returns></returns>
        public IList<SystemGroup> GetGroupList()
        {
            DataSet ds = new DataSet();
            string strsql = @"Select * From SystemGroup";
            ds = SqlHelper.GetDataSet(CommandType.Text, strsql, null);
            IList<SystemGroup> list = IListHelper.DataSetToIList<SystemGroup>(ds, 0);
            return list;
        }
        #endregion
    }
}
