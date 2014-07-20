<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instruction.aspx.cs" Inherits="TrafficExam.Web.Instruction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/Instruction.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div class="AdminMain">
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" class="bxxqtable">
                        <tr>
                            <td>
                                <div>
                                    <img src="Images/PicLogintop_3.png" width="100%" height="90px" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <p>
                                    <strong>温馨提示：</strong><br />
                                    1、遵守考场纪律，服从监考人员指挥
                                    <br />
                                    2、进入考场，手机关机，禁止抽烟,禁止吃零食
                                    <br />
                                    3、未经工作人员允许，考生禁止随意出入考场
                                    <br />
                                    4、考场内禁止大声喧哗，禁止随意走动<br />
                                    5、考试中认真答题，不准交头接耳
                                    <br />
                                    6、考试中不准冒名顶替，不准弄虚作假
                                    <br />
                                    7、注意考场卫生，禁止随意吐痰，禁止乱扔纸屑
                                    <br />
                                    8、爱好公物及考试设备
                                </p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Adminjctk">
                    <p>
                        <strong>考试考点分布：</strong><br />
                    </p>
                    <div id="info">
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input id="btnPratice" type="submit" class="Adminrighttablebtn" value="开始练习"/>
                    <input id="btnBegExam" type="submit" class="Adminrighttablebtn" value="开始考试" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
