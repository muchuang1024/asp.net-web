using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllFunction
    {

        IFunction iFunction = null;
        /// <summary>
        /// 实现工厂
        /// </summary>
        public BllFunction()
        {
            iFunction = BussinessFactory.NewDBFunction();
        }
        /// <summary>
        /// 判断用户是否具有页面访问权限
        /// </summary>
        /// <param name="hrefAddress"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool IsBrowsed(string hrefAddress, string loginName)
        {
            return iFunction.IsBrowsed(hrefAddress, loginName);
        }
        /// <summary>
        /// 根据页面地址返回树形菜单ID
        /// </summary>
        /// <param name="hrefAddress"></param>
        /// <returns></returns>
        public int GetFunctionId(string hrefAddress)
        {
            return iFunction.GetFunctionId(hrefAddress);
        }

        /// <summary>
        /// 获取树形菜单ID下所有节点列表
        /// </summary>
        /// <param name="treeId">树形菜单ID</param>
        /// <returns></returns>
        public IList<SystemFunction> GetFunctionList(string treeId)
        {
            return iFunction.GetFunctionList(treeId);
        }
        /// <summary>
        /// 获取用户所对应的树形菜单下节点列表
        /// </summary>
        /// <param name="treeId">树形菜单ID</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public IList<SystemFunction> GetFunctionList(string treeId, string loginName)
        {
            return iFunction.GetFunctionList(treeId, loginName);
        }
        /// <summary>
        ///  获取角色（用户等级）所对应的功能模块列表
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public IList<SystemFunction> GetFunctionListByGroupId(string groupId)
        {
            return iFunction.GetFunctionListByGroupId(groupId);
        }
    }
}
