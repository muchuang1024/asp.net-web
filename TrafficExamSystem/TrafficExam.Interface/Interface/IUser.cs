using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Model;

namespace TrafficExam.Interface
{
    public interface IUser
    {
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        bool AddUserInfo(SystemUser info);
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        bool UpdateUserInfo(SystemUser info);
        /// <summary>
        /// 删除数据,单条
        /// </summary>s
        /// <param name="pkId">主键ID</param>
        /// <returns></returns>
        bool DeleteUserInfo(int userId);

        /// <summary>
        ///  根据用户名与密码获取用户信息
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="loginPassword">密码</param>
        /// <returns></returns>
        IList<SystemUser> GetUserInfoList(string loginName, string loginPassword);

        /// <summary>
        /// 获取管理员密码
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        IList<SystemUser> GetAdminPwd(string loginName);
        /// <summary>
        /// 验证用户是否打开
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        bool IsOpen(string loginName);
        /// <summary>
        /// 修改Ip地址
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        bool UpdateUserIp(string ipAddress, string loginName);

        /// <summary>
        /// 更新管理员密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool UpdateAdminPwd(string loginName, string password);
        /// <summary>
        /// 验证Ip地址
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
   
        string CheckIpAddress(string loginName);

        /// <summary>
        /// 提交考试
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        bool SubmitExam(string tableName,string loginName,ref int Score);

        /// <summary>
        /// 根据用户等级，获取人员列表
        /// </summary>
        /// <param name="Depart"></param>
        /// <returns></returns>
        IList<SystemUser> GetUserList(int groupId);
        /// <summary>
        /// 根据用户表主键获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<SystemUser> GetUserInfo(int userId);
        /// <summary>
        /// 设置人员状态打开
        /// </summary>
        /// <param name="loginNames">用户名组合</param>
        /// <returns></returns>
        bool SetUserState(string loginNames,string TableName);

        /// <summary>
        /// 考试人员信息搜索
        /// </summary>
        /// <param name="name"></param>
        /// <param name="policeid"></param>
        /// <param name="position"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        IList<SystemUser> SearchUserInfo(string name, string policeid, string position, string depart);

        /// <summary>
        /// 获取要考试的用户登录名
        /// </summary>
        /// <returns></returns>
        IList<SystemUser> GetLoginName();




    }
}
