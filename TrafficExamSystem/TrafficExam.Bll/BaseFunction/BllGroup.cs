using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllGroup
    {
        IGroup iGroup = null;
        /// <summary>
        /// 实现工厂
        /// </summary>
        public BllGroup()
        {
            iGroup = BussinessFactory.NewDBGroup();
        }
        /// <summary>
        /// 获取所有权限分组名称
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<SystemGroup> GetGroupList()
        {
            return iGroup.GetGroupList();
        }
    }
}
