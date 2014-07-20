using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///filter 的摘要说明
/// </summary>
public class filter
{
	public filter()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    #region 过滤SQL注入
    /// <summary>
    /// 对用户录入的数据进行防止SQL注入检查
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string FilterSQL(string text)
    {
        text = text.Trim();
        if (text != string.Empty)
        {
            text = text.Replace("'", "''");
            text = text.Replace("--", "''--''");
            text = text.Replace(";", string.Empty);
            text = text.Replace("\n", "。");
        }
        return text;
    }
    #endregion
}