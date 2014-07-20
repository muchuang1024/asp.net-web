<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemTitle.aspx.cs" Inherits="TrafficExam.Web.SystemApplication.ItemTitle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>题库管理</title>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td align="center" valign="top">
                    <table width="690" border="0" cellspacing="0" class="bxgsbox">
                        <tr>
                            <td align="center" class="bxgsboxtitle">
                                题库信息
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0">
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            考点
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <span class="Adminrighttabletdtext">
                                                <select id="selectInsurerName" class="Adminjcselcet" style="width: 208px">
                                                    <option value="请选择">请选择</option>
                                                    <option value="第一类考点">第一类考点</option>
                                                    <option value="第二类考点">第二类考点</option>
                                                    <option value="第三类考点">第三类考点</option>
                                                </select>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            题目类型
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <input id="radioInsuranceTypeA" checked="checked" type="radio" name="group_InsuranceType"
                                                value="1" />单选
                                            <input id="radioInsuranceTypeB" type="radio" name="group_InsuranceType" value="2" />多选
                                            <input id="radioInsuranceTypeC" type="radio" name="group_InsuranceType" value="3" />判断
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            答案个数
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <span class="Adminrighttabletdtext">
                                                <select id="select1" class="Adminjcselcet" style="width: 208px">
                                                    <option value="请选择">请选择</option>
                                                    <option value="6">6</option>
                                                    <option value="5">5</option>
                                                    <option value="4">4</option>
                                                    <option value="3">3</option>
                                                    <option value="2">2</option>
                                                </select>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Adminrighttabletdtitle">
                                            第一答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password1" class="Adminrighttableiput" type="password" maxlength="16" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Adminrighttabletdtitle">
                                            第二答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password2" class="Adminrighttableiput" type="password" maxlength="16" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Adminrighttabletdtitle">
                                            第三答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password3" class="Adminrighttableiput" type="password" maxlength="16" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Adminrighttabletdtitle">
                                            第四答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password4" class="Adminrighttableiput" type="password" maxlength="16" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Adminrighttabletdtitle">
                                            本题答案
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="txtAdminRepeatPassWord" class="Adminrighttableiput" type="password" maxlength="16" />
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
                                            <input id="btnReg" type="submit" class="Adminrighttablebtn" value="添加" />
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
</body>
</html>
