using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data.SqlClient;
using System.Data;
using TrafficExam.Command;


namespace TrafficExam.Data
{
    public class DBUser : IUser
    {
        #region 新增用户
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="info">用户信息</param>
        /// <returns></returns>
        public bool AddUserInfo(SystemUser info)
        {
            //sql语句拼接,采用存储过程书写方式
            string strSql = "Insert into SystemUser(LoginName,LoginPassword,GroupId,PoliceCode,IsOpen,RealName,Sex,PubDateTime,Position,Department) values";
            strSql += "(@loginName,@loginPassword,@groupId,@policeCode,@isOpen,@realName,@sex,@pubDateTime,@position,@department)";
            SqlParameter[] sp = new SqlParameter[10];
            sp[0] = new SqlParameter("@loginName", DbType.String);
            sp[0].Value = info.LoginName;//用户名

            sp[1] = new SqlParameter("@loginPassword", DbType.String);
            sp[1].Value = info.LoginPassword;//密码

            sp[2] = new SqlParameter("@groupId", DbType.Int32);
            sp[2].Value = info.GroupId;//分组

            sp[3] = new SqlParameter("@policeCode", DbType.String);
            sp[3].Value = info.PoliceCode;//警员证

            sp[4] = new SqlParameter("@isOpen", DbType.Boolean);
            sp[4].Value = info.IsOpen;//状态

            sp[5] = new SqlParameter("@realName", DbType.String);
            sp[5].Value = info.RealName;//真实姓名

            sp[6] = new SqlParameter("@sex", DbType.String);
            sp[6].Value = info.Sex;//真实姓名

            sp[7] = new SqlParameter("@pubDateTime", DbType.DateTime);
            sp[7].Value = info.PubDateTime;

            sp[8] = new SqlParameter("@position", DbType.String);
            sp[8].Value = info.Position;

            sp[9] = new SqlParameter("@department", DbType.String);
            sp[9].Value = info.Department;

            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, sp);
        }
        #endregion

        #region  修改用户
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="info">用户信息</param>
        /// <returns></returns>
        public bool UpdateUserInfo(SystemUser info)
        {
            //sql语句拼接,采用存储过程书写方式
            string strSql = "Update SystemUser set LoginName=@LoginName,LoginPassword=@LoginPassword,RealName=@RealName,";
            strSql += "Sex=@Sex,IsOpen=@IsOpen,PoliceCode=@PoliceCode,GroupId=@GroupId,Position=@Position,Department=@Department,PubDateTime=@PubDateTime where UserId=@UserId";
            SqlParameter[] sp = new SqlParameter[11];
            sp[0] = new SqlParameter("@LoginName", DbType.String);
            sp[0].Value = info.LoginName;//用户名

            sp[1] = new SqlParameter("@LoginPassword", DbType.String);
            sp[1].Value = info.LoginPassword;

            sp[2] = new SqlParameter("@RealName", DbType.String);
            sp[2].Value = info.RealName;

            sp[3] = new SqlParameter("@Sex", DbType.String);
            sp[3].Value = info.Sex;

            sp[4] = new SqlParameter("@IsOpen", DbType.Boolean);
            sp[4].Value = info.IsOpen;

            sp[5] = new SqlParameter("@PoliceCode", DbType.String);
            sp[5].Value = info.PoliceCode;

            sp[6] = new SqlParameter("@GroupId", DbType.Int32);
            sp[6].Value = info.GroupId;

            sp[7] = new SqlParameter("@PubDateTime", DbType.DateTime);
            sp[7].Value = info.PubDateTime;

            sp[8] = new SqlParameter("@Position", DbType.DateTime);
            sp[8].Value = info.Position;

            sp[9] = new SqlParameter("@Department", DbType.DateTime);
            sp[9].Value = info.Department;

            sp[10] = new SqlParameter("@UserId", DbType.String);
            sp[10].Value = info.UserId;

            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, sp);
        }
        #endregion

        #region 删除用户信息
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="pkId"></param>
        /// <returns></returns>
        public bool DeleteUserInfo(int userId)
        {
            //sql语句拼接,采用存储过程书写方式
            string strSql = "Delete From SystemUser Where UserId='" + userId + "'";
            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, null);
        }
        #endregion

        #region 根据用户名和密码获取用户信息
        /// <summary> 
        /// 根据用户名和密码获取用户信息
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="loginPassword">用户密码</param>
        /// <returns></returns>
        public IList<SystemUser> GetUserInfoList(string loginName, string loginPassword)
        {
            DataSet ds = new DataSet();
            string strSql = @"Select * From SystemUser Where LoginName='" + loginName + "' and LoginPassword='" + loginPassword + "'";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemUser> list = IListHelper.DataSetToIList<SystemUser>(ds, 0);
            return list;
        }
        #endregion

        #region 更改管理员密码
        /// <summary>
        /// 更改管理员密码
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdateAdminPwd(string loginName, string password)
        {
            string strSql = "update SystemUser set LoginPassword='" + password + "' where LoginName = '" + loginName + "'";
            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, null);

        }
        #endregion

        #region  判断用户是否处于打开状态
        /// <summary>
        /// 判断用户是否处于打开状态
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool IsOpen(string loginName)
        {
            //sql语句拼接,采用存储过程书写方式
            string strSql = " select IsOpen  from SystemUser  where LoginName=@LoginName";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@LoginName", DbType.String);
            sp[0].Value = loginName;//用户名
            return (bool)SqlHelper.ExecuteScalar(CommandType.Text, strSql, sp);
        }
        #endregion

        #region 用户第一次登陆后修改Ip
        /// <summary>
        /// 用户第一次登陆后修改Ip
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool UpdateUserIp(string ipAddress, string loginName)
        {
            //sql语句拼接,采用存储过程书写方式
            string strSql = "Update SystemUser set IpAddress=@IpAddress where LoginName=@LoginName";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@IpAddress", DbType.String);
            sp[0].Value = ipAddress;//Ip地址
            sp[1] = new SqlParameter("@LoginName", DbType.String);
            sp[1].Value = loginName;//用户名

            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, sp);
        }
        #endregion

        #region  验证Ip地址
        /// <summary>
        /// 验证Ip地址
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public string CheckIpAddress(string loginName)
        {
            //sql语句拼接,采用存储过程书写方式
            string strSql = " select IpAddress  from SystemUser  where LoginName=@LoginName";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@LoginName", DbType.String);
            sp[0].Value = loginName;//用户名
            object o = SqlHelper.ExecuteScalar(CommandType.Text, strSql, sp);
            if (o != null)
            {
                return o.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 提交考卷
        /// <summary>
        /// 提交考卷
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool SubmitExam(string tableName, string loginName, ref int Score)
        {
            //sql语句拼接,采用存储过程书写方式
            string view = "";//视图
            if (tableName == "Paper")
            {
                view = "View_Paper";
            }
            else if (tableName == "PraticePaper")
            {
                view = "View_PraticePaper";
            }
            string strSql = "Update SystemUser set IsOpen='false' where LoginName=@LoginName" ;
            string sql = "select Score from " +view+ " where LoginName=N'" + loginName + "'";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@LoginName", DbType.String);
            sp[0].Value = loginName;//用户名
            Score = (int)SqlHelper.ExecuteScalar(CommandType.Text, sql, null);
            return SqlHelper.ExecuteSqlText(CommandType.Text, strSql, sp);
        }

        #endregion

        #region 设置要考试的用户的IsOpen为true状态
        ///<summary>
        ///设置用户的IsOpen为true状态
        ///</summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public bool SetUserState(string loginNames,string TableName)
        {
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@loginNames", DbType.String);
            sp[0].Value = loginNames;//用户名
            sp[1] = new SqlParameter("@TableName", DbType.String);
            sp[1].Value = TableName;//表名
            return SqlHelper.ExecuteSqlText(CommandType.StoredProcedure, "Proc_SetPaper", sp);
        }
        #endregion

        #region 获取人员信息列表
        /// <summary>
        /// 获取人员信息列表
        /// </summary>
        /// <param name="groupId">分组Id</param>
        /// <returns></returns>
        public IList<SystemUser> GetUserList(int groupId)
        {
            DataSet ds = new DataSet();
            string strSql = @"Select UserId, RealName,LoginName, PoliceCode,IsOpen,Position,Department,Sex From SystemUser Where GroupId = '" + groupId + "'";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemUser> list = IListHelper.DataSetToIList<SystemUser>(ds, 0);
            return list;
        }
        #endregion

        #region 获取管理员密码
        /// <summary>
        /// 获取管理员密码
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IList<SystemUser> GetAdminPwd(string loginName)
        {
            DataSet ds = new DataSet();
            string sql = @"select LoginPassword from SystemUser where LoginName = '" + loginName + "'";
            ds = SqlHelper.GetDataSet(CommandType.Text, sql, null);
            IList<SystemUser> list = IListHelper.DataSetToIList<SystemUser>(ds, 0);
            return list;

        }
        #endregion

        #region 根据用户表主键获取用户信息
        /// <summary>
        /// 根据用户表主键获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<SystemUser> GetUserInfo(int userId)
        {
            DataSet ds = new DataSet();
            string strSql = @"Select UserId, RealName,LoginName,LoginPassword, PoliceCode,IsOpen,Position,Department, Sex From SystemUser Where UserId = '" + userId + "'";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemUser> list = IListHelper.DataSetToIList<SystemUser>(ds, 0);
            return list;
        }
        #endregion

        #region 根据考试人员姓名、警号、职务、部门搜索考试人员信息
        /// <summary>
        /// 根据考试人员姓名、警号、职务、部门搜索考试人员信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="policeId"></param>
        /// <param name="position"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        public IList<SystemUser> SearchUserInfo(string name, string policeId, string position, string depart)
        {
            string sqlstr = @"select UserId ,RealName,Sex,PoliceCode,Position,Department from SystemUser where 1 = 1 and groupId=1";
            if (!string.IsNullOrEmpty(name))
            {
                sqlstr += " and replace(RealName,' ','') like '%" + name + "%'";
            }
            if (!string.IsNullOrEmpty(policeId))
            {
                sqlstr += " and PoliceCode like '%" + policeId + "%'";
            }
            if (position != "")
            {
                sqlstr += " and Position = '" + position + "'";
            }
            if (depart != "")
            {
                sqlstr += " and  Department = '" + depart + "'";
            }
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDataSet(CommandType.Text, sqlstr, null);
            IList<SystemUser> list = IListHelper.DataSetToIList<SystemUser>(ds, 0);
            return list;
        }
        #endregion
        #region 获取要考试的用户登录名
        /// <summary>
        /// 获取本次考试的用户登录名
        /// </summary>
        /// <returns></returns>
        public IList<SystemUser> GetLoginName()
        {
            DataSet ds = new DataSet();
            string strSql = @"Select LoginName From SystemUser Where IsOpen = 1 AND GroupId = 1";
            ds = SqlHelper.GetDataSet(CommandType.Text, strSql, null);
            IList<SystemUser> list = IListHelper.DataSetToIList<SystemUser>(ds, 0);
            return list;
        }
        #endregion
    }


}
