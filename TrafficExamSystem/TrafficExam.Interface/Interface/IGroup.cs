using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IGroup
    {
        /// <summary>
        /// 获取所有权限分组列表
        /// </summary>
        /// <returns></returns>
        IList<SystemGroup> GetGroupList();
    }
}
