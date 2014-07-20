using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficExam.Model;
using TrafficExam.Bll;
using TrafficExam.Command;

namespace TrafficExam.Web.SystemApplication.TreeMenu
{
    public partial class TreeServiceRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SwitchMothod();
            }
        }
        public void SwitchMothod()
        {
            try
            {
                string treeID = Request.QueryString["treeID"].ToString();
                Response.Clear();
                Response.Expires = -1;
                Response.ContentType = "text/xml";
                Response.Charset = "utf-8";
                IList<SystemFunction> listFunction = null;
                switch (treeID)
                {
                    #region 得到栏目的所有下级图片
                    case "1":
                        if (HttpContext.Current.Session["GroupId"].ToString() == "3")//超级管理员
                        {
                            listFunction = GetMenuTree(treeID);//加载所有的节点,数据库中默认功能管理的treeId="1"
                        }
                        else
                        {
                            listFunction = GetMenuTree(treeID, HttpContext.Current.Session["LoginName"].ToString());
                        }
                        Response.Write(@"tree.nodes['0_1'] = 'text:网站后台管理; hint:网站后台管理;url:javascript:void(0);';");
                        Response.Write(GetTreeString(listFunction)[0]);
                        break;
                    default:
                        Response.Clear();
                        if (HttpContext.Current.Session["GroupId"].ToString() == "3")//超级管理员
                        {
                            listFunction = GetMenuTree(treeID);
                        }
                        else
                        {
                            listFunction = GetMenuTree(treeID, HttpContext.Current.Session["LoginName"].ToString());
                        }
                        string[] treeNode = GetTreeString(listFunction);
                        Response.Write(treeNode[0]);
                        Response.Write(treeNode[1]);
                        break;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                ExceptionLogInfo log = ExceptionLogInfo.LogInstance();
                log.WriterLog(ex.ToString());
            }
        }
        /// <summary>
        /// 绑定节点对象到树形菜单
        /// </summary>
        /// <param name="listFunction"></param>
        /// <returns></returns>
        public string[] GetTreeString(IList<SystemFunction> listFunction)
        {
            string reValue = "";
            string tmp = "";
            if (listFunction.Count > 0)
            {
                tmp = "tree.names+='";
                for (int i = 0; i < listFunction.Count; i++)
                {
                    string url = listFunction[i].Href.ToString() == "" ? "javascript:void(0)" : listFunction[i].Href.ToString();
                    reValue += @"tree.nodes['" + listFunction[i].MotherId.ToString() + "_" + listFunction[i].FunctionId.ToString() + "']='text:" + listFunction[i].FunctionName.ToString() + ";";
                    reValue += "url:" + url;
                    reValue += listFunction[i].ChildNum.ToString() == "0" ? "';" : ";childNodesFileName:TreeServiceRequest.aspx?treeID=" + listFunction[i].FunctionId.ToString() + "';";
                    tmp += @"\x0f\x0f" + listFunction[i].MotherId.ToString() + "_" + listFunction[i].FunctionId.ToString();
                }
                tmp += "';";
            }
            string[] re = new string[2] { reValue, tmp };
            return re;
        }

        /// <summary>
        /// 获取所有节点列表
        /// </summary>
        /// <param name="treeId"></param>
        /// <returns></returns>
        private IList<SystemFunction> GetMenuTree(string treeId)
        {
            BllFunction bllFunction = new BllFunction();
            IList<SystemFunction> listFunction = bllFunction.GetFunctionList(treeId);
            return listFunction;
        }
        /// <summary>
        /// 获取角色所对应的节点列表
        /// </summary>
        /// <returns></returns>
        private IList<SystemFunction> GetMenuTree(string treeId, string loginName)
        {
            BllFunction bllFunction = new BllFunction();
            IList<SystemFunction> listFunction = bllFunction.GetFunctionList(treeId, loginName);
            return listFunction;
        }
    }
}