using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MDS.XJSON.Core;
using TrafficExam.Command;
using TrafficExam.Bll;
using TrafficExam.Model;

namespace TrafficExam.Web.SystemApplication
{
    public partial class ItemTitleRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();
            try
            {
                switch (Request["ActionName"].ToString())
                {
                    case "GetItemTitleList":
                    //获取题库
                        int pageIndex = Int32.Parse(Request["PageIndex"].ToString());
                        int pageSize = Int32.Parse(Request["PageSize"].ToString());
                         string itemtitle=Request["Title"].ToString().Trim();
                         string itemsubjecttype = Request["SubjectType"].ToString().Trim();
                         string itemsubjectitem = Request["SubjectItem"].ToString().Trim();
                         Response.Write(GetItemTitleList(pageIndex, pageSize, itemtitle, itemsubjecttype, itemsubjectitem));
                        break;
                    case "GetItemTitleInfo":
                        //获取考题信息
                        int ItemTitleId = Int32.Parse(Request["ItemTitleId"].ToString());
                        Response.Write(json.Serialize(GetItemTitleInfo(ItemTitleId)));
                        break;
                    case "InsertItemTitle":
                        //新增题库
                        string title = Request["Title"].ToString().Trim();
                        string firstoption = Request["FirstOption"].ToString().Trim();
                        string secondoption = Request["SecondOption"].ToString().Trim();
                        string thirdoption = Request["ThirdOption"].ToString().Trim();
                        string fourthoption = Request["FourthOption"].ToString().Trim();
                        string fifthoption = Request["FifthOption"].ToString().Trim();
                        string sixthoption = Request["SixthOption"].ToString().Trim();
                        string answer = Request["Answer"].ToString().Trim();
                        string subjecttype = Request["SubjectType"].ToString().Trim();
                        string subjectitem = Request["SubjectItem"].ToString().Trim();
                        int itemcount = Convert.ToInt32(Request["ItemCount"].ToString());
                        ItemTitle item = new ItemTitle();
                        item.Title = title;
                        item.FirstOption=firstoption;
                        item.SecondOption = secondoption;
                        item.ThirdOption = thirdoption;
                        item.FourthOption = fourthoption;
                        item.FifthOption = fifthoption;
                        item.SixthOption = sixthoption;
                        item.Answer = answer;
                        item.SubjectType = subjecttype;
                        item.ItemCount = itemcount;
                        item.SubjectItem = subjectitem;
                        Response.Write(json.Serialize(InsertItemTitle(item)));
                        break;
                    case "UpdateItemTitleInfo":
                        //更新题库
                        int titleid = Int32.Parse(Request["TitleId"].ToString());
                        string utitle = Request["Title"].ToString().Trim();
                        string ufirstoption = Request["FirstOption"].ToString().Trim();
                        string usecondoption = Request["SecondOption"].ToString().Trim();
                        string uthirdoption = Request["ThirdOption"].ToString().Trim();
                        string ufourthoption = Request["FourthOption"].ToString().Trim();
                        string ufifthoption = Request["FifthOption"].ToString().Trim();
                        string usixthoption = Request["SixthOption"].ToString().Trim();
                        string uanswer = Request["Answer"].ToString().Trim();
                        string usubjecttype = Request["SubjectType"].ToString().Trim();
                        int uitemcount = Convert.ToInt32(Request["ItemCount"].ToString());
                        string usubjectitem = Request["SubjectItem"].ToString().Trim();
                        ItemTitle item1 = new ItemTitle();
                        item1.TitleId = titleid;
                        item1.Title = utitle;
                        item1.FirstOption=ufirstoption;
                        item1.SecondOption = usecondoption;
                        item1.ThirdOption = uthirdoption;
                        item1.FourthOption = ufourthoption;
                        item1.FifthOption = ufifthoption;
                        item1.SixthOption = usixthoption;
                        item1.Answer = uanswer;
                        item1.SubjectType = usubjecttype;
                        item1.ItemCount = uitemcount;
                        item1.SubjectItem = usubjectitem;
                        Response.Write(json.Serialize(UpdateItemTitleInfo(item1)));
                        break;
                    case "SearchTitleInfo":
                         string stitle=Request["Title"].ToString().Trim();
                         string ssubjecttype = Request["SubjectType"].ToString().Trim();
                         string ssubjectitem = Request["SubjectItem"].ToString().Trim();
                         Response.Write(json.Serialize(SearchTitleInfo(stitle, ssubjecttype, ssubjectitem)));
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
        private string GetItemTitleList(int pageIndex, int pageSize ,string title, string SubjectType, string SubjectItem)
        {
            BllItemTitle bllItemTitle = new BllItemTitle();
            //string condition = Request["Condition"].ToString();
            ///选择条件
            string where = "1=1";
            if (title != "")
            {
                where += "and Title like '%" + title + "%'";
            }
            if (SubjectType != "")
            {
                where += " and SubjectType = '" + SubjectType + "'";
            }
            if (SubjectItem != "")
            {
                where += " and SubjectItem = '" + SubjectItem + "'";
            }
            /*GetWhere解析条件(包含排序字段与方式)*/
            //if (condition.Length > 1)//有参数传递过来
            //{
            //    where = GetWhere(condition);//自己解析方法
            //}
            //else
            //{
            //    where = "1=1";
            //}
            #region 方法2：使用ListDictionary进行where拼接
            //string condition = Request["Condition"];
            //ListDictionary xht = QueryString.GetQueryString(condition);
            //string sqlWhere = GetSearchCondition(xht);
            #endregion
            int pageCount = 0;//总页数
            int rowCount = 0;//总记录数
            string orderField = "TitleId";//默认排序,主键
            //多表联合查询
            string tableName = "dbo.ItemTitle";
            //查询字段
            string fields = "TitleId,Title,SubjectType,ItemCount,SubjectItem";
            //获取到IList<ItemTitle>对象
            IList<ItemTitle> list = bllItemTitle.GetItemTitleList(tableName, fields, orderField, pageIndex, pageSize, where, ref pageCount, ref rowCount);
            //json.Serialize不能直接返回Ilist<T>,所以自己扩展了一个IJsonHelper
            return IJsonHelper.ListToJson<ItemTitle>(list, "ItemTitle", pageCount, rowCount);
        }
        private IList<ItemTitle> GetItemTitleInfo(int itemTitleId)
        {
            //根据题库Id获取题库信息
            BllItemTitle bllItemTitle = new BllItemTitle();
            return bllItemTitle.GetItemTitleInfo(itemTitleId);
        }
        private bool InsertItemTitle(ItemTitle item)
        {
            BllItemTitle bllItemTitle = new BllItemTitle();
            return bllItemTitle.InsertItemTitle(item);
        }
        private bool UpdateItemTitleInfo(ItemTitle item)
        {
            BllItemTitle bllItemTitle = new BllItemTitle();
            return bllItemTitle.UpdateItemTitle(item);
        }
        private IList<ItemTitle> SearchTitleInfo(string title, string SubjectType, string SubjectItem)
        {
            BllItemTitle bllItemTitle = new BllItemTitle();
            return bllItemTitle.SearchTitleInfo(title, SubjectType, SubjectItem);
        }
    }
}