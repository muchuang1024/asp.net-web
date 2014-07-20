<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUserInfo.aspx.cs"
    Inherits="TrafficExam.Web.SystemApplication.UpdateUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改用户信息</title>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/UpdateUserInfo.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td align="center" valign="top">
                    <table width="690" border="0" cellspacing="0" class="bxgsbox">
                        <tr>
                            <td align="center" class="bxgsboxtitle">
                                修改人员信息
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0">
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            姓名
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <input type="text" id="txtRealName" style="height: 25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            性别
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <input checked="checked" type="radio" name="group_Sex" value="男" id="boy" />男
                                            <input type="radio" name="group_Sex" value="女" id="girl" />女
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            警号
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <input type="text" id="txtPoliceCode" style="height: 25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            密码
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <input type="text" id="txtPassword" style="width: 150px; height: 25px" disabled />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            确认密码
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <input type="text" id="txtRepeatPassword" style="width: 150px; height: 25px" disabled />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            职务
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <span class="Adminrighttabletdtext">
                                                <select id="selectPosition" class="Adminjtselcet" style="width: 151px">
                                                    <option value="请选择">请选择</option>
                                                    <option value="大队领导">大队领导</option>
                                                    <option value="部门领导">部门领导</option>
                                                    <option value="民警">民警</option>
                                                    <option value="协警">协警</option>
                                                </select>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            部门
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <span class="Adminrighttabletdtext">
                                                <select id="selectDepartment" class="Adminjtselcet" style="width: 151px">
                                                    <option value="请选择">请选择</option>
                                                    <option value="大队部">大队部</option>
                                                    <option value="事故中队">事故中队</option>
                                                    <option value="监控中心">监控中心</option>
                                                    <option value="办公室">办公室</option>
                                                    <option value="车管所">车管所</option>
                                                    <option value="邓关中队">邓关中队</option>
                                                    <option value="二中队">二中队</option>
                                                    <option value="仙市中队">仙市中队</option>
                                                    <option value="沿滩中队">沿滩中队</option>
                                                    <option value="新进人员">新进人员</option>
                                                    <option value="其他">其他</option>
                                                </select>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="Adminrightline">
                                </div>
                                <table width="100%" border="0">
                                    <tr>
                                        <td height="53" align="center">
                                            <input id="btnUpdate" type="submit" class="Adminrighttablebtn" value="修改" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <input id="Condition" name="Condition" type="hidden" />
</body>
</html>
