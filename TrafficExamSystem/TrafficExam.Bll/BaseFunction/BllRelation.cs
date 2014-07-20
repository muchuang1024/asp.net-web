using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllRelation
    {
        IRelation iRelation = null;
        /// <summary>
        /// 实现工厂
        /// </summary>
        public BllRelation()
        {
            iRelation = BussinessFactory.NewDBRelation();
        }

        /// <summary>
        /// 获得角色对应功能模块ID列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<SystemRelation> GetFunctionList(string groupId)
        {
            return iRelation.GetRelationList(groupId);
        }
        /// <summary>
        /// 更新角色所对应的功能
        /// </summary>
        /// <param name="functionIds">功能节点Id</param>
        /// <param name="groupId">角色对应的Id</param>
        /// <returns></returns>
        public bool UpdateRelationInfo(string functionIds, string groupId)
        {
            return iRelation.UpdateRelationInfo(functionIds, groupId);
        }
    }
}
