using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IRelation
    {
        /// <summary>
        /// 根据角色分组Id获取对应菜单节点列表
        /// </summary>
        /// <param name="groupId">角色分组Id</param>
        /// <returns></returns>
        IList<SystemRelation> GetRelationList(string groupId);

        /// <summary>
        /// 更新角色对应的功能分组
        /// </summary>
        /// <param name="functionIds">功能分组</param>
        /// <param name="groupId">角色Id</param>
        /// <returns></returns>
        bool UpdateRelationInfo(string functionIds, string groupId);

    }
}
