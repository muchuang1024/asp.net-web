using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    /// <summary>
    /// 角色分组对应功能
    /// </summary>
    public class SystemRelation
    {
        #region 属性
        private int groupId;

        /// <summary>
        /// 获取或设置用户所在权限组ID
        /// </summary>
        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }
        private int functionId;
        /// <summary>
        /// 获取或设置用户所在权限组对应显示的树型结构的ID
        /// </summary>
        public int FunctionId
        {
            get { return functionId; }
            set { functionId = value; }
        }
        private string key;
        /// <summary>
        /// 获取或设置key值【备注】
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        #endregion

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SystemRelation()
        {
            this.groupId = 0;
            this.functionId = 0;
            this.key = "";
        }
        /// <summary>
        /// 赋值构造函数
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="functionId">树形菜单ID</param>
        /// <param name="key"></param>
        public SystemRelation(int groupId, int functionId, string key)
        {
            this.groupId = groupId;
            this.functionId = functionId;
            this.key = key;
        }
        #endregion
    }
}
