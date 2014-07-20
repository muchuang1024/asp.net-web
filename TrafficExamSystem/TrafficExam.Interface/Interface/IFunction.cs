using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IFunction
    {
        /// <summary>
        /// 根据地址获取树形菜单ID
        /// </summary>
        /// <param name="hrefAddress">浏览器地址</param>
        /// <returns></returns>
        int GetFunctionId(string hrefAddress);
        /// <summary>
        /// 判断用户是否具有页面浏览权限
        /// </summary>
        /// <param name="functionId">树形菜单Id</param>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        bool IsBrowsed(string hrefAddress, string loginName);
        /// <summary>
        /// 获取所有节点列表【超级管理员直接获取,传递值为"1"】
        /// </summary>
        /// <param name="treeId">树形菜单ID</param>
        /// <returns></returns>
        IList<SystemFunction> GetFunctionList(string treeId);
        /// <summary>
        /// 获取用户所对应的节点列表
        /// </summary>
        /// <param name="treeId">树形菜单ID</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        IList<SystemFunction> GetFunctionList(string treeId, string loginName);
        /// <summary>
        /// 获取角色所对应的功能列表
        /// </summary>
        /// <param name="groupId">角色分组Id</param>
        /// <returns></returns>
        IList<SystemFunction> GetFunctionListByGroupId(string groupId);

    }
}
