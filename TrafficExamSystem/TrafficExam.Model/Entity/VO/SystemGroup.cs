using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    /// <summary>
    /// 系统角色分组
    /// </summary>
    public class SystemGroup
    {
        #region 属性
        private int groupId;
        /// <summary>
        /// 获取或设置权限组ID
        /// </summary>
        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        private string groupName;
        /// <summary>
        /// 获取或设置权限名称
        /// </summary>
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        private string createName;
        /// <summary>
        /// 获取或设置创建名称【备注】
        /// </summary>
        public string CreateName
        {
            get { return createName; }
            set { createName = value; }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SystemGroup()
        {
            this.groupId = 0;
            this.groupName = "";
            this.createName = "";
        }
        /// <summary>
        /// 赋值构造函数
        /// </summary>
        /// <param name="groupId">权限组ID</param>
        /// <param name="groupName">权限中文名称</param>
        /// <param name="createName">创建名称</param>
        public SystemGroup(int groupId, string groupName, string createName)
        {
            this.groupName = groupName;
            this.groupId = groupId;
            this.createName = createName;
        }

        #endregion
    }
}
