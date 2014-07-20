using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using System.Data;
using TrafficExam.Command;
using TrafficExam.Model;
using System.Data.SqlClient;

namespace TrafficExam.Data
{
    public class DBFunction : IFunction
    {
        #region 根据页面地址获取树形菜单Id
        /// <summary>
        /// 根据页面地址获取树形菜单Id
        /// </summary>
        /// <param name="hrefAddress">页面地址</param>
        /// <returns></returns>
        public int GetFunctionId(string hrefAddress)
        {
            int functionId = 0;
            object searchId = SqlHelper.ExecuteScalar(CommandType.Text, "select FunctionId  from  SystemFunction where Href=@hrefAddress", new SqlParameter("@hrefAddress", hrefAddress));
            if (searchId != null)
                functionId = Convert.ToInt32(searchId);
            return functionId;
        }
        #endregion

        #region 判断用户是否有访问页面权限
        /// <summary>
        /// 判断用户是否有访问页面权限
        /// </summary>
        /// <param name="hrefAddress">页面地址</param>
        /// <param name="loginName">登陆名</param>
        /// <returns></returns>
        public bool IsBrowsed(string hrefAddress, string loginName)
        {
            //AdminBasePage.cs判断用户是否有访问页面权限
            //如果用户在浏览器地址中输入不符合规则的地址.则数据库中不存在记录,那么functionId为0,直接返回false
            int functionId = GetFunctionId(hrefAddress);
            if (functionId != 0)
            {
                string strsql = @"select SystemFunction.FunctionId from SystemFunction";
                strsql += " inner join SystemRelation on SystemFunction.FunctionId=SystemRelation.FunctionId ";
                strsql += " inner join SystemUser on SystemRelation.GroupId=SystemUser.GroupId";
                strsql += " where SystemUser.LoginName='" + loginName + "'";
                DataTable dt = SqlHelper.GetDataTable(CommandType.Text, strsql, null);
                foreach (DataRow dr in dt.Rows)
                {
                    if (functionId == Convert.ToInt32(dr["FunctionId"]))
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region 获取树形菜单Id下所有节点列表
        /// <summary>
        /// 获取树形菜单Id下所有节点列表
        /// </summary>
        /// <param name="treeId">树形菜单ID</param>
        /// <returns></returns>
        public IList<SystemFunction> GetFunctionList(string treeId)
        {
            string strSql = @"Select *  From  SystemFunction Where motherId='" + treeId + "'";
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemFunction> list = IListHelper.DataSetToIList<SystemFunction>(ds, 0);
            return list;
        }
        #endregion

        #region 获取用户所对应的树形菜单下节点列表
        /// <summary>
        /// 获取用户所对应的树形菜单下节点列表
        /// </summary>
        /// <param name="treeId">树形菜单Id</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public IList<SystemFunction> GetFunctionList(string treeId, string loginName)
        {
            string strSql = "select SystemFunction.* from SystemFunction";
            strSql += " inner join SystemRelation on SystemFunction.FunctionId=SystemRelation.FunctionId";
            strSql += " inner join SystemUser on SystemRelation.GroupId=SystemUser.GroupId";
            strSql += " inner join SystemGroup on SystemGroup.GroupId=SystemUser.GroupId where";
            strSql += " SystemFunction.MotherId='" + treeId + "' and SystemUser.LoginName='" + loginName + "'";
            strSql += " order by SystemFunction.FunctionId";
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemFunction> list = IListHelper.DataSetToIList<SystemFunction>(ds, 0);
            return list;
        }
        #endregion

        #region 获取角色所对应的功能列表
        /// <summary>
        /// 获取角色所对应的功能列表
        /// </summary>
        /// <param name="groupId">功能节点Id</param>
        /// <returns></returns>
        public IList<SystemFunction> GetFunctionListByGroupId(string groupId)
        {
            DataSet ds = new DataSet();
            string strSql = @"select SystemFunction.* from SystemFunction ";
            strSql += " inner join (select FunctionId from SystemRelation where groupId='" + groupId + "')t";
            strSql += " on SystemFunction.FunctionId=t.FunctionId";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemFunction> list = IListHelper.DataSetToIList<SystemFunction>(ds, 0);
            return list;
        }
        #endregion
    }
}
