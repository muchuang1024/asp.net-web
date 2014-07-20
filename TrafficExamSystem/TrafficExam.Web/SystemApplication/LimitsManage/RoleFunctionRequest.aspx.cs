using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MDS.XJSON.Core;
using TrafficExam.Command;
using TrafficExam.Model;
using TrafficExam.Bll;

namespace TrafficExam.Web.SystemApplication.LimitsManage
{
    public partial class RoleFunctionRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                switch (Request["ActionName"].ToString())
                {
                    case "GetGroupList":
                        //把数据库权限分组返回到界面进行显示
                        Response.Write(json.Serialize(GetGroupList()));
                        break;
                    case "GetFunctionList":
                        string groupId = Request["Group_Id"].ToString().Trim();
                        Response.Write(json.Serialize(GetFunctionAndGroupList(groupId)));
                        break;
                    case "SaveRoleGroup":
                        string selectedFunctionIds = Request["SelectedRoleGroup[]"].ToString();
                        string selectedGroupId = Request["RoleSelected"].ToString();
                        Response.Write(json.Serialize(SaveRoleGroup(selectedFunctionIds, selectedGroupId)));
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
        /// 获取所有的角色分组列表
        /// </summary>
        /// <returns></returns>
        private IList<SystemGroup> GetGroupList()
        {
            BllGroup bllGroup = new BllGroup();
            //获取所有权限人组名称
            IList<SystemGroup> list = bllGroup.GetGroupList();
            return list;
        }
        /// <summary>
        /// 组合2个功能列表,其一为：所有的功能名称！其二为：角色所对应的功能名称,用于页面组合显示
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private Dictionary<string, IList<SystemFunction>> GetFunctionAndGroupList(string groupId)
        {
            Dictionary<string, IList<SystemFunction>> dic = new Dictionary<string, IList<SystemFunction>>();

            //数据库中默认第一个菜单名称为：【功能管理】,其对应treeId默认为"1"
            IList<SystemFunction> functionList = GetFunctionList("1");
            //获取角色所对应的功能列表
            IList<SystemFunction> functionListByGroupId = GetFunctionListByGroupId(groupId);

            dic.Add("FunctionList", functionList);
            dic.Add("FunctionListByGroupId", functionListByGroupId);

            return dic;
        }
        /// <summary>
        /// 保存角色对应的
        /// </summary>
        /// <param name="selectedFunctionIds">功能菜单Id组</param>
        /// <param name="selectedGroupId">角色id</param>
        /// <returns></returns>
        private string SaveRoleGroup(string selectedFunctionIds, string selectedGroupId)
        {
            BllRelation bllRelation = new BllRelation();
            if (bllRelation.UpdateRelationInfo(selectedFunctionIds, selectedGroupId))
                return "true";//更新成功
            //更新失败
            return "false";
        }

        /// <summary>
        ///  获取树形菜单ID下所有节点列表
        /// </summary>
        /// <returns></returns>
        private IList<SystemFunction> GetFunctionList(string treeId)
        {
            BllFunction bllFunction = new BllFunction();

            IList<SystemFunction> list = bllFunction.GetFunctionList(treeId);

            return list;
        }
        /// <summary>
        ///  获取角色所对应的功能列表
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private IList<SystemFunction> GetFunctionListByGroupId(string groupId)
        {
            BllFunction bllFunction = new BllFunction();

            IList<SystemFunction> list = bllFunction.GetFunctionListByGroupId(groupId);

            return list;
        }
    }
}