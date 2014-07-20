using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data;
using TrafficExam.Command;
using System.Data.SqlClient;

namespace TrafficExam.Data
{
    public class DBRelation : IRelation
    {
        #region 根据角色分组Id返回对应的功能节点Id
        /// <summary>
        /// 根据角色分组Id返回对应的功能节点Id
        /// </summary>
        /// <param name="groupId">角色分组Id</param>
        /// <returns></returns>
        public IList<SystemRelation> GetRelationList(string groupId)
        {
            DataSet ds = new DataSet();
            string strSql = @"Select FunctionId From SystemRelation Where groupId='" + groupId + "'";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemRelation> list = IListHelper.DataSetToIList<SystemRelation>(ds, 0);
            return list;
        }
        #endregion

        #region  更新角色对用的功能分组

        string groupkeys = "";
        /// <summary>
        /// 更新角色对用的功能分组
        /// </summary>
        /// <param name="functionIds">功能分组</param>
        /// <param name="groupId">角色Id</param>
        /// <returns></returns>
        public bool UpdateRelationInfo(string functionIds, string groupId)
        {
            //为角色分配了多个功能,在前端JS数组传递时,默认采用逗号分割,所以这里增加了判断,取得所有功能节点及其子节点
            if (functionIds.Contains(","))
            {
                string[] functionId = functionIds.Split(',');
                for (int i = 0; i <= functionId.Length - 1; i++)
                {
                    GetOldGroupId(functionId[i].ToString());
                }
            }
            else//当角色只分配了一个功能，取得该节点及其子节点
            {
                GetOldGroupId(functionIds);
            }
            //获取到递归的节点+自身节点,此时完整的为角色分配好所有的功能节点ID
            groupkeys = groupkeys + functionIds;
            //解析出所有的角色对应功能ID
            string[] groupkey = groupkeys.Split(',');
            //首先清除该角色所对应的功能ID,及SystemRelation表中的groupId,其中默认功能管理及FunctionId=1的不清理
            string sql = "Delete From SystemRelation Where GroupId='" + groupId + "' and FunctionId<>'1' ";
            for (int j = 0; j <= groupkey.Length - 1; j++)
            {
                //为角色组合所有的功能ID
                sql += " Insert SystemRelation(GroupId,FunctionId) Values('" + groupId + "','" + groupkey[j].ToString() + "')";
            }
            groupkeys = "";//当使用递归删除的时候,超过4层,CLR垃圾清理器并没有清理掉变量值,这里需要手动清除
            return SqlHelper.ExecuteSqlText(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 获取节点所包含的所有子功能节点ID,使用逗号分割
        /// 【递归调用方法】
        /// </summary>
        /// <param name="groupkey"></param>
        /// <returns></returns>
        private string GetOldGroupId(string functionId)
        {
            string parentkey = functionId;//上级节点

            string sql = "SELECT FunctionId  FROM  SystemFunction where  MotherId='" + parentkey + "'";
            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, "SELECT FunctionId  FROM SystemFunction where  MotherId=@functionId", new SqlParameter("@functionId", functionId));
            while (dr.Read())//当第一次为传递进来的groupkey及其子节点全部遍历完以后，在回到最初的groupkey进行递归,这个时候执行的记录是已经遍历完第一次的记录在回到初始记录进行递归
            {
                groupkeys += dr["FunctionId"].ToString() + ',';
                GetOldGroupId(dr["FunctionId"].ToString());//这里的递归的意思是他会把自己传递进行的执行完了以后，在回来执行执行下部的查询
            }
            dr.Close();//SqlDataReader递归调用,用一次关一次
            return groupkeys;
        }
        #endregion
    }
}
