using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///getClass 的摘要说明
/// </summary>
public class getClass1
{
    private int score;
	public getClass1()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public getClass1(int score)
    {
        this.score = score;       
    }
    public string getScore()
    {
        if (score < 0)
        {
            return "error";
        }
        else if (score < 100 && score >= 0)
        {
            return "学前班";
        }
        else if(score<200)
        {
            return "小学生";
        }
        else if (score < 500)
        {
            return "初中生";
        }
        else if (score < 2000)
        { 
            return "高中生";
        }
        else if (score < 4000)
        {
            return "大学生";
        }
        else if (score < 8000)
        {
            return "硕士生";
        }
        else
        {
            return "博士";
        }

    }
}