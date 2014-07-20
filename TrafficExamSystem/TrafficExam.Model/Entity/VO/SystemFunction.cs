using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficExam.Model
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public class SystemFunction
    {
        #region 属性
        private int functionId;
        /// <summary>
        /// 获取或设置树形菜单ID
        /// </summary>
        public int FunctionId
        {
            get { return functionId; }
            set { functionId = value; }
        }
        private string functionName;
        /// <summary>
        /// 获取或设置功能名称
        /// </summary>
        public string FunctionName
        {
            get { return functionName; }
            set { functionName = value; }
        }
        private int motherId;
        /// <summary>
        /// 获取或设置菜单上级节点ID
        /// </summary>
        public int MotherId
        {
            get { return motherId; }
            set { motherId = value; }
        }

        private int childNum;
        /// <summary>
        /// 获取或设置节点子节点个数
        /// </summary>
        public int ChildNum
        {
            get { return childNum; }
            set { childNum = value; }
        }
        private string href;
        /// <summary>
        /// 获取或设置功能菜单连接页面地址
        /// </summary>
        public string Href
        {
            get { return href; }
            set { href = value; }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SystemFunction()
        {
            this.functionId = 0;
            this.functionName = "";
            this.motherId = 0;
            this.childNum = 0;
            this.href = "";
        }
        /// <summary>
        /// 赋值构造函数
        /// </summary>
        /// <param name="functionId">功能菜单ID</param>
        /// <param name="functionName">功能菜单们名称</param>
        /// <param name="montherId">功能材料上级节点</param>
        /// <param name="childNum">功能菜单子节点个数</param>
        /// <param name="href">功能菜单所对应页面地址</param>
        public SystemFunction(int functionId, string functionName, int motherId, int childNum, string href)
        {
            this.functionId = functionId;
            this.functionName = functionName;
            this.motherId = motherId;
            this.childNum = childNum;
            this.href = href;
        }
        #endregion
    }
}
