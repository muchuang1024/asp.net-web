using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficExam.Command;
using TrafficExam.Model;
using TrafficExam.Bll;
using MDS.XJSON.Core;

namespace TrafficExam.Web.SystemApplication
{
    public partial class UserRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                int userId = 0;
                string condition = "";
                string loginName = Session["LoginName"].ToString();
                switch (Request["ActionName"].ToString())
                {
                    case "InsertUser":
                        condition = Request["Condition"].ToString().Trim();
                        Response.Write(json.Serialize(InsertUser(condition)));
                        break;
                    case "UpdateUserInfo":
                        condition = Request["Condition"].ToString().Trim();
                        userId = Convert.ToInt32(Request["UserId"].ToString().Trim());
                        Response.Write(json.Serialize(UpdateUserInfo(condition, userId)));
                        break;
                    case "GetUserList":
                        Response.Write(IJsonHelper.ListToJson<SystemUser>(GetUserList(1), "UserInfo"));
                        break;
                    case "DeleteUserInfo":
                        userId = Convert.ToInt32(Request["UserId"].ToString().Trim());
                        Response.Write(json.Serialize(DeleteUserInfo(userId)));
                        break;
                    case "GetUserInfo":
                        userId = Convert.ToInt32(Request["UserId"].ToString().Trim());
                        Response.Write(IJsonHelper.ListToJson<SystemUser>(GetUserInfo(userId), "UserInfo"));
                        break;
                    case "UpdateAdminPassword":
                        string password =  Request["Password"].ToString().Trim();
                        Response.Write(json.Serialize(UpdateAdminPass(loginName, password)));
                        break;
                    case "GetAdminPwd":
                        Response.Write(IJsonHelper.ListToJson<SystemUser>(GetAdminPwd(loginName), "UserInfo"));
                        break;
                    case "SearchUserInfo":
                        string name = Request["Name"].ToString().Trim().Replace(" ", "");
                        string policeid = Request["PoliceId"].ToString().Trim();
                        string position = Request["Position"].ToString().Trim();
                        string depart = Request["Depart"].ToString().Trim();
                        Response.Write(IJsonHelper.ListToJson<SystemUser>(SearchUserInfo(name, policeid, position, depart), "UserInfo"));
                        break;
                 
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogInfo log = ExceptionLogInfo.LogInstance();
                log.WriterLog(ex.ToString());
            }
        }
        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        private bool InsertUser(string condition)
        {
            BllUser bllUser = new BllUser();
            SystemUser userInfo = new SystemUser();
            bool result = GetUserInfo(condition, ref userInfo);
            if (result)
            {
                userInfo.GroupId = 1;
                userInfo.IsOpen = false;
                return bllUser.InsertData(userInfo);
            }
            return true;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        private bool UpdateUserInfo(string condition, int userId)
        {
            BllUser bllUser = new BllUser();
            SystemUser userInfo = new SystemUser();
            bool result = GetUserInfo(condition, ref userInfo);
            if (result)
            {
                userInfo.UserId = userId;
                userInfo.GroupId = 1;
                userInfo.IsOpen = false;
                return bllUser.UpdateData(userInfo);
            }
            return true;
        }

        /// <summary>
        /// 获取分组对应用户信息列表
        /// </summary>
        /// <param name="groupId">分组Id</param>
        /// <returns></returns>
        private IList<SystemUser> GetUserList(int groupId)
        {
            BllUser bllUser = new BllUser();
            return bllUser.GetUserList(groupId);
        }

        /// <summary>
        /// 获取管理员密码
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        private IList<SystemUser> GetAdminPwd(string loginName)
        {
            BllUser bllUser = new BllUser();
            return bllUser.GetAdminPwd(loginName);
        }
        /// <summary>
        /// 根据用户表主键获取用户信息
        /// </summary>
        /// <param name="userId">用户表主键</param>
        /// <returns></returns>
        private IList<SystemUser> GetUserInfo(int userId)
        {
            BllUser bllUser = new BllUser();
            return bllUser.GetUserInfo(userId);
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userId">用户表主键</param>
        /// <returns></returns>
        private bool DeleteUserInfo(int userId)
        {
            BllUser bllUser = new BllUser();
            return bllUser.DeleteUserInfo(userId);
        }

        #region 解析传递参数信息为用户信息赋值
        /// <summary>
        /// 解析传递参数信息为车辆信息赋值
        /// </summary>
        /// <param name="condition">条件字符串</param>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        private bool GetUserInfo(string condition, ref  SystemUser userInfo)
        {
            string fields = "";
            string[] conditions = condition.Split('&');
            string[] field = null;
            for (int i = 0; i < conditions.Length; i++)
            {
                fields = conditions[i].ToString();
                field = fields.Split('=');

                if (field[0].ToString() == "RealName")
                {
                    if (!string.IsNullOrEmpty(field[1].ToString()))//姓名
                    {
                        userInfo.RealName = field[1].ToString();
                    }
                }
                if (field[0].ToString() == "Sex")//性别
                {
                    if (!string.IsNullOrEmpty(field[1].ToString()))
                        userInfo.Sex = field[1].ToString().Trim();
                }
                if (field[0].ToString() == "LoginPassword")//密码
                {
                    if (!string.IsNullOrEmpty(field[1].ToString()))
                        userInfo.LoginPassword = field[1].ToString().Trim();
                }
                if (field[0].ToString() == "PoliceCode")
                {
                    if (!string.IsNullOrEmpty(field[1].ToString()))//警号
                    {
                        userInfo.LoginName = MethodResources.FilterSQL(field[1].ToString());
                        userInfo.PoliceCode = MethodResources.FilterSQL(field[1].ToString());
                    }
                }
                if (field[0].ToString() == "Position")//职务
                {
                    if (!string.IsNullOrEmpty(field[1].ToString()))
                        userInfo.Position = field[1].ToString().Trim();
                }
                if (field[0].ToString() == "Department")//部门
                {
                    if (!string.IsNullOrEmpty(field[1].ToString()))
                        userInfo.Department = field[1].ToString().Trim();
                }
            }
            return true;
        }
        #endregion

        #region 搜索考试人员信息
        /// <summary>
        /// 搜索考试人员信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="policeid"></param>
        /// <param name="position"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        private IList<SystemUser> SearchUserInfo(string name, string policeid, string position, string depart)
        {
            BllUser bllUser = new BllUser();
            return bllUser.SearchUserInfo(name, policeid, position, depart);
        }
        #endregion

        /// <summary>
        /// 更新管理员密码
        /// </summary>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        private bool UpdateAdminPass(string  loginName, string newpwd)
        {
            BllUser blluser = new BllUser();
            return blluser.UpdateAdminPwd(loginName,newpwd);

        }
    }
}