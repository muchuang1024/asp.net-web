using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    public class SystemUser
    {
        #region 属性
        private int userId;
        /// <summary>
        /// 获取或设置用户编号
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string loginName;
        /// <summary>
        /// 获取或设置用户登录名
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string loginPassword;
        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string LoginPassword
        {
            get { return loginPassword; }
            set { loginPassword = value; }
        }
        private int groupId;
        /// <summary>
        /// 获取或设置用户分组编号
        /// </summary>
        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }
        private string policeCode;
        /// <summary>
        /// 警员编号
        /// </summary>
        public string PoliceCode
        {
            get { return policeCode; }
            set { policeCode = value; }
        }
        private bool isOpen;
        /// <summary>
        /// 判断用户状态为开启或关闭
        /// </summary>
        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; }
        }
        private string realName;
        /// <summary>
        /// 获取或设置用户真实姓名
        /// </summary>
        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }
        private DateTime pubDateTime;
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime PubDateTime
        {
            get { return pubDateTime; }
            set { pubDateTime = value; }
        }
        private string position;
        /// <summary>
        /// 职务
        /// </summary>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        private string department;
        /// <summary>
        /// 部门
        /// </summary>
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        private string sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        #endregion

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SystemUser()
        {
            this.userId = 0;
            this.loginName = "";
            this.loginPassword = "";
            this.groupId = 0;
            this.policeCode = "";
            this.isOpen = false;
            this.realName = "";
            this.pubDateTime = DateTime.Now;
            this.position = "";
            this.department = "";
        }
        /// <summary>
        /// 赋值构造函数
        /// </summary>
        /// <param name="userId">用户组ID</param>
        /// <param name="loginName">用户登录名</param>
        /// <param name="loginPassword">用户密码</param>
        /// <param name="groupId">权限组ID</param>
        /// <param name="createName">创建名称</param>
        /// <param name="telephoneNumber">手机电话</param>
        /// <param name="houseNumber">家庭电话</param>
        /// <param name="isOpen">是否开启</param>
        /// <param name="address">联系地址</param>
        /// <param name="realName">真实姓名</param>
        /// <param name="email">联系Email</param>
        /// <param name="city">城市</param>
        /// <param name="pubDateTime">提交日期</param>
        public SystemUser(int userId, string loginName, string loginPassword, int groupId, string policeCode, bool isOpen, string realName, DateTime pubDateTime, string position, string department)
        {
            this.userId = userId;
            this.loginName = loginName;
            this.loginPassword = loginPassword;
            this.groupId = groupId;
            this.policeCode = policeCode;
            this.isOpen = isOpen;
            this.realName = realName;
            this.pubDateTime = pubDateTime;
            this.position = position;
            this.department = department;
        }
        #endregion
    }
}
