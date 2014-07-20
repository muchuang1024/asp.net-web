using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrafficExam.Bll;

namespace TrafficExam.Web
{
    public class AdminBasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 重写OnLoad,实现登陆判断,对用户访问页面是否有权限也进行了判断,防止用户登陆后,通过在浏览器输入地址访问没有权限的页面
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (HttpContext.Current.Session["LoginName"] == null)//如果未登陆跳转到登陆页面
            {
                string script = "<script>alert('请登陆!');window.top.location.href='" + GetRootPath().TrimEnd("/".ToCharArray()) + "/Index.aspx';</script>";
                HttpContext.Current.Response.Write(script);
                HttpContext.Current.Response.End();
            }

            string hrefAddress = HttpContext.Current.Request.CurrentExecutionFilePath;//获取到浏览器中地址信息
            ViewState["FunctionId"] = "";

            BllFunction bllFunction = new BllFunction();
            if (bllFunction.GetFunctionId(hrefAddress) != 0)
            {
                //获取到这个地址所对应的FunctionId,用于下面判断
                ViewState["FunctionId"] = bllFunction.GetFunctionId(hrefAddress).ToString();
            }
            else
            {
                string script = "<script>alert('访问的页面出错了!');window.location.href='" + GetRootPath().TrimEnd("/".ToCharArray()) + "/Error.aspx';</script>";
                HttpContext.Current.Response.Write(script);
                HttpContext.Current.Response.End();
            }

            //如果登陆了并且访问的页面的ID不为空
            if (!string.IsNullOrEmpty(HttpContext.Current.Session["LoginName"].ToString()) && !string.IsNullOrEmpty(ViewState["FunctionId"].ToString()))
            {
                bool limits = bllFunction.IsBrowsed(hrefAddress, HttpContext.Current.Session["LoginName"].ToString());
                string script = "";
                if (!limits)
                {
                    script = "<script>alert('你没有访问权限!');window.top.location.href='" + GetRootPath().TrimEnd("/".ToCharArray()) + "/Index.aspx';</script>";
                    HttpContext.Current.Response.Write(script);
                    HttpContext.Current.Response.End();
                }
            }
            base.OnLoad(e);
        }
        public string GetRootPath()
        {
            //是否为SSL认证站点
            string Secure = HttpContext.Current.Request.ServerVariables["HTTPS"];
            string HttpProtocol = (Secure == "on" ? "https://" : "http://");
            //服务器名称
            string serverName = HttpContext.Current.Request.ServerVariables["Server_Name"];
            string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            //应用服务名称
            string ApplicationName = HttpContext.Current.Request.ApplicationPath;//应用程序根路径
            return HttpProtocol + serverName + (Port.Length > 0 ? ":" + Port : string.Empty) + ApplicationName;
        }
    }
}