using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;

namespace TrafficExam.Bll
{
    public class BllUser
    {

        IUser user = null;
        public BllUser()
        {
            user = BussinessFactory.NewDBUser();
        }

        /// <summary>
        /// 插入用户信息数据
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns></returns>
        public bool InsertData(SystemUser info)
        {
            return user.AddUserInfo(info);
        }
        /// <summary>
        /// 修改用户信息数据
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns></returns>
        public bool UpdateData(SystemUser info)
        {
            return user.UpdateUserInfo(info);
        }
        /// <summary>
        /// 删除用户信息数据
        /// </summary>
        /// <param name="userId">主键Id</param>
        /// <returns></returns>
        public bool DeleteUserInfo(int userId)
        {
            return user.DeleteUserInfo(userId);
        }

       /// <summary>
        /// 更改管理员密码
       /// </summary>
       /// <param name="loginName"></param>
       /// <param name="password"></param>
       /// <returns></returns>
        public  bool UpdateAdminPwd(string loginName, string password)
        {
            return user.UpdateAdminPwd(loginName, password);
        }
        /// <summary>
        /// 判断用户登录名是否重复
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public bool IsOpen(string loginName)
        {
            return user.IsOpen(loginName);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="loginPassword">用户密码</param>
        /// <returns></returns>
        public IList<SystemUser> GetUserInfoList(string loginName, string loginPassword)
        {
            return user.GetUserInfoList(loginName, loginPassword);
        }

        /// <summary>
        ///  获取管理员密码
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IList<SystemUser> GetAdminPwd(string loginName)
        {
            return user.GetAdminPwd(loginName);
        }
        /// <summary>
        /// 用户第一次登录后修改Ip
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="loginName"></param>
        /// <param name="isOpen"></param>
        /// <returns></returns>
        public bool UpdateUserIp(string ipAddress, string loginName)
        {
            return user.UpdateUserIp(ipAddress, loginName);
        }
        /// <summary>
        /// 验证Ip地址
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string CheckIpAddress(string loginName)
        {
            return user.CheckIpAddress(loginName);
        }

        /// <summary>
        /// 提交考试[提交考试只是将IsOpen的true修改为false]
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool SubmitExam(string tableName,string loginName,ref int score)
        {
            return user.SubmitExam(tableName,loginName,ref score);
        }
        /// <summary>
        ///  根据用户等级，获取人员列表
        /// </summary>
        /// <param name="分组Id">groupId</param>
        /// <returns></returns>
        public IList<SystemUser> GetUserList(int groupId)
        {
            return user.GetUserList(groupId);
        }
        /// <summary>
        /// 根据用户表主键获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<SystemUser> GetUserInfo(int userId)
        {
            return user.GetUserInfo(userId);
        }
        /// <summary>
        /// 设置用户状态为打开
        /// </summary>
        /// <param name="PoliceCode"></param>
        /// <returns></returns>
        public bool SetUserState(string loginNames, string TableName)
        {
            return user.SetUserState(loginNames, TableName);
        }
        /// <summary>
        /// 搜索考试人员信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="policeid"></param>
        /// <param name="position"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        public IList<SystemUser> SearchUserInfo(string name, string policeid, string position, string depart)
        {
            return user.SearchUserInfo(name, policeid, position, depart);
        
        }

        /// <summary>
        /// 获取要考试的用户登录名
        /// </summary>
        /// <returns></returns>
        public IList<SystemUser> GetLoginName()
        {
            return user.GetLoginName();
        }
    }

}
